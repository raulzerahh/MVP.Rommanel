using System;
using System.Linq;
using FluentValidation;

namespace MVP.Project.Domain.Commands.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, informe o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c)
                .Must(customer => 
                {
                    // Se for CNPJ, não valida nada relacionado à data de nascimento
                    if (IsCNPJ(customer.DocumentNumber))
                        return true;

                    // Se for CPF, valida a data de nascimento
                    return customer.BirthDate != default && 
                           customer.BirthDate <= DateTime.Now && 
                           IsValidAge(customer.BirthDate);
                })
                .WithMessage("O cliente deve ter pelo menos 18 anos");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, informe o e-mail")
                .EmailAddress().WithMessage("E-mail inválido");
        }

        protected void ValidateDocumentNumber()
        {
            RuleFor(c => c.DocumentNumber)
                .NotEmpty().WithMessage("Por favor, informe o CPF/CNPJ")
                .MaximumLength(20).WithMessage("O CPF/CNPJ deve ter no máximo 20 caracteres")
                .Must(BeValidDocument).WithMessage("CPF/CNPJ inválido");
        }

        protected void ValidateStateInscription()
        {
            RuleFor(c => c)
                .Must(HaveValidStateInscription)
                .WithMessage("A inscrição estadual é obrigatória para CNPJ e deve conter apenas números");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("ID inválido");
        }

        private bool IsValidAge(DateTime birthDate)
        {
            var age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;

            return age >= 18;
        }

        private bool IsCPF(string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return false;

            var numbers = documentNumber.Where(char.IsDigit).ToArray();
            return numbers.Length == 11;
        }

        private bool IsCNPJ(string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return false;

            var numbers = documentNumber.Where(char.IsDigit).ToArray();
            return numbers.Length == 14;
        }

        private bool BeValidDocument(string document)
        {
            if (string.IsNullOrWhiteSpace(document)) return false;

            // Remove caracteres não numéricos
            document = new string(document.Where(char.IsDigit).ToArray());

            // Verifica se é CPF (11 dígitos) ou CNPJ (14 dígitos)
            if (document.Length != 11 && document.Length != 14) return false;

            if (document.Length == 11)
        {
                return IsValidCPF(document);
            }
            else
            {
                return IsValidCNPJ(document);
            }
        }

        private bool IsValidCPF(string cpf)
        {
            if (cpf.Length != 11) return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.All(x => x == cpf[0])) return false;

            // Validação do primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (cpf[i] - '0') * (10 - i);
            }
            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;
            if (digit1 != (cpf[9] - '0')) return false;

            // Validação do segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (cpf[i] - '0') * (11 - i);
            }
            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;
            if (digit2 != (cpf[10] - '0')) return false;

            return true;
        }

        private bool IsValidCNPJ(string cnpj)
        {
            if (cnpj.Length != 14) return false;

            // Verifica se todos os dígitos são iguais
            if (cnpj.All(x => x == cnpj[0])) return false;

            // Validação do primeiro dígito verificador
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += (cnpj[i] - '0') * multiplier1[i];
            }
            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;
            if (digit1 != (cnpj[12] - '0')) return false;

            // Validação do segundo dígito verificador
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += (cnpj[i] - '0') * multiplier2[i];
            }
            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;
            if (digit2 != (cnpj[13] - '0')) return false;

            return true;
        }

        private bool HaveValidStateInscription(T command)
        {
            // Remove caracteres não numéricos do documento
            var document = new string(command.DocumentNumber.Where(char.IsDigit).ToArray());

            // Se for CNPJ (14 dígitos)
            if (document.Length == 14)
            {
                // Verifica se a inscrição estadual está preenchida
                if (string.IsNullOrWhiteSpace(command.StateInscription))
                    return false;

                // Verifica se contém apenas números
                return command.StateInscription.All(char.IsDigit);
            }

            // Se for CPF, a inscrição estadual é opcional
            return true;
        }
    }
}