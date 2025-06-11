// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public partial class AzureDataProtectionBuilderExtensionsTests
    {
        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_Credential_Throws_Exception_When_Credential_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", (TokenCredential)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "tokenCredential");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_Credential_Throws_Exception_When_Credential_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), (TokenCredential)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "tokenCredential");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_String_And_CredentialFunc_Throws_Exception_When_CredentialFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault("http://www.example.com/dummyKey", (Func<IServiceProvider, TokenCredential>)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "tokenCredentialFactory");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_Uri_And_CredentialFunc_Throws_Exception_When_CredentialFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault(new Uri("http://www.example.com/dummyKey"), (Func<IServiceProvider, TokenCredential>)null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "tokenCredentialFactory");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_FuncString_And_CredentialFunc_Throws_Exception_When_CredentialFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault(_ => "http://www.example.com/dummyKey", null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "tokenCredentialFactory");
        }

        [Test]
        public void ProtectKeysWithAzureKeyVault_With_FuncUri_And_CredentialFunc_Throws_Exception_When_CredentialFactory_Is_Null()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            TestDelegate action = () => builder.ProtectKeysWithAzureKeyVault(_ => new Uri("http://www.example.com/dummyKey"), null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.NotNull(ex);
            Assert.AreEqual(ex.ParamName, "tokenCredentialFactory");
        }
    }
}
