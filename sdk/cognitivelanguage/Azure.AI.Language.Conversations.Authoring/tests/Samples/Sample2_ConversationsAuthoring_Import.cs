// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample2_ConversationsAuthoring_Import : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void Import()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            #region Snippet:Sample1_ConversationsAuthoring_Import
            string projectName = "MyImportedProject";

            var projectMetadata = new CreateProjectConfig(
                projectKind: "Conversation",
                settings: new ProjectSettings
                (
                    confidenceThreshold : 0.7F
                ),
                projectName: projectName,
                multilingual: true,
                description: "Trying out CLU with assets",
                language: "en"
            );

            var projectAssets = new ConversationExportedProjectAssets();

            projectAssets.Intents.Add(new ConversationExportedIntent ( category : "intent1" ));
            projectAssets.Intents.Add(new ConversationExportedIntent ( category : "intent2" ));

            projectAssets.Entities.Add(new ConversationExportedEntity ( category : "entity1" ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "text1",
                language: "en",
                intent: "intent1",
                dataset: "dataset1",
                entities: new List<ExportedUtteranceEntityLabel>
                {
                    new ExportedUtteranceEntityLabel
                    (
                        category : "entity1",
                        offset : 5,
                        length : 5
                    )
                }
            ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "text2",
                language: "en",
                intent: "intent2",
                dataset: "dataset1",
                entities: new List<ExportedUtteranceEntityLabel>()
            ));

            var exportedProject = new ExportedProject(
                projectFileVersion: "2023-10-01",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            Operation operation = authoringClient.Import(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                body: exportedProject,
                exportedProjectFormat: ExportedProjectFormat.Conversation
            );

             // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
