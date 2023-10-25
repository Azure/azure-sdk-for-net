// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
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
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "How are you?",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = projectName,
                    DeploymentName = deploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            #endregion

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
            string respondingProjectName = orchestrationPrediction.TopIntent;
            dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                dynamic questionAnsweringResponse = targetIntentResult.Result;
                Console.WriteLine($"Question Answering Response:");
                foreach (dynamic answer in questionAnsweringResponse.Answers)
                {
                    Console.WriteLine(answer.Answer?.ToString());
                }
            }
            #endregion

            Assert.That(targetIntentResult.TargetProjectKind?.ToString(), Is.EqualTo("QuestionAnswering"));
            Assert.That(respondingProjectName, Is.EqualTo("ChitChat-QnA"));
        }

        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionConversation()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "How are you?",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.OrchestrationProjectName,
                    DeploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestrationPrediction.TopIntent;
            dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
            {
                dynamic questionAnsweringResult = targetIntentResult.Result;

                Console.WriteLine($"Answers:");
                foreach (dynamic answer in questionAnsweringResult.Answers)
                {
                    Console.WriteLine($"{answer.Answer}");
                    Console.WriteLine($"Confidence: {answer.ConfidenceScore}");
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(targetIntentResult.TargetProjectKind?.ToString(), Is.EqualTo("QuestionAnswering"));
            Assert.That(orchestrationPrediction.TopIntent?.ToString(), Is.EqualTo("ChitChat-QnA"));
        }

        [SyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public void AnalyzeConversationOrchestrationPredictionLuis()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Reserve a table for 2 at the Italian restaurant.",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.OrchestrationProjectName,
                    DeploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
            string respondingProjectName = orchestrationPrediction.TopIntent;
            dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Luis")
            {
                dynamic luisResponse = targetIntentResult.Result;
                Console.WriteLine($"LUIS Response: {luisResponse}");
            }
            #endregion

            Assert.That(targetIntentResult.TargetProjectKind?.ToString(), Is.EqualTo("Luis"));
            Assert.That(orchestrationPrediction.TopIntent?.ToString(), Is.EqualTo("RestaurantIntent"));
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
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "How are you?",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = projectName,
                    DeploymentName = deploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            #endregion

            string respondingProjectName = orchestrationPrediction.TopIntent;
            dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                dynamic questionAnsweringResponse = targetIntentResult.Result;
                Console.WriteLine($"Question Answering Response:");
                foreach (dynamic answer in questionAnsweringResponse.Answers)
                {
                    Console.WriteLine(answer.Answer?.ToString());
                }
            }

            Assert.That(targetIntentResult.TargetProjectKind?.ToString(), Is.EqualTo("QuestionAnswering"));
            Assert.That(respondingProjectName, Is.EqualTo("ChitChat-QnA"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionConversationAsync()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Send an email to Carol about tomorrow's demo",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.OrchestrationProjectName,
                    DeploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            string respondingProjectName = orchestrationPrediction.TopIntent;
            dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Conversation")
            {
                dynamic conversationResult = targetIntentResult.Result;
                dynamic conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (dynamic intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (dynamic entity in conversationPrediction.Entities)
                {
                    Console.WriteLine($"Entity Text: {entity.Text}");
                    Console.WriteLine($"Entity Category: {entity.Category}");
                    Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
                    Console.WriteLine($"Starting Position: {entity.Offset}");
                    Console.WriteLine($"Length: {entity.Length}");
                    Console.WriteLine();

                    if (entity.resolutions is not null)
                    {
                        foreach (dynamic resolution in entity.Resolutions)
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

            Assert.That(targetIntentResult.TargetProjectKind?.ToString(), Is.EqualTo("Conversation"));
            Assert.That(orchestrationPrediction.TopIntent?.ToString(), Is.EqualTo("EmailIntent"));
        }

        [AsyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public async Task AnalyzeConversationOrchestrationPredictionLuisAsync()
        {
            ConversationAnalysisClient client = Client;
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Reserve a table for 2 at the Italian restaurant.",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.OrchestrationProjectName,
                    DeploymentName = TestEnvironment.OrchestrationDeploymentName,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;

            string respondingProjectName = orchestrationPrediction.TopIntent;
            dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult.TargetProjectKind == "Luis")
            {
                dynamic luisResponse = targetIntentResult.Result;
                Console.WriteLine($"LUIS Response: {luisResponse}");
            }

            Assert.That(targetIntentResult.TargetProjectKind?.ToString(), Is.EqualTo("Luis"));
            Assert.That(orchestrationPrediction.TopIntent?.ToString(), Is.EqualTo("RestaurantIntent"));
        }
    }
}
