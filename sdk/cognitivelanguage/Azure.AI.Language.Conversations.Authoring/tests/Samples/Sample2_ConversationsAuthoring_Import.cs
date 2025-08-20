// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_ConversationsAuthoring_Import
            string projectName = "MyImportedProject";
            ConversationAuthoringProject projectClient = client.GetProject(projectName);

            ConversationAuthoringCreateProjectDetails projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                language: "en"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.7F),
                Multilingual = true,
                Description = "Trying out CLU with assets"
            };

            ConversationExportedProjectAsset projectAssets = new ConversationExportedProjectAsset();

            projectAssets.Intents.Add(new ConversationExportedIntent ( category : "intent1" ));
            projectAssets.Intents.Add(new ConversationExportedIntent ( category : "intent2" ));

            projectAssets.Entities.Add(new ConversationExportedEntity ( category : "entity1" ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "text1",
                intent: "intent1"
            )
            {
                Language = "en",
                Dataset = "dataset1"
            });

            projectAssets.Utterances[projectAssets.Utterances.Count - 1].Entities.Add(new ExportedUtteranceEntityLabel(
                category: "entity1",
                offset: 5,
                length: 5
            ));

            projectAssets.Utterances.Add(new ConversationExportedUtterance(
                text: "text2",
                intent: "intent2"
            )
            {
                Language = "en",
                Dataset = "dataset1"
            });

            ConversationAuthoringExportedProject exportedProject = new ConversationAuthoringExportedProject(
                projectFileVersion: "2023-10-01",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            Operation operation = projectClient.Import(
                waitUntil: WaitUntil.Completed,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

             // Extract the operation-location header
            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
            Console.WriteLine($"Operation Location: {operationLocation}");

            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
