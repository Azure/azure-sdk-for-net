// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class TextAnalyticsSampleBase : SamplesBase<TextAnalyticsTestEnvironment>
    {
        private const int MaxRetriesCount = 12;

        public TextAnalyticsClientOptions CreateSampleOptions(bool useStaticResource = default)
        {
            TextAnalyticsAudience audience = TestEnvironment.GetAudience();

            TextAnalyticsClientOptions options = new()
            {
                Audience = audience
            };

            // We have seen transient timeouts while testing the custom text analysis features which are potentially
            // related to the use of the static resource.
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/25041.
            // Similarly, we have also seen transient timeouts when running tests in the China cloud regions which are
            // likely due to the physical distance between those regions and our CI infrastructure running in the US.
            if (useStaticResource || audience == TextAnalyticsAudience.AzureChina)
            {
                options.Retry.MaxRetries = MaxRetriesCount;
            }

            return options;
        }
    }
}
