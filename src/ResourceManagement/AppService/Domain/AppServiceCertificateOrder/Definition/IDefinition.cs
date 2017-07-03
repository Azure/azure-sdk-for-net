// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using KeyVault.Fluent;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithHostName,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCertificateSku,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithKeyVault,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCreate
    {
    }

    /// <summary>
    /// An app service certificate order definition allowing hostname to be set.
    /// </summary>
    public interface IWithHostName 
    {
        /// <summary>
        /// Specifies the hostname the certificate binds to.
        /// </summary>
        /// <param name="hostName">The bare host name, without "www". Use . prefix if it's a wild card certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCertificateSku WithHostName(string hostName);
    }

    /// <summary>
    /// An app service certificate order definition with sufficient inputs to create a new
    /// app service certificate order in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithValidYears,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithAutoRenew,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// An app service certificate order definition allowing resource group to be set.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithExistingResourceGroup<Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithHostName>
    {
    }

    /// <summary>
    /// An app service certificate order definition allowing valid years to be set.
    /// </summary>
    public interface IWithValidYears 
    {
        /// <summary>
        /// Specifies the valid years of the certificate.
        /// </summary>
        /// <param name="years">Minimum 1 year, and maximum 3 years.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithValidYears(int years);
    }

    /// <summary>
    /// An app service certificate order definition allowing SKU to be set.
    /// </summary>
    public interface IWithCertificateSku 
    {
        /// <summary>
        /// Specifies the SKU of the certificate to be wildcard. It will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithDomainVerification WithWildcardSku();

        /// <summary>
        /// Specifies the SKU of the certificate to be standard. It will only provide
        /// SSL support to the hostname, and www.hostname. Wildcard type will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp WithStandardSku();
    }

    /// <summary>
    /// An app service certificate order definition allowing auto-renew settings to be set.
    /// </summary>
    public interface IWithAutoRenew 
    {
        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithAutoRenew(bool enabled);
    }

    /// <summary>
    /// An app service certificate order definition allowing domain verification method to be set.
    /// </summary>
    public interface IWithDomainVerification 
    {
        /// <summary>
        /// Specifies the Azure managed domain to verify the ownership of the domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithKeyVault WithDomainVerification(IAppServiceDomain domain);
    }

    /// <summary>
    /// An app service certificate order definition allowing more domain verification methods to be set.
    /// </summary>
    public interface IWithKeyVault 
    {
        /// <summary>
        /// Creates a new key vault to store the certificate private key.
        /// DO NOT use this method if you are logged in from an identity without access
        /// to the Active Directory Graph.
        /// </summary>
        /// <param name="vaultName">The name of the new key vault.</param>
        /// <param name="region">The region to create the vault.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithNewKeyVault(string vaultName, Region region);

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
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithExistingKeyVault(IVault vault);
    }

    /// <summary>
    /// An app service certificate order definition allowing more domain verification methods to be set.
    /// </summary>
    public interface IWithDomainVerificationFromWebApp  :
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithDomainVerification
    {
        /// <summary>
        /// Specifies the web app to verify the ownership of the domain. The web app needs to
        /// be bound to the hostname for the certificate.
        /// </summary>
        /// <param name="webApp">The web app bound to the hostname.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition.IWithKeyVault WithWebAppVerification(IWebAppBase webApp);
    }
}