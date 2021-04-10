// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    /// <summary>
    /// Options class used by the <see cref="AzureKeyVaultConfigurationExtensions"/>.
    /// </summary>
    public class AzureKeyVaultConfigurationOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="AzureKeyVaultConfigurationOptions"/>.
        /// </summary>
        public AzureKeyVaultConfigurationOptions()
        {
            Manager = KeyVaultSecretManager.Instance;
        }

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
