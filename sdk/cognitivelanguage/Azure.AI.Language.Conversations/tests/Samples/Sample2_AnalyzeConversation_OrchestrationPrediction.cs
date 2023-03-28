// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.Dynamic;

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
            string projectName = "DomainOrchestrator";
            string deploymentName = "production";
#if !SNIPPET
            projectName = TestEnvironment.OrchestrationProjectName;
            deploymentName = TestEnvironment.OrchestrationDeploymentName;
#endif

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
                    projectName,
                    deploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;
            #endregion

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
            string respondingProjectName = orchestrationPrediction.topIntent;
            dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

            if (targetIntentResult.targetProjectKind == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                dynamic questionAnsweringResponse = targetIntentResult.result;
                Console.WriteLine($"Question Answering Response:");
                foreach (dynamic answer in questionAnsweringResponse.answers)
                {
                    Console.WriteLine(answer.answer?.ToString());
                }
            }
            #endregion

            Assert.That(targetIntentResult.targetProjectKind?.ToString(), Is.EqualTo("QuestionAnswering"));
            Assert.That(respondingProjectName, Is.EqualTo("ChitChat-QnA"));
        }

        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionConversation()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestrationPrediction.topIntent;
            dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

            if (targetIntentResult.targetProjectKind == "Conversation")
            {
                dynamic conversationResult = targetIntentResult.result;
                dynamic conversationPrediction = conversationResult.prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.topIntent}");
                Console.WriteLine($"Intents:");
                foreach (dynamic intent in conversationPrediction.intents)
                {
                    Console.WriteLine($"Intent Category: {intent.category}");
                    Console.WriteLine($"Confidence: {intent.confidenceScore}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (dynamic entity in conversationPrediction.entities)
                {
                    Console.WriteLine($"Entity Text: {entity.text}");
                    Console.WriteLine($"Entity Category: {entity.category}");
                    Console.WriteLine($"Confidence: {entity.confidenceScore}");
                    Console.WriteLine($"Starting Position: {entity.offset}");
                    Console.WriteLine($"Length: {entity.length}");
                    Console.WriteLine();

                    if (entity.resolutions is not null)
                    {
                        foreach (dynamic resolution in entity.resolutions)
                        {
                            if (resolution.resolutionKind == "DateTimeResolution")
                            {
                                Console.WriteLine($"Datetime Sub Kind: {resolution.dateTimeSubKind}");
                                Console.WriteLine($"Timex: {resolution.timex}");
                                Console.WriteLine($"Value: {resolution.value}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            #endregion

            Assert.That(targetIntentResult.targetProjectKind?.ToString(), Is.EqualTo("Conversation"));
            Assert.That(orchestrationPrediction.topIntent?.ToString(), Is.EqualTo("EmailIntent"));
        }

        [SyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public void AnalyzeConversationOrchestrationPredictionLuis()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Reserve a table for 2 at the Italian restaurant.",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
            string respondingProjectName = orchestrationPrediction.topIntent;
            dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

            if (targetIntentResult.targetProjectKind == "Luis")
            {
                dynamic luisResponse = targetIntentResult.result;
                Console.WriteLine($"LUIS Response: {luisResponse}");
            }
            #endregion

            Assert.That(targetIntentResult.targetProjectKind?.ToString(), Is.EqualTo("Luis"));
            Assert.That(orchestrationPrediction.topIntent?.ToString(), Is.EqualTo("RestaurantIntent"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionQuestionAnsweringAsync()
        {
            ConversationAnalysisClient client = Client;

            string projectName = TestEnvironment.OrchestrationProjectName;
            string deploymentName = TestEnvironment.OrchestrationDeploymentName;

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
                    projectName,
                    deploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;
            #endregion

            string respondingProjectName = orchestrationPrediction.topIntent;
            dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

            if (targetIntentResult.targetProjectKind == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                dynamic questionAnsweringResponse = targetIntentResult.result;
                Console.WriteLine($"Question Answering Response:");
                foreach (dynamic answer in questionAnsweringResponse.answers)
                {
                    Console.WriteLine(answer.answer?.ToString());
                }
            }

            Assert.That(targetIntentResult.targetProjectKind?.ToString(), Is.EqualTo("QuestionAnswering"));
            Assert.That(respondingProjectName, Is.EqualTo("ChitChat-QnA"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionConversationAsync()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;

            string respondingProjectName = orchestrationPrediction.topIntent;
            dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

            if (targetIntentResult.targetProjectKind == "Conversation")
            {
                dynamic conversationResult = targetIntentResult.result;
                dynamic conversationPrediction = conversationResult.prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.topIntent}");
                Console.WriteLine($"Intents:");
                foreach (dynamic intent in conversationPrediction.intents)
                {
                    Console.WriteLine($"Intent Category: {intent.category}");
                    Console.WriteLine($"Confidence: {intent.confidenceScore}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (dynamic entity in conversationPrediction.entities)
                {
                    Console.WriteLine($"Entity Text: {entity.text}");
                    Console.WriteLine($"Entity Category: {entity.category}");
                    Console.WriteLine($"Confidence: {entity.confidenceScore}");
                    Console.WriteLine($"Starting Position: {entity.offset}");
                    Console.WriteLine($"Length: {entity.length}");
                    Console.WriteLine();

                    if (entity.resolutions is not null)
                    {
                        foreach (dynamic resolution in entity.resolutions)
                        {
                            if (resolution.resolutionKind == "DateTimeResolution")
                            {
                                Console.WriteLine($"Datetime Sub Kind: {resolution.dateTimeSubKind}");
                                Console.WriteLine($"Timex: {resolution.timex}");
                                Console.WriteLine($"Value: {resolution.value}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

            Assert.That(targetIntentResult.targetProjectKind?.ToString(), Is.EqualTo("Conversation"));
            Assert.That(orchestrationPrediction.topIntent?.ToString(), Is.EqualTo("EmailIntent"));
        }

        [AsyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public async Task AnalyzeConversationOrchestrationPredictionLuisAsync()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Reserve a table for 2 at the Italian restaurant.",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;

            string respondingProjectName = orchestrationPrediction.topIntent;
            dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

            if (targetIntentResult.targetProjectKind == "Luis")
            {
                dynamic luisResponse = targetIntentResult.result;
                Console.WriteLine($"LUIS Response: {luisResponse}");
            }

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("Luis"));
            Assert.That(orchestrationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("RestaurantIntent"));
        }
    }
}
