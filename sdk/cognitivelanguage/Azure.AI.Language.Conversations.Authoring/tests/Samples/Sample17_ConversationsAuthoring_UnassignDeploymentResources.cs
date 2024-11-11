// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample17_ConversationsAuthoring_UnassignDeploymentResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void UnassignDeploymentResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";

            var unassignConfig = new UnassignDeploymentResourcesConfig(
                assignedResourceIds: new List<string> { "SampleAzureResourceId" }
            );

            #region Snippet:Sample17_ConversationsAuthoring_UnassignDeploymentResources
            Operation operation = authoringClient.UnassignDeploymentResources(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: unassignConfig
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
            Console.WriteLine($"Unassign operation-location: {operationLocation}");
            Console.WriteLine($"Unassign operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
