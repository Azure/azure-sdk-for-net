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
            string projectName = "{projectName}";

            var projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                projectName: projectName,
                language: "en-us"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.0F),
                Multilingual = false,
                Description = string.Empty
            };

            var projectAssets = new ConversationExportedProjectAsset();
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "None"));
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "Buy"));

            var entity = new ConversationExportedEntity(category: "product")
            {
                CompositionMode = ConversationAuthoringCompositionMode.CombineComponents
            };
            projectAssets.Entities.Add(entity);

            projectAssets.Utterances.Add(new ConversationExportedUtterance(text: "I want to buy a house", intent: "Buy")
            {
                Language = "en-us",
                Dataset = "Train"
            });
            projectAssets.Utterances[0].Entities.Add(new ExportedUtteranceEntityLabel(category: "product", offset: 16, length: 5));

            var exportedProject = new ConversationAuthoringExportedProject(
                projectFileVersion: "2022-10-01-preview",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            Operation operation = client.Import(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ImportAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_ConversationsAuthoring_ImportAsync
            string projectName = "{projectName}";

            var projectMetadata = new ConversationAuthoringCreateProjectDetails(
                projectKind: "Conversation",
                projectName: projectName,
                language: "en-us"
            )
            {
                Settings = new ConversationAuthoringProjectSettings(0.0F),
                Multilingual = false,
                Description = string.Empty
            };

            var projectAssets = new ConversationExportedProjectAsset();
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "None"));
            projectAssets.Intents.Add(new ConversationExportedIntent(category: "Buy"));

            var entity = new ConversationExportedEntity(category: "product")
            {
                CompositionMode = ConversationAuthoringCompositionMode.CombineComponents
            };
            projectAssets.Entities.Add(entity);

            projectAssets.Utterances.Add(new ConversationExportedUtterance(text: "I want to buy a house", intent: "Buy")
            {
                Language = "en-us",
                Dataset = "Train"
            });
            projectAssets.Utterances[0].Entities.Add(new ExportedUtteranceEntityLabel(category: "product", offset: 16, length: 5));

            var exportedProject = new ConversationAuthoringExportedProject(
                projectFileVersion: "2022-10-01-preview",
                stringIndexType: StringIndexType.Utf16CodeUnit,
                metadata: projectMetadata
            )
            {
                Assets = projectAssets
            };

            Operation operation = await client.ImportAsync(
                waitUntil: WaitUntil.Completed,
                projectName: projectName,
                exportedProject: exportedProject,
                exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
            );

            Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
            #endregion
        }
    }
}
