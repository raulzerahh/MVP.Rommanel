using System;
using System.Collections.Generic;
using System.Linq;
using MVP.Project.Domain.Commands;

namespace MVP.Project.Domain.Models
{
    public static class CustomerExtensions
    {
        public static void UpdateFromDictionary(this Customer customer, Dictionary<string, object> updates)
        {
            if (updates == null || !updates.Any()) return;

            var updateActions = new Dictionary<string, Action<object>>
            {
                { nameof(Customer.Name), value => customer.UpdateName((string)value) },
                { nameof(Customer.Email), value => customer.UpdateEmail((string)value) },
                { nameof(Customer.DocumentNumber), value => customer.UpdateDocumentNumber((string)value) },
                { nameof(Customer.BirthDate), value => customer.UpdateBirthDate((DateTime)value) },
                { nameof(Customer.Phone), value => customer.UpdatePhone((string)value) },
                { nameof(Customer.StateInscription), value => customer.UpdateStateInscription((string)value) },
                { nameof(Customer.StreetAddress), value => customer.UpdateStreetAddress((string)value) },
                { nameof(Customer.BuildingNumber), value => customer.UpdateBuildingNumber((string)value) },
                { nameof(Customer.SecondaryAddress), value => customer.UpdateSecondaryAddress((string)value) },
                { nameof(Customer.Neighborhood), value => customer.UpdateNeighborhood((string)value) },
                { nameof(Customer.ZipCode), value => customer.UpdateZipCode((string)value) },
                { nameof(Customer.City), value => customer.UpdateCity((string)value) },
                { nameof(Customer.State), value => customer.UpdateState((string)value) },
                { nameof(Customer.Active), value => customer.UpdateActive((bool)value) }
            };

            foreach (var update in updates)
            {
                if (updateActions.TryGetValue(update.Key, out var action) && update.Value != null)
                {
                    action(update.Value);
                }
            }
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