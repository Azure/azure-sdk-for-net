// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

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
            string projectName = "{projectName}";
            string deploymentName1 = "{deploymentName1}";
            string deploymentName2 = "{deploymentName2}";
            ConversationAuthoringSwapDeploymentsDetails swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);
            ConversationAuthoringProject projectClient = client.GetProject(projectName);
            Operation operation = projectClient.SwapDeployments(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
            Console.WriteLine($"Swap operation-location: {operationLocation}");
            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task SwapDeploymentsAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_SwapDeploymentsAsync
            string projectName = "{projectName}";
            string deploymentName1 = "{deploymentName1}";
            string deploymentName2 = "{deploymentName2}";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            ConversationAuthoringSwapDeploymentsDetails swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);

            Operation operation = await projectClient.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
            Console.WriteLine($"Swap operation-location: {operationLocation}");
            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
