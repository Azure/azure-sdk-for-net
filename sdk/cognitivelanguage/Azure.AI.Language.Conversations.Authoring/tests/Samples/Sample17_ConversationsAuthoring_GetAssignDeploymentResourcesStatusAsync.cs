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
    public partial class Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatusAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetAssignDeploymentResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            var client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            string projectName = "EmailApp";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            // Build resource metadata
            var resourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02",
                customDomain: "sdk-test-02",
                region: "eastus2"
            );

            var assignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { resourceMetadata }
            );

            // Submit assignment operation
            Operation assignOperation = await projectClient.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: assignDetails
            );

            string operationLocation = assignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? location
                : throw new InvalidOperationException("Operation-Location header not found.");

            // Extract only the jobId part from the URL
            string jobId = new Uri(location).Segments.Last().Split('?')[0];
            Console.WriteLine($"Job ID: {jobId}");

            // Wait a bit for job to propagate (optional: Thread.Sleep or retry loop)
            await Task.Delay(3000);

            // Call status API
            Response<ConversationAuthoringDeploymentResourcesState> statusResponse = await projectClient.GetAssignDeploymentResourcesStatusAsync(jobId);

            Assert.IsNotNull(statusResponse);
            Console.WriteLine($"Deployment assignment status: {statusResponse.Value.Status}");
        }
    }
}
