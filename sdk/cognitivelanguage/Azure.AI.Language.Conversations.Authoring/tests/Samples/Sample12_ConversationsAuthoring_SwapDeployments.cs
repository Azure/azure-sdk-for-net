// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_SwapDeployments
            ConversationAuthoringProject projectClient = client.GetConversationAuthoringProjectClient();

            string projectName = "{projectName}";
            string deploymentName1 = "{deploymentName1}";
            string deploymentName2 = "{deploymentName2}";
            ConversationAuthoringSwapDeploymentsDetails swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);
            Operation operation = projectClient.SwapDeployments(WaitUntil.Completed, projectName, swapDetails);

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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_SwapDeploymentsAsync
            ConversationAuthoringProject projectClient = client.GetConversationAuthoringProjectClient();

            string projectName = "{projectName}";
            string deploymentName1 = "{deploymentName1}";
            string deploymentName2 = "{deploymentName2}";
            ConversationAuthoringSwapDeploymentsDetails swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);

            Operation operation = await projectClient.SwapDeploymentsAsync(WaitUntil.Completed, projectName, swapDetails);

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
            Console.WriteLine($"Swap operation-location: {operationLocation}");
            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
