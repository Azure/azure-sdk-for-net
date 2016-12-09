// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificateOrder.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure App Service Certificate Order.
    /// </summary>
    public interface IAppServiceCertificateOrder  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        IUpdatable<AppServiceCertificateOrder.Update.IUpdate>,
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceCertificateOrderInner>
    {
        int ValidityInYears { get; }

        Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> GetKeyVaultBindingAsync(CancellationToken cancellationToken = default(CancellationToken));

        int KeySize { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.CertificateOrderStatus Status { get; }

        Microsoft.Azure.Management.AppService.Fluent.ICertificateDetails Root { get; }

        bool AutoRenew { get; }

        string SerialNumber { get; }

        Microsoft.Azure.Management.AppService.Fluent.ICertificateDetails Intermediate { get; }

        string DomainVerificationToken { get; }

        Microsoft.Azure.Management.AppService.Fluent.ICertificateDetails SignedCertificate { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.CertificateProductType ProductType { get; }

        string CertificateSigningRequest { get; }

        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding GetKeyVaultBinding();

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        void VerifyDomainOwnership(IAppServiceDomain domain);

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding CreateKeyVaultBinding(string certificateName, IVault vault);

        System.DateTime ExpirationTime { get; }

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        Task VerifyDomainOwnershipAsync(IAppServiceDomain domain, CancellationToken cancellationToken = default(CancellationToken));

        System.DateTime LastCertificateIssuanceTime { get; }

        string DistinguishedName { get; }

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> CreateKeyVaultBindingAsync(string certificateName, IVault vault, CancellationToken cancellationToken = default(CancellationToken));
    }
}