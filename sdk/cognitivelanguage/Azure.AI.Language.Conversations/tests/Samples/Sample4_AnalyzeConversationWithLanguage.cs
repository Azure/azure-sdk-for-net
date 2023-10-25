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
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Enviar un email a Carol acerca de la presentación de mañana",
                        Language = "es",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = projectName,
                    DeploymentName = deploymentName,
                    Verbose = true,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            Response response = client.AnalyzeConversation(RequestContent.Create(data, JsonPropertyNames.CamelCase));
            #endregion

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic conversationPrediction = conversationalTaskResult.Result.Prediction;

            Console.WriteLine($"Project Kind: {conversationPrediction.ProjectKind}");
            Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

            Console.WriteLine("Intents:");
            foreach (dynamic intent in conversationPrediction.Intents)
            {
                Console.WriteLine($"Category: {intent.Category}");
                Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (dynamic entity in conversationPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
                Console.WriteLine();

                if (entity.Resolutions is not null)
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.TopIntent?.ToString(), Is.EqualTo("Send"));
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
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Enviar un email a Carol acerca de la presentación de mañana",
                        Language = "es",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = projectName,
                    DeploymentName = deploymentName,
                    Verbose = true,

                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = "Utf16CodeUnit",
                },
                Kind = "Conversation",
            };

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguageAsync
            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));
            #endregion

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            dynamic conversationPrediction = conversationalTaskResult.Result.Prediction;

            Console.WriteLine($"Project Kind: {conversationPrediction.ProjectKind}");
            Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

            Console.WriteLine("Intents:");
            foreach (dynamic intent in conversationPrediction.Intents)
            {
                Console.WriteLine($"Category: {intent.Category}");
                Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (dynamic entity in conversationPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
                Console.WriteLine();

                if (entity.Resolutions is not null)
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

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.TopIntent?.ToString(), Is.EqualTo("Send"));
        }
    }
}
