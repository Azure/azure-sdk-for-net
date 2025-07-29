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
    public partial class Sample13_ConversationsAuthoring_DeleteDeployment : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteDeployment()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample13_ConversationsAuthoring_DeleteDeployment
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            Operation operation = deploymentClient.DeleteDeployment(
                waitUntil: WaitUntil.Completed
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
            Console.WriteLine($"Delete operation-location: {operationLocation}");
            Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DeleteDeploymentAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample13_ConversationsAuthoring_DeleteDeploymentAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            Operation operation = await deploymentClient.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
            Console.WriteLine($"Delete operation-location: {operationLocation}");
            Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
