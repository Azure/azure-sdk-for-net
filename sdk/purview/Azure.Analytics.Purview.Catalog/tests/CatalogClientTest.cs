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
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(0, fetchBodyJson.GetProperty("@search.count").GetInt16());
        }

        [RecordedTest]
        public async Task Suggest()
        {
            PurviewCatalogClient client = GetCatalogClient();
            var data = new
            {
                keywords = "sampledata.csv",
            };
            Response fetchResponse = await client.SuggestAsync(RequestContent.Create(data));
            Assert.AreEqual(fetchResponse.Status, 200);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("s3://testpurview/sampledata.csv", fetchBodyJson.GetProperty("value")[0].GetProperty("qualifiedName").GetString());
        }

        [RecordedTest]
        public async Task AutoComplete()
        {
            PurviewCatalogClient client = GetCatalogClient();
            var data = new
            {
                keywords = "sampledata",
            };
            Response fetchResponse = await client.AutoCompleteAsync(RequestContent.Create(data));
            Assert.AreEqual(fetchResponse.Status, 200);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("sampledata csv", fetchBodyJson.GetProperty("value")[0].GetProperty("queryPlusText").GetString());
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
