// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Represents the settings used to configure a <see cref="SecretClient"/> that can be loaded from an <see cref="IConfigurationSection"/>.
    /// </summary>
    [Experimental("SCME0002")]
    public class SecretClientSettings : ClientSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="Uri"/> to the vault on which the client operates.
        /// Appears as "DNS Name" in the Azure portal.
        /// </summary>
        public Uri? VaultUri { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SecretClientOptions"/> used to configure requests sent to Key Vault.
        /// </summary>
        public SecretClientOptions? Options { get; set; }

        /// <inheritdoc/>
        protected override void BindCore(IConfigurationSection section)
        {
            string? endpoint = section["VaultUri"];
            if (!string.IsNullOrEmpty(endpoint))
            {
                VaultUri = new Uri(endpoint);
            }

            IConfigurationSection optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new SecretClientOptions(optionsSection);
            }
        }
    }
}
