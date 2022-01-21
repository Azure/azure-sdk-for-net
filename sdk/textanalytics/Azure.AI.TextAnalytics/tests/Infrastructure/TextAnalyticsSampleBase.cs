// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class TextAnalyticsSampleBase : SamplesBase<TextAnalyticsTestEnvironment>
    {
        public TextAnalyticsClientOptions CreateSampleOptions()
        {
            var options = new TextAnalyticsClientOptions();
            options.Retry.MaxRetries = TextAnalyticsClientLiveTestBase.MaxRetriesCount;

            return options;
        }
    }
}
