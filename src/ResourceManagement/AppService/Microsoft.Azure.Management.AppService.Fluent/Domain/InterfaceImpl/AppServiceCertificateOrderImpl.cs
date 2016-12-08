// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificateOrder.Definition;
    using AppServiceCertificateOrder.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Fluent.KeyVault;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;

    internal partial class AppServiceCertificateOrderImpl 
    {
        /// <summary>
        /// Specifies the Azure managed domain to verify the ownership of the domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        AppServiceCertificateOrder.Definition.IWithKeyVault AppServiceCertificateOrder.Definition.IWithDomainVerification.WithDomainVerification(IAppServiceDomain domain)
        {
            return this.WithDomainVerification(domain) as AppServiceCertificateOrder.Definition.IWithKeyVault;
        }

        /// <summary>
        /// Specifies the SKU of the certificate to be standard. It will only provide
        /// SSL support to the hostname, and www.hostname. Wildcard type will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp AppServiceCertificateOrder.Definition.IWithCertificateSku.WithStandardSku()
        {
            return this.WithStandardSku() as AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp;
        }

        /// <summary>
        /// Specifies the SKU of the certificate to be wildcard. It will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        AppServiceCertificateOrder.Definition.IWithDomainVerification AppServiceCertificateOrder.Definition.IWithCertificateSku.WithWildcardSku()
        {
            return this.WithWildcardSku() as AppServiceCertificateOrder.Definition.IWithDomainVerification;
        }

        /// <summary>
        /// Specifies the web app to verify the ownership of the domain. The web app needs to
        /// be bound to the hostname for the certificate.
        /// </summary>
        /// <param name="webApp">The web app bound to the hostname.</param>
        AppServiceCertificateOrder.Definition.IWithKeyVault AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp.WithWebAppVerification(IWebAppBase<object> webApp)
        {
            return this.WithWebAppVerification(webApp) as AppServiceCertificateOrder.Definition.IWithKeyVault;
        }

        Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.SignedCertificate
        {
            get
            {
                return this.SignedCertificate() as Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.AutoRenew
        {
            get
            {
                return this.AutoRenew();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.CertificateSigningRequest
        {
            get
            {
                return this.CertificateSigningRequest();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.DomainVerificationToken
        {
            get
            {
                return this.DomainVerificationToken();
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.VerifyDomainOwnership(IAppServiceDomain domain)
        {
 
            this.VerifyDomainOwnership(domain);
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.SerialNumber
        {
            get
            {
                return this.SerialNumber();
            }
        }

        Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.GetKeyVaultBinding()
        {
            return this.GetKeyVaultBinding() as Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.CreateKeyVaultBinding(string certificateName, IVault vault)
        {
            return this.CreateKeyVaultBinding(certificateName, vault) as Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.ExpirationTime
        {
            get
            {
                return this.ExpirationTime();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.CertificateProductType Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.ProductType
        {
            get
            {
                return this.ProductType();
            }
        }

        int Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.ValidityInYears
        {
            get
            {
                return this.ValidityInYears();
            }
        }

        /// <summary>
        /// Bind a Key Vault secret to a certificate store that will be used for storing the certificate once it's ready.
        /// </summary>
        /// <param name="certificateName">The name of the Key Vault Secret.</param>
        /// <param name="vault">The key vault to store the certificate.</param>
        async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding> Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.CreateKeyVaultBindingAsync(string certificateName, IVault vault, CancellationToken cancellationToken)
        {
            return await this.CreateKeyVaultBindingAsync(certificateName, vault, cancellationToken) as Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        /// <summary>
        /// Verifies the ownership of the domain by providing the Azure purchased domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        async Task Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.VerifyDomainOwnershipAsync(IAppServiceDomain domain, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(domain, cancellationToken);
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.CertificateOrderStatus Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.Status
        {
            get
            {
                return this.Status();
            }
        }

        Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.Root
        {
            get
            {
                return this.Root() as Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails;
            }
        }

        Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.Intermediate
        {
            get
            {
                return this.Intermediate() as Microsoft.Azure.Management.Appservice.Fluent.ICertificateDetails;
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.DistinguishedName
        {
            get
            {
                return this.DistinguishedName();
            }
        }

        async Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding> Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.GetKeyVaultBindingAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeyVaultBindingAsync(cancellationToken) as Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding;
        }

        int Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.KeySize
        {
            get
            {
                return this.KeySize();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder.LastCertificateIssuanceTime
        {
            get
            {
                return this.LastCertificateIssuanceTime();
            }
        }

        /// <summary>
        /// Specifies the hostname the certificate binds to.
        /// </summary>
        /// <param name="hostName">The bare host name, without "www". Use *. prefix if it's a wild card certificate.</param>
        AppServiceCertificateOrder.Definition.IWithCertificateSku AppServiceCertificateOrder.Definition.IWithHostName.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as AppServiceCertificateOrder.Definition.IWithCertificateSku;
        }

        /// <summary>
        /// Specifies the valid years of the certificate.
        /// </summary>
        /// <param name="years">Minimum 1 year, and maximum 3 years.</param>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithValidYears.WithValidYears(int years)
        {
            return this.WithValidYears(years) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        AppServiceCertificateOrder.Update.IUpdate AppServiceCertificateOrder.Update.IWithAutoRenew.WithAutoRenew(bool enabled)
        {
            return this.WithAutoRenew(enabled) as AppServiceCertificateOrder.Update.IUpdate;
        }

        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithAutoRenew.WithAutoRenew(bool enabled)
        {
            return this.WithAutoRenew(enabled) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder;
        }

        /// <summary>
        /// Specifies an existing key vault to store the certificate private key.
        /// 
        /// The vault MUST allow 2 service principals to read/write secrets:
        /// f3c21649-0979-4721-ac85-b0216b2cf413 and abfa0a7c-a6b6-4736-8310-5855508787cd.
        /// If they don't have access, an attempt will be made to grant access. If you are
        /// logged in from an identity without access to the Active Directory Graph, this
        /// attempt will fail.
        /// </summary>
        /// <param name="vault">The vault to store the private key.</param>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithKeyVault.WithExistingKeyVault(IVault vault)
        {
            return this.WithExistingKeyVault(vault) as AppServiceCertificateOrder.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new key vault to store the certificate private key.
        /// 
        /// DO NOT use this method if you are logged in from an identity without access
        /// to the Active Directory Graph.
        /// </summary>
        /// <param name="vaultName">The name of the new key vault.</param>
        /// <param name="region">The region to create the vault.</param>
        AppServiceCertificateOrder.Definition.IWithCreate AppServiceCertificateOrder.Definition.IWithKeyVault.WithNewKeyVault(string vaultName, Region region)
        {
            return this.WithNewKeyVault(vaultName, region) as AppServiceCertificateOrder.Definition.IWithCreate;
        }
    }
}