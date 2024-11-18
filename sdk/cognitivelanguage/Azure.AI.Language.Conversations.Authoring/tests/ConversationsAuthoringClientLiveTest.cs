// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core.TestFramework;
using Azure.AI.Language.Conversations.Authoring.Models;
using System.Collections.Generic;
using System.Threading;

namespace Azure.AI.Language.Conversations.Authoring.Tests
{
    public class ConversationsAuthoringClientLiveTest : ConversationAuthoringTestBase
    {
        public ConversationsAuthoringClientLiveTest(bool isAsync, AuthoringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task CreateProjectAsync()
        {
            // Arrange
            string projectName = "MyNewProjectAsync";
            var projectData = new
            {
                projectName = projectName,
                language = "en",
                projectKind = "Conversation",
                description = "Project description",
                multilingual = true
            };

            // Convert to RequestContent
            using RequestContent content = RequestContent.Create(projectData);

            // Act
            Response response = await client.CreateProjectAsync(projectName, content);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(201, response.Status);

            Console.WriteLine($"Project created with status: {response.Status}");
        }

        [RecordedTest]
        public async Task ImportProjectAsync()
        {
            string projectName = "MyImportedProjectAsync";

            var projectMetadata = new CreateProjectConfig(
                projectKind: "Conversation",
                projectName: projectName,
                language: "en"
            )
            {
                Settings = new ProjectSettings(0.7F),
                Multilingual = true,
                Description = "Trying out CLU with assets"
            };

            var projectAssets = new ConversationExportedProjectAssets();

            projectAssets.Intents.Add(new ConversationExportedIntent(category: "intent1"));
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "intent2"));

