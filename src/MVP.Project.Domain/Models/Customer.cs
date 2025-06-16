using System;
using NetDevPack.Domain;

namespace MVP.Project.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string email, string documentNumber, DateTime birthDate, string phone, string stateInscription, 
            string streetAddress, string buildingNumber, string secondaryAddress, string neighborhood, string zipCode, string city, string state, bool active)
        {
            Id = id;
            Name = name;
            Email = email;
            DocumentNumber = documentNumber;
            BirthDate = birthDate;
            Phone = phone;
            StateInscription = stateInscription;
            StreetAddress = streetAddress;
            BuildingNumber = buildingNumber;
            SecondaryAddress = secondaryAddress;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;
            Active = active;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string StateInscription { get; private set; }
        public string StreetAddress { get; private set; }
        public string BuildingNumber { get; private set; }
        public string SecondaryAddress { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public bool Active { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateDocumentNumber(string documentNumber)
        {
            DocumentNumber = documentNumber;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void UpdatePhone(string phone)
        {
            Phone = phone;
        }

        public void UpdateStateInscription(string stateInscription)
        {
            StateInscription = stateInscription;
        }

        public void UpdateStreetAddress(string streetAddress)
        {
            StreetAddress = streetAddress;
        }

        public void UpdateBuildingNumber(string buildingNumber)
        {
            BuildingNumber = buildingNumber;
        }

        public void UpdateSecondaryAddress(string secondaryAddress)
        {
            SecondaryAddress = secondaryAddress;
        }

        public void UpdateNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;
        }

        public void UpdateZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }

        public void UpdateCity(string city)
        {
            City = city;
        }

        public void UpdateState(string state)
        {
            State = state;
        }

        public void UpdateActive(bool active)
        {
            Active = active;
        }

        public bool IsCNPJ()
        {
            if (string.IsNullOrEmpty(DocumentNumber))
                return false;

            var documentNumber = DocumentNumber.Replace(".", "").Replace("-", "").Replace("/", "");
            return documentNumber.Length == 14;
        }
    }
}