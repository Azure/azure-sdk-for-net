// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class TextAnalyticsSampleBase : SamplesBase<TextAnalyticsTestEnvironment>
    {
        public TextAnalyticsClientOptions CreateSampleOptions(bool useStaticResource = default)
        {
            Uri authorityHost = new(TestEnvironment.AuthorityHostUrl);

            TextAnalyticsClientOptions options = new()
            {
                Audience = TextAnalyticsTestEnvironment.GetAudience(authorityHost)
            };

            // While we use a persistent resource for live tests, we need to increase our retries.
            // We should remove when having dynamic resource again
            // Issue: https://github.com/Azure/azure-sdk-for-net/issues/25041
            if (useStaticResource)
            {
                options.Retry.MaxRetries = TextAnalyticsClientLiveTestBase.MaxRetriesCount;
            }

            return options;
        }
    }
}
