// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample17_TextAuthoring_GetAssignDeploymentResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetAssignDeploymentResourcesStatus()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample17_TextAuthoring_GetAssignDeploymentResourcesStatus
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

            // Submit assignment operation
            Operation assignOperation = projectClient.AssignDeploymentResources(
                waitUntil: WaitUntil.Started,
                details: assignDetails
            );

            string operationLocation = assignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
                ? location
                : throw new InvalidOperationException("Operation-Location header not found.");

            // Extract only the jobId part from the URL
            string jobId = new Uri(location).Segments.Last().Split('?')[0];
            Console.WriteLine($"Job ID: {jobId}");

            // Call status API
            Response<TextAuthoringDeploymentResourcesState> statusResponse = projectClient.GetAssignDeploymentResourcesStatus(jobId);

            Console.WriteLine($"Deployment assignment status: {statusResponse.Value.Status}");
            #endregion
        }
    }
}
