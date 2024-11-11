// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample14_ConversationsAuthoring_DeleteDeploymentAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task DeleteDeploymentAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";
            string deploymentName = "SampleDeployment";

            #region Snippet:Sample14_ConversationsAuthoring_DeleteDeploymentAsync
            Operation operation = await authoringClient.DeleteDeploymentAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
            Console.WriteLine($"Delete operation-location: {operationLocation}");
            Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
