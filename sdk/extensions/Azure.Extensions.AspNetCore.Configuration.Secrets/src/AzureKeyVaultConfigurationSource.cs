// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    /// <summary>
    /// Represents Azure Key Vault secrets as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class AzureKeyVaultConfigurationSource : IConfigurationSource
    {
        private readonly AzureKeyVaultConfigurationOptions _options;
        private readonly SecretClient _client;

        /// <summary>
        /// Creates a new instance of <see cref="AzureKeyVaultConfigurationSource"/>.
        /// </summary>
        /// <param name="client">The <see cref="SecretClient"/> to use for retrieving values.</param>
        /// <param name="options">The <see cref="AzureKeyVaultConfigurationOptions"/> to configure provider behaviors.</param>
        public AzureKeyVaultConfigurationSource(SecretClient client, AzureKeyVaultConfigurationOptions options)
        {
            _options = options;
            _client = client;
        }

        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AzureKeyVaultConfigurationProvider(_client, _options);
        }
    }
}
