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
    public partial class Sample7_ConversationsAuthoring_CancelTrainingJobAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task CancelTrainingJobAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            #region Snippet:Sample7_ConversationsAuthoring_CancelTrainingJobAsync
            string projectName = "MyProject";
            string jobId = "YourTrainingJobId";

            Operation<TrainingJobResult> cancelOperation = await authoringClient.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                jobId: jobId
            );

             // Extract the operation-location header
            string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
            #endregion
        }
    }
}
