// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    /// <summary>
    /// Default implementation of <see cref="KeyVaultSecretManager"/> that loads all secrets
    /// and replaces '--' with ':' in key names.
    /// </summary>
    public class KeyVaultSecretManager
    {
        internal static KeyVaultSecretManager Instance { get; } = new KeyVaultSecretManager();

        /// <summary>
        /// Maps secret to a configuration key.
        /// </summary>
        /// <param name="secret">The <see cref="KeyVaultSecret"/> instance.</param>
        /// <returns>Configuration key name to store secret value.</returns>
        public virtual string GetKey(KeyVaultSecret secret)
        {
            return secret.Name.Replace("--", ConfigurationPath.KeyDelimiter);
        }

        /// <summary>
        /// Checks if <see cref="KeyVaultSecret"/> value should be retrieved.
        /// </summary>
        /// <param name="secret">The <see cref="SecretProperties"/> instance.</param>
        /// <returns><code>true</code> if secrets value should be loaded, otherwise <code>false</code>.</returns>
        public virtual bool Load(SecretProperties secret)
        {
            return true;
        }
    }
}
