// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

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
            string projectName = "MyTextProject001";
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
            Assert.IsNotNull(projectMetadata.StorageInputContainerName);

            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            Console.WriteLine($"StorageInputContainerName: {projectMetadata.StorageInputContainerName}");
        }

        [RecordedTest]
        public async Task ImportAsync()
        {
            // Arrange
            string projectName = "MyImportTextProject0717";

            var projectMetadata = new TextAuthoringCreateProjectDetails(
                projectKind: "CustomSingleLabelClassification",
                storageInputContainerName: "single-class-example",
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
        public async Task ImportRawStringAsync()
        {
            // Arrange
            string projectName = "MyImportTextProjectRaw0718";

            string rawJson = """
            {
              "projectFileVersion": "2025-05-15-preview",
              "stringIndexType": "Utf16CodeUnit",
              "metadata": {
                "projectKind": "CustomSingleLabelClassification",
                "storageInputContainerName": "single-class-example",
                "language": "en",
                "description": "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
                "multilingual": false,
                "settings": {}
              },
              "assets": {
                "projectKind": "CustomSingleLabelClassification",
                "classes": [
                  { "category": "Date" },
                  { "category": "LenderName" },
                  { "category": "LenderAddress" }
                ],
                "documents": [
                  {
                    "class": { "category": "Date" },
                    "location": "01.txt",
                    "language": "en"
                  },
                  {
                    "class": { "category": "LenderName" },
                    "location": "02.txt",
                    "language": "en"
                  }
                ]
              }
            }
            """;

            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Act
            Operation operation = await projectClient.ImportAsync(
                waitUntil: WaitUntil.Started,
                projectJson: rawJson
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(202, operation.GetRawResponse().Status);

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
                storageInputContainerName: "multi-class-example",
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
            string projectName = "MyImportTextProject";
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
            string projectName = "single-class-project";

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
            string projectName = "single-class-project";
            string jobId = "a0f21063-df96-49ea-b275-2c50b4c5fe33_638864928000000000"; // Replace with an actual job ID.
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
            string projectName = "single-class-project";
            string trainedModelLabel = "model1";
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
            string projectName = "single-class-project";
            string trainedModelLabel = "model1";
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
            string projectName = "single-class-project";
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
            string projectName = "single-class-project";
            string deploymentName = "deployment1";
            var deploymentDetails = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "model1");

            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);
            // Act
            Operation operation = await deploymentClient.DeployProjectAsync(
                waitUntil: WaitUntil.Started,
                details: deploymentDetails
            );

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected the status to indicate successful deployment.");

            // Logging for additional context
            Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task SwapDeploymentsAsync()
        {
            // Arrange
            string projectName = "single-class-project";
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
            string projectName = "single-class-project";
            string deploymentName = "singleclassdeployment";
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

        [RecordedTest]
        public async Task ExportProjectAsync()
        {
            // Arrange
            string projectName = "single-class-project";

            TextAuthoringProject projectAuthoringClient = client.GetProject(projectName);

            // Act
            Operation operation = await projectAuthoringClient.ExportAsync(
                waitUntil: WaitUntil.Completed,
                stringIndexType: StringIndexType.Utf16CodeUnit);

            // Assert
            Assert.IsNotNull(operation, "The export operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and check the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;

            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task GetModelEvaluationResultsAsync()
        {
            // Arrange
            string projectName = "single-class-project";
            string trainedModelLabel = "model1";
            StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

            TextAuthoringTrainedModel trainedModelAuthoringClient = client.GetTrainedModel(projectName, trainedModelLabel);

            // Act
            AsyncPageable<TextAuthoringDocumentEvalResult> results = trainedModelAuthoringClient.GetModelEvaluationResultsAsync(
                stringIndexType: stringIndexType
            );

            // Assert
            Assert.IsNotNull(results, "The evaluation results should not be null.");

            await foreach (TextAuthoringDocumentEvalResult result in results)
            {
                // Validate base properties
                Assert.IsNotNull(result, "The result should not be null.");
                Assert.IsNotNull(result.Location, "The result location should not be null.");
                Assert.IsNotNull(result.Language, "The result language should not be null.");

                // Validate classification result
                if (result is CustomSingleLabelClassificationDocumentEvalResult singleLabelResult)
                {
                    var classification = singleLabelResult.CustomSingleLabelClassificationResult;

                    Assert.IsNotNull(classification, "The classification result should not be null.");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(classification.ExpectedClass), "The expected class should not be null or empty.");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(classification.PredictedClass), "The predicted class should not be null or empty.");
                }
                else
                {
                    Assert.Fail($"Unsupported result type: {result.GetType().Name}");
                }
            }
        }

        [RecordedTest]
        public async Task GetDeploymentAsync()
        {
            // Arrange
            string projectName = "single-class-project";
            string deploymentName = "deployment1";

            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            // Act
            Response<TextAuthoringProjectDeployment> response = await deploymentClient.GetDeploymentAsync();

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected status to be 200 (OK).");

            TextAuthoringProjectDeployment deployment = response.Value;

            Assert.IsNotNull(deployment, "Deployment details should not be null.");
            Assert.IsNotNull(deployment.DeploymentName, "DeploymentName should not be null.");
            Assert.IsNotNull(deployment.ModelId, "ModelId should not be null.");
            Assert.IsNotNull(deployment.LastTrainedOn, "LastTrainedOn should not be null.");
            Assert.IsNotNull(deployment.LastDeployedOn, "LastDeployedOn should not be null.");
            Assert.IsNotNull(deployment.DeploymentExpiredOn, "DeploymentExpiredOn should not be null.");
            Assert.IsNotNull(deployment.ModelTrainingConfigVersion, "ModelTrainingConfigVersion should not be null.");
        }
    }
}
