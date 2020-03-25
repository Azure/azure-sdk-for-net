// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
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
        public void RecognizePiiEntitiesBatch()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample5RecognizePiiEntitiesBatch
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2","Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
                {
                     Language = "en",
                }
            };

            RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Pii Entity Recognition\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (RecognizePiiEntitiesResult result in results)
            {
                TextDocumentInput document = documents[i++];

                Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Debug.WriteLine($"    Document error code: {result.Error.Code}.");
                    Debug.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Debug.WriteLine($"    Recognized the following {result.Entities.Count()} PII entit{(result.Entities.Count() > 1 ? "ies" : "y ")}:");

                    foreach (PiiEntity entity in result.Entities)
                    {
                        Debug.WriteLine($"        Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                    }

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.GraphemeCount}");
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
