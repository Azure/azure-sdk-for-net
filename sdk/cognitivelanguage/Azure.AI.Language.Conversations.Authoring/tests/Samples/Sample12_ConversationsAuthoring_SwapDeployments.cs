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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_SwapDeployments
            string projectName = "SampleProject";
            var deploymentName1 = "deployment1";
            var deploymentName2 = "deployment2";
            var swapDetails = new SwapDeploymentsDetails(deploymentName1, deploymentName2);
            ConversationAuthoringDeployment deploymentAuthoringClient = client.GetDeployment(projectName, deploymentName1);
            Operation operation = deploymentAuthoringClient.SwapDeployments(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
            Console.WriteLine($"Swap operation-location: {operationLocation}");
            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
