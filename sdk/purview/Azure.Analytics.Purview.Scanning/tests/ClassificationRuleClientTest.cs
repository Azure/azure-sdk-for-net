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
    public class ClassificationRuleClientTest : ClassificationRuleClientTestBase
    {
        public ClassificationRuleClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ClassificationRuleOperations()
        {
            //Create
            string name = "test_classificationrule1009";
            var client = GetClassificationRuleClient(name);
            var data = new
            {
                name = name,
                kind = "Custom",
                properties = new
                {
                    description = "test-description1009",
                    classificationName = "test_classification1009",
                    columnPatterns = new[]
                    {
                        new { pattern = "classid", kind = "Regex" },
                        new { pattern = "part_name", kind = "Regex" },
                        new { pattern = "price", kind = "Regex" }
                    }
                },
                ruleStatus = "Enabled"
            };
            Response createResponse = await client.CreateOrUpdateAsync(RequestContent.Create(data));
            Assert.AreEqual(201, createResponse.Status);
            //Update (version 2 will be generated)
            data = new
            {
                name = name,
                kind = "Custom",
                properties = new
                {
                    description = "test-description1009-updated",
                    classificationName = "test_classification1009",
                    columnPatterns = new[]
                    {
                        new { pattern = "classid", kind = "Regex" },
                        new { pattern = "part_name", kind = "Regex" },
                        new { pattern = "price", kind = "Regex" }
                    }
                },
                ruleStatus = "Enabled"
            };
            Response updateResponse = await client.CreateOrUpdateAsync(RequestContent.Create(data));
            Assert.AreEqual(200, updateResponse.Status);
            //Get
            Response getResponse = await client.GetPropertiesAsync(new());
            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocumentGet.RootElement;
            Assert.AreEqual("test-description1009-updated", getBodyJson.GetProperty("properties").GetProperty("description").GetString());
            //Get Version
            var getVersionResponseList = client.GetVersionsAsync(new()).GetAsyncEnumerator();
            await getVersionResponseList.MoveNextAsync();
            using var jsonDocumentVersionList = JsonDocument.Parse(getVersionResponseList.Current);
            JsonElement getVersionBodyJson = jsonDocumentVersionList.RootElement;
            Assert.AreEqual("test-description1009", getVersionBodyJson.GetProperty("properties").GetProperty("description").GetString());
            await getVersionResponseList.MoveNextAsync();
            using var jsonDocumentVersionListNext = JsonDocument.Parse(getVersionResponseList.Current);
            JsonElement getSecondVersionBodyJson = jsonDocumentVersionListNext.RootElement;
            await getVersionResponseList.DisposeAsync();
            Assert.AreEqual("test-description1009-updated", getSecondVersionBodyJson.GetProperty("properties").GetProperty("description").GetString());
            //Tag Version
            Response TagVersionResponse = await client.TagVersionAsync(2, "Keep", new());
            Assert.AreEqual(202, TagVersionResponse.Status);
            //Delete
            Response deleteresponse = await client.DeleteAsync();
            Assert.AreEqual(200, deleteresponse.Status);
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
