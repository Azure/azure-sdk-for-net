// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Secrets.Extensions.Configuration
{
    /// <summary>
    /// The <see cref="IKeyVaultSecretManager"/> instance used to control secret loading.
    /// </summary>
    public interface IKeyVaultSecretManager
    {
        /// <summary>
        /// Checks if <see cref="KeyVaultSecret"/> value should be retrieved.
        /// </summary>
        /// <param name="secret">The <see cref="KeyVaultSecret"/> instance.</param>
        /// <returns><code>true</code> if secrets value should be loaded, otherwise <code>false</code>.</returns>
        bool Load(SecretProperties secret);

        /// <summary>
        /// Maps secret to a configuration key.
        /// </summary>
        /// <param name="secret">The <see cref="KeyVaultSecret"/> instance.</param>
        /// <returns>Configuration key name to store secret value.</returns>
        string GetKey(KeyVaultSecret secret);
    }
}
