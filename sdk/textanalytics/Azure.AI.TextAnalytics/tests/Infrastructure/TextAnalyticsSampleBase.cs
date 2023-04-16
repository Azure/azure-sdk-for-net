// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class TextAnalyticsSampleBase : SamplesBase<TextAnalyticsTestEnvironment>
    {
        private const int MaxRetriesCount = 12;

        public TextAnalyticsClientOptions CreateSampleOptions(bool useStaticResource = default)
        {
            TextAnalyticsClientOptions options = new()
            {
                Audience = TestEnvironment.GetAudience()
            };

            // While we use a persistent resource for live tests, we need to increase our retries.
            // We should remove when having dynamic resource again
            // Issue: https://github.com/Azure/azure-sdk-for-net/issues/25041
            if (useStaticResource)
            {
                options.Retry.MaxRetries = MaxRetriesCount;
            }

            return options;
        }

        internal void IgnoreIfNotPublicCloud()
        {
            if (TestEnvironment.GetAudience() != TextAnalyticsAudience.AzurePublicCloud)
            {
                Assert.Ignore("Currently, these tests can only be run in the public cloud.");
            }
        }
    }
}
