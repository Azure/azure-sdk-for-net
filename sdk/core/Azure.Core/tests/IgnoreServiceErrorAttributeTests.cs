// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Experimental.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [IgnoreServiceError(403, "Forbidden", Message = "Target environment attestation statement cannot be verified.")]
    public class IgnoreServiceErrorAttributeTests : RecordedTestBase
    {
        public IgnoreServiceErrorAttributeTests(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task ReleaseKeyAttestationErrorThrowsInconclusive()
        {
            MockResponse resp = new(403);
            resp.AddHeader(HttpHeader.Names.ContentType, "application/json");
            resp.SetContent(@"{""error"":{""code"":""Forbidden"",""message"":""Target environment attestation statement cannot be verified."",""innererror"":{""code"":""AccessDenied""}}}");

            PetStoreClientOptions options = new()
            {
                Transport = new MockTransport(resp),
            };

            PetStoreClient client = new(new Uri("https://example.azurepetstore.com"), new MockCredential(), options);
            await client.GetPetAsync("pet1");

            Assert.Fail("Client method did not throw expected HTTP 403");
        }

        [RecordedTest]
        [IgnoreServiceError(400, "BadParameter")]
        public async Task ExportableNotSupportedThrowsInconclusive()
        {
            MockResponse resp = new(400);
            resp.AddHeader(HttpHeader.Names.ContentType, "application/json");
            resp.SetContent(@"{""error"":{""code"":""BadParameter"",""message"":""AKV.SKR.1001: The exportable attribute is only supported with premium vaults and API version >= '7.3-preview'.""}}");

            PetStoreClientOptions options = new()
            {
                Transport = new MockTransport(resp),
            };

            PetStoreClient client = new(new Uri("https://example.azurepetstore.com"), new MockCredential(), options);
            await client.GetPetAsync("pet1");

            Assert.Fail("Client method did not throw expected HTTP 400");
        }
    }
}
