// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
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
        /// Converts a loaded list of secrets into a corresponding set of configuration key-value pairs.
        /// </summary>
        /// <param name="secrets">A set of secrets retrieved during <see cref="AzureKeyVaultConfigurationProvider.Load"/> call.</param>
        /// <returns>The dictionary of configuration key-value pairs that would be assigned to the <see cref="ConfigurationProvider.Data"/>
        /// and exposed from the <see cref="IConfiguration"/>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="secrets"/> is <code>null</code>.</exception>
        public virtual Dictionary<string, string> GetData(IEnumerable<KeyVaultSecret> secrets)
        {
            Argument.AssertNotNull(secrets, nameof(secrets));

            var data = new Dictionary<string, KeyVaultSecret>(StringComparer.OrdinalIgnoreCase);

            foreach (var secret in secrets)
            {
                string key = GetKey(secret);

                // It is possible that multiple
                // LoadedSecrets objects uses the same configuration key. This loop
                // takes the latest updated value for each key.
                if (data.TryGetValue(key, out KeyVaultSecret currentSecret))
                {
                    if (secret.Properties.UpdatedOn > currentSecret.Properties.UpdatedOn)
                    {
                        data[key] = secret;
                    }
                }
                else
                {
                    data.Add(key, secret);
                }
            }

            return data.ToDictionary(d => d.Key, v => v.Value.Value);
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
