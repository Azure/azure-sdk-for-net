// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Conversations_Identity_Namespace
using Azure.Identity;
using Azure.Core;
#endregion

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class CreateClient : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        public void CreateAuthoringClientForSpecificApiVersion()
        {
            #region Snippet:CreateAuthoringClientForSpecificApiVersion
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            credential = new(TestEnvironment.ApiKey);
#endif
            ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
            #endregion
        }

        [Test]
        public void AuthoringClient_CreateWithDefaultAzureCredential()
        {
            #region Snippet:AnalyzeConversationAuthoring_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("{endpoint}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
            #endregion
        }

        [Test]
        public void BadArgument()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:AuthoringClient_BadRequest
            try
            {
                string invalidProjectName = "InvalidProject";
                ConversationAuthoringProject projectClient = client.GetProject(invalidProjectName);
                ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
                  projectKind: "Conversation",
                  language: "invalid-lang"
                )
                {
                    Description = "This is a test for invalid configuration."
                };
                using RequestContent content = RequestContent.Create(projectData);
                Response response = projectClient.CreateProject(content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
