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
    public partial class Sample21_ConversationsAuthoring_ListProjectResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ListProjectResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample21_ConversationsAuthoring_ListProjectResources
            string projectName = "{projectName}";

            // Retrieve resources assigned to this project
            Pageable<ConversationAuthoringAssignedDeploymentResource> pageable =
                client.GetDeploymentResources(projectName);

            foreach (ConversationAuthoringAssignedDeploymentResource resource in pageable)
            {
                Console.WriteLine($"Resource ID: {resource.ResourceId}");
                Console.WriteLine($"Region: {resource.Region}");
                Console.WriteLine();
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ListProjectResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client =
                new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample21_ConversationsAuthoring_ListProjectResourcesAsync
            string projectName = "{projectName}";

            // Retrieve resources assigned to this project (async)
            AsyncPageable<ConversationAuthoringAssignedDeploymentResource> pageable =
                client.GetDeploymentResourcesAsync(projectName);

            await foreach (ConversationAuthoringAssignedDeploymentResource resource in pageable)
            {
                Console.WriteLine($"Resource ID: {resource.ResourceId}");
                Console.WriteLine($"Region: {resource.Region}");
                Console.WriteLine();
            }
            #endregion
        }
    }
}
