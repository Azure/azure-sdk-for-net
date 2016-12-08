// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceDomain.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of a domain.
    /// 
    /// Domains in Azure are purchased from 3rd party domain providers. By calling
    /// Creatable.create()} or {.
    /// </summary>
    /// <link>
    /// Creatable.createAsync() you agree to
    /// the agreements listed in Creatable.create()} or {.
    /// </link>
    public interface IAppServiceDomain  :
        IGroupableResource,
        IHasName,
        IRefreshable<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain>,
        IUpdatable<AppServiceDomain.Update.IUpdate>,
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.DomainInner>
    {
        Microsoft.Azure.Management.AppService.Fluent.Models.DomainPurchaseConsent Consent { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact TechContact { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.DomainStatus RegistrationStatus { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostName> ManagedHostNames { get; }

        System.DateTime CreatedTime { get; }

        bool Privacy { get; }

        System.DateTime LastRenewedTime { get; }

        bool AutoRenew { get; }

        System.Collections.Generic.IList<string> NameServers { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact BillingContact { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken);

        System.DateTime ExpirationTime { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order bound to this domain.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken));

        bool ReadyForDnsRecordManagement { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact RegistrantContact { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.Contact AdminContact { get; }
    }
}