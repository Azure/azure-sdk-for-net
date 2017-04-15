// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.IO;

    internal partial class HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Uses Server Name Indication (SNI) based SSL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>>.WithSniBasedSsl()
        {
            return this.WithSniBasedSsl() as HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Uses IP based SSL. Only one hostname can be bound to IP based SSL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>>.WithIpBasedSsl()
        {
            return this.WithIpBasedSsl() as HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Uses Server Name Indication (SNI) based SSL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>.WithSniBasedSsl()
        {
            return this.WithSniBasedSsl() as HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Uses IP based SSL. Only one hostname can be bound to IP based SSL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>.WithIpBasedSsl()
        {
            return this.WithIpBasedSsl() as HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppBase Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.AppService.Fluent.IWebAppBase;
            }
        }

        /// <summary>
        /// Specifies the hostname to bind SSL certificate to.
        /// </summary>
        /// <param name="hostname">The naked hostname, excluding "www". But use . prefix for wild card typed certificate order.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithHostname<WebAppBase.Definition.IWithCreate<FluentT>>.ForHostname(string hostname)
        {
            return this.ForHostname(hostname) as HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the hostname to bind SSL certificate to.
        /// </summary>
        /// <param name="hostname">The naked hostname, excluding "www". But use . prefix for wild card typed certificate order.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithHostname<WebAppBase.Update.IUpdate<FluentT>>.ForHostname(string hostname)
        {
            return this.ForHostname(hostname) as HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        WebAppBase.Update.IUpdate<FluentT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<WebAppBase.Update.IUpdate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Gets the SSL cert thumbprint.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IHostNameSslBinding.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }

        /// <summary>
        /// Gets the virtual IP address assigned to the host name if IP based SSL is enabled.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IHostNameSslBinding.VirtualIP
        {
            get
            {
                return this.VirtualIP();
            }
        }

        /// <summary>
        /// Gets the SSL type.
        /// </summary>
        Models.SslState Microsoft.Azure.Management.AppService.Fluent.IHostNameSslBinding.SslState
        {
            get
            {
                return this.SslState();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<WebAppBase.Definition.IWithCreate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies a ready-to-use certificate order to use. This is usually useful for reusing wildcard certificates.
        /// </summary>
        /// <param name="certificateOrder">The ready-to-use certificate order.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithCreate<FluentT>>.WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            return this.WithExistingAppServiceCertificateOrder(certificateOrder) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Uploads a PFX certificate.
        /// </summary>
        /// <param name="pfxFile">The PFX certificate file to upload.</param>
        /// <param name="password">The password to the certificate.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithCreate<FluentT>>.WithPfxCertificateToUpload(string pfxFile, string password)
        {
            return this.WithPfxCertificateToUpload(pfxFile, password) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Places a new App Service certificate order to use for the hostname.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithCreate<FluentT>>.WithNewStandardSslCertificateOrder(string certificateOrderName)
        {
            return this.WithNewStandardSslCertificateOrder(certificateOrderName) as HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies a ready-to-use certificate order to use. This is usually useful for reusing wildcard certificates.
        /// </summary>
        /// <param name="certificateOrder">The ready-to-use certificate order.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>.WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            return this.WithExistingAppServiceCertificateOrder(certificateOrder) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Uploads a PFX certificate.
        /// </summary>
        /// <param name="pfxFile">The PFX certificate file to upload.</param>
        /// <param name="password">The password to the certificate.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>.WithPfxCertificateToUpload(string pfxFile, string password)
        {
            return this.WithPfxCertificateToUpload(pfxFile, password) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Places a new App Service certificate order to use for the hostname.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>.WithNewStandardSslCertificateOrder(string certificateOrderName)
        {
            return this.WithNewStandardSslCertificateOrder(certificateOrderName) as HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Stores the certificate in an existing vault.
        /// </summary>
        /// <param name="vault">The existing vault to use.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithCreate<FluentT>>.WithExistingKeyVault(IVault vault)
        {
            return this.WithExistingKeyVault(vault) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Creates a new key vault to store the certificate.
        /// </summary>
        /// <param name="vaultName">The name of the key vault to create.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>> HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithCreate<FluentT>>.WithNewKeyVault(string vaultName)
        {
            return this.WithNewKeyVault(vaultName) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Stores the certificate in an existing vault.
        /// </summary>
        /// <param name="vault">The existing vault to use.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>>.WithExistingKeyVault(IVault vault)
        {
            return this.WithExistingKeyVault(vault) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Creates a new key vault to store the certificate.
        /// </summary>
        /// <param name="vaultName">The name of the key vault to create.</param>
        /// <return>The next stage of the definition.</return>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>>.WithNewKeyVault(string vaultName)
        {
            return this.WithNewKeyVault(vaultName) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }
    }
}