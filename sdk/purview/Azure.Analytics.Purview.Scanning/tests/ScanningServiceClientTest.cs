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
            Response fetchResponse = await client.GetSystemRulesetsAsync();
            Assert.AreEqual(200, fetchResponse.Status);
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.IsTrue(fetchBodyJson.TryGetProperty("value", out JsonElement rulesListJson));
            Assert.Greater(rulesListJson.GetArrayLength(), 1);
        }
        [RecordedTest]
        public async Task SystemRulesetsDataSourceOperations()
        {
            //Get with type
            PurviewScanningServiceClient client = GetScanningClient();
            Response fetchWithTypeResponse = await client.GetSystemRulesetsForDataSourceAsync("AzureFileService");
            Assert.AreEqual(200, fetchWithTypeResponse.Status);
            JsonElement fetchWithTypeBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeResponse)).RootElement;
            Assert.AreEqual("systemscanrulesets/AzureFileService", fetchWithTypeBodyJson.GetProperty("id").GetString());
            //Get with type and version
            Response fetchWithTypeVersionResponse = await client.GetSystemRulesetsForVersionAsync(1,"AzureFileService");
            Assert.AreEqual(200, fetchWithTypeVersionResponse.Status);
            JsonElement fetchWithTypeVersionBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeVersionResponse)).RootElement;
            Assert.AreEqual("systemscanrulesets/AzureFileService", fetchWithTypeVersionBodyJson.GetProperty("id").GetString());
            //Get with type for latest version
            Response fetchWithTypeLatestVerResponse = await client.GetLatestSystemRulesetsAsync("AzureFileService");
            Assert.AreEqual(200, fetchWithTypeLatestVerResponse.Status);
            JsonElement fetchWithTypeLatestVerBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeLatestVerResponse)).RootElement;
            Assert.AreEqual("systemscanrulesets/AzureFileService", fetchWithTypeLatestVerBodyJson.GetProperty("id").GetString());
            //Get with type for list of versions
            Response fetchWithTypeforListResponse = await client.GetSystemRulesetsVersionsAsync("AzureFileService");
            Assert.AreEqual(200, fetchWithTypeforListResponse.Status);
            JsonElement fetchWithTypeforListBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeforListResponse)).RootElement;
            Assert.AreEqual(1, fetchWithTypeforListBodyJson.GetProperty("count").GetInt32());
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
            Response createResponse = await client.CreateOrUpdateKeyVaultReferenceAsync("default-keyvault",RequestContent.Create(data));
            Assert.AreEqual(200, createResponse.Status);
            //Get
            Response getResponse = await client.GetKeyVaultReferenceAsync("default-keyvault");
            Assert.AreEqual(200, getResponse.Status);
            JsonElement getBodyJson = JsonDocument.Parse(GetContentFromResponse(getResponse)).RootElement;
            Assert.AreEqual("https://test-keyvault0908.vault.azure.net/", getBodyJson.GetProperty("properties").GetProperty("baseUrl").GetString());
            //Delete
            Response deleteResponse = await client.DeleteKeyVaultReferenceAsync("default-keyvault");
            Assert.AreEqual(200, deleteResponse.Status);
        }
        [RecordedTest]
        public async Task GetClassificationRules()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            //Get
            Response fetchResponse = await client.GetClassificationRulesAsync();
            Assert.AreEqual(200, fetchResponse.Status);
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.AreEqual("classificationrules/test_rule1008", fetchBodyJson.GetProperty("value")[0].GetProperty("id").GetString());
        }
        [RecordedTest]
        public async Task GetDataSources()
        {
            PurviewScanningServiceClient client = GetScanningClient();
            Response fetchResponse = await client.GetDataSourcesAsync();
            Assert.AreEqual(200, fetchResponse.Status);
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.AreEqual("datasources/test-source1008", fetchBodyJson.GetProperty("value")[0].GetProperty("id").GetString());
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
            Response createReponse = await client.CreateOrUpdateScanRulesetAsync("test-scanrule1008",RequestContent.Create(data));
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
            Response updateReponse = await client.CreateOrUpdateScanRulesetAsync("test-scanrule1008", RequestContent.Create(updateData));
            Assert.AreEqual(200, updateReponse.Status);
            //Get
            Response getResponse = await client.GetClassificationRulesAsync();
            Assert.AreEqual(200, getResponse.Status);
            JsonElement getBodyJson = JsonDocument.Parse(GetContentFromResponse(getResponse)).RootElement;
            Assert.AreEqual("classificationrules/test_rule1008", getBodyJson.GetProperty("value")[0].GetProperty("id").GetString());
            //delete
            Response deleteResponse = await client.DeleteScanRulesetAsync("test-scanrule1008");
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
