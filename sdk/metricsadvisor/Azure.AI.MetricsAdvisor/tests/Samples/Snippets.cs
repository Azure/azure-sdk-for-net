// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public class Snippets : MetricsAdvisorTestEnvironment
    {
        [RecordedTest]
        public void CreateMetricsAdvisorClient()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;

            #region Snippet:CreateMetricsAdvisorClient
            //@@ string endpoint = "<endpoint>";
            //@@ string subscriptionKey = "<subscriptionKey>";
            //@@ string apiKey = "<apiKey>";
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);
            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);
            #endregion
        }
    }
}
