// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceDomain.Definition;
    using AppServiceDomain.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    internal partial class AppServiceDomainImpl 
    {
        /// <summary>
        /// Specifies if the registrant contact information is exposed publicly.
        /// If domain privacy is turned on, the contact information will NOT be
        /// available publicly.
        /// </summary>
        /// <param name="domainPrivacy">True if domain privacy is turned on.</param>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithDomainPrivacy.WithDomainPrivacyEnabled(bool domainPrivacy)
        {
            return this.WithDomainPrivacyEnabled(domainPrivacy) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies if the registrant contact information is exposed publicly.
        /// If domain privacy is turned on, the contact information will NOT be
        /// available publicly.
        /// </summary>
        /// <param name="domainPrivacy">True if domain privacy is turned on.</param>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithDomainPrivacy.WithDomainPrivacyEnabled(bool domainPrivacy)
        {
            return this.WithDomainPrivacyEnabled(domainPrivacy) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain;
        }

        /// <summary>
        /// Specify the admin contact.
        /// </summary>
        /// <param name="contact">The admin contact.</param>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithAdminContact.WithAdminContact(Contact contact)
        {
            return this.WithAdminContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the admin contact.
        /// </summary>
        /// <param name="contact">The admin contact.</param>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithAdminContact.WithAdminContact(Contact contact)
        {
            return this.WithAdminContact(contact) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Specify the tech contact.
        /// </summary>
        /// <param name="contact">The tech contact.</param>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithTechContact.WithTechContact(Contact contact)
        {
            return this.WithTechContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the tech contact.
        /// </summary>
        /// <param name="contact">The tech contact.</param>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithTechContact.WithTechContact(Contact contact)
        {
            return this.WithTechContact(contact) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Specify the billing contact.
        /// </summary>
        /// <param name="contact">The billing contact.</param>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithBillingContact.WithBillingContact(Contact contact)
        {
            return this.WithBillingContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the billing contact.
        /// </summary>
        /// <param name="contact">The billing contact.</param>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithBillingContact.WithBillingContact(Contact contact)
        {
            return this.WithBillingContact(contact) as AppServiceDomain.Update.IUpdate;
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.AutoRenew
        {
            get
            {
                return this.AutoRenew();
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostName> Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.ManagedHostNames
        {
            get
            {
                return this.ManagedHostNames() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostName>;
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        void Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
 
            this.VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.DomainStatus Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.RegistrationStatus
        {
            get
            {
                return this.RegistrationStatus();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.LastRenewedTime
        {
            get
            {
                return this.LastRenewedTime();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.ExpirationTime
        {
            get
            {
                return this.ExpirationTime();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.CreatedTime
        {
            get
            {
                return this.CreatedTime();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.RegistrantContact
        {
            get
            {
                return this.RegistrantContact() as Microsoft.Azure.Management.AppService.Fluent.Models.Contact;
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.DomainPurchaseConsent Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.Consent
        {
            get
            {
                return this.Consent() as Microsoft.Azure.Management.AppService.Fluent.Models.DomainPurchaseConsent;
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        async Task Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken, cancellationToken);
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.BillingContact
        {
            get
            {
                return this.BillingContact() as Microsoft.Azure.Management.AppService.Fluent.Models.Contact;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.ReadyForDnsRecordManagement
        {
            get
            {
                return this.ReadyForDnsRecordManagement();
            }
        }

        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.NameServers
        {
            get
            {
                return this.NameServers() as System.Collections.Generic.IList<string>;
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.AdminContact
        {
            get
            {
                return this.AdminContact() as Microsoft.Azure.Management.AppService.Fluent.Models.Contact;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.Privacy
        {
            get
            {
                return this.Privacy();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain.TechContact
        {
            get
            {
                return this.TechContact() as Microsoft.Azure.Management.AppService.Fluent.Models.Contact;
            }
        }

        /// <summary>
        /// Specifies if the domain should be automatically renewed when it's
        /// about to expire.
        /// </summary>
        /// <param name="autoRenew">True if the domain should be automatically renewed.</param>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithAutoRenew.WithAutoRenewEnabled(bool autoRenew)
        {
            return this.WithAutoRenewEnabled(autoRenew) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies if the domain should be automatically renewed when it's
        /// about to expire.
        /// </summary>
        /// <param name="autoRenew">True if the domain should be automatically renewed.</param>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithAutoRenew.WithAutoRenewEnabled(bool autoRenew)
        {
            return this.WithAutoRenewEnabled(autoRenew) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Starts the definition of a new domain contact.
        /// </summary>
        DomainContact.Definition.IBlank<AppServiceDomain.Definition.IWithCreate> AppServiceDomain.Definition.IWithRegistrantContact.DefineRegistrantContact
        {
            get
            {
                return this.DefineRegistrantContact() as DomainContact.Definition.IBlank<AppServiceDomain.Definition.IWithCreate>;
            }
        }

        /// <summary>
        /// Specify the registrant contact. By default, this is also the contact for
        /// admin, billing, and tech.
        /// </summary>
        /// <param name="contact">The registrant contact.</param>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithRegistrantContact.WithRegistrantContact(Contact contact)
        {
            return this.WithRegistrantContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }
    }
}