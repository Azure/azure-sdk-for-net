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

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetAssignDeploymentResourcesStatus()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatus
            string sampleProjectName = "SampleProject";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group/providers/Microsoft.CognitiveServices/accounts/sample-account",
                customDomain: "sample-domain",
                region: "sample-region"
            );

            var sampleAssignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
            );

            // Submit assignment operation
            Operation sampleAssignOperation = sampleProjectClient.AssignDeploymentResources(
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
            Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse = sampleProjectClient.GetAssignDeploymentResourcesStatus(sampleJobId);

            Console.WriteLine($"Deployment assignment status: {sampleStatusResponse.Value.Status}");
            #endregion
        }
    }
}
