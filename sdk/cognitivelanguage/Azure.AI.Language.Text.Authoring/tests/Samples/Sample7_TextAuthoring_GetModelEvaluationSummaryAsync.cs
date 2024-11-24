// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Models;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample7_TextAuthoring_GetModelEvaluationSummaryAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetModelEvaluationSummaryAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample7_TextAuthoring_GetSingleLabelClassificationEvaluationSummaryAsync

            string projectName = "LoanAgreements";
            string trainedModelLabel = "model2";

            // Get the evaluation summary for the trained model
            Response<EvaluationSummary> evaluationSummaryResponse = await authoringClient.GetModelEvaluationSummaryAsync(projectName, trainedModelLabel);

            EvaluationSummary evaluationSummary = evaluationSummaryResponse.Value;

            // Cast to the specific evaluation summary type for custom single label classification
            if (evaluationSummary is CustomSingleLabelClassificationEvaluationSummary singleLabelSummary)
            {
                Console.WriteLine($"Project Kind: CustomSingleLabelClassification");
                Console.WriteLine($"Evaluation Options: ");
                Console.WriteLine($"    Kind: {singleLabelSummary.EvaluationOptions.Kind}");
                Console.WriteLine($"    Training Split Percentage: {singleLabelSummary.EvaluationOptions.TrainingSplitPercentage}");
                Console.WriteLine($"    Testing Split Percentage: {singleLabelSummary.EvaluationOptions.TestingSplitPercentage}");

                Console.WriteLine($"Micro F1: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroF1}");
                Console.WriteLine($"Micro Precision: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroPrecision}");
                Console.WriteLine($"Micro Recall: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroRecall}");
                Console.WriteLine($"Macro F1: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroF1}");
                Console.WriteLine($"Macro Precision: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroPrecision}");
                Console.WriteLine($"Macro Recall: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroRecall}");

                // Print confusion matrix
                Console.WriteLine("Confusion Matrix:");
                foreach (var row in singleLabelSummary.CustomSingleLabelClassificationEvaluation.ConfusionMatrix.AdditionalProperties)
                {
                    Console.WriteLine($"Row: {row.Key}");
                    var columnData = row.Value.ToObjectFromJson<Dictionary<string, BinaryData>>();
                    foreach (var col in columnData)
                    {
                        var values = col.Value.ToObjectFromJson<Dictionary<string, float>>();
                        Console.WriteLine($"    Column: {col.Key}, Normalized Value: {values["normalizedValue"]}, Raw Value: {values["rawValue"]}");
                    }
                }

                // Print class-specific metrics
                Console.WriteLine("Class-Specific Metrics:");
                foreach (var kvp in singleLabelSummary.CustomSingleLabelClassificationEvaluation.Classes)
                {
                    Console.WriteLine($"Class: {kvp.Key}");
                    Console.WriteLine($"    F1: {kvp.Value.F1}");
                    Console.WriteLine($"    Precision: {kvp.Value.Precision}");
                    Console.WriteLine($"    Recall: {kvp.Value.Recall}");
                    Console.WriteLine($"    True Positives: {kvp.Value.TruePositiveCount}");
                    Console.WriteLine($"    True Negatives: {kvp.Value.TrueNegativeCount}");
                    Console.WriteLine($"    False Positives: {kvp.Value.FalsePositiveCount}");
                    Console.WriteLine($"    False Negatives: {kvp.Value.FalseNegativeCount}");
                }
            }
            else
            {
                Console.WriteLine("The returned evaluation summary is not for a single-label classification project.");
            }
            #endregion
        }
    }
}
