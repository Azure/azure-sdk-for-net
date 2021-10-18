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
            Response fetchResponse = await client.GetMetadataRolesAsync();
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.GreaterOrEqual(fetchBodyJson.GetProperty("values").GetArrayLength(),1);
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
