// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
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
            string projectName = "TestWorkflow";
            string deploymentName = "production";
#if !SNIPPET
            projectName = TestEnvironment.OrchestrationProjectName;
            deploymentName = TestEnvironment.OrchestrationDeploymentName;
#endif
             Console.WriteLine("=== Request Info ===");
             Console.WriteLine($"Project Name: {projectName}");
             Console.WriteLine($"Deployment Name: {deploymentName}");

            AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
                new ConversationAnalysisInput(
                    new TextConversationItem(
                        id: "1",
                        participantId: "participant1",
                        text: "How are you?")),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });
            var serializedRequest = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() }
            });

            Console.WriteLine("Request payload:");
            Console.WriteLine(serializedRequest);

            Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
            ConversationActionResult conversationResult = response.Value as ConversationActionResult;
            OrchestrationPrediction orchestrationPrediction = conversationResult.Result.Prediction as OrchestrationPrediction;
            #endregion

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
            string respondingProjectName = orchestrationPrediction.TopIntent;
            Console.WriteLine($"Top intent: {respondingProjectName}");

            TargetIntentResult targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult is QuestionAnsweringTargetIntentResult questionAnsweringTargetIntentResult)
            {
                AnswersResult questionAnsweringResponse = questionAnsweringTargetIntentResult.Result;
                Console.WriteLine($"Question Answering Response:");
                foreach (KnowledgeBaseAnswer answer in questionAnsweringResponse.Answers)
                {
                    Console.WriteLine(answer.Answer?.ToString());
                }
            }
            #endregion

            Assert.That(targetIntentResult is QuestionAnsweringTargetIntentResult);
            Assert.That(respondingProjectName, Is.EqualTo("ChitChat-QnA"));
        }

        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationOrchestrationPredictionConversation()
        {
            ConversationAnalysisClient client = Client;
            string projectName = TestEnvironment.OrchestrationProjectName;
            string deploymentName = TestEnvironment.OrchestrationDeploymentName;
            AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
                new ConversationAnalysisInput(
                    new TextConversationItem(
                        id: "1",
                        participantId: "1",
                        text: "How are you?")),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
            {
                // Use Utf16CodeUnit for strings in .NET.
                StringIndexType = StringIndexType.Utf16CodeUnit,
            });

            Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
            ConversationActionResult conversationActionResult = response.Value as ConversationActionResult;
            OrchestrationPrediction orchestrationPrediction = conversationActionResult.Result.Prediction as OrchestrationPrediction;

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestrationPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult is ConversationTargetIntentResult conversationTargetIntent)
            {
                ConversationResult conversationResult = conversationTargetIntent.Result;
                ConversationPrediction conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
                Console.WriteLine($"Intents:");
                foreach (ConversationIntent intent in conversationPrediction.Intents)
                {
                    Console.WriteLine($"Intent Category: {intent.Category}");
                    Console.WriteLine($"Confidence: {intent.Confidence}");
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(targetIntentResult is QuestionAnsweringTargetIntentResult);
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

            AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
                new ConversationAnalysisInput(
                    new TextConversationItem(
                        id: "1",
                        participantId: "1",
                        text: "How are you?")),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
            Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
            #endregion
            ConversationActionResult conversationResult = response.Value as ConversationActionResult;
            OrchestrationPrediction orchestrationPrediction = conversationResult.Result.Prediction as OrchestrationPrediction;
            string respondingProjectName = orchestrationPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult is QuestionAnsweringTargetIntentResult questionAnsweringTargetIntentResult)
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                AnswersResult questionAnsweringResponse = questionAnsweringTargetIntentResult.Result;
                Console.WriteLine($"Question Answering Response:");
                foreach (KnowledgeBaseAnswer answer in questionAnsweringResponse.Answers)
                {
                    Console.WriteLine(answer.Answer?.ToString());
                }
            }

            Assert.That(targetIntentResult is QuestionAnsweringTargetIntentResult);
            Assert.That(respondingProjectName, Is.EqualTo("ChitChat-QnA"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationOrchestrationPredictionConversationAsync()
        {
            ConversationAnalysisClient client = Client;
            AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
                new ConversationAnalysisInput(
                    new TextConversationItem(
                        id: "1",
                        participantId: "1",
                        text: "Send an email to Carol about tomorrow's demo")),
                new ConversationLanguageUnderstandingActionContent(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName)
                {
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
            ConversationActionResult conversationActionResult = response.Value as ConversationActionResult;
            OrchestrationPrediction orchestrationPrediction = conversationActionResult.Result.Prediction as OrchestrationPrediction;
            string respondingProjectName = orchestrationPrediction.TopIntent;
            TargetIntentResult targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

            if (targetIntentResult is ConversationTargetIntentResult conversationTargetIntentResult)
            {
                ConversationResult conversationResult = conversationTargetIntentResult.Result;
                ConversationPrediction conversationPrediction = conversationResult.Prediction;

                Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
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

                    if (entity.Resolutions != null && entity.Resolutions.Any())
                    {
                        foreach (ResolutionBase resolution in entity.Resolutions)
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
            }

            Assert.That(targetIntentResult is ConversationTargetIntentResult);
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
