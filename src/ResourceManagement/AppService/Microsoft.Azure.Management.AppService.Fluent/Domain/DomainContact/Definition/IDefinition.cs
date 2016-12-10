// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Resource.Fluent.Core;

    /// <summary>
    /// The stage of contact definition allowing 2nd line of address to be set.
    /// </summary>
    public interface IWithAddressLine2<ParentT>  :
        IWithCity<ParentT>
    {
        /// <summary>
        /// Specifies the 2nd line of the address.
        /// </summary>
        /// <param name="addressLine2">The 2nd line of the address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCity<ParentT> WithAddressLine2(string addressLine2);
    }

    /// <summary>
    /// The final stage of the domain contact definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the domain contact definition
    /// can be attached to the parent domain definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithOrganization<ParentT>,
        IWithJobTitle<ParentT>,
        IWithFaxNumber<ParentT>
    {
        Microsoft.Azure.Management.AppService.Fluent.Models.Contact Build { get; }
    }

    /// <summary>
    /// The stage of contact definition allowing city to be set.
    /// </summary>
    public interface IWithCity<ParentT> 
    {
        /// <summary>
        /// Specifies the city of the address.
        /// </summary>
        /// <param name="city">The city of the address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithStateOrProvince<ParentT> WithCity(string city);
    }

    /// <summary>
    /// The stage of contact definition allowing country to be set.
    /// </summary>
    public interface IWithCountry<ParentT> 
    {
        /// <summary>
        /// Specifies the country of the address.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPostalCode<ParentT> WithCountry(CountryISOCode country);
    }

    /// <summary>
    /// The stage of contact definition allowing phone number to be set.
    /// </summary>
    public interface IWithPhoneNumber<ParentT> 
    {
        /// <summary>
        /// Specifies the phone number.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithPhoneNumber(string phoneNumber);
    }

    /// <summary>
    /// The entirety of a domain contact definition.
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithFirstName<ParentT>,
        IWithMiddleName<ParentT>,
        IWithAddressLine1<ParentT>,
        IWithAddressLine2<ParentT>,
        IWithCity<ParentT>,
        IWithStateOrProvince<ParentT>,
        IWithCountry<ParentT>,
        IWithPostalCode<ParentT>,
        IWithEmail<ParentT>,
        IWithPhoneCountryCode<ParentT>,
        IWithPhoneNumber<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of contact definition allowing email to be set.
    /// </summary>
    public interface IWithEmail<ParentT> 
    {
        /// <summary>
        /// Specifies the email.
        /// </summary>
        /// <param name="email">Contact's email address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAddressLine1<ParentT> WithEmail(string email);
    }

    /// <summary>
    /// The stage of contact definition allowing organization to be set.
    /// </summary>
    public interface IWithOrganization<ParentT> 
    {
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithOrganization(string organziation);
    }

    /// <summary>
    /// The stage of contact definition allowing job title to be set.
    /// </summary>
    public interface IWithJobTitle<ParentT> 
    {
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithJobTitle(string jobTitle);
    }

    /// <summary>
    /// The stage of contact definition allowing first name to be set.
    /// </summary>
    public interface IWithFirstName<ParentT> 
    {
        /// <summary>
        /// Specifies the first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithMiddleName<ParentT> WithFirstName(string firstName);
    }

    /// <summary>
    /// The stage of contact definition allowing middle name to be set.
    /// </summary>
    public interface IWithMiddleName<ParentT>  :
        IWithLastName<ParentT>
    {
        /// <summary>
        /// Specifies the middle name.
        /// </summary>
        /// <param name="middleName">The middle name.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithLastName<ParentT> WithMiddleName(string middleName);
    }

    /// <summary>
    /// The stage of contact definition allowing fax number to be set.
    /// </summary>
    public interface IWithFaxNumber<ParentT> 
    {
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithFaxNumber(string faxNumber);
    }

    /// <summary>
    /// The first stage of a domain contact definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithFirstName<ParentT>
    {
    }

    /// <summary>
    /// The stage of contact definition allowing phone country code to be set.
    /// </summary>
    public interface IWithPhoneCountryCode<ParentT> 
    {
        /// <summary>
        /// Specifies the country code of the phone number.
        /// </summary>
        /// <param name="code">The country code.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPhoneNumber<ParentT> WithPhoneCountryCode(CountryPhoneCode code);
    }

    /// <summary>
    /// The stage of contact definition allowing last name to be set.
    /// </summary>
    public interface IWithLastName<ParentT> 
    {
        /// <summary>
        /// Specifies the last name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithEmail<ParentT> WithLastName(string lastName);
    }

    /// <summary>
    /// The stage of contact definition allowing 1st line of address to be set.
    /// </summary>
    public interface IWithAddressLine1<ParentT> 
    {
        /// <summary>
        /// Specifies the 1st line of the address.
        /// </summary>
        /// <param name="addressLine1">The 1st line of the address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAddressLine2<ParentT> WithAddressLine1(string addressLine1);
    }

    /// <summary>
    /// The stage of contact definition allowing postal/zip code to be set.
    /// </summary>
    public interface IWithPostalCode<ParentT> 
    {
        /// <summary>
        /// Specifies the postal code or zip code of the address.
        /// </summary>
        /// <param name="postalCode">The postal code of the address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPhoneCountryCode<ParentT> WithPostalCode(string postalCode);
    }

    /// <summary>
    /// The stage of contact definition allowing state/province to be set.
    /// </summary>
    public interface IWithStateOrProvince<ParentT> 
    {
        /// <summary>
        /// Specifies the state or province of the address.
        /// </summary>
        /// <param name="stateOrProvince">The state or province of the address.</param>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCountry<ParentT> WithStateOrProvince(string stateOrProvince);
    }
}