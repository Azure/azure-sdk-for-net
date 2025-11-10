// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests
{
    public partial class QuestionAnsweringAuthoringLiveTestBase : QuestionAnsweringTestBase<QuestionAnsweringAuthoringClient>
    {
        private ConcurrentQueue<string> _projects = new();

        public QuestionAnsweringAuthoringLiveTestBase(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, serviceVersion, mode)
        {
        }

        [TearDown]
        public async Task DeleteProjectsAsync()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            using TestRecording.DisableRecordingScope scope = Recording.DisableRecording();
            while (_projects.TryDequeue(out string projectName))
            {
                try
                {
                    await Client.DeleteProjectAsync(WaitUntil.Started, projectName).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.Status == 404)
                {
                }
            }
        }

        protected string CreateTestProjectName()
        {
            return "TestProject" + Recording.GenerateId();
        }

        protected void CreateProject(string projectName = default)
        {
            projectName ??= CreateTestProjectName();
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
            projectName ??= CreateTestProjectName();
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

        protected void EnqueueProjectDeletion(string projectName) => _projects.Enqueue(projectName);
    }
}
