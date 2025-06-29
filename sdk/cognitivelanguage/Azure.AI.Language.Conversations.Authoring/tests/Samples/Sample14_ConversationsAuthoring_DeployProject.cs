// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample14_ConversationsAuthoring_DeployProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeployProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProject
            string projectName = "Test-data-labels";
            string deploymentName = "staging";

            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

            Operation operation = deploymentClient.DeployProject(
                waitUntil: WaitUntil.Completed,
                trainedModeDetails
            );

            // Extract operation-location from response headers
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
            Console.WriteLine($"Delete operation-location: {operationLocation}");
            Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void DeployProject_WithAssignedResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectWithAssignedResources
            string projectName = "EmailAppEnglish";
            string deploymentName = "assignedDeployment";

            // Create AOAI resource reference
            AnalyzeConversationAuthoringDataGenerationConnectionInfo assignedAoaiResource =
                new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                    AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                    deploymentName: "gpt-4o")
                {
                    ResourceId = "/subscriptions/e54a2925-af7f-4b05-9ba1-2155c5fe8a8e/resourceGroups/gouri-eastus/providers/Microsoft.CognitiveServices/accounts/sdk-test-openai"
                };

            // Create Cognitive Services resource with AOAI linkage
            ConversationAuthoringDeploymentResource assignedResource =
                new ConversationAuthoringDeploymentResource(
                    resourceId: "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-01",
                    region: "East US")
                {
                    AssignedAoaiResource = assignedAoaiResource
                };

            // Set up deployment details with assigned resources
            ConversationAuthoringCreateDeploymentDetails deploymentDetails =
                new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
            deploymentDetails.AssignedResources.Add(assignedResource);

            // Get deployment client
            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            // Start deployment
            Operation operation = deploymentClient.DeployProject(WaitUntil.Started, deploymentDetails);

            // Output result
            Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
                ? location : "Not found";
            Console.WriteLine($"Operation-Location header: {operationLocation}");
            #endregion
        }
    }
}
