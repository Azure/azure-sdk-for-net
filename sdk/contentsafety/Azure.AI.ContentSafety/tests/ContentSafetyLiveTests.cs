// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
            var optoins = InstrumentClientOptions(new ContentSafetyClientOptions());

            if (useTokenCredential)
            {
                AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.Credential.ToString());
                client = new ContentSafetyClient(endpoint, credential, options: optoins);
            }
            else
            {
                AzureKeyCredential credential = new AzureKeyCredential(key ?? TestEnvironment.Key);
                client = new ContentSafetyClient(endpoint, credential, options: optoins);
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

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value.HateResult);
            Assert.Greater(response.Value.HateResult.Severity, 0);
            Assert.IsNotNull(response.Value.SelfHarmResult);
            Assert.IsNull(response.Value.SexualResult);
            Assert.IsNull(response.Value.ViolenceResult);
        }

        [RecordedTest]
        public async Task TestAnalyzeImage()
        {
            var client = CreateContentSafetyClient();

            var image = new ContentSafetyImageData()
            {
                Content = BinaryData.FromBytes(File.ReadAllBytes(TestData.TestImageLocation))
            };
            var request = new AnalyzeImageOptions(image);
            var response = await client.AnalyzeImageAsync(request);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value.ViolenceResult);
            Assert.Greater(response.Value.ViolenceResult.Severity, 0);
            Assert.IsNotNull(response.Value.HateResult);
            Assert.IsNotNull(response.Value.SexualResult);
            Assert.IsNotNull(response.Value.SelfHarmResult);
        }

        [RecordedTest]
        public async Task TestCreateOrUpdateBlocklist()
        {
            var client = CreateContentSafetyClient();

            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";

            var data = new
            {
                description = blocklistDescription,
            };

            Response response = await client.CreateOrUpdateTextBlocklistAsync(blocklistName, RequestContent.Create(data));

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Status, 200);
        }
    }
}
