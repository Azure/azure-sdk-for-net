// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public partial class QuestionAnsweringProjectsLiveTestBase : QuestionAnsweringTestBase<QuestionAnsweringProjectsClient>
    {
        private ConcurrentQueue<string> _projects = new();

        public QuestionAnsweringProjectsLiveTestBase(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [TearDown]
        public async Task DeleteProjectsAsync()
        {
            List<Task> tasks = new();
            while (_projects.TryDequeue(out string projectName))
            {
                tasks.Add(Client.DeleteProjectAsync(WaitUntil.Completed, projectName));
            }

            await Task.WhenAll(tasks);
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
            _projects.Enqueue(projectName);
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

            Response response = await Client.CreateProjectAsync(projectName, creationRequestContent);
            _projects.Enqueue(projectName);

            return response;
        }

        protected async Task DeleteProjectAsync(string projectName)
        {
            Operation<BinaryData> deletionOperation = await Client.DeleteProjectAsync(WaitUntil.Completed, projectName);
        }

        protected void DeleteProject(string projectName)
        {
            // Insert this back when the delete LRO bug is fixed
            Operation<BinaryData> deletionOperation = Client.DeleteProject(WaitUntil.Completed, projectName);
        }
    }
}
