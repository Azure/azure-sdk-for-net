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
    public partial class Sample14_ConversationsAuthoring_DeployProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeployProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProject
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            var deploymentDetails = new ConversationAuthoringCreateDeploymentDetails("{trainedModelLabel}");

            Operation operation = client.DeployProject(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName,
                details: deploymentDetails
            );

            Console.WriteLine($"Deployment completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DeployProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_ConversationsAuthoring_DeployProjectAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";

            var deploymentDetails = new ConversationAuthoringCreateDeploymentDetails("{trainedModelLabel}");

            Operation operation = await client.DeployProjectAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName,
                details: deploymentDetails
            );

            Console.WriteLine($"Deployment completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
