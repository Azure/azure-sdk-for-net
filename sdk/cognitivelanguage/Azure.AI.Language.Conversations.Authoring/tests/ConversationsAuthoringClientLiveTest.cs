// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            string projectName = "NewProject1201";

            var projectData = new ConversationAuthoringCreateProjectDetails(
                  projectKind: "Conversation",
                  projectName: projectName,
                  language: "en-us"
                )
            {
                Multilingual = true,
                Description = "Project description"
            };

            // Act - flat client: CreateProject is a protocol method, so we pass RequestContent
            Response response = await client.CreateProjectAsync(projectName, RequestContent.Create(projectData));

            // Assert
            Assert.IsNotNull(response);

            Console.WriteLine($"Project created with status: {response.Status}");
        }

        [RecordedTest]
        public async Task ImportProjectAsync()
        {
            string projectName = "Test-data-labels1202";

            // Create metadata based on JSON data
            var projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                projectName: projectName,
                language: "en-us"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.0F),
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

            // Call the Import function on the flat client
            Operation operation = await client.ImportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Assert the operation and response
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task ImportProjectAsRawJsonAsync()
        {
            string projectName = "Test-data-labels1203";

            string rawJson = """
            {
              "projectFileVersion": "2025-11-15-preview",
              "stringIndexType": "Utf16CodeUnit",
              "metadata": {
                "projectKind": "Conversation",
                "language": "en-us",
                "settings": {
                  "confidenceThreshold": 0.0
                },
                "projectName": "Test-data-labels0702",
                "multilingual": false,
                "description": ""
              },
              "assets": {
                "projectKind": "Conversation",
                "intents": [
                  { "category": "None" },
                  { "category": "Buy" }
                ],
                "entities": [
                  {
                    "category": "product",
                    "compositionSetting": "combineComponents"
                  }
                ],
                "utterances": [
                  {
                    "text": "I want to buy a house",
                    "intent": "Buy",
                    "language": "en-us",
                    "dataset": "Train",
                    "entities": [
                      { "category": "product", "offset": 16, "length": 5 }
                    ]
                  },
                  {
                    "text": "I want to buy surface pro",
                    "intent": "Buy",
                    "language": "en-us",
                    "dataset": "Train",
                    "entities": [
                      { "category": "product", "offset": 14, "length": 11 }
                    ]
                  },
                  {
                    "text": "I want to buy xbox",
                    "intent": "Buy",
                    "language": "en-us",
                    "dataset": "Train",
                    "entities": [
                      { "category": "product", "offset": 14, "length": 4 }
                    ]
                  }
                ]
              }
            }
            """;

            // Call the Import using protocol method with raw JSON via RequestContent
            Operation operation = await client.ImportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                content: RequestContent.Create(BinaryData.FromString(rawJson)),
                exportedProjectFormat: "Conversation"
            );

            // Assert the operation and response
            Assert.IsNotNull(operation);
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project import (raw JSON) completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task ImportProjectAsync_WithAssignedResourcesAndMetadata()
        {
            // Arrange
            string projectName = "TestImportedApp0623";

            var projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                projectName: projectName,
                language: "en-us"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.7F),
                Multilingual = true,
                Description = "Trying out CLU"
            };

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

            var exportedProject = new ConversationAuthoringExportedProject(
                projectFileVersion: "2025-11-15-preview",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            // Act - flat client
            Operation operation = await client.ImportAsync(
                waitUntil: WaitUntil.Started,
                projectName: projectName,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected operation status to be 202 (Accepted).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project import request submitted with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task ExportProjectAsync()
        {
            // Arrange
            string projectName = "NewProject1201";

            // Act - flat client
            Operation operation = await client.ExportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                stringIndexType: StringIndexType.Utf16CodeUnit,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Assert
            Assert.IsNotNull(operation, "The export operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;

            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task GetProjectAsync()
        {
            // Arrange
            string projectName = "NewProject1201";

            // Act - flat client
            Response<ConversationAuthoringProjectMetadata> response = await client.GetProjectAsync(projectName);
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
            string projectName = "NewProject1201";

            // Act - flat client
            Operation operation = await client.DeleteProjectAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Console.WriteLine($"DeleteProjectAsync with status: {operation.GetRawResponse().Status}");
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
        }

        [RecordedTest]
        public async Task TrainAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";

            // Train convenience method is suppressed; use protocol method with RequestContent
            var trainingJobJson = new
            {
                modelLabel = "MyModel",
                trainingMode = "standard",
                trainingConfigVersion = "2023-04-15",
                evaluationOptions = new
                {
                    kind = "percentage",
                    testingSplitPercentage = 20,
                    trainingSplitPercentage = 80
                }
            };

            using RequestContent content = RequestContent.Create(BinaryData.FromObjectAsJson(trainingJobJson));

            // Act - flat client protocol method
            Operation<BinaryData> operation = await client.TrainAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                content: content,
                context: null
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
        }

        [RecordedTest]
        public async Task TrainAsync_withDataGenerationSettings()
        {
            // Arrange
            string projectName = "EmailAppEnglish";

            // AnalyzeConversationAuthoringDataGenerationSettings is internal; use JSON via protocol method
            var trainingJobJson = new
            {
                modelLabel = "ModelWithDG",
                trainingMode = "standard",
                trainingConfigVersion = "2025-05-15-preview-ConvLevel",
                evaluationOptions = new
                {
                    kind = "percentage",
                    testingSplitPercentage = 20,
                    trainingSplitPercentage = 80
                },
                dataGenerationSettings = new
                {
                    enableDataGeneration = true,
                    dataGenerationConnectionInfo = new
                    {
                        kind = "AzureOpenAI",
                        deploymentName = "gpt-4o",
                        resourceId = "/subscriptions/e54a2925-af7f-4b05-9ba1-2155c5fe8a8e/resourceGroups/gouri-eastus/providers/Microsoft.CognitiveServices/accounts/sdk-test-openai"
                    }
                }
            };

            using RequestContent content = RequestContent.Create(BinaryData.FromObjectAsJson(trainingJobJson));

            // Act - flat client protocol method
            Operation<BinaryData> operation = await client.TrainAsync(
                waitUntil: WaitUntil.Started,
                projectName: projectName,
                content: content,
                context: null
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

            // Act - flat client protocol method
            Operation<BinaryData> cancelOperation = await client.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Started,
                projectName: projectName,
                jobId: jobId,
                context: null
            );

            // Assert
            Assert.IsNotNull(cancelOperation, "The cancellation operation should not be null.");
            Console.WriteLine($"CancelTrainingJob with status: {cancelOperation.GetRawResponse().Status}");
            string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
        }

        [RecordedTest]
        public async Task GetModelEvaluationSummaryAsync()
        {
            // Arrange
            string projectName = "EmailApp";
            string trainedModelLabel = "Model1";

            // Act - flat client
            Response<ConversationAuthoringEvalSummary> evaluationSummaryResponse = await client.GetModelEvaluationSummaryAsync(projectName, trainedModelLabel);

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

            // Act - flat client
            AsyncPageable<AnalyzeConversationAuthoringUtteranceEvaluationResult> results = client.GetModelEvaluationResultsAsync(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel,
                stringIndexType: stringIndexType
            );

            // Assert
            Assert.IsNotNull(results, "The evaluation results should not be null.");

            await foreach (AnalyzeConversationAuthoringUtteranceEvaluationResult result in results)
            {
                Assert.IsNotNull(result.Text, "The result text should not be null.");
                Assert.IsNotNull(result.Language, "The result language should not be null.");

                Assert.IsNotNull(result.IntentsResult, "The intents result should not be null.");
                Assert.IsNotNull(result.IntentsResult.ExpectedIntent, "The expected intent should not be null.");
                Assert.IsNotNull(result.IntentsResult.PredictedIntent, "The predicted intent should not be null.");

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

            // Act - flat client
            Operation operation = await client.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            // Assert
            Assert.IsNotNull(operation, "The operation result should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected operation status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
        }

        [RecordedTest]
        public async Task DeleteTrainedModelAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";
            string trainedModelLabel = "MyModel";

            // Act - flat client
            Response response = await client.DeleteTrainedModelAsync(projectName, trainedModelLabel);

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

            // Act - flat client
            Operation operation = await client.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: swapDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected status to be 200 (OK).");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
        }

        [RecordedTest]
        public async Task DeleteDeploymentAsync()
        {
            // Arrange
            string projectName = "Test-data-labels";
            string deploymentName = "deployment1";

            // Act - flat client
            Operation operation = await client.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Console.WriteLine($"DeleteDeployment with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task DeployProjectAsync()
        {
            // Arrange
            string projectName = "EmailApp";
            var deploymentName = "staging";

            ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("Model1");

            // Act - flat client
            Operation operation = await client.DeployProjectAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName,
                details: trainedModeDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Console.WriteLine($"DeployProject with status: {operation.GetRawResponse().Status}");
        }

        [RecordedTest]
        public async Task DeployProjectAsync_WithAssignedResources()
        {
            // Arrange
            string projectName = "EmailAppEnglish";
            string deploymentName = "assignedDeployment";

            // Create the assigned resource
            var assignedResource = new ConversationAuthoringDeploymentResource(
                resourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-01",
                region: "East US"
            );

            // Create deployment details with assigned resources
            var deploymentDetails = new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
            deploymentDetails.AssignedResources.Add(assignedResource);

            // Act - flat client
            Operation operation = await client.DeployProjectAsync(
                waitUntil: WaitUntil.Started,
                projectName: projectName,
                deploymentName: deploymentName,
                details: deploymentDetails
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

            // Act - flat client
            Response<ConversationAuthoringProjectDeployment> response = await client.GetDeploymentAsync(projectName, deploymentName);

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

        [RecordedTest]
        public async Task ListAssignedResourceDeploymentsAsync()
        {
            // Act - already on root client
            AsyncPageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
                client.GetAssignedResourceDeploymentsAsync();

            await foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
            {
                Assert.IsNotNull(meta, "Metadata item should not be null.");
                Assert.IsNotNull(meta.ProjectName, "ProjectName should not be null.");
                Assert.IsNotEmpty(meta.ProjectName, "ProjectName should not be empty.");
                Assert.IsNotNull(meta.DeploymentsMetadata, "DeploymentsMetadata should not be null.");

                foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
                {
                    Assert.IsNotNull(deployment, "Deployment metadata should not be null.");
                    Assert.IsNotNull(deployment.DeploymentName, "DeploymentName should not be null.");
                    Assert.IsNotEmpty(deployment.DeploymentName, "DeploymentName should not be empty.");

                    Assert.AreNotEqual(
                        default(DateTimeOffset),
                        deployment.LastDeployedOn,
                        "LastDeployedOn should be set.");

                    Assert.AreNotEqual(
                        default(DateTimeOffset),
                        deployment.DeploymentExpiresOn,
                        "DeploymentExpiresOn should be set.");
                }
            }
        }

        [RecordedTest]
        public async Task ListDeploymentResourcesAsync()
        {
            // Arrange
            string projectName = "EmailApp";

            // Act - flat client (renamed from GetProjectResources to GetDeploymentResources)
            AsyncPageable<ConversationAuthoringAssignedDeploymentResource> pageable =
                client.GetDeploymentResourcesAsync(projectName);

            // Assert each resource item as we stream results
            await foreach (ConversationAuthoringAssignedDeploymentResource resource in pageable)
            {
                Assert.IsNotNull(resource, "Resource item should not be null.");

                Assert.IsNotNull(resource.ResourceId, "ResourceId should not be null.");
                Assert.IsNotEmpty(resource.ResourceId, "ResourceId should not be empty.");

                Assert.IsNotNull(resource.Region, "Region should not be null.");
                Assert.IsNotEmpty(resource.Region, "Region should not be empty.");
            }
        }

        [RecordedTest]
        public async Task DeleteDeploymentFromResourcesAsync()
        {
            // Arrange
            string projectName = "EmailApp";
            string deploymentName = "deploysdk2";

            var deleteBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02"
                }
            };

            // Act - flat client
            Operation operation = null;

            try
            {
                operation = await client.DeleteDeploymentFromResourcesAsync(
                    WaitUntil.Started,
                    projectName: projectName,
                    deploymentName: deploymentName,
                    details: deleteBody);
            }
            catch (RequestFailedException e)
            {
                Assert.Fail($"DeleteDeploymentFromResourcesAsync failed: {e.Message}");
            }

            Assert.IsNotNull(operation, "Operation should not be null.");

            // Await completion
            try
            {
                await operation.WaitForCompletionResponseAsync();
            }
            catch (RequestFailedException e)
            {
                Assert.Fail($"Delete operation failed: {e.Message}");
                throw;
            }

            // Assert completion
            Assert.IsTrue(operation.HasCompleted, "The deletion operation should have completed.");
        }
    }
}
