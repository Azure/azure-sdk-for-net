// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Configuration.KeyVault
{
    /// <summary>
    /// Represents Azure Key Vault secrets as an <see cref="IConfigurationSource"/>.
    /// </summary>
    internal class KeyVaultConfigurationSource : IConfigurationSource
    {
        private readonly KeyVaultConfigurationOptions _options;
        private readonly SecretClient _client;

        /// <summary>
        /// Creates a new instance of <see cref="KeyVaultConfigurationSource"/>.
        /// </summary>
        /// <param name="client">The <see cref="SecretClient"/> to use for retrieving values.</param>
        /// <param name="options">The <see cref="KeyVaultConfigurationOptions"/> to configure provider behaviors.</param>
        public KeyVaultConfigurationSource(SecretClient client, KeyVaultConfigurationOptions options)
        {
            _options = options;
            _client = client;
        }

        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new KeyVaultConfigurationProvider(_client, _options);
        }
    }
}
