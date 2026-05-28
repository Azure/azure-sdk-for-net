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
    public partial class Sample10_TextAuthoring_LoadSnapshot : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void LoadSnapshot()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample10_TextAuthoring_LoadSnapshot
            string projectName = "{projectName}";
            string trainedModelLabel = "{modelLabel}";
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Operation operation = trainedModelClient.LoadSnapshot(
                waitUntil: WaitUntil.Completed
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful snapshot loading.");
        }

        [Test]
        [AsyncOnly]
        public async Task LoadSnapshotAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample10_TextAuthoring_LoadSnapshotAsync
            string projectName = "{projectName}";
            string trainedModelLabel = "{modelLabel}"; // Replace with your actual model label.
            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Operation operation = await trainedModelClient.LoadSnapshotAsync(
                waitUntil: WaitUntil.Completed
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(200, operation.GetRawResponse().Status, "Expected the status to indicate successful snapshot loading.");
        }
    }
}
