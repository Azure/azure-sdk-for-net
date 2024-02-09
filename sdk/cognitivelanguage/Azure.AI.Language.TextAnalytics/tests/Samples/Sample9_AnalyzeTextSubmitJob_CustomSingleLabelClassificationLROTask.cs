// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.Language.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample9_AnalyzeTextSubmitJob_CustomSingleLabelClassificationLROTask : SamplesBase<TextAnalyticsClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CustomSingleLabelClassificationLROTask()
        {
            #region Snippet:Sample9_AnalyzeTextSubmitJob_CustomSingleLabelClassificationLROTask
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            Text.Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

            string documentA =
                "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
                + " add it to my playlist.";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
            {
                Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
        }
            };

            // Specify the project and deployment names of the desired custom model. To train your own custom model to
            // recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
            string projectName = TestEnvironment.CSCProjectName;
            string deploymentName = TestEnvironment.CSCDeploymentName;

            AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
            {
                new CustomSingleLabelClassificationLROTask()
                {
                    Parameters = new CustomSingleLabelClassificationTaskParameters(projectName, deploymentName)
                }
            });
            Operation operation = client.AnalyzeTextSubmitJob(WaitUntil.Completed, analyzeTextJobsInput);

            AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

            foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
            {
                if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.CustomSingleLabelClassificationLROResults)
                {
                    CustomSingleLabelClassificationLROResult customClassificationResult = (CustomSingleLabelClassificationLROResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (ClassificationDocumentResult customClassificationDocument in customClassificationResult.Results.Documents)
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
