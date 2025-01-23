// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample3_TextAuthoring_CreateProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample3_TextAuthoring_CreateProject
            string projectName = "MyNewProject";
            var projectData = new
            {
                projectName = projectName,
                language = "en",
                projectKind = "CustomEntityRecognition",
                description = "Project description for a Custom Entity Recognition project",
                multilingual = true
            };

            using RequestContent content = RequestContent.Create(projectData);
            Response response = authoringClient.CreateProject(projectName, content);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion

            Assert.AreEqual(201, response.Status, "Expected the status to indicate project creation success.");
        }
    }
}
