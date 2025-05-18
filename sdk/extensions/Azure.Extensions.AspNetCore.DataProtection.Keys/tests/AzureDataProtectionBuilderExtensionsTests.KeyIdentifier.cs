// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public partial class AzureDataProtectionBuilderExtensionsTests
    {
        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_Credential_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((string)null, new MockCredential());

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_Credential_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((Uri)null, new MockCredential());

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_CredentialFunc_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((string)null, _ => new MockCredential());

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_KeyResolver_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((Uri)null, new KeyResolver(new MockCredential()));

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_KeyResolver_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((string)null, new KeyResolver(new MockCredential()));

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_CredentialFunc_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((Uri)null, _ => new MockCredential());

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_FuncString_And_CredentialFunc_Throws_Exception_When_KeyIdentifierFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((Func<IServiceProvider, string>)null, _ => new MockCredential());

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifierFactory");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_FuncUri_And_CredentialFunc_Throws_Exception_When_KeyIdentifierFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((Func<IServiceProvider, Uri>)null, _ => new MockCredential());

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifierFactory");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_KeyResolverFunc_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((string)null, _ => new KeyResolver(new MockCredential()));

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_KeyResolverFunc_Throws_Exception_When_KeyIdentifier_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault((Uri)null, _ => new KeyResolver(new MockCredential()));

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "keyIdentifier");
        }
    }
}
