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

namespace Azure.Analytics.Purview.Scanning.Tests
{
    public class ScanningServiceClientTest : ScanningServiceClientTestBase
    {
        public ScanningServiceClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListSystemRulesets()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            Response fetchResponse = await client.GetSystemRulesetsAsync();
            Assert.AreEqual(200, fetchResponse.Status);
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.IsTrue(fetchBodyJson.TryGetProperty("value", out JsonElement rulesListJson));
            Assert.Greater(rulesListJson.GetArrayLength(), 1);
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
