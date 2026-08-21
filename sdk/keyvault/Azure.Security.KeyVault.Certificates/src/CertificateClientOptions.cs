// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Options that allow you to configure the requests sent to Key Vault.
    /// </summary>
    public class CertificateClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2026_03_01_Preview;

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
            /// The Key Vault API version 2026-03-01-preview.
            /// </summary>
            V2026_03_01_Preview = 8,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests. For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
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
        public CertificateClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;

            this.ConfigureLogging();
        }

        /// <summary>
        /// Gets or sets whether to disable verification that the authentication challenge resource matches the Key Vault domain.
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
        /// <para>
        /// Setting this to <see langword="true"/> is a request, not a guarantee. It can be silently ignored when
        /// the effective transport cannot apply the binding certificate — for example when
        /// <see cref="Azure.Core.ClientOptions.Transport"/> is set to a custom transport whose
        /// <see cref="System.Net.Http.HttpClient"/> is fixed at construction time, or when the credential does
        /// not honor <see cref="Azure.Core.TokenRequestContext.IsProofOfPossessionEnabled"/>. In those cases the
        /// client falls back to a plain bearer token and does not send the <c>x-ms-tokenboundauth</c> header.
        /// </para>
        /// <para>
        /// Throughput profile changes materially when enabled. Proof-of-Possession tokens are bound to a specific
        /// request URI and HTTP method, so <see cref="Azure.Core.Pipeline.BearerTokenAuthenticationPolicy"/>'s
        /// single-slot access-token cache is invalidated whenever the request URI or method changes. Because it
        /// is one slot rather than a per-URI map, alternating requests to different vault resources will each
        /// drive a fresh credential invocation. That is inherent to binding a token to a request line; MSAL has
        /// its own inner cache, but callers enabling this should be aware they are trading throughput for
        /// cryptographic binding.
        /// </para>
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
                ServiceVersion.V2026_03_01_Preview => "2026-03-01-preview",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
