// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update
{
    using Microsoft.Azure.Management.Appservice.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update.IUpdate WithAutoRenewEnabled(bool autoRenew);
    }

    /// <summary>
    /// The template for a domain update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain>,
        IWithAdminContact,
        IWithBillingContact,
        IWithTechContact,
        IWithAutoRenew,
        IWithDomainPrivacy,
        IUpdateWithTags<Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update.IUpdate>
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update.IUpdate WithBillingContact(Contact contact);
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update.IUpdate WithAdminContact(Contact contact);
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update.IUpdate WithDomainPrivacyEnabled(bool domainPrivacy);
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceDomain.Update.IUpdate WithTechContact(Contact contact);
    }
}