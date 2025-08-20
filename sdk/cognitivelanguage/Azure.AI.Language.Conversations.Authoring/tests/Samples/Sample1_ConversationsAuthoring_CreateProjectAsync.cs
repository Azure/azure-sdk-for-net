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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample1_ConversationsAuthoring_CreateProjectAsync
            string projectName = "MyNewProjectAsync";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);
            ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
                  projectKind: "Conversation",
                  language: "en-us"
                )
            {
                Multilingual = true,
                Description = "Project description"
            };

            Response response = await projectClient.CreateProjectAsync(projectData);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion
        }
    }
}
