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
    public partial class Sample11_TextAuthoring_DeleteTrainedModel : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteTrainedModel()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample11_TextAuthoring_DeleteTrainedModel
            string projectName = "{projectName}";
            string trainedModelLabel = "{modelLabel}";
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Response response = trainedModelClient.DeleteTrainedModel();

            Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status, "Expected the status to indicate successful deletion.");
        }

        [Test]
        [AsyncOnly]
        public async Task DeleteTrainedModelAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample11_TextAuthoring_DeleteTrainedModelAsync
            string projectName = "{projectName}";
            string trainedModelLabel = "{modelLabel}";
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Response response = await trainedModelClient.DeleteTrainedModelAsync();

            Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status, "Expected the status to indicate successful deletion.");
        }
    }
}
