// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientLiveTests(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("Send an email to Carol about the tomorrow's demo", TestEnvironment.Project);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Conversation, customConversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Read", customConversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var conversationPrediction = customConversationalTaskResult.Result.Prediction as ConversationPrediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(conversationPrediction.Intents);
            Assert.IsNotEmpty(conversationPrediction.Entities);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Conversation()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("Send an email to Carol about the tomorrow's demo", TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, customConversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("EmailIntent", customConversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;
            Assert.IsNotNull(orchestratorPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestratorPrediction.Intents);

            // cast top intent
            var topIntent = orchestratorPrediction.Intents[orchestratorPrediction.TopIntent] as ConversationTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.Conversation, topIntent.TargetProjectKind);

            // assert entities and intents
            Assert.IsNotEmpty(topIntent.Result.Prediction.Entities);
            Assert.IsNotEmpty(topIntent.Result.Prediction.Intents);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("Reserve a table for 2 at the Italian restaurant", TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, customConversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", customConversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;
            Assert.IsNotNull(orchestratorPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestratorPrediction.Intents);

            // cast top intent
            var topIntent = orchestratorPrediction.Intents[orchestratorPrediction.TopIntent] as LuisTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.Luis, topIntent.TargetProjectKind);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_QuestionAnswering()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("How are you?", TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, customConversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", customConversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;
            Assert.IsNotNull(orchestratorPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestratorPrediction.Intents);

            // cast top intent
            var topIntent = orchestratorPrediction.Intents[orchestratorPrediction.TopIntent] as QuestionAnsweringTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.QuestionAnswering, topIntent.TargetProjectKind);
        }

        [RecordedTest]
        public async Task StartAnalyzeConversationAsync_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;

            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions."),
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

            var analyzeConversationOperation = await client.StartAnalyzeConversationAsync(input, tasks);
            await analyzeConversationOperation.WaitForCompletionAsync();

            var jobResults = analyzeConversationOperation.Value;
            Assert.NotNull(jobResults);

            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationSummarization = result as AnalyzeConversationSummarizationResult;
                Assert.NotNull(analyzeConversationSummarization);

                var results = analyzeConversationSummarization.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (var conversation in results.Conversations)
                {
                    Assert.NotNull(conversation.Summaries);
                    foreach (var summary in conversation.Summaries)
                    {
                        Assert.NotNull(summary.Text);
                        Assert.NotNull(summary.Aspect);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task StartAnalyzeConversationAsync_ConversationPII_TextInput()
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

            var analyzeConversationOperation = await Client.StartAnalyzeConversationAsync(input, tasks);
            await analyzeConversationOperation.WaitForCompletionAsync();

            var jobResults = analyzeConversationOperation.Value;
            Assert.NotNull(jobResults);

            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;
                Assert.NotNull(analyzeConversationPIIResult);

                var results = analyzeConversationPIIResult.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (var conversation in results.Conversations)
                {
                    Assert.NotNull(conversation.ConversationItems);
                    foreach (var conversationItem in conversation.ConversationItems)
                    {
                        Assert.NotNull(conversationItem.Entities);
                        foreach (var entity in conversationItem.Entities)
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
        public async Task StartAnalyzeConversationAsync_ConversationPII_TranscriptInput()
        {
            var transciprtConversationItemOne = new TranscriptConversationItem(
               id: "1",
               participantId: "speaker",
               itn: "hi",
               maskedItn: "hi",
               text: "Hi",
               lexical: "hi");
            transciprtConversationItemOne.AudioTimings.Add(new WordLevelTiming(4500000, 2800000, "hi"));

            var transciprtConversationItemTwo = new TranscriptConversationItem(
               id: "2",
               participantId: "speaker",
               itn: "jane doe",
               maskedItn: "jane doe",
               text: "Jane doe",
               lexical: "jane doe");
            transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(7100000, 4800000, "jane"));
            transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(12000000, 1700000, "jane"));

            var transciprtConversationItemThree = new TranscriptConversationItem(
                id: "3",
                participantId: "agent",
                itn: "hi jane what's your phone number",
                maskedItn: "hi jane what's your phone number",
                text: "Hi Jane, what's your phone number?",
                lexical: "hi jane what's your phone number");
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(7700000, 3100000, "hi"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(10900000, 5700000, "jane"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(17300000, 2600000, "what's"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(20000000, 1600000, "your"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(21700000, 1700000, "phone"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(23500000, 2300000, "number"));

            var transcriptConversationItems = new List<TranscriptConversationItem>()
            {
                transciprtConversationItemOne,
                transciprtConversationItemTwo,
                transciprtConversationItemThree,
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

            var analyzeConversationOperation = await Client.StartAnalyzeConversationAsync(input, tasks);

            await analyzeConversationOperation.WaitForCompletionAsync();

            var jobResults = analyzeConversationOperation.Value;
            Assert.NotNull(jobResults);

            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;
                Assert.NotNull(analyzeConversationPIIResult);

                var results = analyzeConversationPIIResult.Results;
                Assert.NotNull(results);

                Assert.NotNull(results.Conversations);
                foreach (var conversation in results.Conversations)
                {
                    Assert.NotNull(conversation.ConversationItems);
                    foreach (var conversationItem in conversation.ConversationItems)
                    {
                        Assert.NotNull(conversationItem.Entities);
                        foreach (var entity in conversationItem.Entities)
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
