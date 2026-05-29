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
    public partial class Sample22_ConversationsAuthoring_DeleteDeploymentFromResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteDeploymentFromResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResources
            ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            // Define the Azure resource IDs from which the deployment should be deleted
            var deleteBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            // Begin delete operation
            Operation operation =
                deploymentClient.DeleteDeploymentFromResources(WaitUntil.Started, projectName, deploymentName, deleteBody);

            // Wait for completion
            operation.WaitForCompletionResponse();

            Console.WriteLine("Deployment delete-from-resources operation completed.");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DeleteDeploymentFromResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResourcesAsync
            ConversationAuthoringDeployment deploymentClient = client.GetConversationAuthoringDeploymentClient();

            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            // Define the Azure resource IDs from which the deployment should be deleted
            var deleteBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            // Begin the delete operation
            Operation operation =
                await deploymentClient.DeleteDeploymentFromResourcesAsync(
                    WaitUntil.Started,
                    projectName,
                    deploymentName,
                    deleteBody);

            // Wait for completion
            await operation.WaitForCompletionResponseAsync();

            Console.WriteLine("Deployment delete-from-resources async operation completed.");
            #endregion
        }
    }
}
