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
            ConversationAnalysisAuthoringClient client =
                new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResources
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            // Get the deployment-scoped client
            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            // Define the Azure resource IDs from which the deployment should be deleted
            var deleteBody = new ConversationAuthoringProjectResourceIds
            {
                AzureResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            // Begin delete operation
            Operation operation =
                deploymentClient.DeleteDeploymentFromResources(WaitUntil.Started, deleteBody);

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
            ConversationAnalysisAuthoringClient client =
                new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResourcesAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            // Get the deployment-scoped client
            ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            // Define the Azure resource IDs from which the deployment should be deleted
            var deleteBody = new ConversationAuthoringProjectResourceIds
            {
                AzureResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            // Begin the delete operation
            Operation operation =
                await deploymentClient.DeleteDeploymentFromResourcesAsync(
                    WaitUntil.Started,
                    deleteBody);

            // Wait for completion
            await operation.WaitForCompletionResponseAsync();

            Console.WriteLine("Deployment delete-from-resources async operation completed.");
            #endregion
        }
    }
}
