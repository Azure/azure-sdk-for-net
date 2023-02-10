// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Text.Json;
using Azure.Core;
using System.IO;

namespace Azure.Analytics.Purview.Administration.Tests
{
    public class CollectionsClientTest: CollectionsClientTestBase
    {
        public CollectionsClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateOrUpdateTask()
        {
            var options = new PurviewAccountClientOptions();
            var collectionName = "mysubCollection";
            PurviewCollection client = GetCollectionsClient(collectionName);

            var data = new
            {
                parentCollection = new
                {
                    referenceName = "dotnetLLCPurviewAccount"
                },
            };
            Response createResponse = await client.CreateOrUpdateCollectionAsync(RequestContent.Create(data), default);

            using var jsonDocumentCreate = JsonDocument.Parse(GetContentFromResponse(createResponse));
            JsonElement createBodyJson = jsonDocumentCreate.RootElement;
            Assert.AreEqual("mysubCollection", createBodyJson.GetProperty("name").GetString());
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Response getResponse = await client.GetCollectionAsync(new());
                using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(getResponse));
                JsonElement getBodyJson = jsonDocumentGet.RootElement;
                if (getBodyJson.GetProperty("collectionProvisioningState").GetString() == "Succeeded")
                    break;
            }
            Response delRespons = await client.DeleteCollectionAsync(default);
        }

        [RecordedTest]
        public async Task GetTask()
        {
            var options = new PurviewAccountClientOptions();
            var collectionName = "myCollection1";
            PurviewCollection client = GetCollectionsClient(collectionName);

            var data = new
            {
                parentCollection = new
                {
                    referenceName = "dotnetLLCPurviewAccount"
                },
            };
            Response createResponse = await client.CreateOrUpdateCollectionAsync(RequestContent.Create(data), default);
            Response getResponse = await client.GetCollectionAsync(new());
            using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocumentGet.RootElement;
            Assert.AreEqual("myCollection1", getBodyJson.GetProperty("name").GetString());
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Response getRes = await client.GetCollectionAsync(new());
                using var jsonDocumentGetRes = JsonDocument.Parse(GetContentFromResponse(getRes));
                JsonElement getJson = jsonDocumentGetRes.RootElement;
                if (getJson.GetProperty("collectionProvisioningState").GetString() == "Succeeded")
                    break;
            }
            Response delRespons = await client.DeleteCollectionAsync(default);
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
