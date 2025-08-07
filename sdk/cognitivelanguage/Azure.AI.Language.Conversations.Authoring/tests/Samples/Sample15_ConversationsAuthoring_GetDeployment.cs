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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample15_ConversationsAuthoring_GetDeployment
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            Response<ConversationAuthoringProjectDeployment> response = deploymentClient.GetDeployment();

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

                    if (assignedResource.AssignedAoaiResource != null)
                    {
                        Console.WriteLine($"AOAI Kind: {assignedResource.AssignedAoaiResource.Kind}");
                        Console.WriteLine($"AOAI Resource ID: {assignedResource.AssignedAoaiResource.ResourceId}");
                        Console.WriteLine($"AOAI Deployment Name: {assignedResource.AssignedAoaiResource.DeploymentName}");
                    }
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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample15_ConversationsAuthoring_GetDeploymentAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            Response<ConversationAuthoringProjectDeployment> response = await deploymentClient.GetDeploymentAsync();

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

                    if (assignedResource.AssignedAoaiResource != null)
                    {
                        Console.WriteLine($"AOAI Kind: {assignedResource.AssignedAoaiResource.Kind}");
                        Console.WriteLine($"AOAI Resource ID: {assignedResource.AssignedAoaiResource.ResourceId}");
                        Console.WriteLine($"AOAI Deployment Name: {assignedResource.AssignedAoaiResource.DeploymentName}");
                    }
                }
            }
            #endregion
        }
    }
}
