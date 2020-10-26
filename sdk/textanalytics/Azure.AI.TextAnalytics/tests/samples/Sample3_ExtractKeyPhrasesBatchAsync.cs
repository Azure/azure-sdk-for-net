// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task ExtractKeyPhrasesBatchAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

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

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Extract Key Phrases\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (ExtractKeyPhrasesResult result in results)
            {
                TextDocumentInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Console.WriteLine($"    Document error: {result.Error.ErrorCode}.");
                    Console.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Console.WriteLine($"    Extracted the following {result.KeyPhrases.Count()} key phrases:");

                    foreach (string keyPhrase in result.KeyPhrases)
                    {
                        Console.WriteLine($"        {keyPhrase}");
                    }

                    Console.WriteLine($"    Document statistics:");
                    Console.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.CharacterCount}");
                    Console.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Console.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Console.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Console.WriteLine("");
        }
    }
}
