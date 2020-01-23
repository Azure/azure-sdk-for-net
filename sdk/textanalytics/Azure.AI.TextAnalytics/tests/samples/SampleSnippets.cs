// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using Azure.Identity;
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
        public void CreateTextAnalyticsClient()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            #region Snippet:CreateTextAnalyticsClient
            //@@ string endpoint = "<endpoint>";
            //@@ string subscriptionKey = "<subscriptionKey>";
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
            #endregion
        }

        [Test]
        public void CreateTextAnalyticsClientTokenCredential()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");

            #region Snippet:CreateTextAnalyticsClientTokenCredential
            //@@ string endpoint = "<endpoint>";
            var client = new TextAnalyticsClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void BadRequestSnippet()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
            string input = "Este documento está en español.";

            #region Snippet:BadRequest
            try
            {
                DetectLanguageResult result = client.DetectLanguage(input);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}
