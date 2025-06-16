using MVP.Project.Domain.Commands;
using MVP.Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MVP.Project.Application.ViewModels;

namespace MVP.Project.Application.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerViewModel ToViewModel(this Customer customer)
        {
            if (customer == null) return null;

            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                DocumentNumber = customer.DocumentNumber,
                BirthDate = customer.BirthDate,
                Phone = customer.Phone,
                StateInscription = customer.StateInscription,
                StreetAddress = customer.StreetAddress,
                BuildingNumber = customer.BuildingNumber,
                SecondaryAddress = customer.SecondaryAddress,
                Neighborhood = customer.Neighborhood,
                ZipCode = customer.ZipCode,
                City = customer.City,
                State = customer.State,
                Active = customer.Active
            };
        }

        public static IEnumerable<CustomerViewModel> ToViewModel(this IEnumerable<Customer> customers)
        {
            return customers?.Select(c => c.ToViewModel());
        }

        public static Customer ToEntity(this CustomerViewModel customer)
        {
            if (customer == null) return null;

            return new Customer(customer.Id, customer.Name, customer.Email, customer.DocumentNumber, customer.BirthDate, 
                customer.Phone, customer.StateInscription, customer.StreetAddress, customer.BuildingNumber, customer.SecondaryAddress, 
                customer.Neighborhood, customer.ZipCode, customer.City, customer.State, customer.Active);
        }

        public static RegisterNewCustomerCommand ToRegisterCommand(this CustomerViewModel customer)
        {
            if (customer == null) return null;

            return new RegisterNewCustomerCommand(customer.Id,customer.Name, customer.Email, customer.DocumentNumber, customer.BirthDate, 
                customer.Phone, customer.StateInscription, customer.StreetAddress, customer.BuildingNumber, customer.SecondaryAddress, 
                customer.Neighborhood, customer.ZipCode, customer.City, customer.State, customer.Active);
        }

        public static UpdateCustomerCommand ToUpdateCommand(this CustomerViewModel customer)
        {
            if (customer == null) return null;

            return new UpdateCustomerCommand(customer.Id, customer.Name, customer.Email, customer.DocumentNumber, customer.BirthDate, 
                customer.Phone, customer.StateInscription, customer.StreetAddress, customer.BuildingNumber, customer.SecondaryAddress, 
                customer.Neighborhood, customer.ZipCode, customer.City, customer.State, customer.Active);
        }

        public static void UpdateFromCommand(this Customer customer, UpdateCustomerCommand command)
        {
            if (command == null) return;

            var updateActions = new Dictionary<string, Action>
            {
                { nameof(Customer.Name), () => { if (!string.IsNullOrEmpty(command.Name)) customer.UpdateName(command.Name); } },
                { nameof(Customer.Email), () => { if (!string.IsNullOrEmpty(command.Email)) customer.UpdateEmail(command.Email); } },
                { nameof(Customer.DocumentNumber), () => { if (!string.IsNullOrEmpty(command.DocumentNumber)) customer.UpdateDocumentNumber(command.DocumentNumber); } },
                { nameof(Customer.BirthDate), () => { if (command.BirthDate != default) customer.UpdateBirthDate(command.BirthDate); } },
                { nameof(Customer.Phone), () => { if (!string.IsNullOrEmpty(command.Phone)) customer.UpdatePhone(command.Phone); } },
                { nameof(Customer.StateInscription), () => { if (!string.IsNullOrEmpty(command.StateInscription)) customer.UpdateStateInscription(command.StateInscription); } },
                { nameof(Customer.StreetAddress), () => { if (!string.IsNullOrEmpty(command.StreetAddress)) customer.UpdateStreetAddress(command.StreetAddress); } },
                { nameof(Customer.BuildingNumber), () => { if (!string.IsNullOrEmpty(command.BuildingNumber)) customer.UpdateBuildingNumber(command.BuildingNumber); } },
                { nameof(Customer.SecondaryAddress), () => { if (!string.IsNullOrEmpty(command.SecondaryAddress)) customer.UpdateSecondaryAddress(command.SecondaryAddress); } },
                { nameof(Customer.Neighborhood), () => { if (!string.IsNullOrEmpty(command.Neighborhood)) customer.UpdateNeighborhood(command.Neighborhood); } },
                { nameof(Customer.ZipCode), () => { if (!string.IsNullOrEmpty(command.ZipCode)) customer.UpdateZipCode(command.ZipCode); } },
                { nameof(Customer.City), () => { if (!string.IsNullOrEmpty(command.City)) customer.UpdateCity(command.City); } },
                { nameof(Customer.State), () => { if (!string.IsNullOrEmpty(command.State)) customer.UpdateState(command.State); } },
                { nameof(Customer.Active), () => customer.UpdateActive(command.Active) }
            };

            foreach (var action in updateActions.Values)
            {
                action();
            }
        }
    }
}
