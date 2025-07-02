// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetUnassignDeploymentResourcesStatus()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatus
            string projectName = "MyResourceProject";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Prepare the details for unassigning resources
            var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
                new[]
                {
                    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account"
                }
            );

            // Submit the unassign operation and get the job ID
            Operation unassignOperation = projectClient.UnassignDeploymentResources(
                waitUntil: WaitUntil.Started,
                details: unassignDetails
            );

            string operationLocation = unassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
                ? location
                : throw new InvalidOperationException("Operation-Location header not found.");

            string jobId = new Uri(location).Segments.Last().Split('?')[0];
            Console.WriteLine($"Unassign Job ID: {jobId}");

            // Call the API to get unassign job status
            Response<TextAuthoringDeploymentResourcesState> response =
                projectClient.GetUnassignDeploymentResourcesStatus(jobId);

            Console.WriteLine($"Job Status: {response.Value.Status}");

            if (response.Value.Errors != null && response.Value.Errors.Any())
            {
                Console.WriteLine("Errors:");
                foreach (var error in response.Value.Errors)
                {
                    Console.WriteLine($"- Code: {error.Code}, Message: {error.Message}");
                }
            }
            #endregion

            Assert.AreEqual("Succeeded", response.Value.Status, "Expected the unassign operation to succeed.");
        }
    }
}
