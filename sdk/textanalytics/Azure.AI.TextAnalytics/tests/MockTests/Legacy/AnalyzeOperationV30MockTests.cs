// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Legacy.Tests
{
    public class AnalyzeOperationV30MockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public AnalyzeOperationV30MockTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport = default)
        {
            var options = new TextAnalyticsClientOptions(TextAnalyticsClientOptions.ServiceVersion.V3_0)
            {
                Transport = transport ?? new MockTransport(),
            };

            var client = new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options);
            return InstrumentClient(client);
        }

        [Test]
        public void AnalyzeActionsNotSupported()
        {
            TextAnalyticsClient client = CreateTestClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(new[] { "test" }, new TextAnalyticsActions
            {
                AnalyzeSentimentActions = new[]
                {
                    new AnalyzeSentimentAction(),
                },
            }));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeActionsAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeActions is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        [Test]
        public void RecognizePiiEntitiesNotSupported()
        {
            TextAnalyticsClient client = CreateTestClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.RecognizePiiEntitiesAsync("test"));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntitiesAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntities is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        [Test]
        public void RecognizePiiEntitiesBatchNotSupported()
        {
            TextAnalyticsClient client = CreateTestClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.RecognizePiiEntitiesBatchAsync(new[] { "test" }));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntitiesBatchAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.RecognizePiiEntitiesBatch is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }

        [Test]
        public void StartAnalyzeHealthcareEntitiesNotSupported()
        {
            TextAnalyticsClient client = CreateTestClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeHealthcareEntitiesAsync(new[] { "test" }));

            if (IsAsync)
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeHealthcareEntitiesAsync is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
            else
            {
                Assert.AreEqual("TextAnalyticsClient.StartAnalyzeHealthcareEntities is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
            }
        }
    }
}
