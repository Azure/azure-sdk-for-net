// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Authoring.Conversations.Models;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample13_ConversationsAuthoring_GetDeploymentStatus : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetDeploymentStatus()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";
            string deploymentName = "SampleDeployment";
            string jobId = "SampleJobId";

            #region Snippet:Sample13_ConversationsAuthoring_GetDeploymentStatus
            Response<GetDeploymentStatusResult> response = authoringClient.GetDeploymentStatus(
                projectName: projectName,
                deploymentName: deploymentName,
                jobId: jobId
            );

            Console.WriteLine($"Job ID: {response.Value.JobId}");
            Console.WriteLine($"Created Time: {response.Value.CreatedDateTime}");
            Console.WriteLine($"Last Updated Time: {response.Value.LastUpdatedDateTime}");
            Console.WriteLine($"Expiration Time: {response.Value.ExpirationDateTime}");
            Console.WriteLine($"Status: {response.Value.Status}");
            #endregion

            Assert.AreEqual(200, response.GetRawResponse().Status);
        }
    }
}
