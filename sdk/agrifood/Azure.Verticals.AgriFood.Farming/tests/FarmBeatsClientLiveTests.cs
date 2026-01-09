// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public async Task PartiesSmokeTest()
        {
            FarmBeatsClient client = GetFarmBeatsClient();
            var partiesClient = client.GetPartiesClient();
            const string partyId = "smoke-test-parties-4754";

            Response createdResponse = await partiesClient.CreateOrUpdateAsync(partyId, RequestContent.Create(new object()));
            JsonElement createdBodyJson = JsonDocument.Parse(GetContentFromResponse(createdResponse)).RootElement;

            Assert.Multiple(() =>
            {
                Assert.That(createdBodyJson.GetProperty("id").GetString(), Is.EqualTo(partyId));
                Assert.That(HasProperty(createdBodyJson, "eTag"), Is.True);
                Assert.That(HasProperty(createdBodyJson, "createdDateTime"), Is.True);
                Assert.That(HasProperty(createdBodyJson, "modifiedDateTime"), Is.True);
            });

            Response fetchResponse = await partiesClient.GetPartyAsync(partyId, new());
            JsonElement fetchBodyJson = JsonDocument.Parse(GetContentFromResponse(fetchResponse)).RootElement;

            Assert.Multiple(() =>
            {
                Assert.That(fetchBodyJson.GetProperty("id").GetString(), Is.EqualTo(createdBodyJson.GetProperty("id").GetString()));
                Assert.That(fetchBodyJson.GetProperty("eTag").GetString(), Is.EqualTo(createdBodyJson.GetProperty("eTag").GetString()));
                Assert.That(fetchBodyJson.GetProperty("createdDateTime").GetString(), Is.EqualTo(createdBodyJson.GetProperty("createdDateTime").GetString()));
                Assert.That(fetchBodyJson.GetProperty("modifiedDateTime").GetString(), Is.EqualTo(createdBodyJson.GetProperty("modifiedDateTime").GetString()));
            });

            await partiesClient.DeleteAsync(partyId);
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
