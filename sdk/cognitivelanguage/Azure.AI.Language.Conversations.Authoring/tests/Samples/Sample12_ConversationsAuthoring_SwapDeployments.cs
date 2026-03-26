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
    public partial class Sample12_ConversationsAuthoring_SwapDeployments : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void SwapDeployments()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample12_ConversationsAuthoring_SwapDeployments
            string projectName = "{projectName}";
            string deploymentName1 = "{deploymentName1}";
            string deploymentName2 = "{deploymentName2}";

            var swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);

            Operation operation = client.SwapDeployments(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: swapDetails
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Swap deployments completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task SwapDeploymentsAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample12_ConversationsAuthoring_SwapDeploymentsAsync
            string projectName = "{projectName}";
            string deploymentName1 = "{deploymentName1}";
            string deploymentName2 = "{deploymentName2}";

            var swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);

            Operation operation = await client.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: swapDetails
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Swap deployments completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
