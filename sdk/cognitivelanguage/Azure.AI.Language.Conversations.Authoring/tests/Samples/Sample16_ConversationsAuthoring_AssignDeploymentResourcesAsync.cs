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
    public partial class Sample16_ConversationsAuthoring_AssignDeploymentResourcesAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task AssignDeploymentResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            // Arrange
            string projectName = "EmailApp";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            var resourceMetadata = new ConversationAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02",
                customDomain: "sdk-test-02",
                region: "eastus2"
            );

            var assignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new List<ConversationAuthoringResourceMetadata> { resourceMetadata }
            );

            // Act
            Operation operation = await projectClient.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: assignDetails
            );

            // Assert
            Assert.IsNotNull(operation, "The operation should not be null.");
            Assert.AreEqual(202, operation.GetRawResponse().Status, "Expected status to be 202 (Accepted).");

            // Extract and validate jobId from Operation-Location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
                ? location
                : null;

            Assert.IsNotNull(operationLocation, "Operation-Location header should not be null.");
            string jobId = new Uri(operationLocation).Segments.Last().Split('?')[0];
            Assert.IsFalse(string.IsNullOrEmpty(jobId), "Extracted job ID should not be null or empty.");
        }
    }
}
