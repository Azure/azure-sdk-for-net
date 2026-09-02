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
    public partial class Sample15_ConversationsAuthoring_GetDeployment : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetDeployment()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample15_ConversationsAuthoring_GetDeployment
            ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            Response<ConversationAuthoringProjectDeployment> response = deploymentClient.GetDeployment(projectName, deploymentName);

            ConversationAuthoringProjectDeployment deployment = response.Value;

            Console.WriteLine($"Deployment Name: {deployment.DeploymentName}");
            Console.WriteLine($"Model Id: {deployment.ModelId}");
            Console.WriteLine($"Last Trained On: {deployment.LastTrainedOn}");
            Console.WriteLine($"Last Deployed On: {deployment.LastDeployedOn}");
            Console.WriteLine($"Deployment Expired On: {deployment.DeploymentExpiredOn}");
            Console.WriteLine($"Model Training Config Version: {deployment.ModelTrainingConfigVersion}");

            // Print assigned resources info
            if (deployment.AssignedResources != null)
            {
                foreach (var assignedResource in deployment.AssignedResources)
                {
                    Console.WriteLine($"Resource ID: {assignedResource.ResourceId}");
                    Console.WriteLine($"Region: {assignedResource.Region}");
                }
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetDeploymentAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample15_ConversationsAuthoring_GetDeploymentAsync
            ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            Response<ConversationAuthoringProjectDeployment> response = await deploymentClient.GetDeploymentAsync(projectName, deploymentName);

            ConversationAuthoringProjectDeployment deployment = response.Value;

            Console.WriteLine($"Deployment Name: {deployment.DeploymentName}");
            Console.WriteLine($"Model Id: {deployment.ModelId}");
            Console.WriteLine($"Last Trained On: {deployment.LastTrainedOn}");
            Console.WriteLine($"Last Deployed On: {deployment.LastDeployedOn}");
            Console.WriteLine($"Deployment Expired On: {deployment.DeploymentExpiredOn}");
            Console.WriteLine($"Model Training Config Version: {deployment.ModelTrainingConfigVersion}");

            // Print assigned resources info
            if (deployment.AssignedResources != null)
            {
                foreach (var assignedResource in deployment.AssignedResources)
                {
                    Console.WriteLine($"Resource ID: {assignedResource.ResourceId}");
                    Console.WriteLine($"Region: {assignedResource.Region}");
                }
            }
            #endregion
        }
    }
}
