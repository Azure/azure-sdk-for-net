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
    public partial class Sample16_ConversationsAuthoring_AssignProjectResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AssignProjectResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample16_ConversationsAuthoring_AssignProjectResources
            string projectName = "{projectName}";

            var assignResourcesDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new[]
                {
                    new ConversationAuthoringResourceMetadata(
                        azureResourceId: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}",
                        customDomain: "{customDomain}",
                        region: "{region}"
                    )
                }
            );

            Operation operation = client.AssignProjectResources(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: assignResourcesDetails
            );

            Console.WriteLine($"Assign project resources completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task AssignProjectResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample16_ConversationsAuthoring_AssignProjectResourcesAsync
            string projectName = "{projectName}";

            var assignResourcesDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
                new[]
                {
                    new ConversationAuthoringResourceMetadata(
                        azureResourceId: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}",
                        customDomain: "{customDomain}",
                        region: "{region}"
                    )
                }
            );

            Operation operation = await client.AssignProjectResourcesAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                details: assignResourcesDetails
            );

            Console.WriteLine($"Assign project resources completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
