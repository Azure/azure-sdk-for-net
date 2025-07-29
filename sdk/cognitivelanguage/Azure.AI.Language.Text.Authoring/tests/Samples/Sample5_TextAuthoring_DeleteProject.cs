// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample5_TextAuthoring_DeleteProject : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteProject()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample5_TextAuthoring_DeleteProject
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            Operation operation = projectClient.DeleteProject(
                waitUntil: WaitUntil.Completed
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate project deletion success.");
        }

        [Test]
        [AsyncOnly]
        public async Task DeleteProjectAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample5_TextAuthoring_DeleteProjectAsync
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            Operation operation = await projectClient.DeleteProjectAsync(
                waitUntil: WaitUntil.Completed
            );

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");
            Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
            #endregion

            Assert.AreEqual(204, operation.GetRawResponse().Status, "Expected the status to indicate project deletion success.");
        }
    }
}
