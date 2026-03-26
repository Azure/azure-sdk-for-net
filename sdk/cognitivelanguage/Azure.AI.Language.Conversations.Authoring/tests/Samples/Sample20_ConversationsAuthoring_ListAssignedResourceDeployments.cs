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
    public partial class Sample20_ConversationsAuthoring_ListAssignedResourceDeployments : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ListAssignedResourceDeployments()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample20_ConversationsAuthoring_ListAssignedResourceDeployments
            Pageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
                client.GetAssignedResourceDeployments();

            foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
            {
                Console.WriteLine($"Project Name: {meta.ProjectName}");

                foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
                {
                    Console.WriteLine($"  Deployment Name: {deployment.DeploymentName}");
                    Console.WriteLine($"  Last Deployed On: {deployment.LastDeployedOn}");
                    Console.WriteLine($"  Deployment Expires On: {deployment.DeploymentExpiresOn}");
                }
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ListAssignedResourceDeploymentsAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample20_ConversationsAuthoring_ListAssignedResourceDeploymentsAsync
            AsyncPageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
                client.GetAssignedResourceDeploymentsAsync();

            await foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
            {
                Console.WriteLine($"Project Name: {meta.ProjectName}");

                foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
                {
                    Console.WriteLine($"  Deployment Name: {deployment.DeploymentName}");
                    Console.WriteLine($"  Last Deployed On: {deployment.LastDeployedOn}");
                    Console.WriteLine($"  Deployment Expires On: {deployment.DeploymentExpiresOn}");
                }
            }
            #endregion
        }
    }
}
