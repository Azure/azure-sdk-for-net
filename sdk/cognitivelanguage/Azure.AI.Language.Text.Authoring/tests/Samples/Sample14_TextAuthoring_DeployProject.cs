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
    public partial class Sample14_TextAuthoring_DeployProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeployProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_TextAuthoring_DeployProject
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            var deploymentDetails = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "{modelLabel}");

            Operation operation = deploymentClient.DeployProject(
                waitUntil: WaitUntil.Completed,
                details: deploymentDetails
            );

            Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful deployment.");
        }

        [Test]
        [AsyncOnly]
        public async Task DeployProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_TextAuthoring_DeployProjectAsync
            string projectName = "{projectName}";
            string deploymentName = "{deploymentName}";
            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            var deploymentConfig = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "{modelLabel}");

            Operation operation = await deploymentClient.DeployProjectAsync(
                waitUntil: WaitUntil.Completed,
                details: deploymentConfig
            );

            Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful deployment.");
        }
    }
}
