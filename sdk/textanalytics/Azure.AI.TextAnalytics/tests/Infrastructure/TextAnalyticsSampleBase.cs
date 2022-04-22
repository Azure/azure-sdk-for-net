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
            // Until we have new code working, make sure that samples keep working by targeting legacy path
            var options = new TextAnalyticsClientOptions(TextAnalyticsClientOptions.ServiceVersion.V3_2_Preview_2);
            options.Retry.MaxRetries = TextAnalyticsClientLiveTestBase.MaxRetriesCount;

            return options;
        }
    }
}
