// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        private readonly List<string> _projects = new();

        public void CreateConversationAnalysisProjectsClient()
        {
            #region Snippet:ConversationAnalysisProjectsClient_Create
            Uri endpoint = new Uri("https://myaccount.cognitive.microsoft.com");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            ConversationAnalysisProjectsClient client = new ConversationAnalysisProjectsClient(endpoint, credential);
            #endregion
        }

        [SyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29140")]
        public void ImportProject()
        {
            ConversationAnalysisProjectsClient client = ProjectsClient;

            #region Snippet:ConversationAnalysisProjectsClient_ImportProject
            string projectName = "Menu";
#if !SNIPPET
            projectName = Recording.GenerateId("net-conv-", 100);
#endif

            // Define our project assets and import.
            var importData = new
            {
                projectFileVersion = "2022-05-01",
                metadata = new {
                    projectName,
                    projectKind = "Conversation",
                    multilingual = true,
                    language = "en",
                },

                assets = new
                {
                    projectKind = "Conversation",
                    entities = new[] // ConversationalAnalysisAuthoringConversationExportedEntity
                    {
                        new
                        {
                            category = "Contact",
                            compositionSetting = "combineComponents",
                            prebuilts = new[]
                            {
                                new
                                {
                                    category = "Person.Name",
                                },
                            },

                            // ... more entities.
                        }
                    },

                    intents = new[] // ConversationalAnalysisAuthoringConversationExportedIntent
                    {
                        new
                        {
                            category = "Send",
                        },

                        // ... more intents.
                    },

                    utterances = new[] // ConversationalAnalysisAuthoringConversationExportedUtterance
                    {
                        new
                        {
                            text = "Send an email to Johnson",
                            language = "en",
                            intent = "Send",
                            entities = new[]
                            {
                                new
                                {
                                    category = "Contact",
                                    offset = 17,
                                    length = 7,
                                },
                            },
                        },
                        new
                        {
                            text = "Send Kathy a calendar invite",
                            language = "en",
                            intent = "Send",
                            entities = new[]
                            {
                                new
                                {
                                    category = "Contact",
                                    offset = 5,
                                    length = 5,
                                },
                            },
                        },

                        // ... more utterances.
                    },
                },

                // Use Utf16CodeUnit for strings in .NET.
                stringIndexType = "Utf16CodeUnit",
            };

            Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Started, projectName, RequestContent.Create(importData));
#if !SNIPPET
            _projects.Add(projectName);
            importOperation = InstrumentOperation(importOperation);
#endif
            importOperation.WaitForCompletion();

            // Train the model.
            var trainData = new
            {
                modelLabel = "Sample5",
                trainingMode = "standard",
            };

            Operation<BinaryData> trainOperation = client.Train(WaitUntil.Started, projectName, RequestContent.Create(trainData));
#if !SNIPPET
            trainOperation = InstrumentOperation(trainOperation);
#endif
            trainOperation.WaitForCompletion();

            // Deploy the model.
            var deployData = new
            {
                trainedModelLabel = "Sample5",
            };

            Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Started, projectName, "production", RequestContent.Create(deployData));
#if !SNIPPET
            deployOperation = InstrumentOperation(deployOperation);
#endif
            deployOperation.WaitForCompletion();
#endregion

            using JsonDocument doc = JsonDocument.Parse(deployOperation.Value);
            Assert.False(doc.RootElement.TryGetProperty("errors", out JsonElement errors) && errors.ValueKind == JsonValueKind.Array && errors.GetArrayLength() > 0);
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task ImportProjectAsync()
        {
            ConversationAnalysisProjectsClient client = ProjectsClient;

            #region Snippet:ConversationAnalysisProjectsClient_ImportProjectAsync
            string projectName = "Menu";
#if !SNIPPET
            projectName = Recording.GenerateId("net-conv-", 100);
#endif

            // Define our project assets and import.
            var importData = new
            {
                projectFileVersion = "2022-05-01",
                metadata = new
                {
                    projectName,
                    projectKind = "Conversation",
                    multilingual = true,
                    language = "en",
                },

                assets = new
                {
                    projectKind = "Conversation",
                    entities = new[] // ConversationalAnalysisAuthoringConversationExportedEntity
                    {
                        new
                        {
                            category = "Contact",
                            compositionSetting = "combineComponents",
                            prebuilts = new[]
                            {
                                new
                                {
                                    category = "Person.Name",
                                },
                            },

                            // ... more entities.
                        }
                    },

                    intents = new[] // ConversationalAnalysisAuthoringConversationExportedIntent
                    {
                        new
                        {
                            category = "Send",
                        },

                        // ... more intents.
                    },

                    utterances = new[] // ConversationalAnalysisAuthoringConversationExportedUtterance
                    {
                        new
                        {
                            text = "Send an email to Johnson",
                            language = "en",
                            intent = "Send",
                            entities = new[]
                            {
                                new
                                {
                                    category = "Contact",
                                    offset = 17,
                                    length = 7,
                                },
                            },
                        },
                        new
                        {
                            text = "Send Kathy a calendar invite",
                            language = "en",
                            intent = "Send",
                            entities = new[]
                            {
                                new
                                {
                                    category = "Contact",
                                    offset = 5,
                                    length = 5,
                                },
                            },
                        },

                        // ... more utterances.
                    },
                },

                // Use Utf16CodeUnit for strings in .NET.
                stringIndexType = "Utf16CodeUnit",
            };

            Operation<BinaryData> importOperation = await client.ImportProjectAsync(WaitUntil.Started, projectName, RequestContent.Create(importData));
#if !SNIPPET
            _projects.Add(projectName);
            //importOperation = InstrumentOperation(importOperation);
#endif
            await importOperation.WaitForCompletionAsync();

            // Train the model.
            var trainData = new
            {
                modelLabel = "Sample5",
                trainingMode = "standard",
            };

            Operation<BinaryData> trainOperation = await client.TrainAsync(WaitUntil.Started, projectName, RequestContent.Create(trainData));
#if !SNIPPET
            //trainOperation = InstrumentOperation(trainOperation);
#endif
            await trainOperation.WaitForCompletionAsync();

            // Deploy the model.
            var deployData = new
            {
                trainedModelLabel = "Sample5",
            };

            Operation<BinaryData> deployOperation = await client.DeployProjectAsync(WaitUntil.Started, projectName, "production", RequestContent.Create(deployData));
#if !SNIPPET
            //deployOperation = InstrumentOperation(deployOperation);
#endif
            await deployOperation.WaitForCompletionAsync();
            #endregion

            using JsonDocument doc = JsonDocument.Parse(deployOperation.Value);
            Assert.False(doc.RootElement.TryGetProperty("errors", out JsonElement errors) && errors.ValueKind == JsonValueKind.Array && errors.GetArrayLength() > 0);
        }

        public override async Task StopTestRecordingAsync()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                RequestContext context = new()
                {
                    ErrorOptions = ErrorOptions.NoThrow,
                };

                using (Recording.DisableRecording())
                {
                    foreach (string projectName in _projects)
                    {
                        await ProjectsClient.DeleteProjectAsync(WaitUntil.Completed, projectName, context);
                    }
                }
            }

            await base.StopTestRecordingAsync();
        }
    }
}
