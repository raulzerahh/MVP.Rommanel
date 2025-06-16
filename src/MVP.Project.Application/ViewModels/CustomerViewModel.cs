using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVP.Project.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório")]
        [StringLength(20, ErrorMessage = "O CPF/CNPJ deve ter no máximo 20 caracteres")]
        [DisplayName("CPF/CNPJ")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data de Nascimento")]
        public DateTime BirthDate { get; set; }
        
        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres")]
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        
        [StringLength(50, ErrorMessage = "A inscrição estadual deve ter no máximo 50 caracteres")] 
        [DisplayName("Inscrição Estadual")]
        [RegularExpression(@"^\d+$", ErrorMessage = "A inscrição estadual deve conter apenas números")]
        public string StateInscription { get; set; }

        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")] 
        [DisplayName("Endereço")]
        public string StreetAddress { get; set; }

        [StringLength(20, ErrorMessage = "O número deve ter no máximo 20 caracteres")] 
        [DisplayName("Número")]
        public string BuildingNumber { get; set; }

        [StringLength(200, ErrorMessage = "O complemento deve ter no máximo 200 caracteres")] 
        [DisplayName("Complemento")]
        public string SecondaryAddress { get; set; }

        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres")] 
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }

        [StringLength(20, ErrorMessage = "O CEP deve ter no máximo 20 caracteres")] 
        [DisplayName("CEP")]
        public string ZipCode { get; set; }

        [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres")] 
        [DisplayName("Cidade")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres")] 
        [DisplayName("Estado")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "O status é obrigatório")]
        [DisplayName("Ativo")]
        public bool Active { get; set; }

        public bool IsCNPJ()
        {
            if (string.IsNullOrWhiteSpace(DocumentNumber)) return false;
            var document = new string(DocumentNumber.Where(char.IsDigit).ToArray());
            return document.Length == 14;
        }
    }
}
