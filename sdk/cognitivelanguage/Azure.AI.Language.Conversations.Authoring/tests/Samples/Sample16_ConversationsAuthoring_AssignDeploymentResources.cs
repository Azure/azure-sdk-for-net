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
    public partial class Sample16_ConversationsAuthoring_AssignDeploymentResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AssignDeploymentResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample16_ConversationsAuthoring_AssignDeploymentResources
            // Arrange
            string sampleProjectName = "SampleProject";
            ConversationAuthoringProject sampleProjectClient = client.GetProject(sampleProjectName);

            var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/sample-subscription/resourceGroups/sample-rg/providers/Microsoft.CognitiveServices/accounts/sample-account",
                customDomain: "sample-domain",
                region: "sample-region"
            );

            var sampleAssignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
            );

            // Act
            Operation sampleOperation = sampleProjectClient.AssignDeploymentResources(
                waitUntil: WaitUntil.Started,
                details: sampleAssignDetails
            );

            // Output operation details
            Console.WriteLine("Operation started successfully.");
            Console.WriteLine($"Operation Status: {sampleOperation.GetRawResponse().Status}");

            // Extract and print jobId from Operation-Location header
            string sampleOperationLocation = sampleOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? location
                : null;

            if (!string.IsNullOrEmpty(sampleOperationLocation))
            {
                string sampleJobId = new Uri(sampleOperationLocation).Segments.Last().Split('?')[0];
                Console.WriteLine($"Operation-Location: {sampleOperationLocation}");
                Console.WriteLine($"Job ID: {sampleJobId}");
            }
            else
            {
                Console.WriteLine("Operation-Location header is null or empty.");
            }
            #endregion
        }
    }
}
