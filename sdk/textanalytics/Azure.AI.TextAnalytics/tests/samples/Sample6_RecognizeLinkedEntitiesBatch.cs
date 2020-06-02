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
        public void ExtractEntityLinkingBatch()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesBatch
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
                new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
                {
                     Language = "en",
                }
            };

            RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntitiesBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                TextDocumentInput document = documents[i++];

                Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Debug.WriteLine($"    Document error code: {result.Error.ErrorCode}.");
                    Debug.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Debug.WriteLine($"    Extracted the following {result.Entities.Count()} linked entities:");

                    foreach (LinkedEntity linkedEntity in result.Entities)
                    {
                        Debug.WriteLine($"    Name: \"{linkedEntity.Name}\", Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: \"{linkedEntity.DataSourceEntityId}\"");
                        foreach (LinkedEntityMatch match in linkedEntity.Matches)
                        {
                            Debug.WriteLine($"        Match Text: \"{match.Text}\", Confidence score: {match.ConfidenceScore}");
                        }
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
