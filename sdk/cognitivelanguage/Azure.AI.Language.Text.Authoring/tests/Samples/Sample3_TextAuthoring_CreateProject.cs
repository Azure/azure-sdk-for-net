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
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample3_TextAuthoring_CreateProject
            string projectName = "MyNewProject";
            TextAuthoringProject projectClient = client.GetProject(projectName);
            var projectData = new TextAuthoringCreateProjectDetails(
                projectKind: "customMultiLabelClassification",
                storageInputContainerName: "e2e0test0data",
                language: "en"
            )
            {
                Description = "Project description for a Custom Entity Recognition project",
                Multilingual = true
            };

            Response response = projectClient.CreateProject(projectData);

            Console.WriteLine($"Project created with status: {response.Status}");
            #endregion

            Assert.AreEqual(201, response.Status, "Expected the status to indicate project creation success.");
        }
    }
}
