// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionQuestionAnswering()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPrediction
#if SNIPPET
            ConversationsProject orchestrationProject = new ConversationsProject("DomainOrchestrator", "production");
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "How are you?",
                orchestrationProject);
#else
            Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
                "How are you?",
                TestEnvironment.OrchestrationProject);
#endif
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;
            #endregion

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == TargetProjectKind.QuestionAnswering)
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                QuestionAnsweringTargetIntentResult qnaTargetIntentResult = targetIntentResult as QuestionAnsweringTargetIntentResult;

                BinaryData questionAnsweringResponse = qnaTargetIntentResult.Result;
                Console.WriteLine($"Qustion Answering Response: {questionAnsweringResponse.ToString()}");
            }
            #endregion
            Assert.That(targetIntentResult.TargetProjectKind, Is.EqualTo(TargetProjectKind.QuestionAnswering));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("ChitChat-QnA"));
        }

        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionConversation()
        {
            ConversationAnalysisClient client = Client;
            Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
                "Send an email to Carol about the tomorrow's demo",
                TestEnvironment.OrchestrationProject);

            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == TargetProjectKind.Conversation)
            {
                ConversationTargetIntentResult cluTargetIntentResult = targetIntentResult as ConversationTargetIntentResult;

                ConversationResult conversationResult = cluTargetIntentResult.Result;
                ConversationPrediction conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationResult.Prediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (ConversationIntent intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.Confidence}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (ConversationEntity entity in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entity.Text}");
                    Console.WriteLine($"Entity Category: {entity.Category}");
                    Console.WriteLine($"Confidence: {entity.Confidence}");
                    Console.WriteLine($"Starting Position: {entity.Offset}");
                    Console.WriteLine($"Length: {entity.Length}");
                    Console.WriteLine();

                    foreach (BaseResolution resolution in entity.Resolutions)
                    {
                        if (resolution is DateTimeResolution dateTimeResolution)
                        {
                            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
                            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
                            Console.WriteLine($"Value: {dateTimeResolution.Value}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            #endregion
            Assert.That(targetIntentResult.TargetProjectKind, Is.EqualTo(TargetProjectKind.Conversation));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("EmailIntent"));
        }

        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionLuis()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
                "Reserve a table for 2 at the Italian restaurant.",
                TestEnvironment.OrchestrationProject);

            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == TargetProjectKind.Luis)
            {
                LuisTargetIntentResult luisTargetIntentResult = targetIntentResult as LuisTargetIntentResult;
                BinaryData luisResponse = luisTargetIntentResult.Result;

                Console.WriteLine($"LUIS Response: {luisResponse.ToString()}");
            }
            #endregion

            Assert.That(targetIntentResult.TargetProjectKind, Is.EqualTo(TargetProjectKind.Luis));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("RestaurantIntent"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionQuestionAnsweringAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
#if SNIPPET
            ConversationsProject orchestrationProject = new ConversationsProject("DomainOrchestrator", "production");
            Response<AnalyzeConversationResult> response =  await client.AnalyzeConversationAsync(
                "How are you?",
                orchestrationProject);
#else
            Response<AnalyzeConversationTaskResult> response = await client.AnalyzeConversationAsync(
                "How are you?",
                TestEnvironment.OrchestrationProject);
#endif
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;
            #endregion

            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == TargetProjectKind.QuestionAnswering)
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                QuestionAnsweringTargetIntentResult qnaTargetIntentResult = targetIntentResult as QuestionAnsweringTargetIntentResult;

                BinaryData questionAnsweringResponse = qnaTargetIntentResult.Result;
                Console.WriteLine($"Qustion Answering Response: {questionAnsweringResponse.ToString()}");
            }
            Assert.That(targetIntentResult.TargetProjectKind, Is.EqualTo(TargetProjectKind.QuestionAnswering));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("ChitChat-QnA"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionConversationAsync()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationTaskResult> response = await client.AnalyzeConversationAsync(
                "Send an email to Carol about the tomorrow's demo",
                TestEnvironment.OrchestrationProject);

            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;

            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == TargetProjectKind.Conversation)
            {
                ConversationTargetIntentResult cluTargetIntentResult = targetIntentResult as ConversationTargetIntentResult;

                ConversationResult conversationResult = cluTargetIntentResult.Result;
                ConversationPrediction conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationResult.Prediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (ConversationIntent intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.Confidence}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (ConversationEntity entity in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entity.Text}");
                    Console.WriteLine($"Entity Category: {entity.Category}");
                    Console.WriteLine($"Confidence: {entity.Confidence}");
                    Console.WriteLine($"Starting Position: {entity.Offset}");
                    Console.WriteLine($"Length: {entity.Length}");
                    Console.WriteLine();

                    foreach (BaseResolution resolution in entity.Resolutions)
                    {
                        if (resolution is DateTimeResolution dateTimeResolution)
                        {
                            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
                            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
                            Console.WriteLine($"Value: {dateTimeResolution.Value}");
                            Console.WriteLine();
                        }
                    }
                }
            }

            Assert.That(targetIntentResult.TargetProjectKind, Is.EqualTo(TargetProjectKind.Conversation));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("EmailIntent"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionLuisAsync()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationTaskResult> response = await client.AnalyzeConversationAsync(
                "Reserve a table for 2 at the Italian restaurant.",
                TestEnvironment.OrchestrationProject);

            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            var orchestratorPrediction = customConversationalTaskResult.Result.Prediction as OrchestratorPrediction;

            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == TargetProjectKind.Luis)
            {
                LuisTargetIntentResult luisTargetIntentResult = targetIntentResult as LuisTargetIntentResult;
                BinaryData luisResponse = luisTargetIntentResult.Result;

                Console.WriteLine($"LUIS Response: {luisResponse.ToString()}");
            }

            Assert.That(targetIntentResult.TargetProjectKind, Is.EqualTo(TargetProjectKind.Luis));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("RestaurantIntent"));
        }
    }
}
