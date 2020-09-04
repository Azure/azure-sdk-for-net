// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void AnalyzeHealth()
        {
            Environment.SetEnvironmentVariable("CLIENT_ID", "");
            Environment.SetEnvironmentVariable("TENANT_ID", "");
            Environment.SetEnvironmentVariable("CLIENT_SECRET", "");

            string endpoint = "https://cognitiveusw2dev.azure-api.net/";
            string apiKey = "..";

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeHealth

            IEnumerable<TextDocumentInput> documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "Hello there!")
            };


            AnalyzeHealthOperation operation = client.StartAnalyzeHealth(documents, new TextAnalyticsRequestOptions() { ModelVersion = "latest" });

            operation.WaitForCompletionAsync().ConfigureAwait(false);

            #endregion
        }

        [Test]
        public async System.Threading.Tasks.Task AnalyzeHealthAsync()
        {
            Environment.SetEnvironmentVariable("CLIENT_ID", "");
            Environment.SetEnvironmentVariable("TENANT_ID", "");
            Environment.SetEnvironmentVariable("CLIENT_SECRET", "");

            string endpoint = "https://cognitiveusw2dev.azure-api.net/";
            string apiKey = "..";

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeHealth

            IEnumerable<TextDocumentInput> documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "Hello there!")
            };


            AnalyzeHealthOperation operation = await client.StartAnalyzeHealthAsync(documents, new TextAnalyticsRequestOptions() { ModelVersion = "latest" });

            await operation.WaitForCompletionAsync();

            #endregion
        }
    }
}
