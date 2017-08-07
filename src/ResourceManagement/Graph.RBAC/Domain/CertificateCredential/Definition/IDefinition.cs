// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System;
    using System.IO;

    /// <summary>
    /// The entirety of a credential definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT> :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithCertificateType<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithPublicKey<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithSymmetricKey<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAuthFileCertificate<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAuthFileCertificatePassword<ParentT>
    {
    }

    /// <summary>
    /// The credential definition stage allowing the certificate type to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCertificateType<ParentT>
    {
        /// <summary>
        /// Specifies the type of the certificate to be symmetric.
        /// </summary>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithSymmetricKey<ParentT> WithSymmetricEncryption();

        /// <summary>
        /// Specifies the type of the certificate to be Asymmetric X509.
        /// </summary>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithPublicKey<ParentT> WithAsymmetricX509Certificate();
    }

    /// <summary>
    /// The final stage of the credential definition.
    /// At this stage, more settings can be specified, or the credential definition can be
    /// attached to the parent application / service principal definition
    /// using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithStartDate<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithDuration<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAuthFile<ParentT>
    {
    }

    /// <summary>
    /// A credential definition stage allowing specifying the password for the private key for exporting an auth file.
    /// </summary>
    public interface IWithAuthFileCertificatePassword<ParentT>
    {
        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="privateKeyPassword">The password for the private key.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAttach<ParentT> WithPrivateKeyPassword(string privateKeyPassword);
    }

    /// <summary>
    /// The credential definition stage allowing the duration of key validity to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDuration<ParentT>
    {
        /// <summary>
        /// Specifies the duration for which password or key would be valid. Default value is 1 year.
        /// </summary>
        /// <param name="duration">The duration of validity.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAttach<ParentT> WithDuration(TimeSpan duration);
    }

    /// <summary>
    /// The credential definition stage allowing the public key to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPublicKey<ParentT>
    {
        /// <summary>
        /// Specifies the public key for an asymmetric X509 certificate.
        /// </summary>
        /// <param name="certificate">The certificate content.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAttach<ParentT> WithPublicKey(byte[] certificate);
    }

    /// <summary>
    /// A credential definition stage allowing specifying the private key for exporting an auth file.
    /// </summary>
    public interface IWithAuthFileCertificate<ParentT>
    {
        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="privateKeyPath">The path to the private key file.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAuthFileCertificatePassword<ParentT> WithPrivateKeyFile(string privateKeyPath);
    }

    /// <summary>
    /// A credential definition stage allowing exporting the auth file for the service principal.
    /// </summary>
    public interface IWithAuthFile<ParentT>
    {
        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="outputStream">The output stream to export the file.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAuthFileCertificate<ParentT> WithAuthFileToExport(StreamWriter outputStream);
    }

    /// <summary>
    /// The credential definition stage allowing the secret key to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSymmetricKey<ParentT>
    {
        /// <summary>
        /// Specifies the secret key for a symmetric encryption.
        /// </summary>
        /// <param name="secret">The secret key content.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAttach<ParentT> WithSecretKey(byte[] secret);
    }

    /// <summary>
    /// The first stage of a credential definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithCertificateType<ParentT>
    {
    }

    /// <summary>
    /// The credential definition stage allowing start date to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStartDate<ParentT>
    {
        /// <summary>
        /// Specifies the start date after which password or key would be valid. Default value is current time.
        /// </summary>
        /// <param name="startDate">The start date for validity.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition.IWithAttach<ParentT> WithStartDate(DateTime startDate);
    }
}