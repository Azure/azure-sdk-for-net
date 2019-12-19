// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task DetectLanguageAsync()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            #region Snippet:DetectLanguageAsync
            string input = "Este documento está en español.";

            // Asynchronously detect the language the input text is written in
            DetectLanguageResult result = await client.DetectLanguageAsync(input);
            DetectedLanguage language = result.PrimaryLanguage;

            Console.WriteLine($"Detected language {language.Name} with confidence {language.Score:0.00}.");
            #endregion
        }
    }
}
