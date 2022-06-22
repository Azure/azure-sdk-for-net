// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
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
        public void AnalyzeConversationWithOptions()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithOptions
            string projectName = "Menu";
            string deploymentName = "production";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif

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
                    projectName,
                    deploymentName,
                    verbose = true,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data));
            #endregion

            using JsonDocument result = JsonDocument.Parse(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            Console.WriteLine($"Project Kind: {conversationPrediction.GetProperty("projectKind").GetString()}");
            Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

            Console.WriteLine("Intents:");
            foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
            {
                Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
                Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
            {
                Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("Send"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationWithOptionsAsync()
        {
            ConversationAnalysisClient client = Client;

            string projectName = TestEnvironment.ProjectName;
            string deploymentName = TestEnvironment.DeploymentName;

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
                    projectName,
                    deploymentName,
                    verbose = true,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithOptionsAsync
            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));
            #endregion

            using JsonDocument result = await JsonDocument.ParseAsync(response.ContentStream);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            Console.WriteLine($"Project Kind: {conversationPrediction.GetProperty("projectKind").GetString()}");
            Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

            Console.WriteLine("Intents:");
            foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
            {
                Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
                Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
            {
                Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.GetProperty("topIntent").GetString(), Is.EqualTo("Send"));
        }
    }
}
