// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

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

            // Train convenience method is suppressed; use protocol method with RequestContent
            var trainingJobJson = new
            {
                modelLabel = "{modelLabel}",
                trainingMode = "standard",
                trainingConfigVersion = "1.0",
                evaluationOptions = new
                {
                    kind = "percentage",
                    testingSplitPercentage = 20,
                    trainingSplitPercentage = 80
                }
            };

            using RequestContent content = RequestContent.Create(BinaryData.FromObjectAsJson(trainingJobJson));

            Operation<BinaryData> operation = client.Train(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                content: content,
                context: null
            );

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

            // Use JSON for training job details including data generation settings
            var trainingJobJson = new
            {
                modelLabel = "{modelLabel}",
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
                        resourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                    }
                }
            };

            using RequestContent content = RequestContent.Create(BinaryData.FromObjectAsJson(trainingJobJson));

            Operation<BinaryData> operation = client.Train(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                content: content,
                context: null
            );

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

            var trainingJobJson = new
            {
                modelLabel = "{modelLabel}",
                trainingMode = "standard",
                trainingConfigVersion = "1.0",
                evaluationOptions = new
                {
                    kind = "percentage",
                    testingSplitPercentage = 20,
                    trainingSplitPercentage = 80
                }
            };

            using RequestContent content = RequestContent.Create(BinaryData.FromObjectAsJson(trainingJobJson));

            Operation<BinaryData> operation = await client.TrainAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                content: content,
                context: null
            );

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

            var trainingJobJson = new
            {
                modelLabel = "{modelLabel}",
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
                        resourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                    }
                }
            };

            using RequestContent content = RequestContent.Create(BinaryData.FromObjectAsJson(trainingJobJson));

            Operation<BinaryData> operation = await client.TrainAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                content: content,
                context: null
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
