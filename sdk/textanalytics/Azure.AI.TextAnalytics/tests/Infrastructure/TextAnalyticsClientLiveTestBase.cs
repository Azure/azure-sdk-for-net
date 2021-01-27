// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTestBase : RecordedTestBase<TextAnalyticsTestEnvironment>
    {
        public TextAnalyticsClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new TextAnalyticsRecordedTestSanitizer();
        }

        public TextAnalyticsClient GetClient(AzureKeyCredential credential = default, TextAnalyticsClientOptions options = default)
        {
            string apiKey = TestEnvironment.ApiKey;
            credential ??= new AzureKeyCredential(apiKey);
            options ??= new TextAnalyticsClientOptions();
            return InstrumentClient(
                new TextAnalyticsClient(
                    new Uri(TestEnvironment.Endpoint),
                    credential,
                    InstrumentClientOptions(options))
            );
        }

        public TextAnalyticsClient GetQAClient(AzureKeyCredential credential = default, QARuntimeOptions options = default)
        {
            string apiKey = "c0b16804b5224efda0e3d62dc892c62b";//TestEnvironment.ApiKey;
            credential ??= new AzureKeyCredential(apiKey);
            options ??= new QARuntimeOptions("test", "ef31dd53-6d00-4769-b353-63335503a8b3");
            return InstrumentClient(
                new TextAnalyticsClient(
                    new Uri("https://qnamakerteambugbash-aue.cognitiveservices.azure.com"),
                        //TestEnvironment.Endpoint),
                    credential,
                    InstrumentClientOptions(options))
            );
        }
    }
}
