// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys
{
    internal sealed class ConfigureKeyManagementKeyVaultEncryptorClientOptions : IConfigureOptions<KeyManagementOptions>
    {
        private readonly AzureKeyVaultXmlEncryptor _azureKeyVaultXmlEncryptor;

        public ConfigureKeyManagementKeyVaultEncryptorClientOptions(AzureKeyVaultXmlEncryptor azureKeyVaultXmlEncryptor)
        {
            _azureKeyVaultXmlEncryptor = azureKeyVaultXmlEncryptor;
        }

        public void Configure(KeyManagementOptions options)
        {
            options.XmlEncryptor = _azureKeyVaultXmlEncryptor;
        }
    }
}
