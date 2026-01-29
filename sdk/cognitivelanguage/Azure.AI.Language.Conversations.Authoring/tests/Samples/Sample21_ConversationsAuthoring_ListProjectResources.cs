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
            ConversationAnalysisAuthoringClient client =
                new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample21_ConversationsAuthoring_ListProjectResources
            string projectName = "{projectName}";

            // Retrieve resources assigned to this project
            Pageable<ConversationAuthoringAssignedProjectResource> pageable =
                client.GetProjectResources(projectName);

            foreach (ConversationAuthoringAssignedProjectResource resource in pageable)
            {
                Console.WriteLine($"Resource ID: {resource.ResourceId}");
                Console.WriteLine($"Region: {resource.Region}");

                if (resource.AssignedAoaiResource != null)
                {
                    Console.WriteLine($"AOAI Kind: {resource.AssignedAoaiResource.Kind}");
                    Console.WriteLine($"AOAI Resource ID: {resource.AssignedAoaiResource.ResourceId}");
                    Console.WriteLine($"AOAI Deployment Name: {resource.AssignedAoaiResource.DeploymentName}");
                }

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
            ConversationAnalysisAuthoringClient client =
                new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample21_ConversationsAuthoring_ListProjectResourcesAsync
            string projectName = "{projectName}";

            // Retrieve resources assigned to this project (async)
            AsyncPageable<ConversationAuthoringAssignedProjectResource> pageable =
                client.GetProjectResourcesAsync(projectName);

            await foreach (ConversationAuthoringAssignedProjectResource resource in pageable)
            {
                Console.WriteLine($"Resource ID: {resource.ResourceId}");
                Console.WriteLine($"Region: {resource.Region}");

                if (resource.AssignedAoaiResource != null)
                {
                    Console.WriteLine($"AOAI Kind: {resource.AssignedAoaiResource.Kind}");
                    Console.WriteLine($"AOAI Resource ID: {resource.AssignedAoaiResource.ResourceId}");
                    Console.WriteLine($"AOAI Deployment Name: {resource.AssignedAoaiResource.DeploymentName}");
                }

                Console.WriteLine();
            }
            #endregion
        }
    }
}
