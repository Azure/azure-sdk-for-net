// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public partial class QuestionAnsweringProjectsLiveTestBase : QuestionAnsweringTestBase<QuestionAnsweringProjectsClient>
    {
        public QuestionAnsweringProjectsLiveTestBase(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        protected string CreateTestProjectName()
        {
            return "TestProject" + Recording.GenerateId();
        }

        protected void CreateProject(string projectName = default)
        {
            if (projectName == default)
                projectName = CreateTestProjectName();

            RequestContent creationRequestContent = RequestContent.Create(
                new
                {
                    description = "This is the description for a test project",
                    language = "en",
                    multilingualResource = false,
                    settings = new
                    {
                        defaultAnswer = "No answer found for your question."
                    }
                }
                );

            Client.CreateProject(projectName, creationRequestContent);
        }

        protected async Task<Response> CreateProjectAsync(string projectName = default)
        {
            if (projectName == default)
                projectName = CreateTestProjectName();

            RequestContent creationRequestContent = RequestContent.Create(
                new
                {
                    description = "This is the description for a test project",
                    language = "en",
                    multilingualResource = false,
                    settings = new
                    {
                        defaultAnswer = "No answer found for your question."
                    }
                }
                );

            return await Client.CreateProjectAsync(projectName, creationRequestContent);
        }

        protected async Task DeleteProjectAsync(string projectName)
        {
            Operation<BinaryData> deletionOperation = await Client.DeleteProjectAsync(true, projectName);
        }

        protected void DeleteProject(string projectName)
        {
            // Insert this back when the delete LRO bug is fixed
            Operation<BinaryData> deletionOperation = Client.DeleteProject(true, projectName);
        }
    }
}
