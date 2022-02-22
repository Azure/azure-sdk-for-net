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
                "Where are the calories per recipe?",
                orchestrationProject);
#else
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Where are the calories per recipe?",
                TestEnvironment.OrchestrationProject);
#endif

            OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;
            #endregion
            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetKind == TargetKind.QuestionAnswering)
            {
                QuestionAnsweringTargetIntentResult qnaTargetIntentResult = targetIntentResult as QuestionAnsweringTargetIntentResult;

                KnowledgeBaseAnswers qnaAnswers = qnaTargetIntentResult.Result;

                Console.WriteLine("Answers: \n");
                foreach (KnowledgeBaseAnswer answer in qnaAnswers.Answers)
                {
                    Console.WriteLine($"Answer: {answer.Answer}");
                    Console.WriteLine($"Confidence: {answer.Confidence}");
                    Console.WriteLine($"Source: {answer.Source}");
                    Console.WriteLine();
                }
            }
            #endregion
            Assert.That(targetIntentResult.TargetKind, Is.EqualTo(TargetKind.QuestionAnswering));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("SushiMaking"));
        }

        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionConversation()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "We'll have 2 plates of seared salmon nigiri.",
                TestEnvironment.OrchestrationProject);

            OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetKind == TargetKind.Conversation)
            {
                ConversationTargetIntentResult cluTargetIntentResult = targetIntentResult as ConversationTargetIntentResult;

                ConversationResult conversationResult = cluTargetIntentResult.Result;
                ConversationPrediction conversationPrediction = conversationResult.Prediction;

                if (!String.IsNullOrEmpty(conversationResult.DetectedLanguage))
                    Console.WriteLine($"Detected Language: {conversationResult.DetectedLanguage}");

                Console.WriteLine($"Top Intent: {conversationResult.Prediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (ConversationIntent intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.Confidence}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (ConversationEntity entitiy in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entitiy.Text}");
                    Console.WriteLine($"Entity Category: {entitiy.Category}");
                    Console.WriteLine($"Confidence: {entitiy.Confidence}");
                    Console.WriteLine($"Starting Position: {entitiy.Offset}");
                    Console.WriteLine($"Length: {entitiy.Length}");
                    Console.WriteLine();
                }
            }
            #endregion
            Assert.That(targetIntentResult.TargetKind, Is.EqualTo(TargetKind.Conversation));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("SushiOrder"));
        }

        [SyncOnly]
        [RecordedTest]
        [Ignore(reason: "LUIS Orchestration not set up in CI pipeline")]
        public void AnalyzeConversationOrchestrationPredictionLuis()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Book me flight from London to Paris",
                TestEnvironment.OrchestrationProject);

            OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetKind == TargetKind.Luis)
            {
                LuisTargetIntentResult luisTargetIntentResult = targetIntentResult as LuisTargetIntentResult;
                BinaryData luisResponse = luisTargetIntentResult.Result;

                Console.WriteLine($"LUIS Response: {luisResponse.ToString()}");
            }
            #endregion

            Assert.That(targetIntentResult.TargetKind, Is.EqualTo(TargetKind.Luis));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("FlightBooking"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionQuestionAnsweringAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync

#if SNIPPET
            ConversationsProject orchestrationProject = new ConversationsProject("DomainOrchestrator", "production");
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Where are the calories per recipe?",
                orchestrationProject);
#else
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Where are the calories per recipe?",
                TestEnvironment.OrchestrationProject);
#endif

            OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;
            #endregion

            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetKind == TargetKind.QuestionAnswering)
            {
                QuestionAnsweringTargetIntentResult qnaTargetIntentResult = targetIntentResult as QuestionAnsweringTargetIntentResult;

                KnowledgeBaseAnswers qnaAnswers = qnaTargetIntentResult.Result;

                Console.WriteLine("Answers: \n");
                foreach (KnowledgeBaseAnswer answer in qnaAnswers.Answers)
                {
                    Console.WriteLine($"Answer: {answer.Answer}");
                    Console.WriteLine($"Confidence: {answer.Confidence}");
                    Console.WriteLine($"Source: {answer.Source}");
                    Console.WriteLine();
                }
            }
            Assert.That(targetIntentResult.TargetKind, Is.EqualTo(TargetKind.QuestionAnswering));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("SushiMaking"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionConversationAsync()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "We'll have 2 plates of seared salmon nigiri.",
                TestEnvironment.OrchestrationProject);

            OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;

            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetKind == TargetKind.Conversation)
            {
                ConversationTargetIntentResult cluTargetIntentResult = targetIntentResult as ConversationTargetIntentResult;

                ConversationResult conversationResult = cluTargetIntentResult.Result;
                ConversationPrediction conversationPrediction = conversationResult.Prediction;

                if (!String.IsNullOrEmpty(conversationResult.DetectedLanguage))
                    Console.WriteLine($"Detected Language: {conversationResult.DetectedLanguage}");

                Console.WriteLine($"Top Intent: {conversationResult.Prediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (ConversationIntent intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.Confidence}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (ConversationEntity entitiy in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entitiy.Text}");
                    Console.WriteLine($"Entity Category: {entitiy.Category}");
                    Console.WriteLine($"Confidence: {entitiy.Confidence}");
                    Console.WriteLine($"Starting Position: {entitiy.Offset}");
                    Console.WriteLine($"Length: {entitiy.Length}");
                    Console.WriteLine();
                }
            }

            Assert.That(targetIntentResult.TargetKind, Is.EqualTo(TargetKind.Conversation));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("SushiOrder"));
        }

        [AsyncOnly]
        [RecordedTest]
        [Ignore(reason:"LUIS Orchestration not set up in CI pipeline")]
        public async Task AnalyzeConversationOrchestrationPredictionLuisAsync()
        {
            ConversationAnalysisClient client = Client;

            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Book me flight from London to Paris",
                TestEnvironment.OrchestrationProject);

            OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;

            string respondingProjectName = orchestratorPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetKind == TargetKind.Luis)
            {
                LuisTargetIntentResult luisTargetIntentResult = targetIntentResult as LuisTargetIntentResult;
                BinaryData luisResponse = luisTargetIntentResult.Result;

                Console.WriteLine($"LUIS Response: {luisResponse.ToString()}");
            }

            Assert.That(targetIntentResult.TargetKind, Is.EqualTo(TargetKind.Luis));
            Assert.That(orchestratorPrediction.TopIntent, Is.EqualTo("FlightBooking"));
        }
    }
}
