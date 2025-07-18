// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample18_ConversationsAuthoring_UnassignDeploymentResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void UnassignDeploymentResources()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResources
            // Set project name and create client for the project
            string sampleProjectName = "SampleProject";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            // Define assigned resource ID to be unassigned
            var sampleAssignedResourceIds = new List<string>
            {
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group/providers/Microsoft.CognitiveServices/accounts/sample-account"
            };

            // Build the unassignment details
            var sampleUnassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(sampleAssignedResourceIds);

            // Start the operation
            Operation sampleOperation = sampleProjectClient.UnassignDeploymentResources(
                waitUntil: WaitUntil.Started,
                details: sampleUnassignDetails
            );

            Console.WriteLine($"UnassignDeploymentResources initiated. Status: {sampleOperation.GetRawResponse().Status}");

            // Print jobId from Operation-Location
            if (sampleOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location))
            {
                string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
                Console.WriteLine($"Job ID: {sampleJobId}");
            }
            else
            {
                Console.WriteLine("Operation-Location header not found.");
            }
            #endregion
        }
    }
}
