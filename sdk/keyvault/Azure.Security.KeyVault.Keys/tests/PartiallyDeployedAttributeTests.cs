// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class PartiallyDeployedAttributeTests
    {
        [Test]
        [PartiallyDeployed]
        public void ExportableNotSupportedThrowsInconclusive()
        {
            MockResponse resp = new MockResponse(400)
                .WithHeader(HttpHeader.Names.ContentType, "application/json")
                .WithContent(@"{""error"":{""code"":""BadParameter"",""message"":""AKV.SKR.1001: The exportable attribute is only supported with premium vaults and API version >= '7.3-preview'.""}}");

            KeyClientOptions options = new()
            {
                Transport = new MockTransport(resp),
            };

            KeyClient client = new(new("https://myvault.vault.azure.net"), new MockCredential(), options);
            client.CreateRsaKey(new("test-key")
            {
                Exportable = true,
                KeySize = 2048,
            });

            Assert.Fail("Client method did not throw expected HTTP 400");
        }
    }
}
