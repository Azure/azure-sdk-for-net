// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Catalog.Tests
{
    public class GlossaryClientTest : GlossaryClientTestBase
    {
        public GlossaryClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetGlossaryCategory()
        {
            var client = GetGlossariesClient();
            Response fetchResponse = await client.GetGlossariesAsync();
            Assert.AreEqual(200, fetchResponse.Status);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(1, fetchBodyJson.GetArrayLength());
            JsonElement glossaryItemJson = fetchBodyJson[0];
            Assert.AreEqual("Glossary", glossaryItemJson.GetProperty("name").GetString());
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
