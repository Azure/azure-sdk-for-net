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

            string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                                worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                                We tried again today and it was amazing. Everyone in my family liked the trail although
                                it was too challenging for the less athletic among us.
                                Not necessarily recommended for small children.
                                A hotel close to the trail offers services for childcare in case you want that.";

            string documentB = @"Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia
                                sabía de nuestra celebración y me ayudaron a tenerle una sorpresa a mi pareja.
                                La habitación estaba limpia y decorada como yo había pedido. Una gran experiencia.
                                El próximo año volveremos.";

            string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
                                They had great amenities that included an indoor pool, a spa, and a bar.
                                The spa offered couples massages which were really good. 
                                The spa was clean and felt very peaceful. Overall the whole experience was great.
                                We will definitely come back.";

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", documentA)
                {
                     Language = "en",
                },
                new TextDocumentInput("2", documentB)
                {
                     Language = "es",
                },
                new TextDocumentInput("3", documentC)
                {
                     Language = "en",
                },
                new TextDocumentInput("4", string.Empty)
            };

            var options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            Response<ExtractKeyPhrasesResultCollection> response = await client.ExtractKeyPhrasesBatchAsync(documents, options);
            ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Extract Key Phrases\" Model, version: \"{keyPhrasesInDocuments.ModelVersion}\"");
            Console.WriteLine("");

            foreach (ExtractKeyPhrasesResult keyPhrases in keyPhrasesInDocuments)
            {
                TextDocumentInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

                if (keyPhrases.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error: {keyPhrases.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {keyPhrases.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"  Extracted the following {keyPhrases.KeyPhrases.Count()} key phrases:");

                    foreach (string keyPhrase in keyPhrases.KeyPhrases)
                    {
                        Console.WriteLine($"    {keyPhrase}");
                    }

                    Console.WriteLine($"  Document statistics:");
                    Console.WriteLine($"    Character count: {keyPhrases.Statistics.CharacterCount}");
                    Console.WriteLine($"    Transaction count: {keyPhrases.Statistics.TransactionCount}");
                }
                Console.WriteLine("");
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {keyPhrasesInDocuments.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {keyPhrasesInDocuments.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {keyPhrasesInDocuments.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {keyPhrasesInDocuments.Statistics.TransactionCount}");
            Console.WriteLine("");
        }
    }
}
