// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Catalog.Tests
{
    public class CatalogClientTest : CatalogClientTestBase
    {
        public CatalogClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task Search()
        {
            PurviewCatalogClient client = GetCatalogClient();
            var data = new
            {
                keywords = "myPurview"
            };
            Response fetchResponse = await client.SearchAsync(RequestContent.Create(data));
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.AreEqual(0, fetchBodyJson.GetProperty("@search.count").GetInt16());
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
