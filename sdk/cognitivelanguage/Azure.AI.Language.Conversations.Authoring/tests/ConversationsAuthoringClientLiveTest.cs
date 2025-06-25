// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests
{
    public class ConversationsAuthoringClientLiveTest : ConversationAuthoringTestBase
    {
        public ConversationsAuthoringClientLiveTest(bool isAsync, ConversationAnalysisAuthoringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task CreateProjectAsync()
        {
            // Arrange
            string projectName = "NewProject001";
            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            var projectData = new ConversationAuthoringCreateProjectDetails(
                  projectKind: "Conversation",
                  language: "en-us"
                )
            {
                Multilingual = true,
                Description = "Project description"
            };

            // Act
            Response response = await projectAuthoringClient.CreateProjectAsync(projectData);

            // Assert
            Assert.IsNotNull(response);
            //Assert.AreEqual(201, response.Status);

            Console.WriteLine($"Project created with status: {response.Status}");
        }

        [RecordedTest]
        public async Task ImportProjectAsync()
        {
            string projectName = "Test-data-labels";

            // Create metadata based on JSON data
            var projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                language: "en-us"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.0F), // ConfidenceThreshold set to 0
                Multilingual = false,
                Description = string.Empty
            };

            // Create assets based on JSON data
            var projectAssets = new ConversationExportedProjectAsset();

            projectAssets.Intents.Add(new ConversationExportedIntent(category: "None"));
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "Buy"));

            var entity = new ConversationExportedEntity(category: "product")
            {
                CompositionMode = ConversationAuthoringCompositionMode.CombineComponents
            };
            projectAssets.Entities.Add(entity);

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "I want to buy a house",
                intent: "Buy"
            )
            {
                Language = "en-us",
                Dataset = "Train"
            });
            projectAssets.Utterances[0].Entities.Add(new ExportedUtteranceEntityLabel(
                category: "product",
                offset: 16,
                length: 5
            ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "I want to buy surface pro",
                intent: "Buy"
            )
            {
                Language = "en-us",
                Dataset = "Train"
            });
            projectAssets.Utterances[1].Entities.Add(new ExportedUtteranceEntityLabel(
                category: "product",
                offset: 14,
                length: 11
            ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "I want to buy xbox",
                intent: "Buy"
            )
            {
                Language = "en-us",
                Dataset = "Train"
            });
            projectAssets.Utterances[2].Entities.Add(new ExportedUtteranceEntityLabel(
                category: "product",
                offset: 14,
                length: 4
            ));

            // Build the exported project
            var exportedProject = new ConversationAuthoringExportedProject(
                projectFileVersion: "2022-10-01-preview",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            // Call the ImportAsync function
            Operation operation = await projectAuthoringClient.ImportAsync(
                waitUntil: WaitUntil.Completed,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Assert the operation and response
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and check the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task ImportProjectAsync_WithAssignedResourcesAndMetadata()
        {
            // Arrange
            string projectName = "TestImportedApp0623";

            // Create metadata
            var projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                language: "en-us"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.7F), // ConfidenceThreshold = 0.7
                Multilingual = true,
                Description = "Trying out CLU",
                ProjectName = projectName
            };

            // Create assets
            var projectAssets = new ConversationExportedProjectAsset();

            projectAssets.Intents.Add(new ConversationExportedIntent(category: "Read")
            {
                Description = "The read intent",
                AssociatedEntities = { new ConversationExportedAssociatedEntityLabel(category: "Sender") }
            });
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "Delete")
            {
                Description = "The delete intent"
            });

            projectAssets.Entities.Add(new ConversationExportedEntity(category: "Sender")
            {
                Description = "The description of Sender"
            });

            projectAssets.Entities.Add(new ConversationExportedEntity(category: "Number")
            {
                Description = "The description of Number",
                Regex = new ExportedEntityRegex()
                {
                    Expressions = {
                        new ExportedEntityRegexExpression
                        {
                            RegexKey = "UK Phone numbers",
                            Language = "en-us",
                            RegexPattern = @"^\(?([0-9]{3})\)?[-.\s]?([0-9]{3})[-.\s]?([0-9]{4})$"
                        }
                    }
                }
            });

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "Open Blake's email",
                intent: "Read")
            {
                Dataset = "Train",
                Entities = {
                    new ExportedUtteranceEntityLabel(category: "Sender", offset: 5, length: 5)
                }
            });

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "Delete last email",
                intent: "Delete")
            {
                Language = "en-gb",
                Dataset = "Test"
            });

            // Create exported project
            var exportedProject = new ConversationAuthoringExportedProject(
                projectFileVersion: "2025-05-15-preview",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            // Get project client
            var projectAuthoringClient = client.GetProject(projectName);

            // Act
            Operation operation = await projectAuthoringClient.ImportAsync(
                waitUntil: WaitUntil.Started,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected operation status to be 202 (Accepted).");

            // Print operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project import request submitted with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task ExportProjectAsync()
        {
            // Arrange
            string projectName = "MyNewProjectAsync";

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            // Act
            Operation operation = await projectAuthoringClient.ExportAsync(
                waitUntil: WaitUntil.Completed,
                stringIndexType: StringIndexType.Utf16CodeUnit,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Assert
            Assert.IsNotNull(operation, "The export operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and check the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");

            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task GetProjectAsync()
        {
            // Arrange
            string projectName = "MyNewProjectAsync";

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            // Act
            Response<ConversationAuthoringProjectMetadata> response = await projectAuthoringClient.GetProjectAsync();
            ConversationAuthoringProjectMetadata projectMetadata = response.Value;

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.IsNotNull(projectMetadata, "The project metadata should not be null.");
            Assert.AreEqual(projectName, projectMetadata.ProjectName, "The project name in the response does not match the requested project name.");
            Assert.IsNotNull(projectMetadata.CreatedOn, "Created DateTime should not be null.");
            Assert.IsNotNull(projectMetadata.LastModifiedOn, "Last Modified DateTime should not be null.");
        }

        [RecordedTest]
        public async Task DeleteProjectAsync()
        {
            // Arrange
            string projectName = "NewProject001";

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            // Act
            Operation operation = await projectAuthoringClient.DeleteProjectAsync(
                waitUntil: WaitUntil.Completed
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            //Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");
            Console.WriteLine($"DeleteProjectAsync with status: {operation.GetRawResponse().Status}");
            // Extract and validate the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task TrainAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";

            var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
                modelLabel: "MyModel",
                trainingMode: ConversationAuthoringTrainingMode.Standard
            )
            {
                TrainingConfigVersion = "2023-04-15",
                EvaluationOptions = new ConversationAuthoringEvaluationDetails
                {
                    Kind = ConversationAuthoringEvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            // Act
            Operation<ConversationAuthoringTrainingJobResult> operation = await projectAuthoringClient.TrainAsync(
                waitUntil: WaitUntil.Completed,
                details: trainingJobDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            // Extract and validate the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task TrainAsync_withDataGenerationSettings()
        {
            // Arrange
            string projectName = "EmailAppEnglish";

            var connectionInfo = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                kind: AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                deploymentName: "gpt-4o"
            );
            connectionInfo.ResourceId = "/subscriptions/e54a2925-af7f-4b05-9ba1-2155c5fe8a8e/resourceGroups/gouri-eastus/providers/Microsoft.CognitiveServices/accounts/sdk-test-openai";

            var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
                modelLabel: "ModelWithDG",
                trainingMode: ConversationAuthoringTrainingMode.Standard
            )
            {
                TrainingConfigVersion = "2025-05-15-preview-ConvLevel",
                EvaluationOptions = new ConversationAuthoringEvaluationDetails
                {
                    Kind = ConversationAuthoringEvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                },
                DataGenerationSettings = new AnalyzeConversationAuthoringDataGenerationSettings(
                    enableDataGeneration: true,
                    dataGenerationConnectionInfo: connectionInfo
                )
            };

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);

            // Act
            Operation<ConversationAuthoringTrainingJobResult> operation = await projectAuthoringClient.TrainAsync(
                waitUntil: WaitUntil.Started,
                details: trainingJobDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected operation status to be 202.");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task CancelTrainingJobAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";
            string jobId = "a12078ff-ead0-41fb-951c-8a60b9a6a529_638763840000000000";

            // Act
            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            Operation<ConversationAuthoringTrainingJobResult> cancelOperation = await projectAuthoringClient.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Started,
                jobId: jobId
            );

            // Assert
            Assert.IsNotNull(cancelOperation, "The cancellation operation should not be null.");
            //Assert.AreEqual(200, cancelOperation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");
            Console.WriteLine($"Project created with status: {cancelOperation.GetRawResponse().Status}");
            // Extract and validate the operation-location header
            string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task GetModelEvaluationSummaryAsync()
        {
            // Arrange
            string projectName = "EmailApp";
            string trainedModelLabel = "Model1";

            ConversationAuthoringTrainedModel trainedModelAuthoringClient = client.GetTrainedModel(projectName, trainedModelLabel);
            // Act
            Response<ConversationAuthoringEvalSummary> evaluationSummaryResponse = await trainedModelAuthoringClient.GetModelEvaluationSummaryAsync(            );

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
            string projectName = "Aurora-CLU-Prod";
            string trainedModelLabel = "m1";
            StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

            ConversationAuthoringTrainedModel trainedModelAuthoringClient = client.GetTrainedModel(projectName, trainedModelLabel);
            // Act
            AsyncPageable<UtteranceEvaluationResult> results = trainedModelAuthoringClient.GetModelEvaluationResultsAsync(
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
            string projectName = "EmailApp";
            string trainedModelLabel = "Model1";

            ConversationAuthoringTrainedModel trainedodelAuthoringClient = client.GetTrainedModel(projectName, trainedModelLabel);
            // Act
            Operation operation = await trainedodelAuthoringClient.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed
                );
            // Assert
            Assert.IsNotNull(operation, "The operation result should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task DeleteTrainedModelAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";
            string trainedModelLabel = "MyModel";

            ConversationAuthoringTrainedModel modelAuthoringClient = client.GetTrainedModel(projectName, trainedModelLabel);
            // Act
            Response response = await modelAuthoringClient.DeleteTrainedModelAsync();

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.AreEqual(204, response.Status, "Expected status to be 204 (No Content) indicating successful deletion.");
        }

        [RecordedTest]
        public async Task SwapDeploymentsAsync()
        {
            // Arrange
            string projectName = "EmailApp";
            var deploymentName1 = "staging";
            var deploymentName2 = "production";

            var swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);

            ConversationAuthoringProject projectAuthoringClient = client.GetProject(projectName);
            // Act
            Operation operation = await projectAuthoringClient.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task AssignDeploymentResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            ConversationAnalysisAuthoringClientOptions options =
                new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);

            ConversationAnalysisAuthoringClient client_aad = new ConversationAnalysisAuthoringClient(endpoint, credential, options);

            // Arrange
            string projectName = "EmailApp";
            ConversationAuthoringProject projectClient = client_aad.GetProject(projectName);

            var resourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02",
                customDomain: "sdk-test-02",
                region: "eastus2"
            );

            var assignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { resourceMetadata }
            );

            // Act
            Operation operation = await projectClient.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: assignDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected status to be 202 (Accepted).");

            // Extract and validate jobId from Operation-Location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? location
                : null;

            Assert.IsNotNull(operationLocation, "Operation-Location header should not be null.");
            string jobId = new Uri(operationLocation).Segments.Last().Split('?')[0];
            Assert.IsFalse(string.IsNullOrEmpty(jobId), "Extracted job ID should not be null or empty.");
        }

        [RecordedTest]
        public async Task GetAssignDeploymentResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            var options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
            var client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);

            string projectName = "EmailApp";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            // Build resource metadata
            var resourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02",
                customDomain: "sdk-test-02",
                region: "eastus2"
            );

            var assignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { resourceMetadata }
            );

            // Submit assignment operation
            Operation assignOperation = await projectClient.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: assignDetails
            );

            string operationLocation = assignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? location
                : throw new InvalidOperationException("Operation-Location header not found.");

            // Extract only the jobId part from the URL
            string jobId = new Uri(location).Segments.Last().Split('?')[0];
            Console.WriteLine($"Job ID: {jobId}");

            // Wait a bit for job to propagate (optional: Thread.Sleep or retry loop)
            await Task.Delay(3000);

            // Call status API
            Response<ConversationAuthoringDeploymentResourcesState> statusResponse = await projectClient.GetAssignDeploymentResourcesStatusAsync(jobId);

            Assert.IsNotNull(statusResponse);
            Console.WriteLine($"Deployment assignment status: {statusResponse.Value.Status}");
        }

        [RecordedTest]
        public async Task DeleteDeploymentAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";
            string deploymentName = "deployment1";

            ConversationAuthoringDeployment deploymentAuthoringClient = client.GetDeployment(projectName, deploymentName);
            // Act
            Operation operation = await deploymentAuthoringClient.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            //Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");
            Console.WriteLine($"Project created with status: {operation.GetRawResponse().Status}");
            //string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            //Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task DeployProjectAsync(){
            // Arrange
            string projectName = "EmailApp";
            var deploymentName = "staging";

            ConversationAuthoringDeployment deploymentAuthoringClient = client.GetDeployment(projectName, deploymentName);

            ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("Model1");
            // Act
            Operation operation = await deploymentAuthoringClient.DeployProjectAsync(
                waitUntil: WaitUntil.Completed,
                trainedModeDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            //Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");
            Console.WriteLine($"Project created with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task DeployProjectAsync_WithAssignedResources()
        {
            // Arrange
            string projectName = "EmailAppEnglish";
            string deploymentName = "assignedDeployment";

            // Create the assignedAoaiResource
            var assignedAoaiResource = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                deploymentName: "gpt-4o"
            )
            {
                ResourceId = "/subscriptions/e54a2925-af7f-4b05-9ba1-2155c5fe8a8e/resourceGroups/gouri-eastus/providers/Microsoft.CognitiveServices/accounts/sdk-test-openai"
            };

            // Create the assignedResource
            var assignedResource = new ConversationAuthoringDeploymentResource(
                resourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-01",
                region: "East US"
            )
            {
                AssignedAoaiResource = assignedAoaiResource
            };

            // Create deployment details with assigned resources
            var deploymentDetails = new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");

            // Use Add to populate the read-only AssignedResources
            deploymentDetails.AssignedResources.Add(assignedResource);

            // Create the deployment client
            ConversationAuthoringDeployment deploymentAuthoringClient = client.GetDeployment(projectName, deploymentName);

            // Act
            Operation operation = await deploymentAuthoringClient.DeployProjectAsync(
                waitUntil: WaitUntil.Started,
                deploymentDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected status to be 202 (Accepted).");

            Console.WriteLine($"Deployment created with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Assert.IsNotNull(operationLocation, "Expected operation-location header to be present.");
        }

        [RecordedTest]
        public async Task GetDeploymentAsync()
        {
            // Arrange
            string projectName = "EmailAppEnglish";
            string deploymentName = "assignedDeployment";

            ConversationAuthoringDeployment deploymentAuthoringClient = client.GetDeployment(projectName, deploymentName);

            // Act
            Response<ConversationAuthoringProjectDeployment> response = await deploymentAuthoringClient.GetDeploymentAsync();

            // Assert
            Assert.IsNotNull(response, "The response should not be null.");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected status to be 200 (OK).");

            ConversationAuthoringProjectDeployment deployment = response.Value;

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
