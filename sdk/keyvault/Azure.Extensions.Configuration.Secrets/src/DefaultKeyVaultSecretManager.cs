// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.Configuration.Secrets
{
    /// <summary>
    /// Default implementation of <see cref="IKeyVaultSecretManager"/> that loads all secrets
    /// and replaces '--' with ':" in key names.
    /// </summary>
    public class DefaultKeyVaultSecretManager : IKeyVaultSecretManager
    {
        internal static IKeyVaultSecretManager Instance { get; } = new DefaultKeyVaultSecretManager();

        /// <inheritdoc />
        public virtual string GetKey(KeyVaultSecret secret)
        {
            return secret.Name.Replace("--", ConfigurationPath.KeyDelimiter);
        }

        /// <inheritdoc />
        public virtual bool Load(SecretProperties secret)
        {
            return true;
        }
    }
}
