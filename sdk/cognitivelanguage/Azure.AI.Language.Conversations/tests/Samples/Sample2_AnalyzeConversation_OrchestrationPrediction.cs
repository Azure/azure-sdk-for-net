// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
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

            var conversationalTaskResult = response.Content.ToDynamic();
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            #endregion

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA

            string respondingProjectName = orchestrationPrediction.TopIntent;
            var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];
            if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                var questionAnsweringResponse = targetIntentResult.Result;
                Console.WriteLine($"Question Answering Response:");
                foreach (var answer in questionAnsweringResponse.Answers)
                {
                    Console.WriteLine(answer.Answer);
                }
            }
            #endregion

            Assert.That((string)targetIntentResult.TargetProjectKind, Is.EqualTo("QuestionAnswering"));
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

            var conversationalTaskResult = response.Content.ToDynamic();
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestrationPrediction.TopIntent;
            var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Conversation")
            {
                var conversationResult = targetIntentResult.Result;
                var conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (var intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (var entity in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entity.Text}");
                    Console.WriteLine($"Entity Category: {entity.Category}");
                    Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
                    Console.WriteLine($"Starting Position: {entity.Offset}");
                    Console.WriteLine($"Length: {entity.Length}");
                    Console.WriteLine();

                    if (entity.Resolutions != null)
                    {
                        foreach (var resolution in entity.Resolutions)
                        {
                            if (resolution.ResolutionKind == "DateTimeResolution")
                            {
                                Console.WriteLine($"Datetime Sub Kind: {resolution.DateTimeSubKind}");
                                Console.WriteLine($"Timex: {resolution.Timex}");
                                Console.WriteLine($"Value: {resolution.Value}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            #endregion

            Assert.That((string)targetIntentResult.TargetProjectKind, Is.EqualTo("Conversation"));
            Assert.That((string)orchestrationPrediction.TopIntent, Is.EqualTo("EmailIntent"));
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

            var conversationalTaskResult = response.Content.ToDynamic();
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
            string respondingProjectName = orchestrationPrediction.TopIntent;
            var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Luis")
            {
                var luisResponse = targetIntentResult.Result;
                Console.WriteLine($"LUIS Response: {(string)luisResponse}");
            }
            #endregion

            Assert.That((string)targetIntentResult.TargetProjectKind, Is.EqualTo("Luis"));
            Assert.That((string)orchestrationPrediction.TopIntent, Is.EqualTo("RestaurantIntent"));
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

            var conversationalTaskResult = response.Content.ToDynamic();
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            #endregion

            string respondingProjectName = orchestrationPrediction.TopIntent;
            var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                var questionAnsweringResponse = targetIntentResult.Result;
                Console.WriteLine($"Question Answering Response:");
                foreach (var answer in questionAnsweringResponse.Answers)
                {
                    Console.WriteLine(answer.Answer);
                }
            }

            Assert.That((string)targetIntentResult.TargetProjectKind, Is.EqualTo("QuestionAnswering"));
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

            var conversationalTaskResult = response.Content.ToDynamic();
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            string respondingProjectName = orchestrationPrediction.TopIntent;
            var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Conversation")
            {
                var conversationResult = targetIntentResult.Result;
                var conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (var intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (var entity in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entity.Text}");
                    Console.WriteLine($"Entity Category: {entity.Category}");
                    Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
                    Console.WriteLine($"Starting Position: {entity.Offset}");
                    Console.WriteLine($"Length: {entity.Length}");
                    Console.WriteLine();

                    if (entity.Resolutions != null)
                    {
                        foreach (var resolution in entity.Resolutions)
                        {
                            if (resolution.ResolutionKind == "DateTimeResolution")
                            {
                                Console.WriteLine($"Datetime Sub Kind: {resolution.DateTimeSubKind}");
                                Console.WriteLine($"Timex: {resolution.Timex}");
                                Console.WriteLine($"Value: {resolution.Value}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

            Assert.That((string)targetIntentResult.TargetProjectKind, Is.EqualTo("Conversation"));
            Assert.That((string)orchestrationPrediction.TopIntent, Is.EqualTo("EmailIntent"));
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

            var conversationalTaskResult = response.Content.ToDynamic();
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            string respondingProjectName = orchestrationPrediction.TopIntent;
            var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Luis")
            {
                var luisResponse = targetIntentResult.Result;
                Console.WriteLine($"LUIS Response: {(string)luisResponse}");
            }

            Assert.That((string)targetIntentResult.TargetProjectKind, Is.EqualTo("Luis"));
            Assert.That((string)orchestrationPrediction.TopIntent, Is.EqualTo("RestaurantIntent"));
        }
    }
}
