// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.ContentSafety.Tests
{
    public class BlocklistLiveTests : RecordedTestBase<ContentSafetyClientTestEnvironment>
    {
        public BlocklistLiveTests(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        protected BlocklistClient CreateBlocklistClient(bool useTokenCredential = false, string key = default, bool skipInstrumenting = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            BlocklistClient client;
            var options = InstrumentClientOptions(new ContentSafetyClientOptions());

            if (useTokenCredential)
            {
                AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.Credential.ToString());
                client = new BlocklistClient(endpoint, credential, options: options);
            }
            else
            {
                AzureKeyCredential credential = new AzureKeyCredential(key ?? TestEnvironment.Key);
                client = new BlocklistClient(endpoint, credential, options: options);
            }

            return skipInstrumenting ? client : InstrumentClient(client);
        }

        [RecordedTest]
        public async Task TestCreateOrUpdateBlocklist()
        {
            var client = CreateBlocklistClient();

            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";

            Response response = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Status, 200);
        }

        [RecordedTest]
        public async Task TestGetTextBlocklist()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.IsNotNull(createBlocklistResponse);
            Assert.GreaterOrEqual(createBlocklistResponse.Status, 200);

            var response = await client.GetTextBlocklistAsync(blocklistName);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(response.Value.Name, blocklistName);
        }

        [RecordedTest]
        public async Task TestAddOrUpdateBlocklistItems()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.IsNotNull(createBlocklistResponse);
            Assert.GreaterOrEqual(createBlocklistResponse.Status, 200);

            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var response = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.IsNotEmpty(response.Value.BlocklistItems);
            var blocklistItems = new List<TextBlocklistItem>(response.Value.BlocklistItems);
            Assert.True(blocklistItems.Any(item => item.Text == blocklistItemText1.Text));
            Assert.True(blocklistItems.Any(item => item.Text == blocklistItemText2.Text));
        }

        [RecordedTest]
        public async Task TestGetTextBlocklistItem()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.IsNotNull(createBlocklistResponse);
            Assert.GreaterOrEqual(createBlocklistResponse.Status, 200);

            // Add Blocklist items
            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var addBlocklistItemResponse = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));
            Assert.IsNotNull(addBlocklistItemResponse);
            Assert.GreaterOrEqual(addBlocklistItemResponse.GetRawResponse().Status, 200);
            var blocklistItemId1 = addBlocklistItemResponse.Value.BlocklistItems[0].BlocklistItemId;
            Assert.IsNotNull(blocklistItemId1);

            var response = await client.GetTextBlocklistItemAsync(blocklistName, blocklistItemId1);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Value.BlocklistItemId, blocklistItemId1);
        }

        [RecordedTest]
        public async Task TestRemoveBlocklistItems()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.IsNotNull(createBlocklistResponse);
            Assert.GreaterOrEqual(createBlocklistResponse.Status, 200);

            // Add Blocklist items
            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var addBlocklistItemResponse = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));
            Assert.IsNotNull(addBlocklistItemResponse);
            Assert.GreaterOrEqual(addBlocklistItemResponse.GetRawResponse().Status, 200);
            var blocklistItemId1 = addBlocklistItemResponse.Value.BlocklistItems[0].BlocklistItemId;
            Assert.IsNotNull(blocklistItemId1);

            RemoveTextBlocklistItemsOptions options = new RemoveTextBlocklistItemsOptions(new List<string> { blocklistItemId1 });
            var response = await client.RemoveBlocklistItemsAsync(blocklistName, options);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 204);
        }

        [RecordedTest]
        public async Task TestDeleteTextBlocklist()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.IsNotNull(createBlocklistResponse);
            Assert.GreaterOrEqual(createBlocklistResponse.Status, 200);

            var response = await client.DeleteTextBlocklistAsync(blocklistName);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, 204);
        }
    }
}
