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
    public partial class Sample17_ConversationsAuthoring_GetAssignProjectResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetAssignProjectResourcesStatus()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample17_ConversationsAuthoring_GetAssignProjectResourcesStatus
            string projectName = "{projectName}";
            string jobId = "{jobId}";

            Response<ConversationAuthoringDeploymentResourcesState> response = client.GetAssignProjectResourcesStatus(projectName, jobId);

            ConversationAuthoringDeploymentResourcesState state = response.Value;

            Console.WriteLine($"Job ID: {state.JobId}");
            Console.WriteLine($"Status: {state.Status}");
            Console.WriteLine($"Created On: {state.CreatedOn}");
            Console.WriteLine($"Last Updated On: {state.LastUpdatedOn}");
            Console.WriteLine($"Expires On: {state.ExpiresOn}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetAssignProjectResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample17_ConversationsAuthoring_GetAssignProjectResourcesStatusAsync
            string projectName = "{projectName}";
            string jobId = "{jobId}";

            Response<ConversationAuthoringDeploymentResourcesState> response = await client.GetAssignProjectResourcesStatusAsync(projectName, jobId);

            ConversationAuthoringDeploymentResourcesState state = response.Value;

            Console.WriteLine($"Job ID: {state.JobId}");
            Console.WriteLine($"Status: {state.Status}");
            Console.WriteLine($"Created On: {state.CreatedOn}");
            Console.WriteLine($"Last Updated On: {state.LastUpdatedOn}");
            Console.WriteLine($"Expires On: {state.ExpiresOn}");
            #endregion
        }
    }
}
