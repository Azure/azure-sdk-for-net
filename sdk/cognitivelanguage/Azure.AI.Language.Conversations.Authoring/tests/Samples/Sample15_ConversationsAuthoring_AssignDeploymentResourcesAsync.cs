// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample15_ConversationsAuthoring_AssignDeploymentResourcesAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task AssignDeploymentResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";

            #region Snippet:Sample15_ConversationsAuthoring_AssignDeploymentResourcesAsync
            // Define resources metadata
            var resourcesMetadata = new List<ResourceMetadata>
            {
                new ResourceMetadata(
                    azureResourceId: "SampleAzureResourceId",
                    customDomain: "SampleCustomDomain",
                    region: "SampleRegionCode"
                )
            };

            var assignConfig = new AssignDeploymentResourcesConfig(resourcesMetadata);

            Operation operation = await authoringClient.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: assignConfig
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
            Console.WriteLine($"Assign operation-location: {operationLocation}");
            Console.WriteLine($"Assign operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
