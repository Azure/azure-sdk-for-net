// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResources
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            var deleteBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            Operation operation = client.DeleteDeploymentFromResources(
                WaitUntil.Started,
                projectName: projectName,
                deploymentName: deploymentName,
                details: deleteBody
            );

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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResourcesAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            var deleteBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            Operation operation = await client.DeleteDeploymentFromResourcesAsync(
                WaitUntil.Started,
                projectName: projectName,
                deploymentName: deploymentName,
                details: deleteBody
            );

            await operation.WaitForCompletionResponseAsync();

            Console.WriteLine("Deployment delete-from-resources async operation completed.");
            #endregion
        }
    }
}
