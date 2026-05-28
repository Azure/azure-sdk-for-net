// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample4_TextAuthoring_GetProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample4_TextAuthoring_GetProject
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            Response<TextAuthoringProjectMetadata> response = projectClient.GetProject();
            TextAuthoringProjectMetadata projectMetadata = response.Value;

            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample4_TextAuthoring_GetProjectAsync
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            Response<TextAuthoringProjectMetadata> response = await projectClient.GetProjectAsync();
            TextAuthoringProjectMetadata projectMetadata = response.Value;

            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            #endregion
        }
    }
}
