// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void DetectLanguage()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:TextAnalyticsSample1CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:DetectLanguage
            string document = "Este documento está en español.";

            DetectedLanguage language = client.DetectLanguage(document);

            Console.WriteLine($"Detected language {language.Name} with confidence score {language.ConfidenceScore}.");
            #endregion
        }
    }
}
