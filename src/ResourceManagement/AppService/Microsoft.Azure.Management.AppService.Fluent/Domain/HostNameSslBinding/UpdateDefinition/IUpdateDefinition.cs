// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition
{
    using Microsoft.Azure.Management.Fluent.KeyVault;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Appservice.Fluent;
    using Java.Io;

    /// <summary>
    /// The first stage of a hostname SSL binding definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithHostname<ParentT>
    {
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing key vault for certificate store to be specified.
    /// </summary>
    public interface IWithKeyVault<ParentT> 
    {
        /// <summary>
        /// Creates a new key vault to store the certificate.
        /// </summary>
        /// <param name="vaultName">The name of the key vault to create.</param>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithSslType<ParentT> WithNewKeyVault(string vaultName);

        /// <summary>
        /// Stores the certificate in an existing vault.
        /// </summary>
        /// <param name="vault">The existing vault to use.</param>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithSslType<ParentT> WithExistingKeyVault(IVault vault);
    }

    /// <summary>
    /// The final stage of the hostname SSL binding definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the hostname SSL binding definition
    /// can be attached to the parent web app update using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a hostname SSL binding definition as part of a web app update.
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithHostname<ParentT>,
        IWithCertificate<ParentT>,
        IWithKeyVault<ParentT>,
        IWithSslType<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing certificate information to be specified.
    /// </summary>
    public interface IWithCertificate<ParentT> 
    {
        /// <summary>
        /// Specifies a ready-to-use certificate order to use. This is usually useful for reusing wildcard certificates.
        /// </summary>
        /// <param name="certificateOrder">The ready-to-use certificate order.</param>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithSslType<ParentT> WithExistingAppServiceCertificateOrder(IAppServiceCertificateOrder certificateOrder);

        /// <summary>
        /// Uploads a PFX certificate.
        /// </summary>
        /// <param name="pfxFile">The PFX certificate file to upload.</param>
        /// <param name="password">The password to the certificate.</param>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithSslType<ParentT> WithPfxCertificateToUpload(File pfxFile, string password);

        /// <summary>
        /// Places a new App Service certificate order to use for the hostname.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithKeyVault<ParentT> WithNewStandardSslCertificateOrder(string certificateOrderName);
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing hostname to be specified.
    /// </summary>
    public interface IWithHostname<ParentT> 
    {
        /// <summary>
        /// Specifies the hostname to bind SSL certificate to.
        /// </summary>
        /// <param name="hostname">The naked hostname, excluding "www". But use *. prefix for wild card typed certificate order.</param>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithCertificate<ParentT> ForHostname(string hostname);
    }

    /// <summary>
    /// The stage of a hostname SSL binding definition allowing SSL type to be specified.
    /// </summary>
    public interface IWithSslType<ParentT> 
    {
        /// <summary>
        /// Uses IP based SSL. Only one hostname can be bound to IP based SSL.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithAttach<ParentT> WithIpBasedSsl();

        /// <summary>
        /// Uses Server Name Indication (SNI) based SSL.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IWithAttach<ParentT> WithSniBasedSsl();
    }
}