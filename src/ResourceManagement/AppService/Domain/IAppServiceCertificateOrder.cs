// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure App Service certificate order.
    /// </summary>
    public interface IAppServiceCertificateOrder  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager,Models.AppServiceCertificateOrderInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<AppServiceCertificateOrder.Update.IUpdate>
    {
        /// <summary>
        /// Gets duration in years (must be between 1 and 3).
        /// </summary>
        int ValidityInYears { get; }

        /// <return>The state of the Key Vault secret.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> GetKeyVaultBindingAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the certificate key size.
        /// </summary>
        int KeySize { get; }

        /// <summary>
        /// Gets current order status.
        /// </summary>
        Models.CertificateOrderStatus Status { get; }

        /// <summary>
        /// Gets the root certificate.
        /// </summary>
        Models.CertificateDetails Root { get; }

        /// <summary>
        /// Gets if the certificate should be automatically renewed upon expiration.
        /// </summary>
        bool AutoRenew { get; }

        /// <summary>
        /// Gets current serial number of the certificate.
        /// </summary>
        string SerialNumber { get; }

        /// <summary>
        /// Gets the intermediate certificate.
        /// </summary>
        Models.CertificateDetails Intermediate { get; }

        /// <summary>
        /// Gets the domain verification token.
        /// </summary>
        string DomainVerificationToken { get; }

        /// <summary>
        /// Gets the signed certificate.
        /// </summary>
        Models.CertificateDetails SignedCertificate { get; }

        /// <summary>
        /// Gets the certificate product type.
        /// </summary>
        Models.CertificateProductType ProductType { get; }

        /// <summary>
        /// Gets last certificate signing request that was created for this order.
        /// </summary>
        string CertificateSigningRequest { get; }

        /// <return>The state of the Key Vault secret.</return>
        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding GetKeyVaultBinding();

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        void VerifyDomainOwnership(IAppServiceDomain domain);

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        /// <return>A binding containing the key vault information.</return>
        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding CreateKeyVaultBinding(string certificateName, IVault vault);

        /// <summary>
        /// Gets expiration time.
        /// </summary>
        System.DateTime? ExpirationTime { get; }

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <return>An Observable to the result.</return>
        Task VerifyDomainOwnershipAsync(IAppServiceDomain domain, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets last issuance time.
        /// </summary>
        System.DateTime? LastCertificateIssuanceTime { get; }

        /// <summary>
        /// Gets certificate's distinguished name.
        /// </summary>
        string DistinguishedName { get; }

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        /// <return>A binding containing the key vault information.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> CreateKeyVaultBindingAsync(string certificateName, IVault vault, CancellationToken cancellationToken = default(CancellationToken));
    }
}