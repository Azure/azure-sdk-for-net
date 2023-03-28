// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Dynamic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationWithLanguage()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage
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
                        text = "Enviar un email a Carol acerca de la presentación de mañana",
                        language = "es",
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

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic conversationPrediction = conversationalTaskResult.result.prediction;

            Console.WriteLine($"Project Kind: {conversationPrediction.projectKind}");
            Console.WriteLine($"Top intent: {conversationPrediction.topIntent}");

            Console.WriteLine("Intents:");
            foreach (dynamic intent in conversationPrediction.intents)
            {
                Console.WriteLine($"Category: {intent.category}");
                Console.WriteLine($"Confidence: {intent.confidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (dynamic entity in conversationPrediction.entities)
            {
                Console.WriteLine($"Category: {entity.category}");
                Console.WriteLine($"Text: {entity.text}");
                Console.WriteLine($"Offset: {entity.offset}");
                Console.WriteLine($"Length: {entity.length}");
                Console.WriteLine($"Confidence: {entity.confidenceScore}");
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.topIntent?.ToString(), Is.EqualTo("Send"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationWithLanguageAsync()
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
                        text = "Enviar un email a Carol acerca de la presentación de mañana",
                        language = "es",
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

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguageAsync
            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));
            #endregion

            dynamic conversationalTaskResult = response.Content.ToDynamic();
            dynamic conversationPrediction = conversationalTaskResult.result.prediction;

            Console.WriteLine($"Project Kind: {conversationPrediction.projectKind}");
            Console.WriteLine($"Top intent: {conversationPrediction.topIntent}");

            Console.WriteLine("Intents:");
            foreach (dynamic intent in conversationPrediction.intents)
            {
                Console.WriteLine($"Category: {intent.category}");
                Console.WriteLine($"Confidence: {intent.confidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (dynamic entity in conversationPrediction.entities)
            {
                Console.WriteLine($"Category: {entity.category}");
                Console.WriteLine($"Text: {entity.text}");
                Console.WriteLine($"Offset: {entity.offset}");
                Console.WriteLine($"Length: {entity.length}");
                Console.WriteLine($"Confidence: {entity.confidenceScore}");
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.topIntent?.ToString(), Is.EqualTo("Send"));
        }
    }
}
