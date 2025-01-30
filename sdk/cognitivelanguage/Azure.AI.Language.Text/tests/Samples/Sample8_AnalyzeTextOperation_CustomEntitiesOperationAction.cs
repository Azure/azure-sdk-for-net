// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample8_AnalyzeTextOperation_CustomEntitiesOperationAction : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CustomEntitiesOperationAction()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample8_AnalyzeTextOperation_CustomEntitiesOperationAction
            string textA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us.";

            string textB =
                "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
                + " so they helped me organize a little surprise for my partner. The room was clean and with the"
                + " decoration I requested. It was perfect!";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA) { Language = "en" },
                    new MultiLanguageInput("B", textB) { Language = "en" },
                }
            };

            // Specify the project and deployment names of the desired custom model. To train your own custom model to
            // recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
            string projectName = "<projectName>";
            string deploymentName = "<deploymentName>";
#if !SNIPPET
            projectName = TestEnvironment.CTProjectName;
            deploymentName = TestEnvironment.CTDeploymentName;
#endif

            CustomEntitiesActionContent customEntitiesActionContent = new CustomEntitiesActionContent(projectName, deploymentName);

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new CustomEntitiesOperationAction
                {
                    Name = "CustomEntitiesOperationActionSample", // Optional string for humans to identify action by name.
                    ActionContent = customEntitiesActionContent
                },
            };

            Response<AnalyzeTextOperationState> response = client.AnalyzeTextOperation(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextJobState = response.Value;

            foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
            {
                if (analyzeTextLROResult is CustomEntityRecognitionOperationResult)
                {
                    CustomEntityRecognitionOperationResult customClassificationResult = (CustomEntityRecognitionOperationResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (CustomEntityActionResult entitiesDocument in customClassificationResult.Results.Documents)
                    {
                        Console.WriteLine($"Result for document with Id = \"{entitiesDocument.Id}\":");
                        Console.WriteLine($"  Recognized {entitiesDocument.Entities.Count} Entities:");

                        foreach (NamedEntity entity in entitiesDocument.Entities)
                        {
                            Console.WriteLine($"  NamedEntity: {entity.Text}");
                            Console.WriteLine($"  Category: {entity.Category}");
                            Console.WriteLine($"  Offset: {entity.Offset}");
                            Console.WriteLine($"  Length: {entity.Length}");
                            Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                            Console.WriteLine($"  Subcategory: {entity.Subcategory}");
                            Console.WriteLine();
                        }
                    }
                    // View the errors in the document
                    foreach (DocumentError error in customClassificationResult.Results.Errors)
                    {
                        Console.WriteLine($"  Error in document: {error.Id}!");
                        Console.WriteLine($"  Document error: {error.Error}");
                        continue;
                    }
                    Console.WriteLine();
                }
            }
            #endregion
        }
    }
}