            projectAssets.Entities.Add(new ConversationExportedEntity(category: "entity1"));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "text1",
                intent: "intent1"
            )
            {
                Language = "en",
                Dataset = "dataset1"
            });

            projectAssets.Utterances[projectAssets.Utterances.Count - 1].Entities.Add(new ExportedUtteranceEntityLabel(
                category: "entity1",
                offset: 5,
                length: 5
            ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "text2",
                intent: "intent2"
            )
            {
                Language = "en",
                Dataset = "dataset1"
            });

            var exportedProject = new ExportedProject(
                projectFileVersion: "2023-10-01",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            Operation operation = await client.ImportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: exportedProject,
                exportedProjectFormat: ExportedProjectFormat.Conversation
            );

            // Assert the operation and response
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and check the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");

            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task ExportProjectAsync()
        {
            // Arrange
            string projectName = "MyExportedProjectAsync";

            // Act
            Operation operation = await client.ExportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                stringIndexType: StringIndexType.Utf16CodeUnit,
                exportedProjectFormat: ExportedProjectFormat.Conversation
            );

            // Assert
            Assert.IsNotNull(operation, "The export operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and check the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");

            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task GetProjectAsync()
        {
            // Arrange
            string projectName = "MySampleProjectAsync";

            // Act
            Response<ProjectMetadata> response = await client.GetProjectAsync(projectName);
            ProjectMetadata projectMetadata = response.Value;

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.IsNotNull(projectMetadata, "The project metadata should not be null.");
            Assert.AreEqual(projectName, projectMetadata.ProjectName, "The project name in the response does not match the requested project name.");
            Assert.IsNotNull(projectMetadata.CreatedDateTime, "Created DateTime should not be null.");
            Assert.IsNotNull(projectMetadata.LastModifiedDateTime, "Last Modified DateTime should not be null.");
            Assert.IsNotNull(projectMetadata.LastTrainedDateTime, "Last Trained DateTime should not be null.");
            Assert.IsNotNull(projectMetadata.LastDeployedDateTime, "Last Deployed DateTime should not be null.");
            Assert.IsNotNull(projectMetadata.ProjectKind, "Project Kind should not be null.");
            Assert.IsNotNull(projectMetadata.ProjectName, "Project Name should not be null.");
            Assert.IsNotNull(projectMetadata.Multilingual, "Multilingual property should not be null.");
            Assert.IsNotNull(projectMetadata.Description, "Description should not be null.");
            Assert.IsNotNull(projectMetadata.Language, "Language should not be null.");
        }

        [RecordedTest]
        public async Task DeleteProjectAsync()
        {
            // Arrange
            string projectName = "MySampleProjectAsync";

            // Act
            Operation operation = await client.DeleteProjectAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and validate the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task TrainAsync()
        {
            // Arrange
            string projectName = "MySampleProjectAsync";

            var trainingJobConfig = new TrainingJobConfig(
                modelLabel: "MyModel",
                trainingMode: TrainingMode.Standard
            )
            {
                TrainingConfigVersion = "1.0",
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
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and validate the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task CancelTrainingJobAsync()
        {
            // Arrange
            string projectName = "MyProject";
            string jobId = "YourTrainingJobId";

            // Act
            Operation<TrainingJobResult> cancelOperation = await client.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                jobId: jobId
            );

            // Assert
            Assert.IsNotNull(cancelOperation, "The cancellation operation should not be null.");
            Assert.AreEqual(200, cancelOperation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and validate the operation-location header
            string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task GetModelEvaluationSummaryAsync()
        {
            // Arrange
            string projectName = "MyProject";
            string trainedModelLabel = "YourTrainedModelLabel";

            // Act
            Response<EvaluationSummary> evaluationSummaryResponse = await client.GetModelEvaluationSummaryAsync(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            // Assert
            Assert.IsNotNull(evaluationSummaryResponse, "The evaluation summary response should not be null.");
            var evaluationSummary = evaluationSummaryResponse.Value;
            Assert.IsNotNull(evaluationSummary, "The evaluation summary value should not be null.");

            // Entities evaluation summary
            var entitiesEval = evaluationSummary.EntitiesEvaluation;
            Assert.IsNotNull(entitiesEval, "Entities evaluation summary should not be null.");
            Assert.IsNotNull(entitiesEval.Entities, "Entities collection should not be null.");
            Assert.IsNotNull(entitiesEval.MicroF1, "Entities Micro F1 should not be null.");
            Assert.IsNotNull(entitiesEval.MicroPrecision, "Entities Micro Precision should not be null.");
            Assert.IsNotNull(entitiesEval.MicroRecall, "Entities Micro Recall should not be null.");
            Assert.IsNotNull(entitiesEval.MacroF1, "Entities Macro F1 should not be null.");
            Assert.IsNotNull(entitiesEval.MacroPrecision, "Entities Macro Precision should not be null.");
            Assert.IsNotNull(entitiesEval.MacroRecall, "Entities Macro Recall should not be null.");

            foreach (var entity in entitiesEval.Entities)
            {
                Assert.IsNotNull(entity.Key, "Entity key should not be null.");
                Assert.IsNotNull(entity.Value.F1, $"F1 score for entity '{entity.Key}' should not be null.");
                Assert.IsNotNull(entity.Value.Precision, $"Precision for entity '{entity.Key}' should not be null.");
                Assert.IsNotNull(entity.Value.Recall, $"Recall for entity '{entity.Key}' should not be null.");
                Assert.IsNotNull(entity.Value.TruePositiveCount, $"True Positives for entity '{entity.Key}' should not be null.");
                Assert.IsNotNull(entity.Value.TrueNegativeCount, $"True Negatives for entity '{entity.Key}' should not be null.");
                Assert.IsNotNull(entity.Value.FalsePositiveCount, $"False Positives for entity '{entity.Key}' should not be null.");
                Assert.IsNotNull(entity.Value.FalseNegativeCount, $"False Negatives for entity '{entity.Key}' should not be null.");
            }

            // Intents evaluation summary
            var intentsEval = evaluationSummary.IntentsEvaluation;
            Assert.IsNotNull(intentsEval, "Intents evaluation summary should not be null.");
            Assert.IsNotNull(intentsEval.Intents, "Intents collection should not be null.");
            Assert.IsNotNull(intentsEval.MicroF1, "Intents Micro F1 should not be null.");
            Assert.IsNotNull(intentsEval.MicroPrecision, "Intents Micro Precision should not be null.");
            Assert.IsNotNull(intentsEval.MicroRecall, "Intents Micro Recall should not be null.");
            Assert.IsNotNull(intentsEval.MacroF1, "Intents Macro F1 should not be null.");
            Assert.IsNotNull(intentsEval.MacroPrecision, "Intents Macro Precision should not be null.");
            Assert.IsNotNull(intentsEval.MacroRecall, "Intents Macro Recall should not be null.");

            foreach (var intent in intentsEval.Intents)
            {
                Assert.IsNotNull(intent.Key, "Intent key should not be null.");
                Assert.IsNotNull(intent.Value.F1, $"F1 score for intent '{intent.Key}' should not be null.");
                Assert.IsNotNull(intent.Value.Precision, $"Precision for intent '{intent.Key}' should not be null.");
                Assert.IsNotNull(intent.Value.Recall, $"Recall for intent '{intent.Key}' should not be null.");
                Assert.IsNotNull(intent.Value.TruePositiveCount, $"True Positives for intent '{intent.Key}' should not be null.");
                Assert.IsNotNull(intent.Value.TrueNegativeCount, $"True Negatives for intent '{intent.Key}' should not be null.");
                Assert.IsNotNull(intent.Value.FalsePositiveCount, $"False Positives for intent '{intent.Key}' should not be null.");
                Assert.IsNotNull(intent.Value.FalseNegativeCount, $"False Negatives for intent '{intent.Key}' should not be null.");
            }
        }

        [RecordedTest]
        public async Task GetModelEvaluationResultsAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string trainedModelLabel = "SampleModel";
            StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

            // Act
            AsyncPageable<UtteranceEvaluationResult> results = client.GetModelEvaluationResultsAsync(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel,
                stringIndexType: stringIndexType
            );

            // Assert
            Assert.IsNotNull(results, "The evaluation results should not be null.");

            await foreach (UtteranceEvaluationResult result in results)
            {
                // Validate text and language
                Assert.IsNotNull(result.Text, "The result text should not be null.");
                Assert.IsNotNull(result.Language, "The result language should not be null.");

                // Validate intents result
                Assert.IsNotNull(result.IntentsResult, "The intents result should not be null.");
                Assert.IsNotNull(result.IntentsResult.ExpectedIntent, "The expected intent should not be null.");
                Assert.IsNotNull(result.IntentsResult.PredictedIntent, "The predicted intent should not be null.");

                // Validate entities result
                Assert.IsNotNull(result.EntitiesResult, "The entities result should not be null.");
                Assert.IsNotNull(result.EntitiesResult.ExpectedEntities, "The expected entities list should not be null.");
                Assert.IsNotNull(result.EntitiesResult.PredictedEntities, "The predicted entities list should not be null.");

                foreach (var entity in result.EntitiesResult.ExpectedEntities)
                {
                    Assert.IsNotNull(entity.Category, "The expected entity category should not be null.");
                    Assert.IsTrue(entity.Offset >= 0, "The expected entity offset should be non-negative.");
                    Assert.IsTrue(entity.Length > 0, "The expected entity length should be positive.");
                }

                foreach (var entity in result.EntitiesResult.PredictedEntities)
                {
                    Assert.IsNotNull(entity.Category, "The predicted entity category should not be null.");
                    Assert.IsTrue(entity.Offset >= 0, "The predicted entity offset should be non-negative.");
                    Assert.IsTrue(entity.Length > 0, "The predicted entity length should be positive.");
                }
            }
        }

        [RecordedTest]
        public async Task LoadSnapshotAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string trainedModelLabel = "SampleModel";

            // Act
            Operation operation = await client.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            // Assert
            Assert.IsNotNull(operation, "The operation result should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task DeleteTrainedModelAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string trainedModelLabel = "SampleModel";

            // Act
            Response response = await client.DeleteTrainedModelAsync(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.AreEqual(204, response.Status, "Expected status to be 204 (No Content) indicating successful deletion.");
        }

        [RecordedTest]
        public async Task GetDeploymentStatusAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string deploymentName = "SampleDeployment";
            string jobId = "SampleJobId";

            // Act
            Response<DeploymentJobState> response = await client.GetDeploymentStatusAsync(
                projectName: projectName,
                deploymentName: deploymentName,
                jobId: jobId
            );

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected status to be 200 (OK).");

            var jobState = response.Value;
            Assert.IsNotNull(jobState, "The deployment job state should not be null.");
            Assert.IsNotNull(jobState.JobId, "The JobId should not be null.");
            Assert.IsNotNull(jobState.CreatedDateTime, "The CreatedDateTime should not be null.");
            Assert.IsNotNull(jobState.LastUpdatedDateTime, "The LastUpdatedDateTime should not be null.");
            Assert.IsNotNull(jobState.ExpirationDateTime, "The ExpirationDateTime should not be null.");
            Assert.IsNotNull(jobState.Status, "The Status should not be null.");
        }

        [RecordedTest]
        public async Task SwapDeploymentsAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            var swapConfig = new SwapDeploymentsConfig("production", "staging");

            // Act
            Operation operation = await client.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: swapConfig
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task DeleteDeploymentAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string deploymentName = "SampleDeployment";

            // Act
            Operation operation = await client.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task AssignDeploymentResourcesAsync()
        {
            // Arrange
            string projectName = "SampleProject";

            // Define resources metadata
            var resourcesMetadata = new List<ResourceMetadata>
            {
                new ResourceMetadata(
                    azureResourceId: "SampleAzureResourceId",
                    customDomain: "SampleCustomDomain",
                    region: "SampleRegionCode"
                )
            };

            var assignConfig = new AssignDeploymentResourcesConfig(resourcesMetadata);

            // Act
            Operation operation = await client.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: assignConfig
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task GetAssignDeploymentResourcesStatusAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string jobId = "SampleJobId";

            Response<DeploymentResourcesJobState> response;

            // Act & Assert
            do
            {
                response = await client.GetAssignDeploymentResourcesStatusAsync(
                    projectName: projectName,
                    jobId: jobId
                );

                Assert.IsNotNull(response, "The response should not be null.");
                Assert.IsNotNull(response.Value, "The response value should not be null.");
                Assert.IsNotNull(response.Value.JobId, "The Job ID should not be null.");
                Assert.IsNotNull(response.Value.Status, "The Job status should not be null.");
                Assert.IsNotNull(response.Value.CreatedDateTime, "The Created Date Time should not be null.");
                Assert.IsNotNull(response.Value.LastUpdatedDateTime, "The Last Updated Date Time should not be null.");
                Assert.IsNotNull(response.Value.ExpirationDateTime, "The Expiration Date Time should not be null.");

                // Assert that the job eventually succeeds (polling)
                if (response.Value.Status != JobStatus.Succeeded)
                {
                    Thread.Sleep(2000); // Wait before the next poll
                }
            } while (response.Value.Status != JobStatus.Succeeded);
        }

        [RecordedTest]
        public async Task UnassignDeploymentResourcesAsync()
        {
            // Arrange
            string projectName = "SampleProject";

            var unassignConfig = new UnassignDeploymentResourcesConfig(
                assignedResourceIds: new List<string> { "SampleAzureResourceId" }
            );

            // Act
            Operation operation = await client.UnassignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: unassignConfig
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Validate the presence of operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "The operation-location header should not be null.");
        }

        [RecordedTest]
        public async Task GetUnassignDeploymentResourcesStatusAsync()
        {
            // Arrange
            string projectName = "SampleProject";
            string jobId = "SampleJobId";

            // Act and Assert
            Response<DeploymentResourcesJobState> response;

            do
            {
                response = await client.GetUnassignDeploymentResourcesStatusAsync(
                    projectName: projectName,
                    jobId: jobId
                );

                Assert.IsNotNull(response, "Response should not be null.");
                Assert.IsNotNull(response.Value, "Response value should not be null.");

                // Validate job details
                Assert.AreEqual(jobId, response.Value.JobId, "Job ID mismatch.");
                Assert.IsNotNull(response.Value.Status, "Job status should not be null.");
                Assert.IsNotNull(response.Value.CreatedDateTime, "CreatedDateTime should not be null.");
                Assert.IsNotNull(response.Value.LastUpdatedDateTime, "LastUpdatedDateTime should not be null.");
                Assert.IsNotNull(response.Value.ExpirationDateTime, "ExpirationDateTime should not be null.");

                if (response.Value.Status != JobStatus.Succeeded)
                {
                    // Wait before polling again
                    await Task.Delay(2000);
                }
            }
            while (response.Value.Status != JobStatus.Succeeded);
        }
    }
}
