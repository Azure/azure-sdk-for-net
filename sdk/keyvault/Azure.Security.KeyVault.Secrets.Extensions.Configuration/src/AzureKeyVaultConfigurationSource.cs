// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace Azure.Security.KeyVault.Secrets.Extensions.Configuration
{
    /// <summary>
    /// Represents Azure Key Vault secrets as an <see cref="IConfigurationSource"/>.
    /// </summary>
    internal class AzureKeyVaultConfigurationSource : IConfigurationSource
    {
        private readonly AzureKeyVaultConfigurationOptions _options;

        public AzureKeyVaultConfigurationSource(AzureKeyVaultConfigurationOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AzureKeyVaultConfigurationProvider(_options.Client, _options.Manager, _options.ReloadInterval);
        }
    }
}
