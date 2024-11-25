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
    public partial class Sample8_TextAuthoring_LoadSnapshotAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task LoadSnapshotAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample8_TextAuthoring_LoadSnapshotAsync
            string projectName = "LoanAgreements";
            string trainedModelLabel = "ModelLabel"; // Replace with your actual model label.

            Operation operation = await authoringClient.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                trainedModelLabel: trainedModelLabel
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful snapshot loading.");
        }
    }
}
