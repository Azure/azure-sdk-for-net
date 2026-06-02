// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// Options to configure the requests sent to Key Vault.
    /// </summary>
    [CodeGenType("KeyVaultAccessControlClientOptions")]
    public partial class KeyVaultAdministrationClientOptions : ClientOptions
    {
        internal const string CallerShouldAuditReason = "https://aka.ms/azsdk/callershouldaudit/security-keyvault-administration";

        /// <summary>
        /// Gets the <see cref="KeyVaultAdministrationClientOptions.ServiceVersion"/> of the service API used when
        /// making requests. For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/keyvault/key-vault-versions">Key Vault versions</see>.
        /// </summary>
        public KeyVaultAdministrationClientOptions.ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultAdministrationClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="KeyVaultAdministrationClientOptions.ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public KeyVaultAdministrationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;

            this.ConfigureLogging();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="KeyVaultAdministrationClientOptions"/> from configuration.
        /// </summary>
        /// <param name="section">The configuration section.</param>
        [Experimental("SCME0002")]
        internal KeyVaultAdministrationClientOptions(IConfigurationSection section) : base(section, null)
        {
            Version = LatestVersion;
            if (section is null || !section.Exists())
            {
                return;
            }
            if (section["Version"] is string version && TryGetServiceVersion(version, out ServiceVersion serviceVersion))
            {
                Version = serviceVersion;
            }
            ConfigureLogging();
        }

        /// <summary> The version of the service to use. </summary>
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
            /// The Key Vault API version 7.5.
            /// </summary>
            V7_5 = 4,

            /// <summary>
            /// The Key Vault API version 7.6.
            /// </summary>
            V7_6 = 5,

            /// <summary>
            /// The Key Vault API version 2025-07-01.
            /// </summary>
            V2025_07_01 = 6,
#pragma warning restore CA1707 // Identifiers should not contain underscores
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
                ServiceVersion.V7_5 => "7.5",
                ServiceVersion.V7_6 => "7.6",
                ServiceVersion.V2025_07_01 => "2025-07-01",
                _ => throw new ArgumentOutOfRangeException(nameof(Version), Version, null)
            };
        }

        internal static bool TryGetServiceVersion(string version, out ServiceVersion serviceVersion)
        {
            serviceVersion = ServiceVersion.V7_2;
            switch (version)
            {
                case "7.2":
                    serviceVersion = ServiceVersion.V7_2;
                    return true;
                case "7.3":
                    serviceVersion = ServiceVersion.V7_3;
                    return true;
                case "7.4":
                    serviceVersion = ServiceVersion.V7_4;
                    return true;
                case "7.5":
                    serviceVersion = ServiceVersion.V7_5;
                    return true;
                case "7.6":
                    serviceVersion = ServiceVersion.V7_6;
                    return true;
                case "2025-07-01":
                    serviceVersion = ServiceVersion.V2025_07_01;
                    return true;
                default:
                    return false;
            }
        }
    }
}
