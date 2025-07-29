// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample12_TextAuthoring_SwapDeployments : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void SwapDeployments()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample12_TextAuthoring_SwapDeployments
            string projectName = "{projectName}";
            string firstDeploymentName = "{deploymentName1}";
            string secondDeploymentName = "{deploymentName2}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var swapDetails = new TextAuthoringSwapDeploymentsDetails(
                firstDeploymentName: firstDeploymentName,
                secondDeploymentName: secondDeploymentName
                );

            Operation operation = projectClient.SwapDeployments(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
            );

            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful swap.");
        }

        [Test]
        [AsyncOnly]
        public async Task SwapDeploymentsAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample12_TextAuthoring_SwapDeploymentsAsync
            string projectName = "{projectName}";
            string firstDeploymentName = "{deploymentName1}";
            string secondDeploymentName = "{deploymentName2}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var swapDetails = new TextAuthoringSwapDeploymentsDetails
            (
                firstDeploymentName: firstDeploymentName,
                secondDeploymentName: secondDeploymentName
                );

            Operation operation = await projectClient.SwapDeploymentsAsync(
                waitUntil: WaitUntil.Completed,
                details: swapDetails
            );

            Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful swap.");
        }
    }
}
