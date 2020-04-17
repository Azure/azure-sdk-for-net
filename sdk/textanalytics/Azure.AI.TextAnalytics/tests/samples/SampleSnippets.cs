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
            string endpoint = TextAnalyticsTestEnvironment.Instance.Endpoint;
            string apiKey = TextAnalyticsTestEnvironment.Instance.ApiKey;

            #region Snippet:CreateTextAnalyticsClient
            //@@ string endpoint = "<endpoint>";
            //@@ string apiKey = "<apiKey>";
            var credential = new AzureKeyCredential(apiKey);
            var client = new TextAnalyticsClient(new Uri(endpoint), credential);
            #endregion
        }

        [Test]
        public void CreateTextAnalyticsClientTokenCredential()
        {
            string endpoint = TextAnalyticsTestEnvironment.Instance.Endpoint;

            #region Snippet:CreateTextAnalyticsClientTokenCredential
            //@@ string endpoint = "<endpoint>";
            var client = new TextAnalyticsClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void BadRequestSnippet()
        {
            string endpoint = TextAnalyticsTestEnvironment.Instance.Endpoint;
            string apiKey = TextAnalyticsTestEnvironment.Instance.ApiKey;

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
