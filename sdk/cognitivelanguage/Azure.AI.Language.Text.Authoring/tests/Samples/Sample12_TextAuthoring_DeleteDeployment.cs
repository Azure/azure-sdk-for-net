﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public partial class Sample12_TextAuthoring_DeleteDeployment : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteDeployment()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample12_TextAuthoring_DeleteDeployment
            string projectName = "LoanAgreements";
            string deploymentName = "DeploymentA";
            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            Operation operation = deploymentClient.DeleteDeployment(
                waitUntil: WaitUntil.Completed
            );

            Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate successful deletion.");
        }
    }
}
