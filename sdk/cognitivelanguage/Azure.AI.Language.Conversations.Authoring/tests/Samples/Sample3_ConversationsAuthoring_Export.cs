// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample3_ConversationsAuthoring_Export : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void Export()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            #region Snippet:Sample3_ConversationsAuthoring_Export
            string projectName = "MyExportedProject";

            Operation operation = authoringClient.Export(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                stringIndexType: StringIndexType.Utf16CodeUnit,
                exportedProjectFormat: ExportedProjectFormat.Conversation
            );

             // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
