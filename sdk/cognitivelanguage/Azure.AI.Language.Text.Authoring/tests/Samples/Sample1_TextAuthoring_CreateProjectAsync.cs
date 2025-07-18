// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample1_TextAuthoring_CreateProjectAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task CreateProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample1_TextAuthoring_CreateProjectAsync
            string projectName = "MyNewProjectAsync";
            TextAuthoringProject projectClient = client.GetProject(projectName);
            var projectData = new TextAuthoringCreateProjectDetails(
                projectKind: "customMultiLabelClassification",
                storageInputContainerName: "test-data",
                language: "en"
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
