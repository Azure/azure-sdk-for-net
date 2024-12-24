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
    public partial class Sample9_TextAuthoring_DeleteTrainedModelAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task DeleteTrainedModelAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample9_TextAuthoring_DeleteTrainedModelAsync
            string projectName = "LoanAgreements";
            string trainedModelLabel = "ModelLabel"; // Replace with the actual model label.

            Response response = await authoringClient.DeleteTrainedModelAsync(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status, "Expected the status to indicate successful deletion.");
        }
    }
}
