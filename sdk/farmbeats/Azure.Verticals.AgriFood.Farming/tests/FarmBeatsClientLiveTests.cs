﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Verticals.AgriFood.Farming.Tests
{
    public class FarmBeatsClientLiveTests : FarmBeatsClientLiveTestBase
    {
        public FarmBeatsClientLiveTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task FarmersSmokeTest()
        {
            FarmersClient client = GetFarmersClient();
            const string farmerId = "smoke-test-farmer";

            Response createdResponse = await client.CreateOrUpdateAsync(farmerId, RequestContent.Create(new object()));
            JsonElement createdBodyJson = JsonDocument.Parse(GetContentFromResponse(createdResponse)).RootElement;

            Assert.AreEqual(farmerId, createdBodyJson.GetProperty("id").GetString());
            Assert.IsTrue(HasProperty(createdBodyJson, "eTag"));
            Assert.IsTrue(HasProperty(createdBodyJson, "createdDateTime"));
            Assert.IsTrue(HasProperty(createdBodyJson, "modifiedDateTime"));

            Response fetchResponse = await client.GetAsync(farmerId);
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;

            Assert.AreEqual(createdBodyJson.GetProperty("id").GetString(), fetchBodyJson.GetProperty("id").GetString());
            Assert.AreEqual(createdBodyJson.GetProperty("eTag").GetString(), fetchBodyJson.GetProperty("eTag").GetString());
            Assert.AreEqual(createdBodyJson.GetProperty("createdDateTime").GetString(), fetchBodyJson.GetProperty("createdDateTime").GetString());
            Assert.AreEqual(createdBodyJson.GetProperty("modifiedDateTime").GetString(), fetchBodyJson.GetProperty("modifiedDateTime").GetString());

            await client.DeleteAsync(farmerId);
        }

        private static bool HasProperty(JsonElement e, string propertyName)
        {
            return e.TryGetProperty(propertyName, out JsonElement _);
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
