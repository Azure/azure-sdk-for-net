// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class AttestationMayFailAttributeTests
    {
        [Test]
        [AttestationMayFail]
        public void ReleaseKeyAttestationErrorThrowsInconclusive()
        {
            MockResponse resp = new MockResponse(403)
                .WithHeader(HttpHeader.Names.ContentType, "application/json")
                .WithContent(@"{""error"":{""code"":""Forbidden"",""message"":""Target environment attestation statement cannot be verified."",""innererror"":{""code"":""AccessDenied""}}}");

            KeyClientOptions options = new()
            {
                Transport = new MockTransport(resp),
            };

            KeyClient client = new(new("https://myvault.vault.azure.net"), new MockCredential(), options);
            client.ReleaseKey(new("name", "targetAttestationToken"));

            Assert.Fail("Client method did not throw expected HTTP 403");
        }
    }
}
