// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample18_ConversationsAuthoring_UnassignDeploymentResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void UnassignDeploymentResources()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential credential = new DefaultAzureCredential();
            ConversationAnalysisAuthoringClientOptions options =
                new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);

            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);

            #region Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResourcesAsync
            // Set project name and create client for the project
            string projectName = "EmailApp";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            // Define assigned resource ID to be unassigned
            var assignedResourceIds = new List<string>
            {
                "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02"
            };

            // Build the unassignment details
            var unassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(assignedResourceIds);

            // Start the operation
            Operation operation = projectClient.UnassignDeploymentResources(
                waitUntil: WaitUntil.Started,
                details: unassignDetails
            );

            Console.WriteLine($"UnassignDeploymentResources initiated. Status: {operation.GetRawResponse().Status}");

            // Print jobId from Operation-Location
            if (operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location))
            {
                string jobId = new Uri(location).Segments.Last().Split('?')[0];
                Console.WriteLine($"Job ID: {jobId}");
            }
            else
            {
                Console.WriteLine("Operation-Location header not found.");
            }
            #endregion
        }
    }
}
