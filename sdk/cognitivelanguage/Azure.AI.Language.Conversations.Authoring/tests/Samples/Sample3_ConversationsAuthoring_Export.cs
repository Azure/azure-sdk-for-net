// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample3_ConversationsAuthoring_Export
            ConversationAuthoringProject projectClient = client.GetConversationAuthoringProjectClient();

            string projectName = "{projectName}";
            Operation operation = projectClient.Export(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                stringIndexType: StringIndexType.Utf16CodeUnit,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
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
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample3_ConversationsAuthoring_ExportAsync
            ConversationAuthoringProject projectClient = client.GetConversationAuthoringProjectClient();

            string projectName = "{projectName}";
            Operation operation = await projectClient.ExportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                stringIndexType: StringIndexType.Utf16CodeUnit,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
