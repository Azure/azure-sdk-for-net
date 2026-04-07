// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProject
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

            Operation operation = client.DeployProject(
                WaitUntil.Completed,
                projectName,
                deploymentName,
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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

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
            // Start deployment
            Operation operation = client.DeployProject(WaitUntil.Started, projectName, deploymentName, deploymentDetails);

            // Output result
            Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
                ? location : "Not found";
            Console.WriteLine($"Operation-Location header: {operationLocation}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void DeployProject_WithAssignedResources_20251101()
        {
            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectWithAssignedResources_20251101
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            // Use the 2025-11-01 GA version of the service
            ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_11_01);

            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential, options);

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            // Set up deployment details
            ConversationAuthoringCreateDeploymentDetails deploymentDetails =
                new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
            // Start deployment
            Operation operation = client.DeployProject(WaitUntil.Started, projectName, deploymentName, deploymentDetails);
            #endregion

            // Output result
            Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
                ? location : "Not found";
            Console.WriteLine($"Operation-Location header: {operationLocation}");
        }

        [Test]
        [AsyncOnly]
        public async Task DeployProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

            Operation operation = await client.DeployProjectAsync(
                WaitUntil.Completed,
                projectName,
                deploymentName,
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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

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
            // Start deployment
            Operation operation = await client.DeployProjectAsync(WaitUntil.Started, projectName, deploymentName, deploymentDetails);

            // Output result
            Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
                ? location : "Not found";
            Console.WriteLine($"Operation-Location header: {operationLocation}");
            #endregion
        }

        public async Task DeployProjectAsync_WithAssignedResources_20251101()
        {
            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectAsyncWithAssignedResources_20251101
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            // Use the 2025-11-01 GA version of the service
            ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_11_01);

            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential, options);

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            // Set up deployment details
            ConversationAuthoringCreateDeploymentDetails deploymentDetails =
                new ConversationAuthoringCreateDeploymentDetails("ModelWithDG");
            // Start deployment asynchronously
            Operation operation = await client.DeployProjectAsync(WaitUntil.Started, projectName, deploymentName, deploymentDetails);
            #endregion
            // Output result
            Console.WriteLine($"Deployment started with status: {operation.GetRawResponse().Status}");

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
                ? location : "Not found";
            Console.WriteLine($"Operation-Location header: {operationLocation}");
        }
    }
}
