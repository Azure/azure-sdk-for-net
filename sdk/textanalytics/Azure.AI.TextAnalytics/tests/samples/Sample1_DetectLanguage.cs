// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void DetectLanguage()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            #region Snippet:TextAnalyticsSample1CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));
            #endregion

            #region Snippet:DetectLanguage
            string input = "Este documento está en español.";

            DetectedLanguage language = client.DetectLanguage(input);

            Console.WriteLine($"Detected language {language.Name} with confidence {language.Score}.");
            #endregion
        }
    }
}
