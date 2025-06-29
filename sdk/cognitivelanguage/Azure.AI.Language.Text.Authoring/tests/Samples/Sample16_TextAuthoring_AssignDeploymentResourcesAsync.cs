// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample16_TextAuthoring_AssignDeploymentResourcesAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task AssignDeploymentResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample16_TextAuthoring_AssignDeploymentResourcesAsync
            string projectName = "MyTextProject";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var resourceMetadata = new TextAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account",
                customDomain: "my-custom-domain",
                region: "my-region"
            );

            var assignDetails = new TextAuthoringAssignDeploymentResourcesDetails(
                new List<TextAuthoringResourceMetadata> { resourceMetadata }
            );

            Operation operation = await projectClient.AssignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Completed,
                details: assignDetails
            );

            Console.WriteLine($"Deployment resources assigned with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
