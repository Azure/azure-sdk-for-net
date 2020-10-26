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
        public async Task ExtractKeyPhrasesBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string documentA = @"My cat might need to see a veterinarian. It has been sneezing more than normal, and although my 
little sister thinks it is funny, I a worried it has the cold that I got last week.
We are going to call tomorrow and try to schedule an appointment for this week. Hopefully it will be covered by the cat's insurance.
It might be good to not let it sleep in my room for a while.";

            string documentB = @"We love this trail and make the trip every year. The views are breathtaking and well worth the hike!
Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was amazing.
Everyone in my family liked the trail although it was too challenging for the less athletic among us. Not necessarily recommended for small children.
A hotel close to the trail offers services for childcare in case you want that.";

            string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
They had great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages which were really good. 
The spa was clean and felt very peaceful. Overall the whole experience was great.
We will definitely come back.";

            var documents = new List<string>
            {
                documentA,
                documentB,
                documentC
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            Console.WriteLine($"Extracted key phrases for each document are:");
            int i = 0;
            foreach (ExtractKeyPhrasesResult result in results)
            {
                Console.WriteLine($"For document: \"{documents[i++]}\",");
                Console.WriteLine($"the following {result.KeyPhrases.Count()} key phrases were found: ");

                foreach (string keyPhrase in result.KeyPhrases)
                {
                    Console.WriteLine($"    {keyPhrase}");
                }
            }
        }
    }
}
