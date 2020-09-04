// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void AnalyzeOperation()
        {
            Environment.SetEnvironmentVariable("CLIENT_ID", "");
            Environment.SetEnvironmentVariable("TENANT_ID", "");
            Environment.SetEnvironmentVariable("CLIENT_SECRET", "");

            string endpoint = "https://cognitiveusw2dev.azure-api.net";
            string apiKey = "..";

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeOperation

            IEnumerable<TextDocumentInput> documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "Hello there!")
            };


            AnalyzeOperation operation = client.StartAnalyzeOperation(documents, new TextAnalyticsRequestOptions() { ModelVersion = "latest" });

            operation.WaitForCompletionAsync().ConfigureAwait(false);

            #endregion
        }

        [Test]
        public async Task AnalyzeOperationAsync()
        {
            Environment.SetEnvironmentVariable("CLIENT_ID", "");
            Environment.SetEnvironmentVariable("TENANT_ID", "");
            Environment.SetEnvironmentVariable("CLIENT_SECRET", "");

            string endpoint = "https://cognitiveusw2dev.azure-api.net";
            string apiKey = "..";

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeOperation

            IEnumerable<TextDocumentInput> documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "Hello there!")
            };


            AnalyzeOperation operation = await client.StartAnalyzeOperationAsync(documents, new TextAnalyticsRequestOptions() { ModelVersion = "latest" });

            Response<AnalyzeResultCollection> response = await operation.WaitForCompletionAsync();

            Console.WriteLine("Here", response);
            #endregion
        }
    }
}
