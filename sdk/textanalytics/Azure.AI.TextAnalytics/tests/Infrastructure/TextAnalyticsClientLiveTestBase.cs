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
    }
}
