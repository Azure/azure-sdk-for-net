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

        public TextAnalyticsClient GetClient(
            AzureKeyCredential credential = default,
            TextAnalyticsClientOptions options = default,
            bool useTokenCredential = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new TextAnalyticsClientOptions();

            if (useTokenCredential)
            {
                return InstrumentClient(new TextAnalyticsClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                return InstrumentClient(new TextAnalyticsClient(endpoint, credential, InstrumentClientOptions(options)));
            }
        }
    }
}
