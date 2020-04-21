// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    /// <summary>
    /// Options class used by the <see cref="AzureKeyVaultConfigurationExtensions"/>.
    /// </summary>
    internal class AzureKeyVaultConfigurationOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="AzureKeyVaultConfigurationOptions"/>.
        /// </summary>
        public AzureKeyVaultConfigurationOptions()
        {
            Manager = KeyVaultSecretManager.Instance;
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureKeyVaultConfigurationOptions"/>.
        /// </summary>
        /// <param name="vaultUri">Azure Key Vault uri.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> to use for authentication.</param>
        public AzureKeyVaultConfigurationOptions(
            Uri vaultUri,
            TokenCredential credential) : this()
        {
            Client = new SecretClient(vaultUri, credential);
        }

        /// <summary>
        /// Gets or sets the <see cref="SecretClient"/> to use for retrieving values.
        /// </summary>
        public SecretClient Client { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="KeyVaultSecretManager"/> instance used to control secret loading.
        /// </summary>
        public KeyVaultSecretManager Manager { get; set; }

        /// <summary>
        /// Gets or sets the timespan to wait between attempts at polling the Azure Key Vault for changes. <code>null</code> to disable reloading.
        /// </summary>
        public TimeSpan? ReloadInterval { get; set; }
    }
}
