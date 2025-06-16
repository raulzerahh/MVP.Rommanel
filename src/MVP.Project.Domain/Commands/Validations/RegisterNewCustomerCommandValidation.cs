﻿namespace MVP.Project.Domain.Commands.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
            ValidateDocumentNumber();
            ValidateStateInscription();
        }
    }
}