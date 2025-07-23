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
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

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
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            // Create AOAI resource reference
            AnalyzeConversationAuthoringDataGenerationConnectionInfo assignedAoaiResource =
                new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                    AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                    deploymentName: "gpt-4o")
                {
                    ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                };

            // Create Cognitive Services resource with AOAI linkage
            ConversationAuthoringDeploymentResource assignedResource =
                new ConversationAuthoringDeploymentResource(
                    resourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
                    region: "{region}")
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

        [Test]
        [AsyncOnly]
        public async Task DeployProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

            Operation operation = await deploymentClient.DeployProjectAsync(
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
        [AsyncOnly]
        public async Task DeployProjectAsync_WithAssignedResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectAsyncWithAssignedResources
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            // Create AOAI resource reference
            AnalyzeConversationAuthoringDataGenerationConnectionInfo assignedAoaiResource =
                new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
                    AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
                    deploymentName: "gpt-4o")
                {
                    ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                };

            // Create Cognitive Services resource with AOAI linkage
            ConversationAuthoringDeploymentResource assignedResource =
                new ConversationAuthoringDeploymentResource(
                    resourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
                    region: "{region}")
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
            Operation operation = await deploymentClient.DeployProjectAsync(WaitUntil.Started, deploymentDetails);

            // Output result
            Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
                ? location : "Not found";
            Console.WriteLine($"Operation-Location header: {operationLocation}");
            #endregion
        }
    }
}
