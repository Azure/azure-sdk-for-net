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
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatusAsync
            string sampleProjectName = "SampleProject";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            // Define assigned resource ID to be unassigned
            var sampleAssignedResourceIds = new List<string>
            {
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group/providers/Microsoft.CognitiveServices/accounts/sample-account"
            };

            // Build the unassignment details
            var sampleUnassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(sampleAssignedResourceIds);

            // Start the unassign operation
            Operation sampleUnassignOperation = await sampleProjectClient.UnassignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: sampleUnassignDetails
            );

            Console.WriteLine($"UnassignDeploymentResourcesAsync initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

            // Extract jobId from Operation-Location
            string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? new Uri(location).Segments.Last().Split('?')[0]
                : throw new InvalidOperationException("Operation-Location header not found.");

            Console.WriteLine($"Job ID: {sampleJobId}");

            // Call the API to get unassign job status
            Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse =
                await sampleProjectClient.GetUnassignDeploymentResourcesStatusAsync(sampleJobId);

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
