// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples: SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task AnalyzeOperationAsync()
        {
			string endpoint = TestEnvironment.Endpoint;
			string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSampleHealthcareAsync
            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                }
            };

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters()
                {
                    ModelVersion = "latest"
                },
                EntitiesTaskParameters = new EntitiesTaskParameters()
                {
                    ModelVersion = "latest"
                },
                PiiTaskParameters = new PiiTaskParameters()
                {
                    ModelVersion = "latest"
                },
                DisplayName = "AnalyzeOperationSample"
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchDocuments, operationOptions);

            await operation.WaitForCompletionAsync();

            AnalyzeOperationResult resultCollection = operation.Value;

            RecognizeEntitiesResultCollection entitiesResult = resultCollection.EntitiesResult;

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.KeyPhraseResult;

            RecognizePiiEntitiesResultCollection piiResult = resultCollection.PiiEntitiesResult;

            Console.WriteLine("Recognized Entities");

            foreach (RecognizeEntitiesResult result in entitiesResult)
            {
                Console.WriteLine($"    Recognized the following {result.Entities.Count} entities:");

                foreach (CategorizedEntity entity in result.Entities)
                {
                    Console.WriteLine($"    Entity: {entity.Text}");
                    Console.WriteLine($"    Category: {entity.Category}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                    Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Recognized PII Entities");

            foreach (RecognizePiiEntitiesResult result in piiResult)
            {
                Console.WriteLine($"    Recognized the following {result.Entities.Count} PII entities:");

                foreach (PiiEntity entity in result.Entities)
                {
                    Console.WriteLine($"    Entity: {entity.Text}");
                    Console.WriteLine($"    Category: {entity.Category}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                    Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Key Phrases");

            foreach (ExtractKeyPhrasesResult result in keyPhrasesResult)
            {
                Console.WriteLine($"    Recognized the following {result.KeyPhrases.Count} Keyphrases:");

                foreach (string keyphrase in result.KeyPhrases)
                {
                    Console.WriteLine($"    {keyphrase}");
                }
                Console.WriteLine("");
            }
        }

        #endregion
    }
}
