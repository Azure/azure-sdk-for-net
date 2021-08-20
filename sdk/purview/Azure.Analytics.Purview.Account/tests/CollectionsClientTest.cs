// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Text.Json;
using Azure.Core;
using System.IO;

namespace Azure.Analytics.Purview.Account.Tests
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
            CollectionsClient client = GetCollectionsClient();

            var collectionName = "mysubCollection";
            var data = new
            {
                parentCollection = new
                {
                    referenceName = "dotnetLLCPurviewAccount"
                },
            };
            Response createResponse = await client.CreateOrUpdateCollectionAsync(collectionName, RequestContent.Create(data), default);

            JsonElement createBodyJson = JsonDocument.Parse(GetContentFromResponse(createResponse)).RootElement;
            Assert.AreEqual("mysubCollection", createBodyJson.GetProperty("name").GetString());
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Response getResponse = await client.GetCollectionAsync(collectionName);
                JsonElement getBodyJson = JsonDocument.Parse(GetContentFromResponse(getResponse)).RootElement;
                if (getBodyJson.GetProperty("collectionProvisioningState").GetString() == "Succeeded")
                    break;
            }
            Response delRespons = await client.DeleteCollectionAsync(collectionName, default);
        }

        [RecordedTest]
        public async Task GetTask()
        {
            var options = new PurviewAccountClientOptions();
            CollectionsClient client = GetCollectionsClient();

            var collectionName = "myCollection1";
            var data = new
            {
                parentCollection = new
                {
                    referenceName = "dotnetLLCPurviewAccount"
                },
            };
            Response createResponse = await client.CreateOrUpdateCollectionAsync(collectionName, RequestContent.Create(data), default);
            Response getResponse = await client.GetCollectionAsync(collectionName);
            JsonElement getBodyJson = JsonDocument.Parse(GetContentFromResponse(getResponse)).RootElement;
            Assert.AreEqual("myCollection1", getBodyJson.GetProperty("name").GetString());
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Response getRes = await client.GetCollectionAsync(collectionName);
                JsonElement getJson = JsonDocument.Parse(GetContentFromResponse(getRes)).RootElement;
                if (getJson.GetProperty("collectionProvisioningState").GetString() == "Succeeded")
                    break;
            }
            Response delRespons = await client.DeleteCollectionAsync(collectionName, default);
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
