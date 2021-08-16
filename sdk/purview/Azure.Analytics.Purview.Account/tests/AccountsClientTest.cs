// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Account.Tests
{
    public class AccountsClientTest:AccountsClientTestBase
    {
        public AccountsClientTest(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        public async Task GetTask()
        {
            //TokenCredential credential, Uri endpoint = null, PurviewAccountClientOptions options = null
            var options = new PurviewAccountClientOptions();
            AccountsClient client = GetAccountsClient();
            Response fetchResponse = await client.GetAsync();
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;
            Assert.AreEqual("ycllcPurviewAccount", fetchBodyJson.GetProperty("name").GetString());
        }

        [Test]
        [RecordedTest]
        public async Task UpdateTask()
        {
            var options = new PurviewAccountClientOptions();
            AccountsClient client = GetAccountsClient();
            var data = new JsonData(new Dictionary<string, string>
            {
                ["friendlyName"] = "udpatedFriendlyName"
            });
            Response updateRespons = await client.UpdateAsync(RequestContent.Create(data));
            JsonElement upateBodyJson = JsonDocument.Parse(GetContentFromResponse(updateRespons)).RootElement;
            Assert.AreEqual("ycllcPurviewAccount", upateBodyJson.GetProperty("name").GetString());
            Assert.AreEqual("udpatedFriendlyName", upateBodyJson.GetProperty("properties").GetProperty("friendlyName").GetString());
        }

        [Test]
        [RecordedTest]
        public async Task RegenerateKeysTask()
        {
            var options = new PurviewAccountClientOptions();
            AccountsClient client = GetAccountsClient();
            var data = new JsonData(new Dictionary<string, string>
            {
                ["keyType"] = "PrimaryKey"
            }) ;
            Response genResponse = await client.RegenerateKeysAsync(RequestContent.Create(data));
            JsonElement genKeyBodyJson = JsonDocument.Parse(GetContentFromResponse(genResponse)).RootElement;
            Assert.AreEqual("Endpoint=sb://fake_objectId.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ASDASasdfmasdf123412341234=", genKeyBodyJson.GetProperty("atlasKafkaPrimaryEndpoint"));
            Assert.AreEqual("Endpoint=sb://fake_objectId.servicebus.windows.net/;SharedAccessKeyName=AlternateSharedAccessKey;SharedAccessKey=BSDASasdfmasdf123412341234=", genKeyBodyJson.GetProperty("atlasKafkaSecondaryEndpoint"));
        }

        [Test]
        [RecordedTest]
        public async Task ListKeysTask()
        {
            var options = new PurviewAccountClientOptions();
            AccountsClient client = GetAccountsClient();
            var data = new JsonData(new Dictionary<string, string>
            {
                ["keyType"] = "PrimaryKey"
            });
            Response genResponse = await client.RegenerateKeysAsync(RequestContent.Create(data));
            Response listKeysResponse = await client.ListKeysAsync();
            JsonElement listKeyBodyJson = JsonDocument.Parse(GetContentFromResponse(listKeysResponse)).RootElement;
            Assert.AreEqual("Endpoint=sb://fake_objectId.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ASDASasdfmasdf123412341234=", listKeyBodyJson.GetProperty("atlasKafkaPrimaryEndpoint"));
            Assert.AreEqual("Endpoint=sb://fake_objectId.servicebus.windows.net/;SharedAccessKeyName=AlternateSharedAccessKey;SharedAccessKey=BSDASasdfmasdf123412341234=", listKeyBodyJson.GetProperty("atlasKafkaSecondaryEndpoint"));
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
