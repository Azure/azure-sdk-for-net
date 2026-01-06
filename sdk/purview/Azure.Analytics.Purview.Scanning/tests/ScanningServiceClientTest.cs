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
            Assert.That(fetchBodyJson.GetProperty("scanRulesetType").GetString(), Is.EqualTo("System"));
        }
        [RecordedTest]
        public async Task SystemRulesetsDataSourceOperations()
        {
            //Get with type
            PurviewScanningServiceClient client = GetScanningClient();
            Response fetchWithTypeResponse = await client.GetSystemRulesetsForDataSourceAsync("AzureFileService", new());
            Assert.That(fetchWithTypeResponse.Status, Is.EqualTo(200));
            using var jsonDocumentWithType = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeResponse));
            JsonElement fetchWithTypeBodyJson = jsonDocumentWithType.RootElement;
            Assert.That(fetchWithTypeBodyJson.GetProperty("id").GetString(), Is.EqualTo("systemscanrulesets/AzureFileService"));
            //Get with type and version
            Response fetchWithTypeVersionResponse = await client.GetSystemRulesetsForVersionAsync(1, "AzureFileService", new());
            Assert.That(fetchWithTypeVersionResponse.Status, Is.EqualTo(200));
            using var jsonDocumentWithTypeVersion = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeVersionResponse));
            JsonElement fetchWithTypeVersionBodyJson = jsonDocumentWithTypeVersion.RootElement;
            Assert.That(fetchWithTypeVersionBodyJson.GetProperty("id").GetString(), Is.EqualTo("systemscanrulesets/AzureFileService"));
            //Get with type for latest version
            Response fetchWithTypeLatestVerResponse = await client.GetLatestSystemRulesetsAsync("AzureFileService", new());
            Assert.That(fetchWithTypeLatestVerResponse.Status, Is.EqualTo(200));
            using var jsonDocumentWithTypeLatestVer = JsonDocument.Parse(GetContentFromResponse(fetchWithTypeLatestVerResponse));
            JsonElement fetchWithTypeLatestVerBodyJson = jsonDocumentWithTypeLatestVer.RootElement;
            Assert.That(fetchWithTypeLatestVerBodyJson.GetProperty("id").GetString(), Is.EqualTo("systemscanrulesets/AzureFileService"));
            //Get with type for list of versions
            var fetchWithTypeforListResponseList = client.GetSystemRulesetsVersionsAsync("AzureFileService", new()).GetAsyncEnumerator();
            await fetchWithTypeforListResponseList.MoveNextAsync();
            using var jsonDocumentWithTypeForList = JsonDocument.Parse(fetchWithTypeforListResponseList.Current);
            JsonElement fetchWithTypeforListBodyJson = jsonDocumentWithTypeForList.RootElement;
            await fetchWithTypeforListResponseList.DisposeAsync();
            Assert.That(fetchWithTypeforListBodyJson.GetProperty("kind").GetString(), Is.EqualTo("AzureFileService"));
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
            Assert.That(createResponse.Status, Is.EqualTo(200));
            //Get
            Response getResponse = await client.GetKeyVaultReferenceAsync("default-keyvault", new());
            Assert.That(getResponse.Status, Is.EqualTo(200));
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.That(getBodyJson.GetProperty("properties").GetProperty("baseUrl").GetString(), Is.EqualTo("https://test-keyvault0908.vault.azure.net/"));
            //Delete
            Response deleteResponse = await client.DeleteKeyVaultReferenceAsync("default-keyvault", new());
            Assert.That(deleteResponse.Status, Is.EqualTo(200));
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
            Assert.That(fetchBodyJson.GetProperty("id").GetString(), Is.EqualTo("classificationrules/test_rule1008"));
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
            Assert.That(fetchBodyJson.GetProperty("id").GetString(), Is.EqualTo("datasources/test-source1008"));
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
            Assert.That(createReponse.Status, Is.EqualTo(201));
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
            Assert.That(updateReponse.Status, Is.EqualTo(200));
            //Get
            Response getResponse = await client.GetScanRulesetAsync("test-scanrule1008", new());
            Assert.That(getResponse.Status, Is.EqualTo(200));
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.That(getBodyJson.GetProperty("id").GetString(), Is.EqualTo("scanrulesets/test-scanrule1008"));
            //delete
            Response deleteResponse = await client.DeleteScanRulesetAsync("test-scanrule1008", new());
            Assert.That(deleteResponse.Status, Is.EqualTo(200));
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
