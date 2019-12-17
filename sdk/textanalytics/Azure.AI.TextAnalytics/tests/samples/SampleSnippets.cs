// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
    public partial class Snippets
    {
        [Test]
        public void CreateClient()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            #region Snippet:CreateTextAnalyticsClient
            //@@ string endpoint = "<endpoint>";
            //@@ string subscriptionKey = "<subscriptionKey>";
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
            #endregion Snippet:CreateTextAnalyticsClient
        }
    }
}
