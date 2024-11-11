// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample14_ConversationsAuthoring_SwapDeployments : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void SwapDeployments()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";
            var swapConfig = new SwapDeploymentsConfig("production", "staging");

            #region Snippet:Sample14_ConversationsAuthoring_SwapDeployments
            Operation operation = authoringClient.SwapDeployments(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: swapConfig
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
            Console.WriteLine($"Swap operation-location: {operationLocation}");
            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
