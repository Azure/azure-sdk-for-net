// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample6_ConversationsAuthoring_TrainAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task TrainAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();

            #region Snippet:Sample6_ConversationsAuthoring_TrainAsync
            string projectName = "MySampleProjectAsync";

            var trainingJobDetails = new TrainingJobDetails(
                modelLabel: "MyModel",
                trainingMode: TrainingMode.Standard
            )
            {
                TrainingConfigVersion = "1.0",
                EvaluationOptions = new EvaluationDetails
                {
                    Kind = EvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };

            Operation<TrainingJobResult> operation = await authoringClient.TrainAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: trainingJobDetails
            );

             // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
