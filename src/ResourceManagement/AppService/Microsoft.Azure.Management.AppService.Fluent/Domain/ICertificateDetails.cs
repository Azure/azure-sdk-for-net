// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App certificate.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface ICertificateDetails  :
        IHasInner<Models.CertificateDetailsInner>
    {
        /// <summary>
        /// Gets Valid from.
        /// </summary>
        System.DateTime NotBefore { get; }

        /// <summary>
        /// Gets Issuer.
        /// </summary>
        string Issuer { get; }

        /// <summary>
        /// Gets Thumbprint.
        /// </summary>
        string Thumbprint { get; }

        /// <summary>
        /// Gets Raw certificate data.
        /// </summary>
        string RawData { get; }

        /// <summary>
        /// Gets Subject.
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// Gets Signature Algorithm.
        /// </summary>
        string SignatureAlgorithm { get; }

        /// <summary>
        /// Gets Serial Number.
        /// </summary>
        string SerialNumber { get; }

        /// <summary>
        /// Gets Valid to.
        /// </summary>
        System.DateTime NotAfter { get; }

        /// <summary>
        /// Gets Version.
        /// </summary>
        int Version { get; }
    }
}