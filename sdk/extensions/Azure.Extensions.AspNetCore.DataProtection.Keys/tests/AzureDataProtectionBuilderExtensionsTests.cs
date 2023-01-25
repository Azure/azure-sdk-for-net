// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class AzureDataProtectionBuilderExtensionsTests
    {
        [Test]
        public void ProtectKeysWithAzureKeyVault_UsesAzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var client = new KeyVaultClient((_, _, _) => Task.FromResult(string.Empty));
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), new DefaultAzureCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_WithServiceProviderFunc_UsesAzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var client = new KeyVaultClient((_, _, _) => Task.FromResult(string.Empty));
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", sp => new DefaultAzureCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }
    }
}
