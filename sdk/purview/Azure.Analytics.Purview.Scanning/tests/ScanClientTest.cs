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
    public class ScanClientTest : ScanClientTestBase
    {
        public ScanClientTest(bool isAsync) : base(isAsync)
        {
        }
        [RecordedTest]
        public async Task FliterOperations()
        {
            var client = GetPurviewScanClient("test-datasource1009", "test-scan1009");
            //Create
            var data = new
            {
                name = "custom",
                id = "datasources/test-datasource1009/scans/test-scan1009/filters/custom",
                properties = new
                {
                    includeUriPrefixes = new[]
                    {
                        "https://foo.file.core.windows.net/share1/user",
                        "https://foo.file.core.windows.net/share1/aggregated"
                    },
                    excludeUriPrefixes = new[]
                    {
                        "https://foo.file.core.windows.net/share1/user/temp"
                    }
                }
            };
            Response createResponse = await client.CreateOrUpdateFilterAsync(RequestContent.Create(data));
            Assert.AreEqual(200, createResponse.Status);
            //Get
            Response getResponse = await client.GetFilterAsync(new());
            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("https://foo.file.core.windows.net/share1/user/temp", fetchBodyJson.GetProperty("properties").GetProperty("excludeUriPrefixes")[0].GetString());
        }
        [RecordedTest]
        public async Task ScanRunOperations()
        {
            var client = GetPurviewScanClient("test-datasource1014", "test-scan1014");
            string runUUID = "32767c50-ccd7-c3fd-5aea-94abe54044de";
            //Run
            Response runScanResponse = await client.RunScanAsync(runUUID);
            Assert.AreEqual(202, runScanResponse.Status);
            //Get list
            var getScanRunListResponseList = client.GetRunsAsync(new()).GetAsyncEnumerator();
            await getScanRunListResponseList.MoveNextAsync();
            using var jsonDocument = JsonDocument.Parse(getScanRunListResponseList.Current);
            JsonElement getScanRunListBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(runUUID, getScanRunListBodyJson.GetProperty("id").GetString());
            //Cancel
            Response cancelScanResponse = await client.CancelScanAsync(runUUID, new());
            Assert.AreEqual(202, cancelScanResponse.Status);
        }
        [RecordedTest]
        public async Task ScanTriggerOperations()
        {
            var client = GetPurviewScanClient("test-datasource1009", "test-scan1009");
            //Create
            var data = new
            {
                name = "default",
                properties = new
                {
                    scanLevel = "Incremental",
                    recurrence = new
                    {
                        startTime = "2021-10-12T09:30:00",
                        interval = 1,
                        frequency = "Month",
                        timezone = "China Standard Time",
                        schedule = new
                        {
                            monthDays = new[]
                            {
                                1
                            }
                        }
                    }
                }
            };
            Response createResponse = await client.CreateOrUpdateTriggerAsync(RequestContent.Create(data));
            Assert.AreEqual(201, createResponse.Status);
            //Delete
            Response deleteResponse = await client.DeleteTriggerAsync();
            Assert.AreEqual(200, deleteResponse.Status);
        }
        [RecordedTest]
        public async Task ScanOperations()
        {
            string dataSourceName = "test-datasource1009";
            string scanName = "test-scan1009-2";
            var client = GetPurviewScanClient(dataSourceName, scanName);
            //Create
            var data = new
            {
                name = scanName,
                kind = "AmazonS3Credential",
                properties = new
                {
                    credential = new
                    {
                        referenceName = "test-credential1009",
                        credentialType = "AmazonARN"
                    },
                    collection = new
                    {
                        type = "CollectionReference",
                        referenceName = "dotnetllcpurviewaccount"
                    }
                }
            };
            Response createResponse = await client.CreateOrUpdateAsync(RequestContent.Create(data));
            Assert.AreEqual(201, createResponse.Status);
            //Get
            Response getResponse = await client.GetPropertiesAsync(new());
            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("datasources/test-datasource1009/scans/test-scan1009-2", getBodyJson.GetProperty("id").GetString());
            //Delete
            Response deleteResponse = await client.DeleteAsync();
            Assert.AreEqual(200, deleteResponse.Status);
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
