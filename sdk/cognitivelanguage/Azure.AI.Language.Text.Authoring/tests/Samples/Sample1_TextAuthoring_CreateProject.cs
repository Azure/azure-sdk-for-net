// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample1_TextAuthoring_CreateProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample1_TextAuthoring_CreateProject
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);
            var projectData = new TextAuthoringCreateProjectDetails(
                projectKind: "{projectKind}",
                storageInputContainerName: "{storageInputContainerName}",
                language: "{language}"
            )
            {
                Description = "Project description for a Custom Entity Recognition project",
                Multilingual = true
            };
            #endregion

            Response response = projectClient.CreateProject(projectData);

            Console.WriteLine($"Project created with status: {response.Status}");

            Assert.AreEqual(201, response.Status, "Expected the status to indicate project creation success.");
        }

        [Test]
        [AsyncOnly]
        public async Task CreateProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample1_TextAuthoring_CreateProjectAsync
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);
            var projectData = new TextAuthoringCreateProjectDetails(
                projectKind: "{projectKind}",
                storageInputContainerName: "{storageInputContainerName}",
                language: "{language}"
            )
            {
                Description = "Project description for a Custom Entity Recognition project",
                Multilingual = true
            };

            Response response = await projectClient.CreateProjectAsync(projectData);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion

            Assert.AreEqual(201, response.Status, "Expected the status to indicate project creation success.");
        }
    }
}
