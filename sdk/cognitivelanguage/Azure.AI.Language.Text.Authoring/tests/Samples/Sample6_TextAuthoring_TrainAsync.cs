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
    public partial class Sample5_TextAuthoring_TrainAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task TrainAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample6_TextAuthoring_TrainAsync
            string projectName = "LoanAgreements";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            var trainingJobConfig = new TextAuthoringTrainingJobDetails(
                modelLabel: "model1",
                trainingConfigVersion: "latest"
            )
            {
                EvaluationOptions = new TextAuthoringEvaluationDetails
                {
                    Kind = TextAuthoringEvaluationKind.Percentage,
                    TestingSplitPercentage = 20,
                    TrainingSplitPercentage = 80
                }
            };

            Operation<TextAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
                waitUntil: WaitUntil.Completed,
                details: trainingJobConfig
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful training.");
        }
    }
}
