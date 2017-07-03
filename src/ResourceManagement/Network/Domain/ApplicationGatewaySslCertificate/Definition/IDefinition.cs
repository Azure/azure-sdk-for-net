// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.IO;

    /// <summary>
    /// The stage of an SSL certificate definition allowing to specify the password for the private key (PFX) content of the certificate.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway to return to after attaching.</typeparam>
    public interface IWithPassword<ParentT> 
    {
        /// <summary>
        /// Specifies the password currently used to protect the provided PFX content of the SSL certificate.
        /// </summary>
        /// <param name="password">A password.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithAttach<ParentT> WithPfxPassword(string password);
    }

    /// <summary>
    /// The final stage of an application gateway SSL certificate definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway SSL certificate definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithData<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithPassword<ParentT>
    {
    }

    /// <summary>
    /// The stage of an SSL certificate definition allowing to specify the contents of the SSL certificate.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway to return to after attaching.</typeparam>
    public interface IWithData<ParentT> 
    {
        /// <summary>
        /// Specifies the PFX (PKCS#12) file to get the private key content from.
        /// </summary>
        /// <param name="pfxFile">A file in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>Java.io.IOException when there are problems with the provided file.</throws>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithPassword<ParentT> WithPfxFromFile(FileInfo pfxFile);

        /// <summary>
        /// Specifies the contents of the private key in the PFX (PKCS#12) format, not base64-encoded.
        /// </summary>
        /// <param name="pfxData">The contents of the private key in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithPassword<ParentT> WithPfxFromBytes(params byte[] pfxData);
    }

    /// <summary>
    /// The first stage of an application gateway SSL certificate.
    /// </summary>
    /// <typeparam name="ParentT">The parent application gateway type.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IWithData<ParentT>
    {
    }
}