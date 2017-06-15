// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class DomainContactImpl 
    {
        Models.Contact DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>.Build
        {
            get
            {
                return this.Build() as Models.Contact;
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
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithStateOrProvince<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithCity<AppServiceDomain.Definition.IWithCreate>.WithCity(string city)
        {
            return this.WithCity(city) as DomainContact.Definition.IWithStateOrProvince<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets contact's mailing address.
        /// </summary>
        Models.Address Microsoft.Azure.Management.AppService.Fluent.IDomainContact.AddressMailing
        {
            get
            {
                return this.AddressMailing() as Models.Address;
            }
        }

        /// <summary>
        /// Gets contact's phone number.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Phone
        {
            get
            {
                return this.Phone();
            }
        }

        /// <summary>
        /// Gets contact's fax number.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Fax
        {
            get
            {
                return this.Fax();
            }
        }

        /// <summary>
        /// Gets contact's last name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.LastName
        {
            get
            {
                return this.LastName();
            }
        }

        /// <summary>
        /// Gets contact's email address.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Email
        {
            get
            {
                return this.Email();
            }
        }

        /// <summary>
        /// Gets contact's job title.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.JobTitle
        {
            get
            {
                return this.JobTitle();
            }
        }

        /// <summary>
        /// Gets contact's organization.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.Organization
        {
            get
            {
                return this.Organization();
            }
        }

        /// <summary>
        /// Gets contact's middle name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.MiddleName
        {
            get
            {
                return this.MiddleName();
            }
        }

        /// <summary>
        /// Gets contact's first name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainContact.FirstName
        {
            get
            {
                return this.FirstName();
            }
        }

        /// <summary>
        /// Specifies the postal code or zip code of the address.
        /// </summary>
        /// <param name="postalCode">The postal code of the address.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithPhoneCountryCode<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithPostalCode<AppServiceDomain.Definition.IWithCreate>.WithPostalCode(string postalCode)
        {
            return this.WithPostalCode(postalCode) as DomainContact.Definition.IWithPhoneCountryCode<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the 1st line of the address.
        /// </summary>
        /// <param name="addressLine1">The 1st line of the address.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithAddressLine2<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithAddressLine1<AppServiceDomain.Definition.IWithCreate>.WithAddressLine1(string addressLine1)
        {
            return this.WithAddressLine1(addressLine1) as DomainContact.Definition.IWithAddressLine2<AppServiceDomain.Definition.IWithCreate>;
        }

        DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithFaxNumber<AppServiceDomain.Definition.IWithCreate>.WithFaxNumber(string faxNumber)
        {
            return this.WithFaxNumber(faxNumber) as DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        AppServiceDomain.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<AppServiceDomain.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the 2nd line of the address.
        /// </summary>
        /// <param name="addressLine2">The 2nd line of the address.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithCity<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithAddressLine2<AppServiceDomain.Definition.IWithCreate>.WithAddressLine2(string addressLine2)
        {
            return this.WithAddressLine2(addressLine2) as DomainContact.Definition.IWithCity<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the country of the address.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithPostalCode<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithCountry<AppServiceDomain.Definition.IWithCreate>.WithCountry(CountryISOCode country)
        {
            return this.WithCountry(country) as DomainContact.Definition.IWithPostalCode<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the email.
        /// </summary>
        /// <param name="email">Contact's email address.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithAddressLine1<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithEmail<AppServiceDomain.Definition.IWithCreate>.WithEmail(string email)
        {
            return this.WithEmail(email) as DomainContact.Definition.IWithAddressLine1<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the last name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <return>The next stage of the definition.</return>
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
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithMiddleName<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithFirstName<AppServiceDomain.Definition.IWithCreate>.WithFirstName(string firstName)
        {
            return this.WithFirstName(firstName) as DomainContact.Definition.IWithMiddleName<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the country code of the phone number.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithPhoneNumber<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithPhoneCountryCode<AppServiceDomain.Definition.IWithCreate>.WithPhoneCountryCode(CountryPhoneCode code)
        {
            return this.WithPhoneCountryCode(code) as DomainContact.Definition.IWithPhoneNumber<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the middle name.
        /// </summary>
        /// <param name="middleName">The middle name.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithLastName<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithMiddleName<AppServiceDomain.Definition.IWithCreate>.WithMiddleName(string middleName)
        {
            return this.WithMiddleName(middleName) as DomainContact.Definition.IWithLastName<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
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
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithPhoneNumber<AppServiceDomain.Definition.IWithCreate>.WithPhoneNumber(string phoneNumber)
        {
            return this.WithPhoneNumber(phoneNumber) as DomainContact.Definition.IWithAttach<AppServiceDomain.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the state or province of the address.
        /// </summary>
        /// <param name="stateOrProvince">The state or province of the address.</param>
        /// <return>The next stage of the definition.</return>
        DomainContact.Definition.IWithCountry<AppServiceDomain.Definition.IWithCreate> DomainContact.Definition.IWithStateOrProvince<AppServiceDomain.Definition.IWithCreate>.WithStateOrProvince(string stateOrProvince)
        {
            return this.WithStateOrProvince(stateOrProvince) as DomainContact.Definition.IWithCountry<AppServiceDomain.Definition.IWithCreate>;
        }
    }
}