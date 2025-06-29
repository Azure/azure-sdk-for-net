// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample15_TextAuthoring_GetDeploymentAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetDeploymentAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample15_TextAuthoring_GetDeploymentAsync
            string projectName = "MyDeploymentProjectAsync";
            string deploymentName = "Deployment1";
            TextAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

            Response<TextAuthoringProjectDeployment> response = await deploymentClient.GetDeploymentAsync();

            TextAuthoringProjectDeployment deployment = response.Value;

            Console.WriteLine($"Deployment Name: {deployment.DeploymentName}");
            Console.WriteLine($"Model Id: {deployment.ModelId}");
            Console.WriteLine($"Last Trained On: {deployment.LastTrainedOn}");
            Console.WriteLine($"Last Deployed On: {deployment.LastDeployedOn}");
            Console.WriteLine($"Deployment Expired On: {deployment.DeploymentExpiredOn}");
            Console.WriteLine($"Model Training Config Version: {deployment.ModelTrainingConfigVersion}");
            #endregion
        }
    }
}
