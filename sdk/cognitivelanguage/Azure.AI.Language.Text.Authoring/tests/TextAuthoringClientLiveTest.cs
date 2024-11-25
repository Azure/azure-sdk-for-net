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

namespace Azure.AI.Language.Text.Authoring.Tests
{
    public class TextAuthoringClientLiveTest : TextAuthoringTestBase
    {
        public TextAuthoringClientLiveTest(bool isAsync, AuthoringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task GetProjectAsync()
        {
            // Arrange
            string projectName = "MyTextProjectAsync";

            // Act
            Response<ProjectMetadata> response = await client.GetProjectAsync(projectName);
            ProjectMetadata projectMetadata = response.Value;

            // Assert
            Assert.IsNotNull(projectMetadata);
            Assert.AreEqual(projectName, projectMetadata.ProjectName);
            Assert.IsNotNull(projectMetadata.Language);
            Assert.IsNotNull(projectMetadata.CreatedDateTime);
            Assert.IsNotNull(projectMetadata.LastModifiedDateTime);

            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedDateTime}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedDateTime}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
        }

        [RecordedTest]
        public async Task ImportAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";

            var projectMetadata = new CreateProjectConfig(
                projectKind: "CustomEntityRecognition",
                storageInputContainerName: "loanagreements",
                projectName: projectName,
                language: "en"
            )
            {
                Description = "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
                Multilingual = false,
                Settings = new ProjectSettings()
            };

            var projectAssets = new ExportedCustomEntityRecognitionProjectAssets
            {
                Entities =
                {
                    new ExportedEntity { Category = "Date" },
                    new ExportedEntity { Category = "LenderName" },
                    new ExportedEntity { Category = "LenderAddress" }
                },
                Documents =
                {
                    new ExportedCustomEntityRecognitionDocument
                    {
                        Location = "01.txt",
                        Language = "en-us",
                        Dataset = "Train",
                        Entities =
                        {
                            new ExportedDocumentEntityRegion
                            {
                                RegionOffset = 0,
                                RegionLength = 1793,
                                Labels =
                                {
                                    new ExportedDocumentEntityLabel { Category = "Date", Offset = 5, Length = 9 },
                                    new ExportedDocumentEntityLabel { Category = "LenderName", Offset = 273, Length = 14 },
                                    new ExportedDocumentEntityLabel { Category = "LenderAddress", Offset = 314, Length = 15 }
                                }
                            }
                        }
                    },
                    new ExportedCustomEntityRecognitionDocument
                    {
                        Location = "02.txt",
                        Language = "en-us",
                        Dataset = "Train",
                        Entities =
                        {
                            new ExportedDocumentEntityRegion
                            {
                                RegionOffset = 0,
                                RegionLength = 1804,
                                Labels =
                                {
                                    new ExportedDocumentEntityLabel { Category = "Date", Offset = 5, Length = 10 },
                                    new ExportedDocumentEntityLabel { Category = "LenderName", Offset = 284, Length = 10 },
                                    new ExportedDocumentEntityLabel { Category = "LenderAddress", Offset = 321, Length = 20 }
                                }
                            }
                        }
                    }
                }
            };

            var exportedProject = new ExportedProject(
                projectFileVersion: "2022-05-01",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata)
            {
                Assets = projectAssets
            };

            // Act
            Operation operation = await client.ImportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: exportedProject
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status);

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task CreateProjectAsync()
        {
            // Arrange
            string projectName = "MyTextProject";
            var projectData = new
            {
                projectName = projectName,
                language = "en",
                projectKind = "CustomEntityRecognition",
                description = "Project description for a Custom Entity Recognition project",
                multilingual = true,
                storageInputContainerName = "loanagreements"
            };

            using RequestContent content = RequestContent.Create(projectData);

            // Act
            Response response = await client.CreateProjectAsync(projectName, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(201, response.Status, "Expected the status to indicate project creation success.");

            // Logging for additional context
            Console.WriteLine($"Project created with status: {response.Status}");
        }

        [RecordedTest]
        public async Task DeleteProjectAsync()
        {
            // Arrange
            string projectName = "ProjectToDelete";

            // Act
            Operation operation = await client.DeleteProjectAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate project deletion success.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task TrainAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";

            var trainingJobConfig = new TrainingJobConfig(
                modelLabel: "model1",
                trainingConfigVersion: "latest"
            )
            {
                EvaluationOptions = new EvaluationConfig
                {
                    Kind = EvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };

            // Act
            Operation<TrainingJobResult> operation = await client.TrainAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: trainingJobConfig
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful training.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task CancelTrainingJobAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            string jobId = "training-job-id"; // Replace with an actual job ID.

            // Act
            Operation<TrainingJobResult> operation = await client.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                jobId: jobId
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful cancellation.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task GetModelEvaluationSummaryAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            string trainedModelLabel = "model2";

            // Act
            Response<EvaluationSummary> evaluationSummaryResponse = await client.GetModelEvaluationSummaryAsync(projectName, trainedModelLabel);

            EvaluationSummary evaluationSummary = evaluationSummaryResponse.Value;

            // Assert
            Assert.IsNotNull(evaluationSummary, "Evaluation summary should not be null.");

            // Specific type assertion for single-label classification
            if (evaluationSummary is CustomSingleLabelClassificationEvaluationSummary singleLabelSummary)
            {
                Assert.IsNotNull(singleLabelSummary.EvaluationOptions, "Evaluation options should not be null.");
                Assert.IsNotNull(singleLabelSummary.CustomSingleLabelClassificationEvaluation, "Evaluation metrics should not be null.");
                Assert.IsNotEmpty(singleLabelSummary.CustomSingleLabelClassificationEvaluation.Classes, "Class-specific metrics should not be empty.");

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
                Assert.Fail("Unexpected evaluation summary type.");
            }
        }

        [RecordedTest]
        public async Task LoadSnapshotAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            string trainedModelLabel = "ModelLabel"; // Replace with your actual model label.

            // Act
            Operation operation = await client.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful snapshot loading.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task DeleteTrainedModelAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            string trainedModelLabel = "ModelLabel"; // Replace with the actual model label.

            // Act
            Response response = await client.DeleteTrainedModelAsync(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(204, response.Status, "Expected the status to indicate successful deletion.");

            // Logging for additional context
            Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
        }

        [RecordedTest]
        public async Task DeployProjectAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            string deploymentName = "DeploymentName";
            var deploymentConfig = new CreateDeploymentConfig(trainedModelLabel: "29886710a2ae49259d62cffca977db66");

            // Act
            Operation operation = await client.DeployProjectAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName,
                body: deploymentConfig
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful deployment.");

            // Logging for additional context
            Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task SwapDeploymentsAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            var swapConfig = new SwapDeploymentsConfig(
                firstDeploymentName: "DeploymentA",
                secondDeploymentName: "DeploymentB"
            );

            // Act
            Operation operation = await client.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: swapConfig
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful swap.");

            // Logging for additional context
            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task DeleteDeploymentAsync()
        {
            // Arrange
            string projectName = "LoanAgreements";
            string deploymentName = "DeploymentA";

            // Act
            Operation operation = await client.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate successful deletion.");

            // Logging for additional context
            Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
        }
    }
}
