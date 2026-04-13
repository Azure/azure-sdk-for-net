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
    public partial class Sample1_ConversationsAuthoring_CreateProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample1_ConversationsAuthoring_CreateProject
            string projectName = "{projectName}";
            ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
                  projectKind: "Conversation",
                  projectName: projectName,
                  language: "en-us"
                )
            {
                Multilingual = true,
                Description = "Project description"
            };

            using RequestContent content = RequestContent.Create(projectData);
            Response response = client.CreateProject(projectName, content);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task CreateProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample1_ConversationsAuthoring_CreateProjectAsync
            string projectName = "{projectName}";
            ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
                  projectKind: "Conversation",
                  projectName: projectName,
                  language: "en-us"
                )
            {
                Multilingual = true,
                Description = "Project description"
            };

            using RequestContent content = RequestContent.Create(projectData);
            Response response = await client.CreateProjectAsync(projectName, content);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion
        }
    }
}
