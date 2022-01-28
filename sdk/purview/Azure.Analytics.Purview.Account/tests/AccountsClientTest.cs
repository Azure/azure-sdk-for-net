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

namespace Azure.Analytics.Purview.Account.Tests
{
    public class AccountsClientTest : AccountsClientTestBase
    {
        public AccountsClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetTask()
        {
            PurviewAccountClient client = GetAccountClient();
            Response fetchResponse = await client.GetAccountPropertiesAsync(new());
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.AreEqual("dotnetLLCPurviewAccount", fetchBodyJson.GetProperty("name").GetString());
        }

        [RecordedTest]
        public async Task UpdateTask()
        {
            var options = new PurviewAccountClientOptions();
            PurviewAccountClient client = GetAccountClient();
            var data = new JsonData(new Dictionary<string, string>
            {
                ["friendlyName"] = "udpatedFriendlyName"
            });
            Response updateRespons = await client.UpdateAccountPropertiesAsync(RequestContent.Create(data));
            JsonElement upateBodyJson = JsonDocument.Parse(GetContentFromResponse(updateRespons)).RootElement;
            Assert.AreEqual("dotnetLLCPurviewAccount", upateBodyJson.GetProperty("name").GetString());
            Assert.AreEqual("udpatedFriendlyName", upateBodyJson.GetProperty("properties").GetProperty("friendlyName").GetString());
        }

        [RecordedTest]
        public async Task RegenerateKeysTask()
        {
            var options = new PurviewAccountClientOptions();
            PurviewAccountClient client = GetAccountClient();
            var data = new
            {
                keyType = "PrimaryAtlasKafkaKey",
            };
            Response genResponse = await client.RegenerateAccessKeyAsync(RequestContent.Create(data));
            JsonElement genKeyBodyJson = JsonDocument.Parse(GetContentFromResponse(genResponse)).RootElement;
            Assert.AreEqual(genResponse.Status, 200);
        }

        [RecordedTest]
        public async Task ListKeysTask()
        {
            var options = new PurviewAccountClientOptions();
            PurviewAccountClient client = GetAccountClient();
            var data = new JsonData(new Dictionary<string, string>
            {
                ["keyType"] = "PrimaryAtlasKafkaKey"
            });
            Response genResponse = await client.RegenerateAccessKeyAsync(RequestContent.Create(data));
            JsonElement genKeyBodyJson = JsonDocument.Parse(GetContentFromResponse(genResponse)).RootElement;
            Assert.AreEqual(genResponse.Status, 200);
            Response listKeysResponse = await client.GetAccessKeysAsync(new());
            JsonElement listKeyBodyJson = JsonDocument.Parse(GetContentFromResponse(listKeysResponse)).RootElement;
            Assert.AreEqual(listKeysResponse.Status, 200);
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
