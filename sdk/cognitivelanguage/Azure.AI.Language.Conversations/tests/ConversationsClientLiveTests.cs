// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationsClientLiveTests : ConversationAnalysisTestBase<ConversationsClient>
    {
        public ConversationsClientLiveTests(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Send an email to Carol about the tomorrow's demo",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.ProjectName,
                    DeploymentName = TestEnvironment.DeploymentName,
                },
                Kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationsAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Conversation", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Send", (string)conversationalTaskResult.Result.Prediction.TopIntent);

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
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationsAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("EmailIntent", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("Conversation", (string)topIntent.TargetProjectKind);

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
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationsAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("Luis", (string)topIntent.TargetProjectKind);
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
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationsAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("QuestionAnswering", (string)topIntent.TargetProjectKind);
        }

        [RecordedTest]
        [ServiceVersion(Max = ConversationsClientOptions.ServiceVersion.V2022_05_01)] // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29600
        public async Task SupportsAadAuthentication()
        {
            ConversationsClient client = CreateClient<ConversationsClient>(
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

            Response response = await client.AnalyzeConversationsAsync(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.That((string)conversationalTaskResult.Result.Prediction.TopIntent, Is.EqualTo("Send"));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeConversation_ConversationSummarization()
        {
            var data = new AnalyzeConversationJobsInput(
                new MultiLanguageConversationAnalysisInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            AILanguageConversationsModelFactory.TextConversationItem("1", "Agent", "Hello, how can I help you?", role: ParticipantRole.Agent),
                            AILanguageConversationsModelFactory.TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day.", role: ParticipantRole.Customer),
                            AILanguageConversationsModelFactory.TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.", role: ParticipantRole.Agent)
                        })
                    }),
                    new List<AnalyzeConversationJobTask>
                    {
                        new AnalyzeConversationSummarizationTask()
                        {
                            Parameters = new ConversationSummarizationTaskContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Issue,
                                SummaryAspect.Resolution,
                            }),
                            TaskName = "1",
                        }
                    });

            Response<AnalyzeConversationJobState> analyzeConversationOperation = await Client.AnalyzeConversationsOperationAsync(data);

            AnalyzeConversationJobState analyzeConversationJobState = analyzeConversationOperation.Value;

            Assert.NotNull(analyzeConversationJobState);

            foreach (dynamic analyzeConversationSummarization in analyzeConversationJobState.Tasks.Items)
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
                        Assert.That((string)summary.Aspect, Is.EqualTo("issue").Or.EqualTo("resolution"));
                    }
                }
            }
        }
    }
}
