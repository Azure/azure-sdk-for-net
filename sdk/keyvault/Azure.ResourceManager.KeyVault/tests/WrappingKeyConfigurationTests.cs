// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.KeyVault.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    public class WrappingKeyConfigurationTests
    {
        [Test]
        public void ConstructorUsesServiceIdentityForSerialization()
        {
            var configuration = new WrappingKeyConfiguration(
                new WrappingKeyValue(new Uri("https://example.managedhsm.azure.net/keys/protection-key")));

            Assert.AreEqual("ServiceIdentity", configuration.KeyAuthenticationDataAuthType);

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(configuration, ModelReaderWriterOptions.Json));
            Assert.AreEqual(
                "ServiceIdentity",
                document.RootElement.GetProperty("keyAuthenticationData").GetProperty("authType").GetString());
        }
    }
}
