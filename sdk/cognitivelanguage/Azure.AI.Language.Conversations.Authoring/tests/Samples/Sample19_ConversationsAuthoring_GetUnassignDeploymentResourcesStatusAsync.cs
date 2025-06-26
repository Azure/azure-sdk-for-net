// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatusAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetUnassignDeploymentResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatusAsync
            // Set project name and create client for the project
            string projectName = "EmailApp";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            // Replace with your actual job ID retrieved from the unassign operation
            string jobId = "your-job-id-here";

            // Call the API to get unassign job status
            Response<ConversationAuthoringDeploymentResourcesState> response =
                await projectClient.GetUnassignDeploymentResourcesStatusAsync(jobId);

            Console.WriteLine($"Job Status: {response.Value.Status}");

            if (response.Value.Errors != null && response.Value.Errors.Any())
            {
                Console.WriteLine("Errors:");
                foreach (var error in response.Value.Errors)
                {
                    Console.WriteLine($"- Code: {error.Code}, Message: {error.Message}");
                }
            }
            #endregion
        }
    }
}
