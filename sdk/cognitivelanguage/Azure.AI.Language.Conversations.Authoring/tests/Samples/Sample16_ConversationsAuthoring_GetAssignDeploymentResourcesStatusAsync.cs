// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Authoring.Conversations.Models;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample16_ConversationsAuthoring_GetAssignDeploymentResourcesStatusAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetAssignDeploymentResourcesStatusAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";
            string jobId = "SampleJobId";

            #region Snippet:Sample16_ConversationsAuthoring_GetAssignDeploymentResourcesStatusAsync
            Response<GetAssignDeploymentResourcesStatusResult> response;
            do
            {
                response = await authoringClient.GetAssignDeploymentResourcesStatusAsync(
                    projectName: projectName,
                    jobId: jobId
                );

                Console.WriteLine($"Job ID: {response.Value.JobId}");
                Console.WriteLine($"Status: {response.Value.Status}");
                Console.WriteLine($"Created Date Time: {response.Value.CreatedDateTime}");
                Console.WriteLine($"Last Updated Date Time: {response.Value.LastUpdatedDateTime}");
                Console.WriteLine($"Expiration Date Time: {response.Value.ExpirationDateTime}");

                if (response.Value.Status != JobStatus.Succeeded)
                {
                    // Wait before polling again
                    Thread.Sleep(2000);
                }
            } while (response.Value.Status != JobStatus.Succeeded);
            #endregion
        }
    }
}
