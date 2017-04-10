// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The stage of contact definition allowing 2nd line of address to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithAddressLine2<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCity<ParentT>
    {
        /// <summary>
        /// Specifies the 2nd line of the address.
        /// </summary>
        /// <param name="addressLine2">The 2nd line of the address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCity<ParentT> WithAddressLine2(string addressLine2);
    }

    /// <summary>
    /// The final stage of the domain contact definition.
    /// At this stage, any remaining optional settings can be specified, or the domain contact definition
    /// can be attached to the parent domain definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithOrganization<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithJobTitle<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithFaxNumber<ParentT>
    {
        Microsoft.Azure.Management.AppService.Fluent.Models.Contact Build { get; }
    }

    /// <summary>
    /// The stage of contact definition allowing city to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithCity<ParentT> 
    {
        /// <summary>
        /// Specifies the city of the address.
        /// </summary>
        /// <param name="city">The city of the address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithStateOrProvince<ParentT> WithCity(string city);
    }

    /// <summary>
    /// The stage of contact definition allowing country to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithCountry<ParentT> 
    {
        /// <summary>
        /// Specifies the country of the address.
        /// </summary>
        /// <param name="country">The country of the address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPostalCode<ParentT> WithCountry(CountryISOCode country);
    }

    /// <summary>
    /// The stage of contact definition allowing phone number to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithPhoneNumber<ParentT> 
    {
        /// <summary>
        /// Specifies the phone number.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithPhoneNumber(string phoneNumber);
    }

    /// <summary>
    /// The entirety of a domain contact definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithFirstName<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithMiddleName<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAddressLine1<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAddressLine2<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCity<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithStateOrProvince<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCountry<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPostalCode<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithEmail<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPhoneCountryCode<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPhoneNumber<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of contact definition allowing email to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithEmail<ParentT> 
    {
        /// <summary>
        /// Specifies the email.
        /// </summary>
        /// <param name="email">Contact's email address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAddressLine1<ParentT> WithEmail(string email);
    }

    /// <summary>
    /// The stage of contact definition allowing organization to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithOrganization<ParentT> 
    {
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithOrganization(string organziation);
    }

    /// <summary>
    /// The stage of contact definition allowing job title to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithJobTitle<ParentT> 
    {
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithJobTitle(string jobTitle);
    }

    /// <summary>
    /// The stage of contact definition allowing first name to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithFirstName<ParentT> 
    {
        /// <summary>
        /// Specifies the first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithMiddleName<ParentT> WithFirstName(string firstName);
    }

    /// <summary>
    /// The stage of contact definition allowing middle name to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithMiddleName<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithLastName<ParentT>
    {
        /// <summary>
        /// Specifies the middle name.
        /// </summary>
        /// <param name="middleName">The middle name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithLastName<ParentT> WithMiddleName(string middleName);
    }

    /// <summary>
    /// The stage of contact definition allowing fax number to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithFaxNumber<ParentT> 
    {
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAttach<ParentT> WithFaxNumber(string faxNumber);
    }

    /// <summary>
    /// The first stage of a domain contact definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithFirstName<ParentT>
    {
    }

    /// <summary>
    /// The stage of contact definition allowing phone country code to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithPhoneCountryCode<ParentT> 
    {
        /// <summary>
        /// Specifies the country code of the phone number.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPhoneNumber<ParentT> WithPhoneCountryCode(CountryPhoneCode code);
    }

    /// <summary>
    /// The stage of contact definition allowing last name to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithLastName<ParentT> 
    {
        /// <summary>
        /// Specifies the last name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithEmail<ParentT> WithLastName(string lastName);
    }

    /// <summary>
    /// The stage of contact definition allowing 1st line of address to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithAddressLine1<ParentT> 
    {
        /// <summary>
        /// Specifies the 1st line of the address.
        /// </summary>
        /// <param name="addressLine1">The 1st line of the address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithAddressLine2<ParentT> WithAddressLine1(string addressLine1);
    }

    /// <summary>
    /// The stage of contact definition allowing postal/zip code to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithPostalCode<ParentT> 
    {
        /// <summary>
        /// Specifies the postal code or zip code of the address.
        /// </summary>
        /// <param name="postalCode">The postal code of the address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithPhoneCountryCode<ParentT> WithPostalCode(string postalCode);
    }

    /// <summary>
    /// The stage of contact definition allowing state/province to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching.</typeparam>
    public interface IWithStateOrProvince<ParentT> 
    {
        /// <summary>
        /// Specifies the state or province of the address.
        /// </summary>
        /// <param name="stateOrProvince">The state or province of the address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IWithCountry<ParentT> WithStateOrProvince(string stateOrProvince);
    }
}