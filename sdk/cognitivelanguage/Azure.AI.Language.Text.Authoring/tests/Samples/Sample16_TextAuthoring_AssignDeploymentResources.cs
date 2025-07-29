// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample16_TextAuthoring_AssignDeploymentResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AssignDeploymentResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample16_TextAuthoring_AssignDeploymentResources
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var resourceMetadata = new TextAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
                customDomain: "{customDomain}",
                region: "{Region}"
            );

            var assignDetails = new TextAuthoringAssignDeploymentResourcesDetails(
                new List<TextAuthoringResourceMetadata> { resourceMetadata }
            );

            Operation operation = projectClient.AssignDeploymentResources(
                waitUntil: WaitUntil.Completed,
                details: assignDetails
            );

            Console.WriteLine($"Deployment resources assigned with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task AssignDeploymentResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample16_TextAuthoring_AssignDeploymentResourcesAsync
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var resourceMetadata = new TextAuthoringResourceMetadata(
                azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
                customDomain: "{customDomain}",
                region: "{Region}"
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
