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
using Azure.Core.Serialization;
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
                ProjectFileVersion = "2022-05-01",
                Metadata = new {
                    ProjectName = projectName,
                    ProjectKind = "Conversation",
                    Multilingual = true,
                    Language = "en",
                },

                Assets = new
                {
                    ProjectKind = "Conversation",
                    Entities = new[] // ConversationalAnalysisAuthoringConversationExportedEntity
                    {
                        new
                        {
                            Category = "Contact",
                            CompositionSetting = "combineComponents",
                            Prebuilts = new[]
                            {
                                new
                                {
                                    Category = "Person.Name",
                                },
                            },

                            // ... more entities.
                        }
                    },

                    Intents = new[] // ConversationalAnalysisAuthoringConversationExportedIntent
                    {
                        new
                        {
                            Category = "Send",
                        },

                        // ... more intents.
                    },

                    Utterances = new[] // ConversationalAnalysisAuthoringConversationExportedUtterance
                    {
                        new
                        {
                            Text = "Send an email to Johnson",
                            Language = "en",
                            Intent = "Send",
                            Entities = new[]
                            {
                                new
                                {
                                    Category = "Contact",
                                    Offset = 17,
                                    Length = 7,
                                },
                            },
                        },
                        new
                        {
                            Text = "Send Kathy a calendar invite",
                            Language = "en",
                            Intent = "Send",
                            Entities = new[]
                            {
                                new
                                {
                                    Category = "Contact",
                                    Offset = 5,
                                    Length = 5,
                                },
                            },
                        },

                        // ... more utterances.
                    },
                },

                // Use Utf16CodeUnit for strings in .NET.
                StringIndexType = "Utf16CodeUnit",
            };

#if SNIPPET
            Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Completed, projectName, RequestContent.Create(importData, JsonPropertyNames.CamelCase));
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> importOperation = client.ImportProject(WaitUntil.Started, projectName, RequestContent.Create(importData, JsonPropertyNames.CamelCase));
            await InstrumentOperation(importOperation).WaitForCompletionAsync();

            _projects.Add(projectName);
#endif

            // Train the model.
            var trainData = new
            {
                ModelLabel = "Sample5",
                TrainingMode = "standard",
            };

            Console.WriteLine($"Training project {projectName}...");
#if SNIPPET
            Operation<BinaryData> trainOperation = client.Train(WaitUntil.Completed, projectName, RequestContent.Create(trainData, JsonPropertyNames.CamelCase));
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> trainOperation = client.Train(WaitUntil.Started, projectName, RequestContent.Create(trainData, JsonPropertyNames.CamelCase));
            await InstrumentOperation(trainOperation).WaitForCompletionAsync();
#endif

            // Deploy the model.
            var deployData = new
            {
                TrainedModelLabel = "Sample5",
            };

            Console.WriteLine($"Deploying project {projectName} to production...");
#if SNIPPET
            Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Completed, projectName, "production", RequestContent.Create(deployData, JsonPropertyNames.CamelCase));
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> deployOperation = client.DeployProject(WaitUntil.Started, projectName, "production", RequestContent.Create(deployData, JsonPropertyNames.CamelCase));
            deployOperation = InstrumentOperation(deployOperation);
            await deployOperation.WaitForCompletionAsync();
#endif

            Console.WriteLine("Import complete");
            #endregion

            dynamic deployResult = deployOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.That(deployResult.Errors, Is.Null.Or.Empty);

            // Need to always await something for when SNIPPET is defined above.
            await Task.Yield();
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
                ProjectFileVersion = "2022-05-01",
                Metadata = new
                {
                    ProjectName = projectName,
                    ProjectKind = "Conversation",
                    Multilingual = true,
                    Language = "en",
                },

                Assets = new
                {
                    ProjectKind = "Conversation",
                    Entities = new[] // ConversationalAnalysisAuthoringConversationExportedEntity
                    {
                        new
                        {
                            Category = "Contact",
                            CompositionSetting = "combineComponents",
                            Prebuilts = new[]
                            {
                                new
                                {
                                    Category = "Person.Name",
                                },
                            },

                            // ... more entities.
                        }
                    },

                    Intents = new[] // ConversationalAnalysisAuthoringConversationExportedIntent
                    {
                        new
                        {
                            Category = "Send",
                        },

                        // ... more intents.
                    },

                    Utterances = new[] // ConversationalAnalysisAuthoringConversationExportedUtterance
                    {
                        new
                        {
                            Text = "Send an email to Johnson",
                            Language = "en",
                            Intent = "Send",
                            Entities = new[]
                            {
                                new
                                {
                                    Category = "Contact",
                                    Offset = 17,
                                    Length = 7,
                                },
                            },
                        },
                        new
                        {
                            Text = "Send Kathy a calendar invite",
                            Language = "en",
                            Intent = "Send",
                            Entities = new[]
                            {
                                new
                                {
                                    Category = "Contact",
                                    Offset = 5,
                                    Length = 5,
                                },
                            },
                        },

                        // ... more utterances.
                    },
                },

                // Use Utf16CodeUnit for strings in .NET.
                StringIndexType = "Utf16CodeUnit",
            };

            #region Snippet:ConversationAuthoringClient_ImportProjectAsync
            Operation<BinaryData> importOperation = await client.ImportProjectAsync(WaitUntil.Completed, projectName, RequestContent.Create(importData, JsonPropertyNames.CamelCase));
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
            Operation<BinaryData> trainOperation = await client.TrainAsync(WaitUntil.Completed, projectName, RequestContent.Create(trainData, JsonPropertyNames.CamelCase));

            // Deploy the model.
            var deployData = new
            {
                trainedModelLabel = "Sample5",
            };

            Console.WriteLine($"Deploying project {projectName} to production...");
            Operation<BinaryData> deployOperation = await client.DeployProjectAsync(WaitUntil.Completed, projectName, "production", RequestContent.Create(deployData, JsonPropertyNames.CamelCase));

            Console.WriteLine("Import complete");
            #endregion

            dynamic deployResult = deployOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.That(deployResult.Errors, Is.Null.Or.Empty);
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
