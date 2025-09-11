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
        public void AnalyzeConversation()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversation
            string projectName = "EmailApp";
            string deploymentName = "production";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif

            AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
                new ConversationAnalysisInput(
                    new TextConversationItem(
                        id: "1",
                        participantId: "participant1",
                        text: "Send an email to Carol about tomorrow's demo")),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
            ConversationActionResult conversationActionResult = response.Value as ConversationActionResult;
            ConversationPrediction conversationPrediction = conversationActionResult.Result.Prediction as ConversationPrediction;

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
            #endregion

            Assert.That(conversationPrediction.TopIntent?.ToString(), Is.EqualTo("SendEmail"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationAsync()
        {
            ConversationAnalysisClient client = Client;

            string projectName = TestEnvironment.ProjectName;
            string deploymentName = TestEnvironment.DeploymentName;

            AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
                new ConversationAnalysisInput(
                    new TextConversationItem(
                        id: "1",
                        participantId: "participant1",
                        text: "Send an email to Carol about tomorrow's demo")),
                new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            #region Snippet:ConversationAnalysis_AnalyzeConversationAsync
            Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
            ConversationActionResult conversationResult = response.Value as ConversationActionResult;
            #endregion

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
