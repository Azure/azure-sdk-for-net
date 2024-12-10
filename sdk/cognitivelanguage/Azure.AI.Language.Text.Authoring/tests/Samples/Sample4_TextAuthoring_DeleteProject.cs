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
    public partial class Sample4_TextAuthoring_DeleteProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();

            #region Snippet:Sample4_TextAuthoring_DeleteProject
            string projectName = "ProjectToDelete";

            Operation operation = authoringClient.DeleteProject(
                waitUntil: WaitUntil.Completed,
                projectName: projectName
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate project deletion success.");
        }
    }
}
