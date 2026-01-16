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
            // TODO - re-record tests and unpin version https://github.com/Azure/azure-sdk-for-net/issues/53232
            var options = InstrumentClientOptions(new ContentSafetyClientOptions(ContentSafetyClientOptions.ServiceVersion.V2023_10_01));

            if (useTokenCredential)
            {
                client = new BlocklistClient(endpoint, TestEnvironment.Credential, options: options);
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

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.GreaterThanOrEqualTo(200));
        }

        [RecordedTest]
        public async Task TestGetTextBlocklist()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            var response = await client.GetTextBlocklistAsync(blocklistName);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(blocklistName, Is.EqualTo(response.Value.Name));
        }

        [RecordedTest]
        public async Task TestDeleteTextBlocklist()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestDeleteBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            var response = await client.DeleteTextBlocklistAsync(blocklistName);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo(204));
        }

        [RecordedTest]
        public async Task TestGetTextBlocklists()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            // Create another Blocklist
            var blocklistName2 = "AnotherTestBlocklist";
            var blocklistDescription2 = "Another Test blocklist management";
            Response createBlocklistResponse2 = await client.CreateOrUpdateTextBlocklistAsync(blocklistName2, RequestContent.Create(new { description = blocklistDescription2 }));
            Assert.That(createBlocklistResponse2, Is.Not.Null);
            Assert.That(createBlocklistResponse2.Status, Is.GreaterThanOrEqualTo(200));

            var response = client.GetTextBlocklistsAsync();
            Assert.That(response, Is.Not.Null);
            List<TextBlocklist> blocklist = await response.ToListAsync();
            Assert.That(blocklist.Any(item => item.Name == blocklistName), Is.True);
            Assert.That(blocklist.Any(item => item.Name == blocklistName2), Is.True);
        }

        [RecordedTest]
        public async Task TestAddOrUpdateBlocklistItems()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var response = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.BlocklistItems, Is.Not.Empty);
            var blocklistItems = new List<TextBlocklistItem>(response.Value.BlocklistItems);
            Assert.That(blocklistItems.Any(item => item.Text == blocklistItemText1.Text), Is.True);
            Assert.That(blocklistItems.Any(item => item.Text == blocklistItemText2.Text), Is.True);
        }

        [RecordedTest]
        public async Task TestGetTextBlocklistItem()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            // Add Blocklist items
            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var addBlocklistItemResponse = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));
            Assert.That(addBlocklistItemResponse, Is.Not.Null);
            Assert.That(addBlocklistItemResponse.GetRawResponse().Status, Is.GreaterThanOrEqualTo(200));
            var blocklistItemId1 = addBlocklistItemResponse.Value.BlocklistItems[0].BlocklistItemId;
            Assert.That(blocklistItemId1, Is.Not.Null);

            var response = await client.GetTextBlocklistItemAsync(blocklistName, blocklistItemId1);

            Assert.That(response, Is.Not.Null);
            Assert.That(blocklistItemId1, Is.EqualTo(response.Value.BlocklistItemId));
        }

        [RecordedTest]
        public async Task TestGetTextBlocklistItems()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            // Add Blocklist items
            var blocklistItemText1 = new TextBlocklistItem("This is a test.");
            var blocklistItemText2 = new TextBlocklistItem("This is a test 2.");
            var blocklistItemText3 = new TextBlocklistItem("This is a test 3.");
            var blocklistItemText4 = new TextBlocklistItem("This is a test 4.");
            var blocklistItemText5 = new TextBlocklistItem("This is a test 5.");

            var blocklistItemList = new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2, blocklistItemText3, blocklistItemText4, blocklistItemText5 };
            var addBlocklistItemResponse = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(blocklistItemList));
            Assert.That(addBlocklistItemResponse, Is.Not.Null);
            Assert.That(addBlocklistItemResponse.GetRawResponse().Status, Is.GreaterThanOrEqualTo(200));
            var blocklistItemId1 = addBlocklistItemResponse.Value.BlocklistItems[0].BlocklistItemId;
            Assert.That(blocklistItemId1, Is.Not.Null);

            // Test maxCount
            var response = client.GetTextBlocklistItemsAsync(blocklistName, maxCount: 2);
            Assert.That(response, Is.Not.Null);
            List<TextBlocklistItem> blocklistItems = await response.ToListAsync();
            Assert.That(blocklistItems.Count, Is.LessThanOrEqualTo(2));

            // Test skip
            response = client.GetTextBlocklistItemsAsync(blocklistName, skip: 2);
            Assert.That(response, Is.Not.Null);
            blocklistItems = await response.ToListAsync();
            Assert.That(blocklistItems.Count, Is.GreaterThanOrEqualTo(3));

            // Test maxpagesize
            response = client.GetTextBlocklistItemsAsync(blocklistName, maxpagesize: 2);
            Assert.That(response, Is.Not.Null);
            Assert.That(await response.CountAsync(), Is.GreaterThanOrEqualTo(5));
            await foreach (var page in response.AsPages())
            {
                Assert.That(page.Values.Count, Is.LessThanOrEqualTo(2));
            }
        }

        [RecordedTest]
        public async Task TestRemoveBlocklistItems()
        {
            var client = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestRemoveBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            // Add Blocklist items
            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var addBlocklistItemResponse = await client.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));
            Assert.That(addBlocklistItemResponse, Is.Not.Null);
            Assert.That(addBlocklistItemResponse.GetRawResponse().Status, Is.GreaterThanOrEqualTo(200));
            var blocklistItemId1 = addBlocklistItemResponse.Value.BlocklistItems[0].BlocklistItemId;
            Assert.That(blocklistItemId1, Is.Not.Null);

            RemoveTextBlocklistItemsOptions options = new RemoveTextBlocklistItemsOptions(new List<string> { blocklistItemId1 });
            var response = await client.RemoveBlocklistItemsAsync(blocklistName, options);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo(204));
        }
    }
}
