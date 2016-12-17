// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// A domain definition allowing billing contact to be set.
    /// </summary>
    public interface IWithBillingContact 
    {
        /// <summary>
        /// Specify the billing contact.
        /// </summary>
        /// <param name="contact">The billing contact.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithBillingContact(Contact contact);
    }

    /// <summary>
    /// A domain definition allowing registrant contact to be set.
    /// </summary>
    public interface IWithRegistrantContact 
    {
        /// <summary>
        /// Specify the registrant contact. By default, this is also the contact for
        /// admin, billing, and tech.
        /// </summary>
        /// <param name="contact">The registrant contact.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithRegistrantContact(Contact contact);

        /// <summary>
        /// Starts the definition of a new domain contact.
        /// </summary>
        /// <return>The first stage of the domain contact definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DomainContact.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate> DefineRegistrantContact();
    }

    /// <summary>
    /// A domain definition allowing domain privacy to be set.
    /// </summary>
    public interface IWithDomainPrivacy 
    {
        /// <summary>
        /// Specifies if the registrant contact information is exposed publicly.
        /// If domain privacy is turned on, the contact information will NOT be
        /// available publicly.
        /// </summary>
        /// <param name="domainPrivacy">True if domain privacy is turned on.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithDomainPrivacyEnabled(bool domainPrivacy);
    }

    /// <summary>
    /// A domain definition allowing client IP address to be set.
    /// </summary>
    public interface IWithClientIpAddress 
    {
        /// <summary>
        /// Specifies the client IP address. This is used for record-keeping
        /// of the domain purchase agreement. If not provided, 127.0.0.1 is
        /// used for this version.
        /// </summary>
        /// <param name="ipAddress">The client IP address.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithClientIpAddress(string ipAddress);
    }

    /// <summary>
    /// The first stage of the domain definition.
    /// </summary>
    public interface IBlank  :
        IWithExistingResourceGroup<Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithRegistrantContact>
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithAdminContact,
        IWithBillingContact,
        IWithRegistrantContact,
        IWithTechContact,
        IWithCreate
    {
    }

    /// <summary>
    /// A domain definition allowing auto-renew setting to be set.
    /// </summary>
    public interface IWithAutoRenew 
    {
        /// <summary>
        /// Specifies if the domain should be automatically renewed when it's
        /// about to expire.
        /// </summary>
        /// <param name="autoRenew">True if the domain should be automatically renewed.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithAutoRenewEnabled(bool autoRenew);
    }

    /// <summary>
    /// A domain definition with sufficient inputs to create a new
    /// domain in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        IWithDomainPrivacy,
        IWithAutoRenew,
        IWithClientIpAddress,
        IWithAdminContact,
        IWithBillingContact,
        IWithTechContact,
        ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        IDefinitionWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A domain definition allowing tech contact to be set.
    /// </summary>
    public interface IWithTechContact 
    {
        /// <summary>
        /// Specify the tech contact.
        /// </summary>
        /// <param name="contact">The tech contact.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithTechContact(Contact contact);
    }

    /// <summary>
    /// A domain definition allowing admin contact to be set.
    /// </summary>
    public interface IWithAdminContact 
    {
        /// <summary>
        /// Specify the admin contact.
        /// </summary>
        /// <param name="contact">The admin contact.</param>
        /// <return>The next stage of domain definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition.IWithCreate WithAdminContact(Contact contact);
    }
}