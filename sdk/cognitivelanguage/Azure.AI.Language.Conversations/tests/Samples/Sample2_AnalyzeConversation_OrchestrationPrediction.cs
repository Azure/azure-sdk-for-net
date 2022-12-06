// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Text.Json;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;

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

            using JsonDocument result = JsonDocument.Parse(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");
            #endregion

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
            string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
            JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

            if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                JsonElement questionAnsweringResponse = targetIntentResult.GetProperty("result");
                Console.WriteLine($"Question Answering Response:");
                foreach (JsonElement answer in questionAnsweringResponse.GetProperty("answers").EnumerateArray())
                {
                    Console.WriteLine(answer.GetProperty("answer").GetString());
                }
            }
            #endregion

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("QuestionAnswering"));
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

            using JsonDocument result = JsonDocument.Parse(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
            string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
            JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

            if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "Conversation")
            {
                JsonElement conversationResult = targetIntentResult.GetProperty("result");
                JsonElement conversationPrediction = conversationResult.GetProperty("prediction");

                Console.WriteLine($"Top Intent: {conversationPrediction.GetProperty("topIntent").GetString()}");
                Console.WriteLine($"Intents:");
                foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
                {
                    Console.WriteLine($"Intent Category: {intent.GetProperty("category").GetString()}");
                    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
                {
                    Console.WriteLine($"Entity Text: {entity.GetProperty("text").GetString()}");
                    Console.WriteLine($"Entity Category: {entity.GetProperty("category").GetString()}");
                    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
                    Console.WriteLine($"Starting Position: {entity.GetProperty("offset").GetInt32()}");
                    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                    Console.WriteLine();

                    if (entity.TryGetProperty("resolutions", out JsonElement resolutions))
                    {
                        foreach (JsonElement resolution in resolutions.EnumerateArray())
                        {
                            if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
                            {
                                Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
                                Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
                                Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            #endregion

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("Conversation"));
            Assert.That(orchestrationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("EmailIntent"));
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

            using JsonDocument result = JsonDocument.Parse(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            #region Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
            string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
            JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

            if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "Luis")
            {
                JsonElement luisResponse = targetIntentResult.GetProperty("result");
                Console.WriteLine($"LUIS Response: {luisResponse.GetRawText()}");
            }
            #endregion

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("Luis"));
            Assert.That(orchestrationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("RestaurantIntent"));
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

            using JsonDocument result = await JsonDocument.ParseAsync(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");
            #endregion

            string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
            JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

            if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "QuestionAnswering")
            {
                Console.WriteLine($"Top intent: {respondingProjectName}");

                JsonElement questionAnsweringResponse = targetIntentResult.GetProperty("result");
                Console.WriteLine($"Question Answering Response:");
                foreach (JsonElement answer in questionAnsweringResponse.GetProperty("answers").EnumerateArray())
                {
                    Console.WriteLine(answer.GetProperty("answer").GetString());
                }
            }

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("QuestionAnswering"));
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

            using JsonDocument result = await JsonDocument.ParseAsync(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
            JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

            if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "Conversation")
            {
                JsonElement conversationResult = targetIntentResult.GetProperty("result");
                JsonElement conversationPrediction = conversationResult.GetProperty("prediction");

                Console.WriteLine($"Top Intent: {conversationPrediction.GetProperty("topIntent").GetString()}");
                Console.WriteLine($"Intents:");
                foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
                {
                    Console.WriteLine($"Intent Category: {intent.GetProperty("category").GetString()}");
                    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Entities:");
                foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
                {
                    Console.WriteLine($"Entity Text: {entity.GetProperty("text").GetString()}");
                    Console.WriteLine($"Entity Category: {entity.GetProperty("category").GetString()}");
                    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
                    Console.WriteLine($"Starting Position: {entity.GetProperty("offset").GetInt32()}");
                    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                    Console.WriteLine();

                    if (entity.TryGetProperty("resolutions", out JsonElement resolutions))
                    {
                        foreach (JsonElement resolution in resolutions.EnumerateArray())
                        {
                            if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
                            {
                                Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
                                Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
                                Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("Conversation"));
            Assert.That(orchestrationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("EmailIntent"));
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

            using JsonDocument result = await JsonDocument.ParseAsync(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
            JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

            if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "Luis")
            {
                JsonElement luisResponse = targetIntentResult.GetProperty("result");
                Console.WriteLine($"LUIS Response: {luisResponse.GetRawText()}");
            }

            Assert.That(targetIntentResult.GetProperty("targetProjectKind").GetString(), Is.EqualTo("Luis"));
            Assert.That(orchestrationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("RestaurantIntent"));
        }
    }
}
