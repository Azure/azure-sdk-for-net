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
    public partial class Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetDeploymentDeleteFromResourcesStatus()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client =
                new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatus
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            string jobId = "{jobId}";

            // Get the deployment-scoped client
            ConversationAuthoringDeployment deploymentClient =
                client.GetDeployment(projectName, deploymentName);

            // Retrieve the job status
            Response<ConversationAuthoringDeploymentDeleteFromResourcesState> response =
                deploymentClient.GetDeploymentDeleteFromResourcesStatus(jobId);

            ConversationAuthoringDeploymentDeleteFromResourcesState state = response.Value;

            Console.WriteLine($"Job ID: {state.JobId}");
            Console.WriteLine($"Status: {state.Status}");
            Console.WriteLine($"Created On: {state.CreatedOn}");
            Console.WriteLine($"Last Updated On: {state.LastUpdatedOn}");
            Console.WriteLine($"Expires On: {state.ExpiresOn}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetDeploymentDeleteFromResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client =
                new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatusAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            string jobId = "{jobId}";

            // Get the deployment-scoped client
            ConversationAuthoringDeployment deploymentClient =
                client.GetDeployment(projectName, deploymentName);

            // Retrieve the job status asynchronously
            Response<ConversationAuthoringDeploymentDeleteFromResourcesState> response =
                await deploymentClient.GetDeploymentDeleteFromResourcesStatusAsync(jobId);

            ConversationAuthoringDeploymentDeleteFromResourcesState state = response.Value;

            Console.WriteLine($"Job ID: {state.JobId}");
            Console.WriteLine($"Status: {state.Status}");
            Console.WriteLine($"Created On: {state.CreatedOn}");
            Console.WriteLine($"Last Updated On: {state.LastUpdatedOn}");
            Console.WriteLine($"Expires On: {state.ExpiresOn}");
            #endregion
        }
    }
}
