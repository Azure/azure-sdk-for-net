// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

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
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo")),
                new ConversationTaskParameters(TestEnvironment.ProjectName, TestEnvironment.DeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Conversation, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Send", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var conversationPrediction = conversationalTaskResult.Result.Prediction as ConversationPrediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(conversationPrediction.Intents);
            Assert.IsNotEmpty(conversationPrediction.Entities);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Conversation()
        {
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo")),
                new ConversationTaskParameters(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("EmailIntent", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction as OrchestrationPrediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestrationPrediction.Intents);

            // cast top intent
            var topIntent = orchestrationPrediction.Intents[orchestrationPrediction.TopIntent] as ConversationTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.Conversation, topIntent.TargetProjectKind);

            // assert entities and intents
            Assert.IsNotEmpty(topIntent.Result.Prediction.Entities);
            Assert.IsNotEmpty(topIntent.Result.Prediction.Intents);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Reserve a table for 2 at the Italian restaurant")),
                new ConversationTaskParameters(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction as OrchestrationPrediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestrationPrediction.Intents);

            // cast top intent
            var topIntent = orchestrationPrediction.Intents[orchestrationPrediction.TopIntent] as LuisTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.Luis, topIntent.TargetProjectKind);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_QuestionAnswering()
        {
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "How are you?")),
                new ConversationTaskParameters(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction as OrchestrationPrediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestrationPrediction.Intents);

            // cast top intent
            var topIntent = orchestrationPrediction.Intents[orchestrationPrediction.TopIntent] as QuestionAnsweringTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.QuestionAnswering, topIntent.TargetProjectKind);
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

            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo")),
                new ConversationTaskParameters(TestEnvironment.ProjectName, TestEnvironment.DeploymentName));

            Response response = await client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.That(conversationalTaskResult.Result.Prediction.TopIntent, Is.EqualTo("Send"));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversation_ConversationSummarization()
        {
            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "Agent", "Hello, how can I help you?") { Role = "Agent" },
                new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day.") { Role = "Customer" },
                new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.") { Role = "Agent" },
            };

            var input = new List<TextConversation>()
            {
                new TextConversation("1", "en", textConversationItems)
            };

            var conversationSummarizationTaskParameters = new ConversationSummarizationTaskParameters(new List<SummaryAspect>() { SummaryAspect.Issue, SummaryAspect.Resolution });

            var conversationSummarizationTask = new AnalyzeConversationSummarizationTask("1", AnalyzeConversationLROTaskKind.ConversationalSummarizationTask, conversationSummarizationTaskParameters);
            var tasks = new List<AnalyzeConversationLROTask>()
            {
                conversationSummarizationTask
            };

            var multiLanguageConversationAnalysisInput = new MultiLanguageConversationAnalysisInput(input);
            var analyzeConversationJobsInput = new AnalyzeConversationJobsInput(multiLanguageConversationAnalysisInput, tasks);

            Operation<BinaryData> analyzeConversationOperation = await Client.AnalyzeConversationAsync(WaitUntil.Completed, analyzeConversationJobsInput.AsRequestContent());

            using JsonDocument json = await JsonDocument.ParseAsync(analyzeConversationOperation.Value.ToStream());
            AnalyzeConversationJobState jobResults = AnalyzeConversationJobState.DeserializeAnalyzeConversationJobState(json.RootElement);
            Assert.NotNull(jobResults);

            foreach (AnalyzeConversationJobResult result in jobResults.Tasks.Items)
            {
                var analyzeConversationSummarization = result as AnalyzeConversationSummarizationResult;
                Assert.NotNull(analyzeConversationSummarization);

                SummaryResult results = analyzeConversationSummarization.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (SummaryResultConversationsItem conversation in results.Conversations)
                {
                    Assert.That(conversation.Summaries, Is.Not.Null.And.Not.Empty);
                    foreach (ConversationsSummaryResultSummariesItem summary in conversation.Summaries)
                    {
                        Assert.NotNull(summary.Text);
                        Assert.That(summary.Aspect, Is.EqualTo("issue").Or.EqualTo("resolution"));
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversation_ConversationPII_TextInput()
        {
            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "0", "Hi, I am John Doe.?"),
                new TextConversationItem("2", "1", "Hi John, how are you doing today?"),
                new TextConversationItem("3", "0", "Pretty good."),
            };

            var input = new List<TextConversation>()
            {
                new TextConversation("1", "en", textConversationItems)
            };

            var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, null);

            var piiTask = new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters);
            var tasks = new List<AnalyzeConversationLROTask>()
            {
                piiTask
            };

            var multiLanguageConversationAnalysisInput = new MultiLanguageConversationAnalysisInput(input);
            var analyzeConversationJobsInput = new AnalyzeConversationJobsInput(multiLanguageConversationAnalysisInput, tasks);

            Operation<BinaryData> analyzeConversationOperation = await Client.AnalyzeConversationAsync(WaitUntil.Completed, analyzeConversationJobsInput.AsRequestContent());

            using JsonDocument json = await JsonDocument.ParseAsync(analyzeConversationOperation.Value.ToStream());
            AnalyzeConversationJobState jobResults = AnalyzeConversationJobState.DeserializeAnalyzeConversationJobState(json.RootElement);
            Assert.NotNull(jobResults);

            foreach (AnalyzeConversationJobResult result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;
                Assert.NotNull(analyzeConversationPIIResult);

                ConversationPIIResults results = analyzeConversationPIIResult.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (ConversationPIIResultsConversationsItem conversation in results.Conversations)
                {
                    Assert.NotNull(conversation.ConversationItems);
                    foreach (ConversationPIIItemResult conversationItem in conversation.ConversationItems)
                    {
                        Assert.NotNull(conversationItem.Entities);
                        foreach (Entity entity in conversationItem.Entities)
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
            var transcriptConversationItemOne = new TranscriptConversationItem("1", "speaker", "hi", "hi", "Hi", "hi");
            transcriptConversationItemOne.WordLevelTimings.Add(new WordLevelTiming(4500000, 2800000, "hi"));

            var transcriptConversationItemTwo = new TranscriptConversationItem("2", "speaker", "jane doe", "jane doe", "Jane doe", "jane doe");
            transcriptConversationItemTwo.WordLevelTimings.Add(new WordLevelTiming(7100000, 4800000, "jane"));
            transcriptConversationItemTwo.WordLevelTimings.Add(new WordLevelTiming(12000000, 1700000, "jane"));

            var transcriptConversationItemThree = new TranscriptConversationItem("3", "agent", "hi jane what's your phone number", "hi jane what's your phone number", "Hi Jane, what's your phone number?", "hi jane what's your phone number");
            transcriptConversationItemThree.WordLevelTimings.Add(new WordLevelTiming(7700000, 3100000, "hi"));
            transcriptConversationItemThree.WordLevelTimings.Add(new WordLevelTiming(10900000, 5700000, "jane"));
            transcriptConversationItemThree.WordLevelTimings.Add(new WordLevelTiming(17300000, 2600000, "what's"));
            transcriptConversationItemThree.WordLevelTimings.Add(new WordLevelTiming(20000000, 1600000, "your"));
            transcriptConversationItemThree.WordLevelTimings.Add(new WordLevelTiming(21700000, 1700000, "phone"));
            transcriptConversationItemThree.WordLevelTimings.Add(new WordLevelTiming(23500000, 2300000, "number"));

            var transcriptConversationItems = new List<TranscriptConversationItem>()
            {
                transcriptConversationItemOne,
                transcriptConversationItemTwo,
                transcriptConversationItemThree,
            };

            var input = new List<TranscriptConversation>()
            {
                new TranscriptConversation("1", "en", transcriptConversationItems)
            };

            var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, TranscriptContentType.Lexical);

            var piiTask = new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters);
            var tasks = new List<AnalyzeConversationLROTask>()
            {
                piiTask
            };

            var multiLanguageConversationAnalysisInput = new MultiLanguageConversationAnalysisInput(input);
            var analyzeConversationJobsInput = new AnalyzeConversationJobsInput(multiLanguageConversationAnalysisInput, tasks);

            Operation<BinaryData> analyzeConversationOperation = await Client.AnalyzeConversationAsync(WaitUntil.Completed, analyzeConversationJobsInput.AsRequestContent());

            using JsonDocument json = await JsonDocument.ParseAsync(analyzeConversationOperation.Value.ToStream());
            AnalyzeConversationJobState jobResults = AnalyzeConversationJobState.DeserializeAnalyzeConversationJobState(json.RootElement);
            Assert.NotNull(jobResults);

            foreach (AnalyzeConversationJobResult result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;
                Assert.NotNull(analyzeConversationPIIResult);

                ConversationPIIResults results = analyzeConversationPIIResult.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (ConversationPIIResultsConversationsItem conversation in results.Conversations)
                {
                    Assert.NotNull(conversation.ConversationItems);
                    foreach (ConversationPIIItemResult conversationItem in conversation.ConversationItems)
                    {
                        Assert.NotNull(conversationItem.Entities);
                        foreach (Entity entity in conversationItem.Entities)
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
