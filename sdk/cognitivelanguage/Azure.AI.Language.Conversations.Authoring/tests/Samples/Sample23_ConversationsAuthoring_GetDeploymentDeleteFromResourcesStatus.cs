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
            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatus
            ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            string jobId = "{jobId}";
            // Retrieve the job status
            Response<ConversationAuthoringDeploymentDeleteFromResourcesState> response =
                deploymentClient.GetDeploymentDeleteFromResourcesStatus(projectName, deploymentName, jobId);

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
            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatusAsync
            ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            string jobId = "{jobId}";
            // Retrieve the job status asynchronously
            Response<ConversationAuthoringDeploymentDeleteFromResourcesState> response =
                await deploymentClient.GetDeploymentDeleteFromResourcesStatusAsync(projectName, deploymentName, jobId);

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
