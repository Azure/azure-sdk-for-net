// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.Dynamic;
using System.Collections;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientLiveTests(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about the tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectNam = TestEnvironment.ProjectName,
                    deploymentName = TestEnvironment.DeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Conversation", conversationalTaskResult.Result.Prediction.ProjectKind?.ToString());

            // assert - top intent
            Assert.AreEqual("Send", conversationalTaskResult.Result.Prediction.TopIntent?.ToString());

            // cast prediction
            dynamic conversationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)conversationPrediction.Intents);
            Assert.IsNotEmpty((IEnumerable)conversationPrediction.Entities);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Conversation()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about the tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectNam = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", conversationalTaskResult.Result.Prediction.ProjectKind?.ToString());

            // assert - top intent
            Assert.AreEqual("EmailIntent", conversationalTaskResult.Result.Prediction.TopIntent?.ToString());

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("Conversation", topIntent.TargetProjectKind?.ToString());

            // assert entities and intents
            Assert.IsNotEmpty((IEnumerable)topIntent.Result.Prediction.Entities);
            Assert.IsNotEmpty((IEnumerable)topIntent.Result.Prediction.Intents);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Reserve a table for 2 at the Italian restaurant",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectNam = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", conversationalTaskResult.Result.Prediction.ProjectKind?.ToString());

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("Luis", topIntent.TargetProjectKind?.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_QuestionAnswering()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "How are you?",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectNam = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", conversationalTaskResult.Result.Prediction.ProjectKind?.ToString());

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", conversationalTaskResult.Result.Prediction.TopIntent?.ToString());

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("QuestionAnswering", topIntent.TargetProjectKind?.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Max = ConversationsClientOptions.ServiceVersion.V2022_05_01)] // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29600
        public async Task SupportsAadAuthentication()
        {
            ConversationAnalysisClient client = CreateClient<ConversationAnalysisClient>(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(
                    new ConversationsClientOptions(ServiceVersion)));

            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about the tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.ProjectName,
                    deploymentName = TestEnvironment.DeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.That(conversationalTaskResult.Result.Prediction.TopIntent?.ToString(), Is.EqualTo("Send"));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversation_ConversationSummarization()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            conversationItems = new[]
                            {
                                new
                                {
                                    text = "Hello, how can I help you?",
                                    id = "1",
                                    participantId = "Agent",
                                    role = "Agent",
                                },
                                new
                                {
                                    text = "How to upgrade Office? I am getting error messages the whole day.",
                                    id = "2",
                                    participantId = "Customer",
                                    role = "Customer",
                                },
                                new
                                {
                                    text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    id = "3",
                                    participantId = "Agent",
                                    role = "Agent",
                                },
                            },
                            id = "1",
                            language = "en",
                            modality = "text",
                        },
                    },
                    tasks = new[]
                    {
                        new
                        {
                            parameters = new
                            {
                                summaryAspects = new[]
                                {
                                    "issue",
                                    "resolution",
                                },
                            },
                            kind = "ConversationalSummarizationTask",
                            taskName = "1",
                        },
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = await Client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.NotNull(jobResults);

            foreach (dynamic analyzeConversationSummarization in jobResults.Tasks.Items)
            {
                Assert.NotNull(analyzeConversationSummarization);

                dynamic results = analyzeConversationSummarization.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (dynamic conversation in results.Conversations)
                {
                    Assert.That((IEnumerable)conversation.Summaries, Is.Not.Null.And.Not.Empty);
                    foreach (dynamic summary in conversation.Summaries)
                    {
                        Assert.NotNull(summary.Text);
                        Assert.That(summary.Aspect?.ToString(), Is.EqualTo("issue").Or.EqualTo("resolution"));
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversation_ConversationPII_TextInput()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            conversationItems = new[]
                            {
                                new
                                {
                                    text = "Hi, I am John Doe.?",
                                    id = "1",
                                    participantId = "0",
                                },
                                new
                                {
                                    text = "Hi John, how are you doing today?",
                                    id = "2",
                                    participantId = "1",
                                },
                                new
                                {
                                    text = "Pretty good.",
                                    id = "3",
                                    participantId = "0",
                                },
                            },
                            id = "1",
                            language = "en",
                            modality = "text",
                        },
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = await Client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.NotNull(jobResults);

            foreach (dynamic analyzeConversationPIIResult in jobResults.Tasks.Items)
            {
                Assert.NotNull(analyzeConversationPIIResult);

                dynamic results = analyzeConversationPIIResult.results;
                Assert.NotNull(results);

                Assert.NotNull(results.conversations);
                foreach (dynamic conversation in results.conversations)
                {
                    Assert.NotNull(conversation.ConversationItems);
                    foreach (dynamic conversationItem in conversation.ConversationItems)
                    {
                        Assert.NotNull(conversationItem.Entities);
                        foreach (dynamic entity in conversationItem.Entities)
                        {
                            Assert.NotNull(entity.Text);
                            Assert.NotNull(entity.Length);
                            Assert.NotNull(entity.ConfidenceScore);
                            Assert.NotNull(entity.Category);
                            Assert.NotNull(entity.Offset);
                        }
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversation_ConversationPII_TranscriptInput()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            conversationItems = new[]
                            {
                                new
                                {
                                    itn = "hi",
                                    maskedItn = "hi",
                                    text = "Hi",
                                    lexical = "hi",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "hi",
                                            offset = 4500000,
                                            duration = 2800000,
                                        },
                                    },
                                    id = "1",
                                    participantId = "speaker",
                                },
                                new
                                {
                                    itn = "jane doe",
                                    maskedItn = "jane doe",
                                    text = "Jane doe",
                                    lexical = "jane doe",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "jane",
                                            offset = 7100000,
                                            duration = 4800000,
                                        },
                                        new
                                        {
                                            word = "jane",
                                            offset = 12000000,
                                            duration = 1700000,
                                        }
                                    },
                                    id = "2",
                                    participantId = "speaker",
                                },
                                new
                                {
                                    itn = "hi jane what's your phone number",
                                    maskedItn = "hi jane what's your phone number",
                                    text = "Hi Jane, what's your phone number?",
                                    lexical = "hi jane what's your phone number",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "hi",
                                            offset = 7700000,
                                            duration = 3100000,
                                        },
                                        new
                                        {
                                            word = "jane",
                                            offset = 10900000,
                                            duration = 5700000,
                                        },
                                        new
                                        {
                                            word = "what's",
                                            offset = 17300000,
                                            duration = 2600000,
                                        },
                                        new
                                        {
                                            word = "your",
                                            offset = 20000000,
                                            duration = 1600000,
                                        },
                                        new
                                        {
                                            word = "phone",
                                            offset = 21700000,
                                            duration = 1700000,
                                        },
                                        new
                                        {
                                            word = "number",
                                            offset = 23500000,
                                            duration = 2300000,
                                        }
                                    },
                                    id = "3",
                                    participantId = "agent",
                                }
                            },
                            id = "1",
                            language = "en",
                            modality = "transcript",
                        },
                    },
                },
                tasks = new[]
                {
                    new
                    {
                        parameters = new
                        {
                            piiCategories = new[]
                            {
                                "All"
                            },
                            includeAudioRedaction = false,
                            redactionSource = "lexical",
                            modelVersion = "2022-05-15-preview",
                            loggingOptOut = false,
                        },
                        kind = "ConversationalPIITask",
                        taskName = "analyze",
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = await Client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic(DynamicJsonNameMapping.PascalCaseGetters);
            Assert.NotNull(jobResults);

            foreach (dynamic result in jobResults.Tasks.Items)
            {
                dynamic analyzeConversationPIIResult = result;
                Assert.NotNull(analyzeConversationPIIResult);

                dynamic results = analyzeConversationPIIResult.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (dynamic conversation in results.Conversations)
                {
                    Assert.NotNull(conversation.ConversationItems);
                    foreach (dynamic conversationItem in conversation.ConversationItems)
                    {
                        Assert.NotNull(conversationItem.Entities);
                        foreach (dynamic entity in conversationItem.Entities)
                        {
                            Assert.NotNull(entity.Text);
                            Assert.NotNull(entity.Length);
                            Assert.NotNull(entity.ConfidenceScore);
                            Assert.NotNull(entity.Category);
                            Assert.NotNull(entity.Offset);
                        }
                    }
                }
            }
        }
    }
}
