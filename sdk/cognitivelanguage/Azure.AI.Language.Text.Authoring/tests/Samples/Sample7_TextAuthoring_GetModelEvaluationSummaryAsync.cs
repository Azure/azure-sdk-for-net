// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Text.Json;
using Azure.Core.Serialization;

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
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample7_TextAuthoring_GetSingleLabelClassificationEvaluationSummaryAsync
            string projectName = "LoanAgreements";
            string trainedModelLabel = "model2";
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            // Get the evaluation summary for the trained model
            Response<TextAuthoringEvalSummary> evaluationSummaryResponse = await trainedModelClient.GetModelEvaluationSummaryAsync();

            TextAuthoringEvalSummary evaluationSummary = evaluationSummaryResponse.Value;

            // Cast to the specific evaluation summary type for custom single label classification
            if (evaluationSummary is CustomSingleLabelClassificationEvalSummary singleLabelSummary)
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
                foreach (var row in singleLabelSummary.CustomSingleLabelClassificationEvaluation.ConfusionMatrix)
                {
                    Console.WriteLine($"Row: {row.Key}");
                    foreach (var col in row.Value.AdditionalProperties)
                    {
                        try
                        {
                            // Deserialize BinaryData properly
                            var cell = col.Value.ToObject<TextAuthoringConfusionMatrixCell>(new JsonObjectSerializer());
                            Console.WriteLine($"    Column: {col.Key}, Normalized Value: {cell.NormalizedValue}, Raw Value: {cell.RawValue}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"    Error deserializing column {col.Key}: {ex.Message}");
                        }
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
