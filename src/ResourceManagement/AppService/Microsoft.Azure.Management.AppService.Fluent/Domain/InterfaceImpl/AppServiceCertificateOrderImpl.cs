// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class AppServiceCertificateOrderImpl 
    {
        /// <summary>
        /// Specifies the valid years of the certificate.
        /// </summary>
        /// <param name="years">Minimum 1 year, and maximum 3 years.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithValidYears.WithValidYears(int years)
        {
            return this.WithValidYears(years) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the SKU of the certificate to be standard. It will only provide
        /// SSL support to the hostname, and www.hostname. Wildcard type will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp AppServiceCertificateOrder.Definition.IWithCertificateSku.WithStandardSku()
        {
            return this.WithStandardSku() as AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp;
        }

        /// <summary>
        /// Specifies the SKU of the certificate to be wildcard. It will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithDomainVerification AppServiceCertificateOrder.Definition.IWithCertificateSku.WithWildcardSku()
        {
            return this.WithWildcardSku() as AppServiceCertificateOrder.Definition.IWithDomainVerification;
        }

        /// <summary>
        /// Specifies the Azure managed domain to verify the ownership of the domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithKeyVault AppServiceCertificateOrder.Definition.IWithDomainVerification.WithDomainVerification(IAppServiceDomain domain)
        {
            return this.WithDomainVerification(domain) as AppServiceCertificateOrder.Definition.IWithKeyVault;
        }

        /// <summary>
        /// Specifies the hostname the certificate binds to.
        /// </summary>
        /// <param name="hostName">The bare host name, without "www". Use . prefix if it's a wild card certificate.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithCertificateSku AppServiceCertificateOrder.Definition.IWithHostName.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as AppServiceCertificateOrder.Definition.IWithCertificateSku;
        }

        /// <summary>
        /// Specifies the web app to verify the ownership of the domain. The web app needs to
        /// be bound to the hostname for the certificate.
        /// </summary>
        /// <param name="webApp">The web app bound to the hostname.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithKeyVault AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp.WithWebAppVerification(IWebAppBase webApp)
        {
            return this.WithWebAppVerification(webApp) as AppServiceCertificateOrder.Definition.IWithKeyVault;
        }

        /// <summary>
        /// Creates a new key vault to store the certificate private key.
        /// DO NOT use this method if you are logged in from an identity without access
        /// to the Active Directory Graph.
        /// </summary>
        /// <param name="vaultName">The name of the new key vault.</param>
        /// <param name="region">The region to create the vault.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithKeyVault.WithNewKeyVault(string vaultName, Region region)
        {
            return this.WithNewKeyVault(vaultName, region) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies an existing key vault to store the certificate private key.
        /// The vault MUST allow 2 service principals to read/write secrets:
        /// f3c21649-0979-4721-ac85-b0216b2cf413 and abfa0a7c-a6b6-4736-8310-5855508787cd.
        /// If they don't have access, an attempt will be made to grant access. If you are
        /// logged in from an identity without access to the Active Directory Graph, this
        /// attempt will fail.
        /// </summary>
        /// <param name="vault">The vault to store the private key.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithKeyVault.WithExistingKeyVault(IVault vault)
        {
            return this.WithExistingKeyVault(vault) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        /// <return>The next stage of the update.</return>
        AppServiceCertificateOrder.Update.IUpdate AppServiceCertificateOrder.Update.IWithAutoRenew.WithAutoRenew(bool enabled)
        {
            return this.WithAutoRenew(enabled) as AppServiceCertificateOrder.Update.IUpdate;
        }

        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        /// <return>The next stage of the definition.</return>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithAutoRenew.WithAutoRenew(bool enabled)
        {
            return this.WithAutoRenew(enabled) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets last issuance time.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.LastCertificateIssuanceTime
        {
            get
            {
                return this.LastCertificateIssuanceTime();
            }
        }

        /// <summary>
        /// Gets if the certificate should be automatically renewed upon expiration.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.AutoRenew
        {
            get
            {
                return this.AutoRenew();
            }
        }

        /// <summary>
        /// Gets expiration time.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.ExpirationTime
        {
            get
            {
                return this.ExpirationTime();
            }
        }

        /// <summary>
        /// Gets the certificate product type.
        /// </summary>
        Models.CertificateProductType Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.ProductType
        {
            get
            {
                return this.ProductType();
            }
        }

        /// <summary>
        /// Gets last certificate signing request that was created for this order.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.CertificateSigningRequest
        {
            get
            {
                return this.CertificateSigningRequest();
            }
        }

        /// <summary>
        /// Gets the domain verification token.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.DomainVerificationToken
        {
            get
            {
                return this.DomainVerificationToken();
            }
        }

        /// <summary>
        /// Gets the certificate key size.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.KeySize
        {
            get
            {
                return this.KeySize();
            }
        }

        /// <summary>
        /// Gets the root certificate.
        /// </summary>
        Models.CertificateDetails Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.Root
        {
            get
            {
                return this.Root() as Models.CertificateDetails;
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <return>An Observable to the result.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.VerifyDomainOwnershipAsync(IAppServiceDomain domain, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(domain, cancellationToken);
        }

        /// <summary>
        /// Gets current order status.
        /// </summary>
        Models.CertificateOrderStatus Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the intermediate certificate.
        /// </summary>
        Models.CertificateDetails Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.Intermediate
        {
            get
            {
                return this.Intermediate() as Models.CertificateDetails;
            }
        }

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        /// <return>A binding containing the key vault information.</return>
        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.CreateKeyVaultBinding(string certificateName, IVault vault)
        {
            return this.CreateKeyVaultBinding(certificateName, vault) as Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        /// <summary>
        /// Gets certificate's distinguished name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.DistinguishedName
        {
            get
            {
                return this.DistinguishedName();
            }
        }

        /// <return>The state of the Key Vault secret.</return>
        async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.GetKeyVaultBindingAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeyVaultBindingAsync(cancellationToken) as Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        /// <return>The state of the Key Vault secret.</return>
        Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.GetKeyVaultBinding()
        {
            return this.GetKeyVaultBinding() as Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        /// <return>A binding containing the key vault information.</return>
        async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.CreateKeyVaultBindingAsync(string certificateName, IVault vault, CancellationToken cancellationToken)
        {
            return await this.CreateKeyVaultBindingAsync(certificateName, vault, cancellationToken) as Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        /// <summary>
        /// Gets current serial number of the certificate.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.SerialNumber
        {
            get
            {
                return this.SerialNumber();
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.VerifyDomainOwnership(IAppServiceDomain domain)
        {
 
            this.VerifyDomainOwnership(domain);
        }

        /// <summary>
        /// Gets duration in years (must be between 1 and 3).
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.ValidityInYears
        {
            get
            {
                return this.ValidityInYears();
            }
        }

        /// <summary>
        /// Gets the signed certificate.
        /// </summary>
        Models.CertificateDetails Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder.SignedCertificate
        {
            get
            {
                return this.SignedCertificate() as Models.CertificateDetails;
            }
        }
    }
}