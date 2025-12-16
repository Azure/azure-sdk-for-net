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
    public partial class Sample20_ConversationsAuthoring_ListAssignedResourceDeployments : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ListAssignedResourceDeployments()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample20_ConversationsAuthoring_ListAssignedResourceDeployments
            // List all deployments assigned to resources across projects
            Pageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
                client.GetAssignedResourceDeployments();

            foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
            {
                Console.WriteLine($"Project Name: {meta.ProjectName}");

                if (meta.DeploymentsMetadata != null)
                {
                    foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
                    {
                        Console.WriteLine($"  Deployment Name: {deployment.DeploymentName}");
                        Console.WriteLine($"  Last Deployed On: {deployment.LastDeployedOn}");
                        Console.WriteLine($"  Deployment Expires On: {deployment.DeploymentExpiresOn}");
                        Console.WriteLine();
                    }
                }
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ListAssignedResourceDeploymentsAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample20_ConversationsAuthoring_ListAssignedResourceDeploymentsAsync
            // List all deployments assigned to resources across projects (async)
            AsyncPageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
                client.GetAssignedResourceDeploymentsAsync();

            await foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
            {
                Console.WriteLine($"Project Name: {meta.ProjectName}");

                if (meta.DeploymentsMetadata != null)
                {
                    foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
                    {
                        Console.WriteLine($"  Deployment Name: {deployment.DeploymentName}");
                        Console.WriteLine($"  Last Deployed On: {deployment.LastDeployedOn}");
                        Console.WriteLine($"  Deployment Expires On: {deployment.DeploymentExpiresOn}");
                        Console.WriteLine();
                    }
                }
            }
            #endregion
        }
    }
}
