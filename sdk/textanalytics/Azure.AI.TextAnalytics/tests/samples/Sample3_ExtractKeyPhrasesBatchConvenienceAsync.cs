// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            string documentB =
                "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
                + " so they helped me organize a little surprise for my partner. The room was clean and with the"
                + " decoration I requested. It was perfect!";

            string documentC =
                "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
                + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
                + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
                + " great. We will definitely come back.";

            string documentD = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                documentA,
                documentB,
                documentC,
                documentD
            };

            Response<ExtractKeyPhrasesResultCollection> response = await client.ExtractKeyPhrasesBatchAsync(batchedDocuments);
            ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Extract Key Phrases, model version: \"{keyPhrasesInDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (ExtractKeyPhrasesResult documentResult in keyPhrasesInDocuments)
            {
                Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

                if (documentResult.HasError)
                {
                    Console.WriteLine($"  Error!");
                    Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {documentResult.Error.Message}");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine($"  Extracted {documentResult.KeyPhrases.Count()} key phrases:");

                foreach (string keyPhrase in documentResult.KeyPhrases)
                {
                    Console.WriteLine($"    {keyPhrase}");
                }
                Console.WriteLine();
            }
        }
    }
}
