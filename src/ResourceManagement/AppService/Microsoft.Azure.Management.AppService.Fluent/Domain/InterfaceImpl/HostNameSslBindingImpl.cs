// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading.Tasks;
    using AppServiceCertificateOrder.Definition;
    using HostNameSslBinding.Definition;
    using HostNameSslBinding.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebAppBase.Definition;
    using WebAppBase.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class HostNameSslBindingImpl<FluentT,FluentImplT> 
    {
        string IChildResource<IWebAppBase>.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Uses Server Name Indication (SNI) based SSL.
        /// </summary>
        HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithSniBasedSsl()
        {
            return this.WithSniBasedSsl() as HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Uses IP based SSL. Only one hostname can be bound to IP based SSL.
        /// </summary>
        HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithIpBasedSsl()
        {
            return this.WithIpBasedSsl() as HostNameSslBinding.Definition.IWithAttach<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Uses Server Name Indication (SNI) based SSL.
        /// </summary>
        HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>.WithSniBasedSsl()
        {
            return this.WithSniBasedSsl() as HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Uses IP based SSL. Only one hostname can be bound to IP based SSL.
        /// </summary>
        HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>.WithIpBasedSsl()
        {
            return this.WithIpBasedSsl() as HostNameSslBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the hostname to bind SSL certificate to.
        /// </summary>
        /// <param name="hostname">The naked hostname, excluding "www". But use *. prefix for wild card typed certificate order.</param>
        HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithHostname<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.ForHostname(string hostname)
        {
            return this.ForHostname(hostname) as HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Specifies the hostname to bind SSL certificate to.
        /// </summary>
        /// <param name="hostname">The naked hostname, excluding "www". But use *. prefix for wild card typed certificate order.</param>
        HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithHostname<WebAppBase.Update.IUpdate<FluentT>>.ForHostname(string hostname)
        {
            return this.ForHostname(hostname) as HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<WebAppBase.Update.IUpdate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Update.IUpdate<FluentT>;
        }

        string Microsoft.Azure.Management.AppService.Fluent.IHostNameSslBinding.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IHostNameSslBinding.VirtualIP
        {
            get
            {
                return this.VirtualIP();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.SslState Microsoft.Azure.Management.AppService.Fluent.IHostNameSslBinding.SslState
        {
            get
            {
                return this.SslState();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        WebAppBase.Definition.IWithHostNameSslBinding<FluentT> Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Definition.IWithHostNameSslBinding<FluentT>;
        }

        /// <summary>
        /// Specifies a ready-to-use certificate order to use. This is usually useful for reusing wildcard certificates.
        /// </summary>
        /// <param name="certificateOrder">The ready-to-use certificate order.</param>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            return this.WithExistingAppServiceCertificateOrder(certificateOrder) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Uploads a PFX certificate.
        /// </summary>
        /// <param name="pfxFile">The PFX certificate file to upload.</param>
        /// <param name="password">The password to the certificate.</param>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithPfxCertificateToUpload(string pfxPath, string password)
        {
            return this.WithPfxCertificateToUpload(pfxPath, password) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Places a new App Service certificate order to use for the hostname.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithCertificate<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithNewStandardSslCertificateOrder(string certificateOrderName)
        {
            return this.WithNewStandardSslCertificateOrder(certificateOrderName) as HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Specifies a ready-to-use certificate order to use. This is usually useful for reusing wildcard certificates.
        /// </summary>
        /// <param name="certificateOrder">The ready-to-use certificate order.</param>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>.WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder)
        {
            return this.WithExistingAppServiceCertificateOrder(certificateOrder) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Uploads a PFX certificate.
        /// </summary>
        /// <param name="pfxFile">The PFX certificate file to upload.</param>
        /// <param name="password">The password to the certificate.</param>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>.WithPfxCertificateToUpload(string pfxPath, string password)
        {
            return this.WithPfxCertificateToUpload(pfxPath, password) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Places a new App Service certificate order to use for the hostname.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithCertificate<WebAppBase.Update.IUpdate<FluentT>>.WithNewStandardSslCertificateOrder(string certificateOrderName)
        {
            return this.WithNewStandardSslCertificateOrder(certificateOrderName) as HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Stores the certificate in an existing vault.
        /// </summary>
        /// <param name="vault">The existing vault to use.</param>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithExistingKeyVault(IVault vault)
        {
            return this.WithExistingKeyVault(vault) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Creates a new key vault to store the certificate.
        /// </summary>
        /// <param name="vaultName">The name of the key vault to create.</param>
        HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameSslBinding.Definition.IWithKeyVault<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithNewKeyVault(string vaultName)
        {
            return this.WithNewKeyVault(vaultName) as HostNameSslBinding.Definition.IWithSslType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Stores the certificate in an existing vault.
        /// </summary>
        /// <param name="vault">The existing vault to use.</param>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>>.WithExistingKeyVault(IVault vault)
        {
            return this.WithExistingKeyVault(vault) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Creates a new key vault to store the certificate.
        /// </summary>
        /// <param name="vaultName">The name of the key vault to create.</param>
        HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>> HostNameSslBinding.UpdateDefinition.IWithKeyVault<WebAppBase.Update.IUpdate<FluentT>>.WithNewKeyVault(string vaultName)
        {
            return this.WithNewKeyVault(vaultName) as HostNameSslBinding.UpdateDefinition.IWithSslType<WebAppBase.Update.IUpdate<FluentT>>;
        }
    }
}