// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample10_AnalyzeTextOperation_CustomMultiLabelClassificationOperationAction : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CustomMultiLabelClassificationOperationAction()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample10_AnalyzeTextOperation_CustomMultiLabelClassificationOperationAction
            string textA =
                "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
                + " add it to my playlist.";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA)
                    {
                        Language = "en"
                    },
                }
            };

            // Specify the project and deployment names of the desired custom model. To train your own custom model to
            // recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
            string projectName = "<projectName>";
            string deploymentName = "<deploymentName>";
#if !SNIPPET
            projectName = TestEnvironment.CMCProjectName;
            deploymentName = TestEnvironment.CMCDeploymentName;
#endif

            CustomMultiLabelClassificationActionContent customMultiLabelClassificationActionContent = new CustomMultiLabelClassificationActionContent(projectName, deploymentName);

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new CustomMultiLabelClassificationOperationAction
                {
                    Name = "CMCOperationActionSample",
                    ActionContent = customMultiLabelClassificationActionContent,
                },
            };

            Response<AnalyzeTextOperationState> response = client.AnalyzeTextOperation(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextJobState = response.Value;

            foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
            {
                if (analyzeTextLROResult is CustomMultiLabelClassificationOperationResult)
                {
                    CustomMultiLabelClassificationOperationResult customClassificationResult = (CustomMultiLabelClassificationOperationResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
                    {
                        Console.WriteLine($"Result for document with Id = \"{customClassificationDocument.Id}\":");
                        Console.WriteLine($"  Recognized {customClassificationDocument.Class.Count} classifications:");

                        foreach (ClassificationResult classification in customClassificationDocument.Class)
                        {
                            Console.WriteLine($"  Classification: {classification.Category}");
                            Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
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
                }
            }
            #endregion
        }
    }
}
