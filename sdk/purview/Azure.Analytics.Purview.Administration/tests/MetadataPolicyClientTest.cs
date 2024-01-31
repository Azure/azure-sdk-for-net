// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Text.Json;
using System.IO;

namespace Azure.Analytics.Purview.Administration.Tests
{
    public class MetadataPolicyClientTest : MetadataPolicyClientTestBase
    {
        public MetadataPolicyClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetMetadataPolicy()
        {
            var client = GetMetadataPolicyClient("dotnetllcpurviewaccount");
            Response fetchResponse = await client.GetMetadataPolicyAsync("d04a7fad-ff6c-44f4-8fb4-0d007a8c01f8", new());
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("policy_dotnetLLCPurviewAccount", fetchBodyJson.GetProperty("name").GetString());
            Assert.GreaterOrEqual(fetchBodyJson.GetProperty("properties").GetProperty("attributeRules").GetArrayLength(),1);
        }

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
    }
}
