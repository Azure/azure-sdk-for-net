// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Options that allow you to configure the requests sent to Key Vault by
    /// <see cref="SecretGeneratedClient"/>. This client is built entirely on
    /// the TypeSpec-generated transport — the public surface mirrors
    /// <see cref="SecretClient"/> so customers can adopt it without changing
    /// call sites, while internally relying on auto-generated request/response
    /// code instead of the legacy hand-written pipeline.
    /// </summary>
    public class SecretGeneratedClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2025_07_01;

        /// <summary>
        /// The versions of Azure Key Vault supported by <see cref="SecretGeneratedClient"/>.
        /// Kept in sync with <see cref="SecretClientOptions.ServiceVersion"/> so a
        /// recording captured against either client is replayable on both.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>The Key Vault API version 7.5.</summary>
            V7_5 = 1,

            /// <summary>The Key Vault API version 7.6.</summary>
            V7_6 = 2,

            /// <summary>The Key Vault API version 2025-07-01.</summary>
            V2025_07_01 = 3,
#pragma warning restore CA1707
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretGeneratedClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </param>
        public SecretGeneratedClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        /// <summary>
        /// Gets or sets whether to disable verification that the authentication challenge resource matches the Key Vault domain.
        /// </summary>
        public bool DisableChallengeResourceVerification { get; set; }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V7_5        => "7.5",
                ServiceVersion.V7_6        => "7.6",
                ServiceVersion.V2025_07_01 => "2025-07-01",
                _ => throw new ArgumentException("Unknown service version: " + Version, nameof(Version)),
            };
        }
    }
}
