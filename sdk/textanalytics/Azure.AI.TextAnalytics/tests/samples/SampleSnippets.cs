﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets: SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void CreateTextAnalyticsClient()
        {
            #region Snippet:CreateTextAnalyticsClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [Test]
        public void CreateTextAnalyticsClientTokenCredential()
        {
            #region Snippet:CreateTextAnalyticsClientTokenCredential
#if SNIPPET
            string endpoint = "<endpoint>";
#else
            string endpoint = TestEnvironment.Endpoint;
#endif
            var client = new TextAnalyticsClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credentials = new AzureKeyCredential(apiKey);
            var client = new TextAnalyticsClient(new Uri(endpoint), credentials);
            string document = "Este documento está en español.";

            #region Snippet:BadRequest
            try
            {
                DetectedLanguage result = client.DetectLanguage(document);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}
