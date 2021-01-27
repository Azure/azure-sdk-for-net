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
        public async Task RecognizeEntitiesBatchConvenienceAsync()
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

            string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                                our anniversary so they helped me organize a little surprise for my partner.
                                The room was clean and with the decoration I requested. It was perfect!";

            string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
                                They had great amenities that included an indoor pool, a spa, and a bar.
                                The spa offered couples massages which were really good. 
                                The spa was clean and felt very peaceful. Overall the whole experience was great.
                                We will definitely come back.";

            string documentD = string.Empty;

            var documents = new List<string>
            {
                documentA,
                documentB,
                documentC,
                documentD
            };

            Response<RecognizeEntitiesResultCollection> response = await client.RecognizeEntitiesBatchAsync(documents);
            RecognizeEntitiesResultCollection entititesPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Named Entity Recognition\" Model, version: \"{entititesPerDocuments.ModelVersion}\"");
            Console.WriteLine("");

            foreach (RecognizeEntitiesResult entitiesInDocument in entititesPerDocuments)
            {
                Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
                Console.WriteLine("");

                if (entitiesInDocument.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error code: {entitiesInDocument.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {entitiesInDocument.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"  Recognized the following {entitiesInDocument.Entities.Count()} entities:");

                    foreach (CategorizedEntity entity in entitiesInDocument.Entities)
                    {
                        Console.WriteLine($"    Text: {entity.Text}");
                        Console.WriteLine($"    Offset: {entity.Offset}");
                        Console.WriteLine($"    Category: {entity.Category}");
                        if (!string.IsNullOrEmpty(entity.SubCategory))
                            Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
