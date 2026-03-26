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
    public partial class Sample18_ConversationsAuthoring_UnassignProjectResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void UnassignProjectResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample18_ConversationsAuthoring_UnassignProjectResources
            string projectName = "{projectName}";

            var unassignBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            Operation operation = client.UnassignProjectResources(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: unassignBody
            );

            Console.WriteLine($"Unassign project resources completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task UnassignProjectResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample18_ConversationsAuthoring_UnassignProjectResourcesAsync
            string projectName = "{projectName}";

            var unassignBody = new ConversationAuthoringDeleteDeploymentDetails
            {
                AssignedResourceIds =
                {
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
                }
            };

            Operation operation = await client.UnassignProjectResourcesAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: unassignBody
            );

            Console.WriteLine($"Unassign project resources completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
