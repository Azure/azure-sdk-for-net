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
    public partial class Sample1_ConversationsAuthoring_CreateProjectAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task CreateProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            #region Snippet:Sample1_ConversationsAuthoring_CreateProjectAsync
            string projectName = "MyNewProjectAsync";
            var projectData = new
            {
                projectName = projectName,
                language = "en",
                projectKind = "Conversation",
                description = "Project description",
                multilingual = true
            };

            using RequestContent content = RequestContent.Create(projectData);
            Response response = await authoringClient.CreateProjectAsync(projectName, content);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion
        }
    }
}
