// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets : TextAnalyticsSampleBase
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
            TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
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
            TextAnalyticsClient client = new(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [Test]
        public void BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            AzureKeyCredential credentials = new(apiKey);
            TextAnalyticsClient client = new(new Uri(endpoint), credentials);
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
