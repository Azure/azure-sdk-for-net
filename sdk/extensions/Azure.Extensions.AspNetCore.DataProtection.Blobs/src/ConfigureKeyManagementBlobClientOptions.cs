// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs
{
    internal sealed class ConfigureKeyManagementBlobClientOptions : IConfigureOptions<KeyManagementOptions>
    {
        private readonly AzureBlobXmlRepository _azureBlobXmlRepository;

        public ConfigureKeyManagementBlobClientOptions(AzureBlobXmlRepository azureBlobXmlRepository)
        {
            _azureBlobXmlRepository = azureBlobXmlRepository;
        }

        public void Configure(KeyManagementOptions options)
        {
            options.XmlRepository = _azureBlobXmlRepository;
        }
    }
}
