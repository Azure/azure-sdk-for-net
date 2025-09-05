// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public partial class AzureDataProtectionBuilderExtensionsTests
    {
        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_KeyResolver_Throws_Exception_When_KeyResolver_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", (KeyResolver)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyResolver");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_KeyResolver_Throws_Exception_When_KeyResolver_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), (KeyResolver)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyResolver");
        }

        [Test]
        public void
            ProtectKeysWithAzureKeyVault_With_String_And_KeyResolverFunc_Throws_Exception_When_KeyResolverFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey",
                (Func<IServiceProvider, IKeyEncryptionKeyResolver>)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyResolverFactory");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_KeyResolverFunc_Throws_Exception_When_KeyResolverFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), (Func<IServiceProvider, IKeyEncryptionKeyResolver>)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyResolverFactory");
        }
    }
}
