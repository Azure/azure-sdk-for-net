// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatusAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetUnassignDeploymentResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatusAsync
            string projectName = "MyResourceProjectAsync";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            // Prepare the details for unassigning resources
            var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
                new[]
                {
                    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account"
                }
            );

            // Submit the unassign operation and get the job ID
            Operation unassignOperation = await projectClient.UnassignDeploymentResourcesAsync(
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
                await projectClient.GetUnassignDeploymentResourcesStatusAsync(jobId);

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
        }
    }
}
