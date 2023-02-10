// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void RecognizeEntitiesBatchConvenience()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            #region Snippet:TextAnalyticsSample4RecognizeEntitiesConvenience
            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            string documentB =
                "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
                + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
                + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

            string documentC =
                "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
                + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
                + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
                + " great. We will definitely come back.";

            string documentD = string.Empty;

            List<string> documents = new()
            {
                documentA,
                documentB,
                documentC,
                documentD
            };

            Response<RecognizeEntitiesResultCollection> response = client.RecognizeEntitiesBatch(documents);
            RecognizeEntitiesResultCollection entititesPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of \"Named Entity Recognition\" Model, version: \"{entititesPerDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (RecognizeEntitiesResult entitiesInDocument in entititesPerDocuments)
            {
                Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
                Console.WriteLine();

                if (entitiesInDocument.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error code: {entitiesInDocument.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {entitiesInDocument.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"  Recognized the following {entitiesInDocument.Entities.Count} entities:");

                    foreach (CategorizedEntity entity in entitiesInDocument.Entities)
                    {
                        Console.WriteLine($"    Text: {entity.Text}");
                        Console.WriteLine($"    Offset: {entity.Offset}");
                        Console.WriteLine($"    Length: {entity.Length}");
                        Console.WriteLine($"    Category: {entity.Category}");
                        if (!string.IsNullOrEmpty(entity.SubCategory))
                            Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}
