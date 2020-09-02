// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrasesBatch()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample3ExtractKeyPhrasesBatch
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Text Analytics is one of the Azure Cognitive Services.")
                {
                     Language = "en",
                },
                new TextDocumentInput("3", "My cat might need to see a veterinarian.")
                {
                     Language = "en",
                }
            };

            ExtractKeyPhrasesResultCollection results = client.ExtractKeyPhrasesBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Extract Key Phrases\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (ExtractKeyPhrasesResult result in results)
            {
                TextDocumentInput document = documents[i++];

                Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Debug.WriteLine($"    Document error: {result.Error.ErrorCode}.");
                    Debug.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Debug.WriteLine($"    Extracted the following {result.KeyPhrases.Count()} key phrases:");

                    foreach (string keyPhrase in result.KeyPhrases)
                    {
                        Debug.WriteLine($"        {keyPhrase}");
                    }

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.CharacterCount}");
                    Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
