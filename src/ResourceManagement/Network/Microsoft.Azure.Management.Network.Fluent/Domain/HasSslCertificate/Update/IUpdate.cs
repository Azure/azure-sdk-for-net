// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.IO;

namespace Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update
{
    /// <summary>
    /// The stage of a resource update allowing to specify the SSL certificate to associate with it.
    /// </summary>
    /// <typeparam name="Return">The next stage of the update.</typeparam>
    public interface IWithSslCertificate<ReturnT> 
    {
        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associate with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update.IWithSslPassword<ReturnT> WithSslCertificateFromPfxFile(FileInfo pfxFile);

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the parent resource update.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate associated with this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ReturnT WithSslCertificate(string name);
    }

    /// <summary>
    /// The stage of a resource update allowing to specify the password for the private key of the imported SSL certificate.
    /// </summary>
    /// <typeparam name="Return">The next stage of the update.</typeparam>
    public interface IWithSslPassword<ReturnT> 
    {
        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithSslCertificatePassword(string password);
    }
}