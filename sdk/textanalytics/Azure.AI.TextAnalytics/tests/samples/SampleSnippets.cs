// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            Uri endpoint = new("<endpoint>");
            AzureKeyCredential credential = new("<apiKey>");
#else
            Uri endpoint = new(TestEnvironment.Endpoint);
            var credential = TestEnvironment.Credential;
#endif
            TextAnalyticsClient client = new(endpoint, credential);
            #endregion
        }

        [Test]
        public void CreateTextAnalyticsClientTokenCredential()
        {
            #region Snippet:CreateTextAnalyticsClientTokenCredential
#if SNIPPET
            Uri endpoint = new("<endpoint>");
            var credential = new DefaultAzureCredential();
#else
            Uri endpoint = new(TestEnvironment.Endpoint);
            var credential = TestEnvironment.Credential;
#endif
            TextAnalyticsClient client = new(endpoint, credential);
            #endregion
        }

        [Test]
        public void BadRequestSnippet()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            var credential = TestEnvironment.Credential;
            TextAnalyticsClient client = new(endpoint, credential);

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
