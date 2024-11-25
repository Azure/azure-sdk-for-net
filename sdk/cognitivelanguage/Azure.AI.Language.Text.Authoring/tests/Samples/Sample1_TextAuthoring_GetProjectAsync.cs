// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Models;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample1_TextAuthoring_GetProjectAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample1_TextAuthoring_GetProjectAsync
            string projectName = "MyTextProjectAsync";

            Response<ProjectMetadata> response = await authoringClient.GetProjectAsync(projectName);
            ProjectMetadata projectMetadata = response.Value;

            Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
            Console.WriteLine($"Language: {projectMetadata.Language}");
            Console.WriteLine($"Created DateTime: {projectMetadata.CreatedDateTime}");
            Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedDateTime}");
            Console.WriteLine($"Description: {projectMetadata.Description}");
            #endregion
        }
    }
}
