// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
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
            string projectName = "EmailApp";
            string deploymentName = "production";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif

            AnalyzeConversationInput data =
                new ConversationLanguageUnderstandingInput(
                    new ConversationAnalysisInput(
                        new TextConversationItem(
                            id: "1",
                            participantId: "participant1",
                            text: "Enviar un email a Carol acerca de la presentación de mañana")
                        {
                            Language = "es"
                        }),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                    Verbose = true
                });

            Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
            #endregion

            ConversationActionResult conversationResult = response.Value as ConversationActionResult;

            ConversationPrediction conversationPrediction = conversationResult.Result.Prediction as ConversationPrediction;
            Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

            Console.WriteLine("Intents:");
            foreach (ConversationIntent intent in conversationPrediction.Intents)
            {
                Console.WriteLine($"Category: {intent.Category}");
                Console.WriteLine($"Confidence: {intent.Confidence}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (ConversationEntity entity in conversationPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence: {entity.Confidence}");
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
            Assert.That(conversationPrediction.TopIntent?.ToString(), Is.EqualTo("SendEmail"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationWithLanguageAsync()
        {
            ConversationAnalysisClient client = Client;

            string projectName = TestEnvironment.ProjectName;
            string deploymentName = TestEnvironment.DeploymentName;

            AnalyzeConversationInput data =
                new ConversationLanguageUnderstandingInput(
                    new ConversationAnalysisInput(
                        new TextConversationItem(
                            id: "1",
                            participantId: "1",
                            text: "Enviar un email a Carol acerca de la presentación de mañana")
                        {
                            Language = "es"
                        }),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                    Verbose = true
                });

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguageAsync
            Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
            #endregion

            ConversationActionResult conversationResult = response.Value as ConversationActionResult;

            ConversationPrediction conversationPrediction = conversationResult.Result.Prediction as ConversationPrediction;
            Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

            Console.WriteLine("Intents:");
            foreach (ConversationIntent intent in conversationPrediction.Intents)
            {
                Console.WriteLine($"Category: {intent.Category}");
                Console.WriteLine($"Confidence: {intent.Confidence}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (ConversationEntity entity in conversationPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence: {entity.Confidence}");
                Console.WriteLine();

                if (entity.Resolutions is not null)
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
            Assert.That(conversationPrediction.TopIntent?.ToString(), Is.EqualTo("SendEmail"));
        }
    }
}
