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
    public partial class Sample18_TextAuthoring_UnassignDeploymentResourcesAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task UnassignDeploymentResourcesAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample18_TextAuthoring_UnassignDeploymentResourcesAsync
            string projectName = "MyTextProject";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
                new List<string>
                {
                    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account"
                }
            );

            Operation operation = await projectClient.UnassignDeploymentResourcesAsync(
                waitUntil: WaitUntil.Completed,
                details: unassignDetails
            );

            Console.WriteLine($"Unassign operation completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful unassignment of deployment resources.");
        }
    }
}
