// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class TextAnalyticsSampleBase : SamplesBase<TextAnalyticsTestEnvironment>
    {
        public TextAnalyticsClient CreateTextAnalyticsClient(Uri endpoint, AzureKeyCredential credential, TextAnalyticsClientOptions options = null)
        {
            options = options ?? new TextAnalyticsClientOptions();
            options.Retry.MaxRetries = TextAnalyticsClientLiveTestBase.MaxRetriesCount;

            return new TextAnalyticsClient(endpoint, credential, options);
        }

        public TextAnalyticsClient CreateTextAnalyticsClient(Uri endpoint, TokenCredential credential, TextAnalyticsClientOptions options = null)
        {
            options = options ?? new TextAnalyticsClientOptions();
            options.Retry.MaxRetries = TextAnalyticsClientLiveTestBase.MaxRetriesCount;

            return new TextAnalyticsClient(endpoint, credential, options);
        }
    }
}
