// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class AppServiceDomainImpl 
    {
        /// <summary>
        /// Specifies if the registrant contact information is exposed publicly.
        /// If domain privacy is turned on, the contact information will NOT be
        /// available publicly.
        /// </summary>
        /// <param name="domainPrivacy">True if domain privacy is turned on.</param>
        /// <return>The next stage of domain definition.</return>
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
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithDomainPrivacy.WithDomainPrivacyEnabled(bool domainPrivacy)
        {
            return this.WithDomainPrivacyEnabled(domainPrivacy) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Specify the admin contact.
        /// </summary>
        /// <param name="contact">The admin contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithAdminContact.WithAdminContact(Contact contact)
        {
            return this.WithAdminContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the admin contact.
        /// </summary>
        /// <param name="contact">The admin contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithAdminContact.WithAdminContact(Contact contact)
        {
            return this.WithAdminContact(contact) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Specify the tech contact.
        /// </summary>
        /// <param name="contact">The tech contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithTechContact.WithTechContact(Contact contact)
        {
            return this.WithTechContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the tech contact.
        /// </summary>
        /// <param name="contact">The tech contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithTechContact.WithTechContact(Contact contact)
        {
            return this.WithTechContact(contact) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Specify the billing contact.
        /// </summary>
        /// <param name="contact">The billing contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithBillingContact.WithBillingContact(Contact contact)
        {
            return this.WithBillingContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the billing contact.
        /// </summary>
        /// <param name="contact">The billing contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithBillingContact.WithBillingContact(Contact contact)
        {
            return this.WithBillingContact(contact) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Gets name servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.NameServers
        {
            get
            {
                return this.NameServers() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets admin contact information.
        /// </summary>
        Models.Contact Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.AdminContact
        {
            get
            {
                return this.AdminContact() as Models.Contact;
            }
        }

        /// <summary>
        /// Gets true if domain will renewed automatically.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.AutoRenew
        {
            get
            {
                return this.AutoRenew();
            }
        }

        /// <summary>
        /// Gets technical contact information.
        /// </summary>
        Models.Contact Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.TechContact
        {
            get
            {
                return this.TechContact() as Models.Contact;
            }
        }

        /// <summary>
        /// Gets domain expiration timestamp.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.ExpirationTime
        {
            get
            {
                return this.ExpirationTime();
            }
        }

        /// <summary>
        /// Gets timestamp when the domain was renewed last time.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.LastRenewedTime
        {
            get
            {
                return this.LastRenewedTime();
            }
        }

        /// <summary>
        /// Gets domain creation timestamp.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.CreatedTime
        {
            get
            {
                return this.CreatedTime();
            }
        }

        /// <summary>
        /// Gets billing contact information.
        /// </summary>
        Models.Contact Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.BillingContact
        {
            get
            {
                return this.BillingContact() as Models.Contact;
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken, cancellationToken);
        }

        /// <summary>
        /// Gets domain registration status.
        /// </summary>
        Models.DomainStatus Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.RegistrationStatus
        {
            get
            {
                return this.RegistrationStatus();
            }
        }

        /// <summary>
        /// Gets registrant contact information.
        /// </summary>
        Models.Contact Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.RegistrantContact
        {
            get
            {
                return this.RegistrantContact() as Models.Contact;
            }
        }

        /// <summary>
        /// Gets legal agreement consent.
        /// </summary>
        Models.DomainPurchaseConsent Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.Consent
        {
            get
            {
                return this.Consent() as Models.DomainPurchaseConsent;
            }
        }

        /// <summary>
        /// Gets all hostnames derived from the domain and assigned to Azure resources.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.HostName> Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.ManagedHostNames
        {
            get
            {
                return this.ManagedHostNames() as System.Collections.Generic.IReadOnlyDictionary<string,Models.HostName>;
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
 
            this.VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        /// <summary>
        /// Gets true if Azure can assign this domain to Web Apps. This value will
        /// be true if domain registration status is active and it is hosted on
        /// name servers Azure has programmatic access to.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.ReadyForDnsRecordManagement
        {
            get
            {
                return this.ReadyForDnsRecordManagement();
            }
        }

        /// <summary>
        /// Gets true if domain privacy is enabled for this domain.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain.Privacy
        {
            get
            {
                return this.Privacy();
            }
        }

        /// <summary>
        /// Specifies if the domain should be automatically renewed when it's
        /// about to expire.
        /// </summary>
        /// <param name="autoRenew">True if the domain should be automatically renewed.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithAutoRenew.WithAutoRenewEnabled(bool autoRenew)
        {
            return this.WithAutoRenewEnabled(autoRenew) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies if the domain should be automatically renewed when it's
        /// about to expire.
        /// </summary>
        /// <param name="autoRenew">True if the domain should be automatically renewed.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Update.IUpdate AppServiceDomain.Update.IWithAutoRenew.WithAutoRenewEnabled(bool autoRenew)
        {
            return this.WithAutoRenewEnabled(autoRenew) as AppServiceDomain.Update.IUpdate;
        }

        /// <summary>
        /// Specify the registrant contact. By default, this is also the contact for
        /// admin, billing, and tech.
        /// </summary>
        /// <param name="contact">The registrant contact.</param>
        /// <return>The next stage of domain definition.</return>
        AppServiceDomain.Definition.IWithCreate AppServiceDomain.Definition.IWithRegistrantContact.WithRegistrantContact(Contact contact)
        {
            return this.WithRegistrantContact(contact) as AppServiceDomain.Definition.IWithCreate;
        }

        /// <summary>
        /// Starts the definition of a new domain contact.
        /// </summary>
        /// <return>The first stage of the domain contact definition.</return>
        DomainContact.Definition.IBlank<AppServiceDomain.Definition.IWithCreate> AppServiceDomain.Definition.IWithRegistrantContact.DefineRegistrantContact()
        {
            return this.DefineRegistrantContact() as DomainContact.Definition.IBlank<AppServiceDomain.Definition.IWithCreate>;
        }
    }
}