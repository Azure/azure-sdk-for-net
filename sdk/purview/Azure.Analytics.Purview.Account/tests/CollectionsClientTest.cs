// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdateTask()
        {
            var options = new PurviewAccountClientOptions();
            CollectionsClient client = GetCollectionsClient();

            var collectionName = "myCollection1";
            /*var data = new
            {
                "parentCollection": new {
                    "referenceName": "myParentCollection1"
                }
            }*/
            var data = new {
                parentCollection = new {
                    referenceName = "myParentCollection1"
                },
            };
            Response createResponse = await client.CreateOrUpdateCollectionAsync(collectionName, RequestContent.Create(data), default);

            JsonElement createBodyJson = JsonDocument.Parse(GetContentFromResponse(createResponse)).RootElement;
            Assert.AreEqual("myCollection1", createBodyJson.GetProperty("name").GetString());
        }

        [Test]
        [RecordedTest]
        public async Task GetTask()
        {
            var options = new PurviewAccountClientOptions();
            CollectionsClient client = GetCollectionsClient();

            var collectionName = "myCollection1";
            /*var data = new
            {
                "parentCollection": new {
                    "referenceName": "myParentCollection1"
                }
            }*/
            var data = new
            {
                parentCollection = new
                {
                    referenceName = "myParentCollection1"
                },
            };
            Response createResponse = await client.CreateOrUpdateCollectionAsync(collectionName, RequestContent.Create(data), default);

            Response getResponse = await client.GetCollectionAsync(collectionName);
            JsonElement getBodyJson = JsonDocument.Parse(GetContentFromResponse(getResponse)).RootElement;
            Assert.AreEqual("myCollection1", getBodyJson.GetProperty("name").GetString());
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
