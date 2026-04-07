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
        public async Task GetSystemRulesets()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            var fetchResponseList = client.GetSystemRulesetsAsync(new()).GetAsyncEnumerator();
            await fetchResponseList.MoveNextAsync();
            using var jsonDocument = JsonDocument.Parse(fetchResponseList.Current);
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            await fetchResponseList.DisposeAsync();
            Assert.AreEqual("System", fetchBodyJson.GetProperty("scanRulesetType").GetString());
        }
        [RecordedTest]
        public async Task SystemRulesetsDataSourceOperations()
        {
            //Get with type
            PurviewScanningServiceClient client = GetScanningClient();
            Response fetchWithTypeResponse = await client.GetSystemRulesetsForDataSourceAsync("AzureFileService", new());
            Assert.AreEqual(200, fetchWithTypeResponse.Status);
            using var jsonDocumentWithType = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeResponse));
            JsonElement fetchWithTypeBodyJson = jsonDocumentWithType.RootElement;
            Assert.AreEqual("systemscanrulesets/AzureFileService", fetchWithTypeBodyJson.GetProperty("id").GetString());
            //Get with type and version
            Response fetchWithTypeVersionResponse = await client.GetSystemRulesetsForVersionAsync(1, "AzureFileService", new());
            Assert.AreEqual(200, fetchWithTypeVersionResponse.Status);
            using var jsonDocumentWithTypeVersion = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeVersionResponse));
            JsonElement fetchWithTypeVersionBodyJson = jsonDocumentWithTypeVersion.RootElement;
            Assert.AreEqual("systemscanrulesets/AzureFileService", fetchWithTypeVersionBodyJson.GetProperty("id").GetString());
            //Get with type for latest version
            Response fetchWithTypeLatestVerResponse = await client.GetLatestSystemRulesetsAsync("AzureFileService", new());
            Assert.AreEqual(200, fetchWithTypeLatestVerResponse.Status);
            using var jsonDocumentWithTypeLatestVer = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeLatestVerResponse));
            JsonElement fetchWithTypeLatestVerBodyJson = jsonDocumentWithTypeLatestVer.RootElement;
            Assert.AreEqual("systemscanrulesets/AzureFileService", fetchWithTypeLatestVerBodyJson.GetProperty("id").GetString());
            //Get with type for list of versions
            var fetchWithTypeforListResponseList = client.GetSystemRulesetsVersionsAsync("AzureFileService", new()).GetAsyncEnumerator();
            await fetchWithTypeforListResponseList.MoveNextAsync();
            using var jsonDocumentWithTypeForList = JsonDocument.Parse(fetchWithTypeforListResponseList.Current);
            JsonElement fetchWithTypeforListBodyJson = jsonDocumentWithTypeForList.RootElement;
            await fetchWithTypeforListResponseList.DisposeAsync();
            Assert.AreEqual("AzureFileService", fetchWithTypeforListBodyJson.GetProperty("kind").GetString());
        }
        [RecordedTest]
        public async Task KeyVaultReferenceOperations()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            //Create
            var data = new
            {
                name = "test-keyvault0908",
                properties = new
                {
                    baseurl = "https://test-keyvault0908.vault.azure.net/",
                    description = "test"
                }
            };
            Response createResponse = await client.CreateOrUpdateKeyVaultReferenceAsync("default-keyvault", RequestContent.Create(data));
            Assert.AreEqual(200, createResponse.Status);
            //Get
            Response getResponse = await client.GetKeyVaultReferenceAsync("default-keyvault", new());
            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("https://test-keyvault0908.vault.azure.net/", getBodyJson.GetProperty("properties").GetProperty("baseUrl").GetString());
            //Delete
            Response deleteResponse = await client.DeleteKeyVaultReferenceAsync("default-keyvault", new());
            Assert.AreEqual(200, deleteResponse.Status);
        }
        [RecordedTest]
        public async Task GetClassificationRules()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            //Get
            var fetchResponseList = client.GetClassificationRulesAsync(new()).GetAsyncEnumerator();
            await fetchResponseList.MoveNextAsync();
            using var jsonDocument = JsonDocument.Parse(fetchResponseList.Current);
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            await fetchResponseList.DisposeAsync();
            Assert.AreEqual("classificationrules/test_rule1008", fetchBodyJson.GetProperty("id").GetString());
        }
        [RecordedTest]
        public async Task GetDataSources()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            var fetchResponseList = client.GetDataSourcesAsync(new()).GetAsyncEnumerator();
            await fetchResponseList.MoveNextAsync();
            using var jsonDocument = JsonDocument.Parse(fetchResponseList.Current);
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            await fetchResponseList.DisposeAsync();
            Assert.AreEqual("datasources/test-source1008", fetchBodyJson.GetProperty("id").GetString());
        }
        [RecordedTest]
        public async Task ScanRulesOperations()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            //Create
            var data = new
            {
                name = "test-scanrule1008",
                kind = "AmazonS3",
                properties = new
                {
                    scanningRule = new { fileExtensions = new string[] { "CSV" } },
                    excludedSystemClassifications = new string[] { "MICROSOFT.GOVERNMENT.US.ZIP_CODE" },
                    includedCustomClassificationRuleNames = new string[] { "test_rule1008" }
                }
            };
            Response createReponse = await client.CreateOrUpdateScanRulesetAsync("test-scanrule1008", RequestContent.Create(data), new());
            Assert.AreEqual(201, createReponse.Status);
            //Update
            var updateData = new
            {
                name = "test-scanrule1008",
                kind = "AmazonS3",
                properties = new
                {
                    scanningRule = new { fileExtensions = new string[] { "CSV" } },
                    description = "test-description"
                }
            };
            Response updateReponse = await client.CreateOrUpdateScanRulesetAsync("test-scanrule1008", RequestContent.Create(updateData), new());
            Assert.AreEqual(200, updateReponse.Status);
            //Get
            Response getResponse = await client.GetScanRulesetAsync("test-scanrule1008", new());
            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("scanrulesets/test-scanrule1008", getBodyJson.GetProperty("id").GetString());
            //delete
            Response deleteResponse = await client.DeleteScanRulesetAsync("test-scanrule1008", new());
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
