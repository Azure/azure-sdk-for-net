// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Options that allow you to configure the requests sent to Key Vault.
    /// </summary>
    public class KeyClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2026_01_01_Preview;

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
            V7_0 = 0,

            /// <summary>
            /// The Key Vault API version 7.1.
            /// </summary>
            V7_1 = 1,

            /// <summary>
            /// The Key Vault API version 7.2.
            /// </summary>
            V7_2 = 2,

            /// <summary>
            /// The Key Vault API version 7.3.
            /// </summary>
            V7_3 = 3,

            /// <summary>
            /// The Key Vault API version 7.4.
            /// </summary>
            V7_4 = 4,

            /// <summary>
            /// The Key Vault API version 7.5.
            /// </summary>
            V7_5 = 5,

            /// <summary>
            /// The Key Vault API version 7.6.
            /// </summary>
            V7_6 = 6,

            /// <summary>
            /// The Key Vault API version 2025-07-01.
            /// </summary>
            V2025_07_01 = 7,

            /// <summary>
            /// The Key Vault API version 2026-01-01-preview.
            /// </summary>
            V2026_01_01_Preview = 8,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests. For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyClientOptions"/> class.
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public KeyClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;

            this.ConfigureLogging();
        }

        /// <summary>
        /// Gets or sets whether to disable verification that the authentication challenge resource matches the Key Vault or Managed HSM domain.
        /// </summary>
        public bool DisableChallengeResourceVerification { get; set; }

        /// <summary>
        /// Gets or sets whether to request Proof-of-Possession (PoP) token binding for authenticated requests. When
        /// enabled, the client asks the credential for a token that is cryptographically bound to a client
        /// certificate and, only when the credential and transport actually support it, sends the
        /// <c>x-ms-tokenboundauth</c> header alongside the bound token.
        /// </summary>
        /// <remarks>
        /// This is opt-in and defaults to <see langword="false"/> so existing applications see no change in
        /// authentication behavior, transport/connection-pooling behavior, or resource usage. The underlying
        /// Proof-of-Possession support in Azure.Core and Azure.Identity is experimental (see <c>AZID0004</c>);
        /// enable this only if you understand and accept that.
        /// </remarks>
        public bool EnableProofOfPossession { get; set; }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V7_0 => "7.0",
                ServiceVersion.V7_1 => "7.1",
                ServiceVersion.V7_2 => "7.2",
                ServiceVersion.V7_3 => "7.3",
                ServiceVersion.V7_4 => "7.4",
                ServiceVersion.V7_5 => "7.5",
                ServiceVersion.V7_6 => "7.6",
                ServiceVersion.V2025_07_01 => "2025-07-01",
                ServiceVersion.V2026_01_01_Preview => "2026-01-01-preview",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
