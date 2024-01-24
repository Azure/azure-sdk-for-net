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
    public class MetadataRolesClientTest : MetadataRolesClientTestBase
    {
        public MetadataRolesClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task List()
        {
            var client = GetMetadataPolicyClient();
            AsyncPageable<BinaryData> fetchResponse = client.GetMetadataRolesAsync(new());
            await foreach (BinaryData item in fetchResponse)
            {
                using var jsonDocument = JsonDocument.Parse(item);
                JsonElement fetchBodyJson = jsonDocument.RootElement;
                Assert.AreEqual(fetchBodyJson.GetProperty("id").ToString().StartsWith("purviewmetadatarole"), true);
            }
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
