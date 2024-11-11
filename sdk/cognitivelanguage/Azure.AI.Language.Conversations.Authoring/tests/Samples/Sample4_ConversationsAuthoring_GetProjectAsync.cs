// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample4_ConversationsAuthoring_GetProjectAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            #region Snippet:Sample4_ConversationsAuthoring_GetProjectAsync
            string projectName = "MySampleProjectAsync";

            Response<ProjectMetadata> response = await authoringClient.GetProjectAsync(projectName);
            ProjectMetadata projectMetadata = response.Value;

            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedDateTime}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedDateTime}");
            Console.WriteLine($"Last Trained DateTime: {projectMetadata.LastTrainedDateTime}");
            Console.WriteLine($"Last Deployed DateTime: {projectMetadata.LastDeployedDateTime}");
            Console.WriteLine($"Project Kind: {projectMetadata.ProjectKind}");
            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Multilingual: {projectMetadata.Multilingual}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            #endregion
        }
    }
}
