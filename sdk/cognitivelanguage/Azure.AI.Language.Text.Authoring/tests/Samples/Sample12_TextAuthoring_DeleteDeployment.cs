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
    public partial class Sample12_TextAuthoring_DeleteDeployment : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteDeployment()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample12_TextAuthoring_DeleteDeployment
            string projectName = "LoanAgreements";
            string deploymentName = "DeploymentA";

            Operation operation = authoringClient.DeleteDeployment(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                deploymentName: deploymentName
            );

            Console.WriteLine($"Deployment deletion completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate successful deletion.");
        }
    }
}
