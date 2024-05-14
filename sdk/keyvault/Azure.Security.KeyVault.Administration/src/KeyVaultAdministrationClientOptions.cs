// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// Options to configure the requests sent to Key Vault.
    /// </summary>
    public class KeyVaultAdministrationClientOptions : ClientOptions
    {
        internal const string CallerShouldAuditReason = "https://aka.ms/azsdk/callershouldaudit/security-keyvault-administration";

        /// <summary>
        /// The latest service version supported by this client library.
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V7_5_Preview_1;

        /// <summary>
        /// The versions of Azure Key Vault supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Key Vault API version 7.2.
            /// </summary>
            V7_2 = 1,

            /// <summary>
            /// The Key Vault API version 7.3.
            /// </summary>
            V7_3 = 2,

            /// <summary>
            /// The Key Vault API version 7.4.
            /// </summary>
            V7_4 = 3,

            /// <summary>
            /// The Key Vault API version 7.5-preview.1.
            /// </summary>
            V7_5_Preview_1 = 4,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests. For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultAdministrationClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public KeyVaultAdministrationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;

            this.ConfigureLogging();
        }

        /// <summary>
        /// Gets or sets whether to disable verification that the authentication challenge resource matches the Key Vault or Managed HSM domain.
        /// </summary>
        public bool DisableChallengeResourceVerification { get; set; }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V7_2 => "7.2",
                ServiceVersion.V7_3 => "7.3",
                ServiceVersion.V7_4 => "7.4",
                ServiceVersion.V7_5_Preview_1 => "7.5-preview.1",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
