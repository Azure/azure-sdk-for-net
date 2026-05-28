// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample4_ConversationsAuthoring_GetProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample4_ConversationsAuthoring_GetProject
            string projectName = "{projectName}";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            Response<ConversationAuthoringProjectMetadata> response = projectClient.GetProject();
            ConversationAuthoringProjectMetadata projectMetadata = response.Value;

            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
            Console.WriteLine($"Last Trained DateTime: {projectMetadata.LastTrainedOn}");
            Console.WriteLine($"Last Deployed DateTime: {projectMetadata.LastDeployedOn}");
            Console.WriteLine($"Project Kind: {projectMetadata.ProjectKind}");
            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Multilingual: {projectMetadata.Multilingual}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample4_ConversationsAuthoring_GetProjectAsync
            string projectName = "{projectName}";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            Response<ConversationAuthoringProjectMetadata> response = await projectClient.GetProjectAsync();
            ConversationAuthoringProjectMetadata projectMetadata = response.Value;

            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
            Console.WriteLine($"Last Trained DateTime: {projectMetadata.LastTrainedOn}");
            Console.WriteLine($"Last Deployed DateTime: {projectMetadata.LastDeployedOn}");
            Console.WriteLine($"Project Kind: {projectMetadata.ProjectKind}");
            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Multilingual: {projectMetadata.Multilingual}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            #endregion
        }
    }
}
