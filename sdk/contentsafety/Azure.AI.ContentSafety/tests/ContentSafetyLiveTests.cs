// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
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
            var response = await client.AnalyzeTextAsync(request);

            Assert.IsNotNull(response);
            Assert.Greater(response.Value.HateResult.Severity, 0);
        }

        [RecordedTest]
        public async Task TestAnalyzeImage()
        {
            var client = CreateContentSafetyClient();

            var image = new ImageData()
            {
                Content = new BinaryData(Convert.FromBase64String(TestData.TextImageContent))
            };
            var request = new AnalyzeImageOptions(image);
            var response = await client.AnalyzeImageAsync(request);

            Assert.IsNotNull(response);
            Assert.Greater(response.Value.ViolenceResult.Severity, 0);
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
