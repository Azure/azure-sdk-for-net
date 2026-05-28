// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection.Emit;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample3_TextAuthoring_Export : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void Export()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample3_TextAuthoring_Export
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            Operation operation = projectClient.Export(
                waitUntil: WaitUntil.Completed,
                stringIndexType: StringIndexType.Utf16CodeUnit
            );

            // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ExportAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample3_TextAuthoring_ExportAsync
            string projectName = "{projectName}";
            TextAuthoringProject projectClient = client.GetProject(projectName);

            Operation operation = await projectClient.ExportAsync(
                waitUntil: WaitUntil.Completed,
                stringIndexType: StringIndexType.Utf16CodeUnit
            );

            // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
