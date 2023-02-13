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
    public class DataSourceClientTest : DataSourceClientTestBase
    {
        public DataSourceClientTest(bool isAsync) : base(isAsync)
        {
        }
        [RecordedTest]
        public async Task DataSourceOperations()
        {
            string name = "test-datasources3";
            var client = GetPurviewDataSourceClient(name);
            var data = new
            {
                kind = "AmazonS3",
                name = name,
                properties = new
                {
                    serviceUrl = "s3://testpurview",
                    collection = new
                    {
                        type = "CollectionReference",
                        referenceName = "dotnetllcpurviewaccount"
                    }
                }
            };
            //Create
            Response createResponse = await client.CreateOrUpdateAsync(RequestContent.Create(data));
            Assert.AreEqual(201, createResponse.Status);
            //Get
            Response getResponse = await client.GetPropertiesAsync(new());
            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("datasources/test-datasources3", getBodyJson.GetProperty("id").GetString());
            //Delete
            Response deleteResponse = await client.DeleteAsync();
            Assert.AreEqual(200, deleteResponse.Status);
        }
        [RecordedTest]
        public async Task GetScans()
        {
            var client = GetPurviewDataSourceClient("test-datasource1014");
            var fetchResponseList = client.GetScansAsync(new()).GetAsyncEnumerator();
            await fetchResponseList.MoveNextAsync();
            using var jsonDocument = JsonDocument.Parse(fetchResponseList.Current);
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            await fetchResponseList.DisposeAsync();
            Assert.AreEqual("datasources/test-datasource1014/scans/test-scan1014", fetchBodyJson.GetProperty("id").GetString());
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
