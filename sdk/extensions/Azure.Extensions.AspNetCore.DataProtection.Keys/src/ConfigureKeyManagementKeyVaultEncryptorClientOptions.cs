// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys
{
    internal sealed class ConfigureKeyManagementKeyVaultEncryptorClientOptions : IConfigureOptions<KeyManagementOptions>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConfigureKeyManagementKeyVaultEncryptorClientOptions(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Configure(KeyManagementOptions options)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var provider = scope.ServiceProvider;

            options.XmlEncryptor = provider.GetRequiredService<AzureKeyVaultXmlEncryptor>();
        }
    }
}
