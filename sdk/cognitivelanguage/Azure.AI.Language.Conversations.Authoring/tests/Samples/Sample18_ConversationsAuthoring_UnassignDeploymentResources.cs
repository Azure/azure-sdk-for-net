// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample18_ConversationsAuthoring_UnassignDeploymentResources : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void UnassignDeploymentResources()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResources
            // Set project name and create client for the project
            string sampleProjectName = "{projectName}";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            // Define assigned resource ID to be unassigned
            var sampleUnassignIds = new ConversationAuthoringProjectResourceIds
            {
                AzureResourceIds =
                {
                    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                }
            };

            // Start the operation
            Operation sampleOperation = sampleProjectClient.UnassignProjectResources(
                waitUntil: WaitUntil.Started,
                details: sampleUnassignIds
            );

            Console.WriteLine($"UnassignDeploymentResources initiated. Status: {sampleOperation.GetRawResponse().Status}");

            // Print jobId from Operation-Location
            if (sampleOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location))
            {
                string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
                Console.WriteLine($"Job ID: {sampleJobId}");
            }
            else
            {
                Console.WriteLine("Operation-Location header not found.");
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task UnassignDeploymentResourcesAsync()
        {
            Uri sampleEndpoint = TestEnvironment.Endpoint;
            DefaultAzureCredential sampleCredential = new DefaultAzureCredential();
            var sampleClient = new ConversationAnalysisAuthoringClient(sampleEndpoint, sampleCredential);

            #region Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResourcesAsync
            // Set project name and create client for the project
            string sampleProjectName = "{projectName}";
            ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

            // Define assigned resource ID to be unassigned
            var sampleUnassignIds = new ConversationAuthoringProjectResourceIds
            {
                AzureResourceIds =
                {
                    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
                }
            };

            // Call the operation
            Operation sampleOperation = await sampleProjectClient.UnassignProjectResourcesAsync(
                waitUntil: WaitUntil.Started,
                details: sampleUnassignIds
            );

            Console.WriteLine($"UnassignDeploymentResourcesAsync initiated. Status: {sampleOperation.GetRawResponse().Status}");

            // Print jobId from Operation-Location
            if (sampleOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location))
            {
                string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
                Console.WriteLine($"Job ID: {sampleJobId}");
            }
            else
            {
                Console.WriteLine("Operation-Location header not found.");
            }
            #endregion
        }
    }
}
