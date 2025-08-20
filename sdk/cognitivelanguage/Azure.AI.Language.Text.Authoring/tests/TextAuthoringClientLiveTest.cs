// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Text.Json;
using System.Security.Claims;
using Azure.Core.Serialization;

namespace Azure.AI.Language.Text.Authoring.Tests
{
    public class TextAuthoringClientLiveTest : TextAuthoringTestBase
    {
        public TextAuthoringClientLiveTest(bool isAsync, TextAnalysisAuthoringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task GetProjectAsync()
        {
            // Arrange
            string projectName = "MyTextProject";
            TextAuthoringProject projectClient = client.GetProject(projectName);
            // Act
            Response<TextAuthoringProjectMetadata> response = await projectClient.GetProjectAsync();
            TextAuthoringProjectMetadata projectMetadata = response.Value;

            // Assert
            Assert.IsNotNull(projectMetadata);
            Assert.AreEqual(projectName, projectMetadata.ProjectName);
            Assert.IsNotNull(projectMetadata.Language);
            Assert.IsNotNull(projectMetadata.CreatedOn);
            Assert.IsNotNull(projectMetadata.LastModifiedOn);

            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
        }

        [RecordedTest]
        public async Task ImportAsync()
        {
            // Arrange
            string projectName = "MyImportTextProject";

            var projectMetadata = new TextAuthoringCreateProjectDetails(
                projectKind: "CustomSingleLabelClassification",
                storageInputContainerName: "test-data",
                language: "en"
            )
            {
                Description = "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
                Multilingual = false,
                Settings = new TextAuthoringProjectSettings()
            };

            var projectAssets = new ExportedCustomSingleLabelClassificationProjectAsset
            {
                Classes =
                {
                    new TextAuthoringExportedClass { Category = "Date" },
                    new TextAuthoringExportedClass { Category = "LenderName" },
                    new TextAuthoringExportedClass { Category = "LenderAddress" }
                },
                Documents =
                {
                    new ExportedCustomSingleLabelClassificationDocument
                    {
                        Class= new ExportedDocumentClass{ Category = "Date" },
                        Location = "01.txt",
                        Language = "en"
                    },
                    new ExportedCustomSingleLabelClassificationDocument
                    {
                        Class= new ExportedDocumentClass{ Category = "LenderName" },
                        Location = "02.txt",
                        Language = "en"
                    }
                }
            };

            var exportedProject = new TextAuthoringExportedProject(
                projectFileVersion: "2022-05-01",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata)
            {
                Assets = projectAssets
            };

            TextAuthoringProject projectClient = client.GetProject(projectName);
            // Act
            Operation operation = await projectClient.ImportAsync(
                waitUntil: WaitUntil.Completed,
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
            string projectName = "MyTextProject001";
            var projectMetadata = new TextAuthoringCreateProjectDetails(
                projectKind: "customMultiLabelClassification",
                storageInputContainerName: "e2e0test0data",
                language: "en"
            )
            {
                Description = "Project description for a Custom Entity Recognition project",
                Multilingual = true
            };

            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Act
            Response response = await projectClient.CreateProjectAsync(projectMetadata);

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
            string projectName = "MyTextProject";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Act
            Operation operation = await projectClient.DeleteProjectAsync(
                waitUntil: WaitUntil.Completed
                );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate project deletion success.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task TrainAsync()
        {
            // Arrange
            string projectName = "MyTextProject001";

            var trainingJobDetails = new TextAuthoringTrainingJobDetails(
                modelLabel: "model1",
                trainingConfigVersion: "2022-05-01"
            )
            {
                EvaluationOptions = new TextAuthoringEvaluationDetails
                {
                    Kind = TextAuthoringEvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };
            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Act
            Operation<TextAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
                waitUntil: WaitUntil.Started,
                details: trainingJobDetails
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected the status to indicate successful training.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task CancelTrainingJobAsync()
        {
            // Arrange
            string projectName = "test001";
            string jobId = "05a7d735-cd04-4402-8aa8-131775ed1bb6_638765568000000000"; // Replace with an actual job ID.
            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Act
            Operation<TextAuthoringTrainingJobResult> operation = await projectClient.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Started,
                jobId: jobId
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected the status to indicate successful cancellation.");

            // Logging for additional context
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task GetModelEvaluationSummaryAsync()
        {
            // Arrange
            string projectName = "test001";
            string trainedModelLabel = "m1";
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            // Act
            Response<TextAuthoringEvalSummary> evaluationSummaryResponse = await trainedModelClient.GetModelEvaluationSummaryAsync();

            TextAuthoringEvalSummary evaluationSummary = evaluationSummaryResponse.Value;

            // Assert
            Assert.IsNotNull(evaluationSummary, "Evaluation summary should not be null.");

            // Specific type assertion for single-label classification
            if (evaluationSummary is CustomSingleLabelClassificationEvalSummary singleLabelSummary)
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
                Assert.Fail("Unexpected evaluation summary type.");
            }
        }

        [RecordedTest]
        public async Task LoadSnapshotAsync()
        {
            // Arrange
            string projectName = "test001";
            string trainedModelLabel = "m1"; // Replace with your actual model label.
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            // Act
            Operation operation = await trainedModelClient.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed
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
            string projectName = "MyTextProject";
            string trainedModelLabel = "model1"; // Replace with the actual model label.
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            // Act
            Response response = await trainedModelClient.DeleteTrainedModelAsync();

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
            string projectName = "MyTextProject";
            string deploymentName = "deployment1";
            var deploymentDetails = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "m2");

            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);
            // Act
            Operation operation = await deploymentClient.DeployProjectAsync(
                waitUntil: WaitUntil.Completed,
                details: deploymentDetails
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
            string projectName = "MyTextProject";
            var swapDetails = new TextAuthoringSwapDeploymentsDetails(
                firstDeploymentName: "deployment1",
                secondDeploymentName: "deployment2"
            );
            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Act
            Operation operation = await projectClient.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
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
            string projectName = "MyTextProject";
            string deploymentName = "deployment2";
            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            // Act
            Operation operation = await deploymentClient.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful deletion.");

            // Logging for additional context
            Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
        }
    }
}
