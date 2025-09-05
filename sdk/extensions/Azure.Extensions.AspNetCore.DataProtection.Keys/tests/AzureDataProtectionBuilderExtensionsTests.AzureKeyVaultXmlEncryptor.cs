// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public partial class AzureDataProtectionBuilderExtensionsTests
    {
        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_Credential_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", new MockCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_Credential_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), new MockCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_CredentialFunc_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", _ => new MockCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_KeyResolver_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), new KeyResolver(new MockCredential()));
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_KeyResolver_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", new KeyResolver(new MockCredential()));
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_CredentialFunc_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), _ => new MockCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_FuncString_And_CredentialFunc_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(_ => "http://www.example.com/dummyKey", _ => new MockCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_FuncUri_And_CredentialFunc_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(_ => new Uri("http://www.example.com/dummyKey"), _ => new MockCredential());
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_KeyResolverFunc_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", _ => new KeyResolver(new MockCredential()));
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_KeyResolverFunc_Uses_AzureKeyVaultXmlEncryptor()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), _ => new KeyResolver(new MockCredential()));
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsInstanceOf<AzureKeyVaultXmlEncryptor>(options.Value.XmlEncryptor);
        }
    }
}
