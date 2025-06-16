using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MVP.Project.Domain.Events;
using MVP.Project.Domain.Interfaces;
using MVP.Project.Domain.Models;
using NetDevPack.Messaging;
using NetDevPack.SimpleMediator.Core.Interfaces;

namespace MVP.Project.Domain.Commands
{
    public class CustomerCommandHandler(ICustomerRepository customerRepository) : CommandHandler,
                                        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>,
                                        IRequestHandler<UpdateCustomerCommand, ValidationResult>,
                                        IRequestHandler<RemoveCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.DocumentNumber,
                message.BirthDate, message.Phone, message.StateInscription, message.StreetAddress, message.BuildingNumber,
                message.SecondaryAddress, message.Neighborhood, message.ZipCode, message.City, message.State,
                message.Active);

            if (await _customerRepository.GetByEmail(customer.Email) != null)
            {
                AddError("O e-mail do cliente já está em uso.");
                return ValidationResult;
            }

            if (await _customerRepository.GetByDocumentNumber(customer.DocumentNumber) != null)
            {
                AddError("O CPF/CNPJ informado já está cadastrado para outro cliente.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.DocumentNumber,
                customer.BirthDate,customer.Phone, customer.StateInscription, customer.StreetAddress, customer.BuildingNumber, 
                customer.SecondaryAddress, customer.Neighborhood, customer.ZipCode, customer.City, customer.State, customer.Active));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);
            if (customer == null)
            {
                AddError("Cliente não encontrado.");
                return ValidationResult;
            }

            // Verifica se o email já está em uso por outro cliente
            var existingCustomerWithEmail = await _customerRepository.GetByEmail(message.Email);
            if (existingCustomerWithEmail != null && existingCustomerWithEmail.Id != message.Id)
                {
                AddError("O e-mail do cliente já está em uso por outro cliente.");
                    return ValidationResult;
                }

            // Verifica se o documento já está em uso por outro cliente
            var existingCustomerWithDocument = await _customerRepository.GetByDocumentNumber(message.DocumentNumber);
            if (existingCustomerWithDocument != null && existingCustomerWithDocument.Id != message.Id)
            {
                AddError("O CPF/CNPJ informado já está cadastrado para outro cliente.");
                return ValidationResult;
            }

            var updates = new Dictionary<string, object>
            {
                { nameof(Customer.Name), message.Name },
                { nameof(Customer.Email), message.Email },
                { nameof(Customer.DocumentNumber), message.DocumentNumber },
                { nameof(Customer.BirthDate), message.BirthDate },
                { nameof(Customer.Phone), message.Phone },
                { nameof(Customer.StateInscription), message.StateInscription },
                { nameof(Customer.StreetAddress), message.StreetAddress },
                { nameof(Customer.BuildingNumber), message.BuildingNumber },
                { nameof(Customer.SecondaryAddress), message.SecondaryAddress },
                { nameof(Customer.Neighborhood), message.Neighborhood },
                { nameof(Customer.ZipCode), message.ZipCode },
                { nameof(Customer.City), message.City },
                { nameof(Customer.State), message.State },
                { nameof(Customer.Active), message.Active }
            };

            customer.UpdateFromDictionary(updates);

            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.DocumentNumber,
                customer.BirthDate, customer.Phone, customer.StateInscription, customer.StreetAddress, customer.BuildingNumber,
                customer.SecondaryAddress, customer.Neighborhood, customer.ZipCode, customer.City, customer.State, customer.Active));

            _customerRepository.Update(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);
            if (customer == null)
            {
                AddError("Cliente não encontrado.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}