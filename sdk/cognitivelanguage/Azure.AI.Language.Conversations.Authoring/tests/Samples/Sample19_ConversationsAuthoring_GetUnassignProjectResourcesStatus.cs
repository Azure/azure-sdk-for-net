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
    public partial class Sample19_ConversationsAuthoring_GetUnassignProjectResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetUnassignProjectResourcesStatus()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(sampleEndpoint, sampleCredential);

            #region Snippet:Sample19_ConversationsAuthoring_GetUnassignProjectResourcesStatus
            ConversationAuthoringProject projectClient = client.GetConversationAuthoringProjectClient();

            string sampleProjectName = "{projectName}";
            // Define assigned resource ID to be unassigned
            var sampleUnassignIds = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                }
            };

            // Start the unassign operation
            Operation sampleUnassignOperation = projectClient.UnassignProjectResources(
                WaitUntil.Started,
                sampleProjectName,
                sampleUnassignIds
            );

            Console.WriteLine($"UnassignProjectResources initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

            // Extract jobId from Operation-Location
            string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? new Uri(location).Segments.Last().Split('?')[0]
                : throw new InvalidOperationException("Operation-Location header not found.");

            Console.WriteLine($"Job ID: {sampleJobId}");

            // Call the API to get unassign job status
            Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse =
                projectClient.GetUnassignProjectResourcesStatus(sampleProjectName, sampleJobId);

            Console.WriteLine($"Job Status: {sampleStatusResponse.Value.Status}");

            if (sampleStatusResponse.Value.Errors != null && sampleStatusResponse.Value.Errors.Any())
            {
                Console.WriteLine("Errors:");
                foreach (var sampleError in sampleStatusResponse.Value.Errors)
                {
                    Console.WriteLine($"- Code: {sampleError.Code}, Message: {sampleError.Message}");
                }
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetUnassignProjectResourcesStatusAsync()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(sampleEndpoint, sampleCredential);

            #region Snippet:Sample19_ConversationsAuthoring_GetUnassignProjectResourcesStatusAsync
            ConversationAuthoringProject projectClient = client.GetConversationAuthoringProjectClient();

            string sampleProjectName = "{projectName}";
            // Define assigned resource ID to be unassigned
            var sampleUnassignIds = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                }
            };

            // Start the unassign operation
            Operation sampleUnassignOperation = await projectClient.UnassignProjectResourcesAsync(
                WaitUntil.Started,
                sampleProjectName,
                sampleUnassignIds
            );

            Console.WriteLine($"UnassignProjectResourcesAsync initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

            // Extract jobId from Operation-Location
            string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? new Uri(location).Segments.Last().Split('?')[0]
                : throw new InvalidOperationException("Operation-Location header not found.");

            Console.WriteLine($"Job ID: {sampleJobId}");

            // Call the API to get unassign job status
            Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse =
                await projectClient.GetUnassignProjectResourcesStatusAsync(sampleProjectName, sampleJobId);

            Console.WriteLine($"Job Status: {sampleStatusResponse.Value.Status}");

            if (sampleStatusResponse.Value.Errors != null && sampleStatusResponse.Value.Errors.Any())
            {
                Console.WriteLine("Errors:");
                foreach (var sampleError in sampleStatusResponse.Value.Errors)
                {
                    Console.WriteLine($"- Code: {sampleError.Code}, Message: {sampleError.Message}");
                }
            }
            #endregion
        }
    }
}
