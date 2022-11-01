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
        public void AnalyzeConversation()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversation
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

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data));

            var json = response.Content.ToDynamic();
            var conversationPrediction = json.Result.Prediction;

            Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

            Console.WriteLine("Intents:");
            foreach (var intent in conversationPrediction.Intents)
            {
                Console.WriteLine($"  Category: {intent.Category}");
                Console.WriteLine($"  Confidence: {intent.ConfidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (var entity in conversationPrediction.Entities)
            {
                Console.WriteLine($"  Category: {entity.Category}");
                Console.WriteLine($"  Text: {entity.Text}");
                Console.WriteLine($"  Offset: {entity.Offset}");
                Console.WriteLine($"  Length: {entity.Length}");
                Console.WriteLine($"  Confidence: {entity.ConfidenceScore}");
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
            #endregion

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That((string)conversationPrediction.TopIntent, Is.EqualTo("Send"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationAsync()
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

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            #region Snippet:ConversationAnalysis_AnalyzeConversationAsync
            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));
            #endregion

            var json = response.Content.ToDynamic();
            var conversationPrediction = json.Result.Prediction;

            Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

            Console.WriteLine("Intents:");
            foreach (var intent in conversationPrediction.Intents)
            {
                Console.WriteLine($"  Category: {intent.Category}");
                Console.WriteLine($"  Confidence: {intent.ConfidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (var entity in conversationPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That((string)conversationPrediction.TopIntent, Is.EqualTo("Send"));
        }
    }
}
