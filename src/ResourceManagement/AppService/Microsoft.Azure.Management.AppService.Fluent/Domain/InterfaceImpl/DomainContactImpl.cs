// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using AppServiceDomain.Definition;
    using DomainContact.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Arm;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    internal partial class DomainContactImpl 
    {
        Microsoft.Azure.Management.AppService.Fluent.Models.Contact DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>.Build
        {
            get
            {
                return this.Build() as Microsoft.Azure.Management.AppService.Fluent.Models.Contact;
            }
        }

        DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithJobTitle<AppServiceDomain.Definition.IWithCreate>.WithJobTitle(string jobTitle)
        {
            return this.WithJobTitle(jobTitle) as DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the city of the address.
        /// </summary>
        /// <param name="city">The city of the address.</param>
        DomainContact.Definition.IWithStateOrProvince<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithCity<AppServiceDomain.Definition.IWithCreate>.WithCity(string city)
        {
            return this.WithCity(city) as DomainContact.Definition.IWithStateOrProvince<AppServiceDomain.Definition.IWithCreate>;
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.FirstName
        {
            get
            {
                return this.FirstName();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Phone
        {
            get
            {
                return this.Phone();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.LastName
        {
            get
            {
                return this.LastName();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.Address Microsoft.Azure.Management.AppService.Fluent.IDomainContact.AddressMailing
        {
            get
            {
                return this.AddressMailing() as Microsoft.Azure.Management.AppService.Fluent.Models.Address;
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Email
        {
            get
            {
                return this.Email();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.MiddleName
        {
            get
            {
                return this.MiddleName();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Fax
        {
            get
            {
                return this.Fax();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.JobTitle
        {
            get
            {
                return this.JobTitle();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Organization
        {
            get
            {
                return this.Organization();
            }
        }

        /// <summary>
        /// Specifies the 1st line of the address.
        /// </summary>
        /// <param name="addressLine1">The 1st line of the address.</param>
        DomainContact.Definition.IWithAddressLine2<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithAddressLine1<AppServiceDomain.Definition.IWithCreate>.WithAddressLine1(string addressLine1)
        {
            return this.WithAddressLine1(addressLine1) as DomainContact.Definition.IWithAddressLine2<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the postal code or zip code of the address.
        /// </summary>
        /// <param name="postalCode">The postal code of the address.</param>
        DomainContact.Definition.IWithPhoneCountryCode<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithPostalCode<AppServiceDomain.Definition.IWithCreate>.WithPostalCode(string postalCode)
        {
            return this.WithPostalCode(postalCode) as DomainContact.Definition.IWithPhoneCountryCode<AppServiceDomain.Definition.IWithCreate>;
        }

        DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithFaxNumber<AppServiceDomain.Definition.IWithCreate>.WithFaxNumber(string faxNumber)
        {
            return this.WithFaxNumber(faxNumber) as DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        AppServiceDomain.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<AppServiceDomain.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the 2nd line of the address.
        /// </summary>
        /// <param name="addressLine2">The 2nd line of the address.</param>
        DomainContact.Definition.IWithCity<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithAddressLine2<AppServiceDomain.Definition.IWithCreate>.WithAddressLine2(string addressLine2)
        {
            return this.WithAddressLine2(addressLine2) as DomainContact.Definition.IWithCity<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the country of the address.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        DomainContact.Definition.IWithPostalCode<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithCountry<AppServiceDomain.Definition.IWithCreate>.WithCountry(CountryISOCode country)
        {
            return this.WithCountry(country) as DomainContact.Definition.IWithPostalCode<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the email.
        /// </summary>
        /// <param name="email">Contact's email address.</param>
        DomainContact.Definition.IWithAddressLine1<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithEmail<AppServiceDomain.Definition.IWithCreate>.WithEmail(string email)
        {
            return this.WithEmail(email) as DomainContact.Definition.IWithAddressLine1<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the last name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        DomainContact.Definition.IWithEmail<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithLastName<AppServiceDomain.Definition.IWithCreate>.WithLastName(string lastName)
        {
            return this.WithLastName(lastName) as DomainContact.Definition.IWithEmail<AppServiceDomain.Definition.IWithCreate>;
        }

        DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithOrganization<AppServiceDomain.Definition.IWithCreate>.WithOrganization(string organziation)
        {
            return this.WithOrganization(organziation) as DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        DomainContact.Definition.IWithMiddleName<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithFirstName<AppServiceDomain.Definition.IWithCreate>.WithFirstName(string firstName)
        {
            return this.WithFirstName(firstName) as DomainContact.Definition.IWithMiddleName<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the country code of the phone number.
        /// </summary>
        /// <param name="code">The country code.</param>
        DomainContact.Definition.IWithPhoneNumber<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithPhoneCountryCode<AppServiceDomain.Definition.IWithCreate>.WithPhoneCountryCode(CountryPhoneCode code)
        {
            return this.WithPhoneCountryCode(code) as DomainContact.Definition.IWithPhoneNumber<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the middle name.
        /// </summary>
        /// <param name="middleName">The middle name.</param>
        DomainContact.Definition.IWithLastName<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithMiddleName<AppServiceDomain.Definition.IWithCreate>.WithMiddleName(string middleName)
        {
            return this.WithMiddleName(middleName) as DomainContact.Definition.IWithLastName<AppServiceDomain.Definition.IWithCreate>;
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the phone number.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithPhoneNumber<AppServiceDomain.Definition.IWithCreate>.WithPhoneNumber(string phoneNumber)
        {
            return this.WithPhoneNumber(phoneNumber) as DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the state or province of the address.
        /// </summary>
        /// <param name="stateOrProvince">The state or province of the address.</param>
        DomainContact.Definition.IWithCountry<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithStateOrProvince<AppServiceDomain.Definition.IWithCreate>.WithStateOrProvince(string stateOrProvince)
        {
            return this.WithStateOrProvince(stateOrProvince) as DomainContact.Definition.IWithCountry<AppServiceDomain.Definition.IWithCreate>;
        }
    }
}