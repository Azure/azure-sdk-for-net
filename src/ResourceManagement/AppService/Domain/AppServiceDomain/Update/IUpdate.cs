// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.Models;

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
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IUpdate WithAutoRenewEnabled(bool autoRenew);
    }

    /// <summary>
    /// The template for a domain update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IWithAdminContact,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IWithBillingContact,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IWithTechContact,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IWithAutoRenew,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IWithDomainPrivacy,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IUpdate>
    {
    }

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
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IUpdate WithBillingContact(Contact contact);
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
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IUpdate WithAdminContact(Contact contact);
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
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IUpdate WithDomainPrivacyEnabled(bool domainPrivacy);
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
        Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update.IUpdate WithTechContact(Contact contact);
    }
}