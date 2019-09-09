﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// For more information, see 
        /// <see href="https://docs.microsoft.com/en-us/rest/api/keyvault/key-vault-versions"/>
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V7_0;

        /// <summary>
        /// The versions of Azure Key Vault supported by this client
        /// library. 
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Key Vault API version 7.0.
            /// </summary>
            V7_0 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests. For more information, see 
        /// <see href="https://docs.microsoft.com/en-us/rest/api/keyvault/key-vault-versions"/>
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public CertificateClientOptions(ServiceVersion version = ServiceVersion.V7_0)
        {
            this.Version = version;
        }
    }
}
