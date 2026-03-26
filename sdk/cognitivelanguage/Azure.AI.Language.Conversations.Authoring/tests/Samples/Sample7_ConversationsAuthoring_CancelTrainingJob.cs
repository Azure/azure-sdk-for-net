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
    public partial class Sample7_ConversationsAuthoring_CancelTrainingJob : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CancelTrainingJob()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample7_ConversationsAuthoring_CancelTrainingJob
            string projectName = "{projectName}";
            string jobId = "{jobId}";

            // CancelTrainingJob convenience method is suppressed; use protocol method
            Operation<BinaryData> cancelOperation = client.CancelTrainingJob(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                jobId: jobId,
                context: null
            );

            string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task CancelTrainingJobAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample7_ConversationsAuthoring_CancelTrainingJobAsync
            string projectName = "{projectName}";
            string jobId = "{jobId}";

            Operation<BinaryData> cancelOperation = await client.CancelTrainingJobAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                jobId: jobId,
                context: null
            );

            string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
            #endregion
        }
    }
}
