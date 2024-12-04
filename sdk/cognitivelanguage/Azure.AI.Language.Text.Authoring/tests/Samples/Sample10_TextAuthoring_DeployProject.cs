﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Models;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample10_TextAuthoring_DeployProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeployProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample10_TextAuthoring_DeployProject
            string projectName = "LoanAgreements";
            string deploymentName = "DeploymentName";
            var deploymentDetails = new CreateDeploymentDetails(trainedModelLabel: "29886710a2ae49259d62cffca977db66");

            Operation operation = authoringClient.DeployProject(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName,
                body: deploymentDetails
            );

            Console.WriteLine($"Deployment operation status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful deployment.");
        }
    }
}
