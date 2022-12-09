// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

#region Snippet:ConversationAuthoringClient_Namespaces
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring;
#endregion

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    [IgnoreServiceError(429, "429", Reason = "Exceeded rate limit of S pricing tier given number of tests run")]
    public partial class ConversationAnalysisClientSamples
    {
        private readonly List<string> _projects = new();

        public void CreateConversationAuthoringClient()
        {
            #region Snippet:ConversationAuthoringClient_Create
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            ConversationAuthoringClient client = new ConversationAuthoringClient(endpoint, credential);
            #endregion
        }

        [SyncOnly]
        [RecordedTest]
        public async Task ImportProject()
        {
            ConversationAuthoringClient client = ProjectsClient;

            #region Snippet:ConversationAuthoringClient_ImportProject
            string projectName = "Menu";
#if !SNIPPET
            projectName = Recording.GenerateId("net-conv-", 100);
#endif

            // Define our project assets and import. In practice this would most often be read from a file.
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

#if SNIPPET
            Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Completed, projectName, RequestContent.Create(importData));
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Started, projectName, RequestContent.Create(importData));
            await InstrumentOperation(importOperation).WaitForCompletionAsync();

            _projects.Add(projectName);
#endif

            // Train the model.
            var trainData = new
            {
                modelLabel = "Sample5",
                trainingMode = "standard",
            };

            Console.WriteLine($"Training project {projectName}...");
#if SNIPPET
            Operation<BinaryData> trainOperation = client.Train(WaitUntil.Completed, projectName, RequestContent.Create(trainData));
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> trainOperation = client.Train(WaitUntil.Started, projectName, RequestContent.Create(trainData));
            await InstrumentOperation(trainOperation).WaitForCompletionAsync();
#endif

                // Deploy the model.
                var deployData = new
                {
                    trainedModelLabel = "Sample5",
                };

            Console.WriteLine($"Deploying project {projectName} to production...");
#if SNIPPET
            Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Completed, projectName, "production", RequestContent.Create(deployData));
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Started, projectName, "production", RequestContent.Create(deployData));
            deployOperation = InstrumentOperation(deployOperation);
            await deployOperation.WaitForCompletionAsync();
#endif

            Console.WriteLine("Import complete");
            #endregion

            // TODO: Delete this line and uncomment the next when https://github.com/Azure/azure-sdk-for-net/issues/29140 is resolved.
            using JsonDocument doc = await JsonDocument.ParseAsync(deployOperation.Value.ToStream());
            // using JsonDocument doc = JsonDocument.Parse(deployOperation.Value);
            Assert.False(doc.RootElement.TryGetProperty("errors", out JsonElement errors) && errors.ValueKind == JsonValueKind.Array && errors.GetArrayLength() > 0);
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task ImportProjectAsync()
        {
            ConversationAuthoringClient client = ProjectsClient;

            string projectName = Recording.GenerateId("net-conv-", 100);

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

#region Snippet:ConversationAuthoringClient_ImportProjectAsync
            Operation<BinaryData> importOperation = await client.ImportProjectAsync(WaitUntil.Completed, projectName, RequestContent.Create(importData));
#if !SNIPPET
            _projects.Add(projectName);
#endif

            // Train the model.
            var trainData = new
            {
                modelLabel = "Sample5",
                trainingMode = "standard",
            };

            Console.WriteLine($"Training project {projectName}...");
            Operation<BinaryData> trainOperation = await client.TrainAsync(WaitUntil.Completed, projectName, RequestContent.Create(trainData));

            // Deploy the model.
            var deployData = new
            {
                trainedModelLabel = "Sample5",
            };

            Console.WriteLine($"Deploying project {projectName} to production...");
            Operation<BinaryData> deployOperation = await client.DeployProjectAsync(WaitUntil.Completed, projectName, "production", RequestContent.Create(deployData));

            Console.WriteLine("Import complete");
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
