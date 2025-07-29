// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample6_ConversationsAuthoring_Train : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void Train()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample6_ConversationsAuthoring_Train
            string projectName = "{projectName}";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);
            ConversationAuthoringTrainingJobDetails trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
                modelLabel: "{modelLabel}",
                trainingMode: ConversationAuthoringTrainingMode.Standard
            )
            {
                TrainingConfigVersion = "1.0",
                EvaluationOptions = new ConversationAuthoringEvaluationDetails
                {
                    Kind = ConversationAuthoringEvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };

            Operation<ConversationAuthoringTrainingJobResult> operation = projectClient.Train(
                waitUntil: WaitUntil.Completed,
                details: trainingJobDetails
            );

             // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void Train_withDataGenerationSettings()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample6_ConversationsAuthoring_Train_WithDataGeneration
            string projectName = "{projectName}";

            // Create connection info for data generation
            var connectionInfo = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                kind: AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                deploymentName: "gpt-4o")
            {
                ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
            };

            // Prepare training job details with evaluation and data generation settings
            var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
                modelLabel: "{modelLabel}",
                trainingMode: ConversationAuthoringTrainingMode.Standard)
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
                    dataGenerationConnectionInfo: connectionInfo)
            };

            // Start the training operation
            ConversationAuthoringProject projectClient = client.GetProject(projectName);
            Operation<ConversationAuthoringTrainingJobResult> operation = projectClient.Train(
                waitUntil: WaitUntil.Completed,
                details: trainingJobDetails);

            // Extract operation location header and print status
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task TrainAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample6_ConversationsAuthoring_TrainAsync
            string projectName = "{projectName}";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            ConversationAuthoringTrainingJobDetails trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
                modelLabel: "{modelLabel}",
                trainingMode: ConversationAuthoringTrainingMode.Standard
            )
            {
                TrainingConfigVersion = "1.0",
                EvaluationOptions = new ConversationAuthoringEvaluationDetails
                {
                    Kind = ConversationAuthoringEvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };

            Operation<ConversationAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
                waitUntil: WaitUntil.Completed,
                details: trainingJobDetails
            );

            // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task TrainAsync_withDataGenerationSettings()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample6_ConversationsAuthoring_TrainAsync_WithDataGeneration
            string projectName = "{projectName}";

            // Create connection info for data generation
            var connectionInfo = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                kind: AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                deploymentName: "gpt-4o")
            {
                ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
            };

            // Prepare training job details
            var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
                modelLabel: "{modelLabel}",
                trainingMode: ConversationAuthoringTrainingMode.Standard)
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
                    dataGenerationConnectionInfo: connectionInfo)
            };

            // Start training
            ConversationAuthoringProject projectClient = client.GetProject(projectName);
            Operation<ConversationAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
                waitUntil: WaitUntil.Completed,
                details: trainingJobDetails);

            // Extract and print operation location and status
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
