// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests
{
    public class ContentSafetyLiveTests: RecordedTestBase<ContentSafetyClientTestEnvironment>
    {
        public ContentSafetyLiveTests(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        protected ContentSafetyClient CreateContentSafetyClient(bool useTokenCredential = false, string key = default, bool skipInstrumenting = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            ContentSafetyClient client;
            // TODO - re-record tests and unpin version https://github.com/Azure/azure-sdk-for-net/issues/53232
            var options = InstrumentClientOptions(new ContentSafetyClientOptions(ContentSafetyClientOptions.ServiceVersion.V2023_10_01));

            if (useTokenCredential)
            {
                client = new ContentSafetyClient(endpoint, TestEnvironment.Credential, options: options);
            }
            else
            {
                AzureKeyCredential credential = new AzureKeyCredential(key ?? TestEnvironment.Key);
                client = new ContentSafetyClient(endpoint, credential, options: options);
            }

            return skipInstrumenting ? client : InstrumentClient(client);
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
        public async Task TestAnalyzeText()
        {
            var client = CreateContentSafetyClient();

            var request = new AnalyzeTextOptions(TestData.TestText);
            request.Categories.Add(TextCategory.Hate);
            request.Categories.Add(TextCategory.SelfHarm);
            var response = await client.AnalyzeTextAsync(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis, Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate).Severity, Is.GreaterThan(0));
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.SelfHarm), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Sexual), Is.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Violence), Is.Null);
        }

        [RecordedTest]
        public async Task TestAnalyzeImage()
        {
            var client = CreateContentSafetyClient();

            var image = new ContentSafetyImageData(BinaryData.FromBytes(File.ReadAllBytes(TestData.TestImageLocation)));
            var request = new AnalyzeImageOptions(image);
            var response = await client.AnalyzeImageAsync(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis, Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Violence), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Hate), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Sexual), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.SelfHarm), Is.Not.Null);
        }

        [RecordedTest]
        public async Task TestAnalyzeTextWithBlocklist()
        {
            var client = CreateContentSafetyClient();
            var blocklistClient = CreateBlocklistClient();

            // Create Blocklist
            var blocklistName = "TestAnalyzeTextWithBlocklist";
            var blocklistDescription = "Test blocklist management";
            Response createBlocklistResponse = await blocklistClient.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(new { description = blocklistDescription }));
            Assert.That(createBlocklistResponse, Is.Not.Null);
            Assert.That(createBlocklistResponse.Status, Is.GreaterThanOrEqualTo(200));

            // Add Blocklist items
            var blocklistItemText1 = new TextBlocklistItem("k*ll");
            var blocklistItemText2 = new TextBlocklistItem("h*te");
            var addBlocklistItemResponse = await blocklistClient.AddOrUpdateBlocklistItemsAsync(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(new List<TextBlocklistItem> { blocklistItemText1, blocklistItemText2 }));
            Assert.That(addBlocklistItemResponse, Is.Not.Null);
            Assert.That(addBlocklistItemResponse.GetRawResponse().Status, Is.GreaterThanOrEqualTo(200));

            var request = new AnalyzeTextOptions("I h*te you and I want to k*ll you.");
            request.BlocklistNames.Add(blocklistName);
            var response = await client.AnalyzeTextAsync(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.BlocklistsMatch, Is.Not.Empty);
            Assert.That(response.Value.BlocklistsMatch.ToList().Any(item => item.BlocklistItemText == blocklistItemText1.Text), Is.True);
            Assert.That(response.Value.BlocklistsMatch.ToList().Any(item => item.BlocklistItemText == blocklistItemText2.Text), Is.True);
        }

        [RecordedTest]
        public async Task TestAnalyzeTextWithEntraIdAuth()
        {
            var client = CreateContentSafetyClient(true);

            var request = new AnalyzeTextOptions(TestData.TestText);
            request.Categories.Add(TextCategory.Hate);
            request.Categories.Add(TextCategory.SelfHarm);
            var response = await client.AnalyzeTextAsync(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis, Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate).Severity, Is.GreaterThan(0));
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.SelfHarm), Is.Not.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Sexual), Is.Null);
            Assert.That(response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Violence), Is.Null);
        }
    }
}
