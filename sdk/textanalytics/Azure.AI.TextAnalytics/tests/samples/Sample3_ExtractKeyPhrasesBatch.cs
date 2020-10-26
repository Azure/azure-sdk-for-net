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
            string documentA = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar cómo invocar el método de extracción de frases del servicio de Text Analytics en Microsoft Azure.
También muestra cómo acceder a la información retornada por el servicio.";

            string documentB = @"We love this trail and make the trip every year. The views are breathtaking and well worth the hike!
Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was amazing.
Everyone in my family liked the trail although it was too challenging for the less athletic among us. Not necessarily recommended for small children.
A hotel close to the trail offers services for childcare in case you want that.";

            string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
They had great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages which were really good. 
The spa was clean and felt very peaceful. Overall the whole experience was great.
We will definitely come back.";

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", documentA)
                {
                     Language = "es",
                },
                new TextDocumentInput("2", documentB)
                {
                     Language = "en",
                },
                new TextDocumentInput("3", documentC)
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
