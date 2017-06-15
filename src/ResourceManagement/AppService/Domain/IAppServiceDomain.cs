// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of a domain.
    /// Domains in Azure are purchased from 3rd party domain providers. By calling
    /// Creatable.create() or  Creatable.createAsync() you agree to
    /// the agreements listed in  AppServiceDomains.listAgreements(String).
    /// </summary>
    public interface IAppServiceDomain  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager,Models.DomainInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<AppServiceDomain.Update.IUpdate>
    {
        /// <summary>
        /// Gets legal agreement consent.
        /// </summary>
        Models.DomainPurchaseConsent Consent { get; }

        /// <summary>
        /// Gets technical contact information.
        /// </summary>
        Models.Contact TechContact { get; }

        /// <summary>
        /// Gets domain registration status.
        /// </summary>
        Models.DomainStatus RegistrationStatus { get; }

        /// <summary>
        /// Gets all hostnames derived from the domain and assigned to Azure resources.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.HostName> ManagedHostNames { get; }

        /// <summary>
        /// Gets domain creation timestamp.
        /// </summary>
        System.DateTime CreatedTime { get; }

        /// <summary>
        /// Gets true if domain privacy is enabled for this domain.
        /// </summary>
        bool Privacy { get; }

        /// <summary>
        /// Gets timestamp when the domain was renewed last time.
        /// </summary>
        System.DateTime LastRenewedTime { get; }

        /// <summary>
        /// Gets true if domain will renewed automatically.
        /// </summary>
        bool AutoRenew { get; }

        /// <summary>
        /// Gets name servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> NameServers { get; }

        /// <summary>
        /// Gets billing contact information.
        /// </summary>
        Models.Contact BillingContact { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken);

        /// <summary>
        /// Gets domain expiration timestamp.
        /// </summary>
        System.DateTime ExpirationTime { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if Azure can assign this domain to Web Apps. This value will
        /// be true if domain registration status is active and it is hosted on
        /// name servers Azure has programmatic access to.
        /// </summary>
        bool ReadyForDnsRecordManagement { get; }

        /// <summary>
        /// Gets registrant contact information.
        /// </summary>
        Models.Contact RegistrantContact { get; }

        /// <summary>
        /// Gets admin contact information.
        /// </summary>
        Models.Contact AdminContact { get; }
    }
}