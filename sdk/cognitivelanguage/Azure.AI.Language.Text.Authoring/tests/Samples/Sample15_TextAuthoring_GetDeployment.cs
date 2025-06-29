// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample15_TextAuthoring_GetDeployment : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetDeployment()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample14_TextAuthoring_DeployProject
            string projectName = "LoanAgreements";
            string deploymentName = "DeploymentName";
            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            var deploymentDetails = new TextAuthoringCreateDeploymentDetails(trainedModelLabel: "29886710a2ae49259d62cffca977db66");

            Operation operation = deploymentClient.DeployProject(
                waitUntil: WaitUntil.Completed,
                details: deploymentDetails
            );

            Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful deployment.");
        }
    }
}
