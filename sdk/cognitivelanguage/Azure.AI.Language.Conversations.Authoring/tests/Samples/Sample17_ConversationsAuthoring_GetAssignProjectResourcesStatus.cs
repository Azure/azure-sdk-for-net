// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample17_ConversationsAuthoring_GetAssignProjectResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetAssignProjectResourcesStatus()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample17_ConversationsAuthoring_GetAssignProjectResourcesStatus
            string sampleProjectName = "{projectName}";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
                customDomain: "{customDomain}",
                region: "{region}"
            );

            var sampleAssignDetails = new ConversationAuthoringAssignProjectResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
            );

            // Submit assignment operation
            Operation sampleAssignOperation = sampleProjectClient.AssignProjectResources(
                waitUntil: WaitUntil.Started,
                details: sampleAssignDetails
            );

            string sampleOperationLocation = sampleAssignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
                ? location
                : throw new InvalidOperationException("Operation-Location header not found.");

            // Extract only the jobId part from the URL
            string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
            Console.WriteLine($"Job ID: {sampleJobId}");

            // Call status API
            Response<ConversationAuthoringProjectResourcesState> sampleStatusResponse = sampleProjectClient.GetAssignProjectResourcesStatus(sampleJobId);

            Console.WriteLine($"Deployment assignment status: {sampleStatusResponse.Value.Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetAssignProjectResourcesStatusAsync()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample17_ConversationsAuthoring_GetAssignProjectResourcesStatusAsync
            string sampleProjectName = "{projectName}";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            // Build resource metadata
            var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
                customDomain: "{customDomain}",
                region: "{region}"
            );

            var sampleAssignDetails = new ConversationAuthoringAssignProjectResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
            );

            // Submit assignment operation
            Operation sampleAssignOperation = await sampleProjectClient.AssignProjectResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: sampleAssignDetails
            );

            string sampleOperationLocation = sampleAssignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? location
                : throw new InvalidOperationException("Operation-Location header not found.");

            // Extract only the jobId part from the URL
            string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
            Console.WriteLine($"Job ID: {sampleJobId}");

            // Call status API
            Response<ConversationAuthoringProjectResourcesState> sampleStatusResponse = await sampleProjectClient.GetAssignProjectResourcesStatusAsync(sampleJobId);

            Assert.IsNotNull(sampleStatusResponse);
            Console.WriteLine($"Deployment assignment status: {sampleStatusResponse.Value.Status}");
            #endregion
        }
    }
}
