// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:TextAuthoring_Identity_Namespace
using Azure.Identity;
using Azure.Core;
using Microsoft.Extensions.Options;
#endregion

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class CreateClient : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        public void CreateAuthoringClientForSpecificApiVersion()
        {
            #region Snippet:CreateTextAuthoringClientForSpecificApiVersion
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            credential = new(TestEnvironment.ApiKey);
#endif
            TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
            #endregion
        }

        [Test]
        public void AuthoringClient_CreateWithDefaultAzureCredential()
        {
            #region Snippet:TextAnalysisAuthoring_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("{endpoint}");;
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);
            #endregion
        }

        [Test]
        public void BadArgument()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:TextAuthoringClient_BadRequest
            try
            {
                string invalidProjectName = "InvalidProject";
                TextAuthoringProject projectClient = client.GetProject(invalidProjectName);
                var projectData = new TextAuthoringCreateProjectDetails(
                    projectKind: "Text",
                    storageInputContainerName: "e2e0test0data",
                    language: "invalid-lang" // Invalid language code
                )
                {
                    Description = "This is a test for invalid configuration."
                };

                Response response = projectClient.CreateProject(projectData);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
