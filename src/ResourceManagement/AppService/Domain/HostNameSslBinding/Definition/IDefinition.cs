// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent;

    /// <summary>
    /// The first stage of a hostname SSL binding definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithHostname<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the hostname SSL binding definition.
    /// At this stage, any remaining optional settings can be specified, or the hostname SSL binding definition
    /// can be attached to the parent web app definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing hostname to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithHostname<ParentT> 
    {
        /// <summary>
        /// Specifies the hostname to bind SSL certificate to.
        /// </summary>
        /// <param name="hostname">The naked hostname, excluding "www". But use . prefix for wild card typed certificate order.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithCertificate<ParentT> ForHostname(string hostname);
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing SSL type to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSslType<ParentT> 
    {
        /// <summary>
        /// Uses IP based SSL. Only one hostname can be bound to IP based SSL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithAttach<ParentT> WithIpBasedSsl();

        /// <summary>
        /// Uses Server Name Indication (SNI) based SSL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithAttach<ParentT> WithSniBasedSsl();
    }

    /// <summary>
    /// The entirety of a hostname SSL binding definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithHostname<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithCertificate<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithKeyVault<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithSslType<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing certificate information to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCertificate<ParentT> 
    {
        /// <summary>
        /// Specifies a ready-to-use certificate order to use. This is usually useful for reusing wildcard certificates.
        /// </summary>
        /// <param name="certificateOrder">The ready-to-use certificate order.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithSslType<ParentT> WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder);

        /// <summary>
        /// Uploads a PFX certificate.
        /// </summary>
        /// <param name="pfxFile">The PFX certificate file to upload.</param>
        /// <param name="password">The password to the certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithSslType<ParentT> WithPfxCertificateToUpload(string pfxFile, string password);

        /// <summary>
        /// Places a new App Service certificate order to use for the hostname.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithKeyVault<ParentT> WithNewStandardSslCertificateOrder(string certificateOrderName);
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing key vault for certificate store to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithKeyVault<ParentT> 
    {
        /// <summary>
        /// Creates a new key vault to store the certificate.
        /// </summary>
        /// <param name="vaultName">The name of the key vault to create.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithSslType<ParentT> WithNewKeyVault(string vaultName);

        /// <summary>
        /// Stores the certificate in an existing vault.
        /// </summary>
        /// <param name="vault">The existing vault to use.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IWithSslType<ParentT> WithExistingKeyVault(IVault vault);
    }
}