// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class AzureDataProtectionBuilderExtensionsTests
    {
        [Test]
        public void PersistKeysToAzureBlobStorage_UsesAzureBlobXmlRepository()
        {
            // Arrange
            var client = new BlobClient(new Uri("http://www.example.com"));
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.PersistKeysToAzureBlobStorage(client);
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureBlobXmlRepository>(options.Value.XmlRepository);
        }

        [Test]
        public void PersistKeysToAzureBlobStorage_WithServiceProviderFunc_UsesAzureBlobXmlRepository()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.PersistKeysToAzureBlobStorage(sp => new BlobClient(new Uri("http://www.example.com")));
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureBlobXmlRepository>(options.Value.XmlRepository);
        }
    }
}
