// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/26379")]
        public void AnalyzeConversationWithLanguage()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage
            TextConversationItem input = new TextConversationItem(
                participantId: "1",
                id: "1",
                text: "Tendremos 2 platos de nigiri de salmón braseado.")
            {
                Language = "es"
            };
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(input);

#if SNIPPET
            ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

            Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
                textConversationItem,
                conversationsProject,
                options);
#else
            Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
                "Tendremos 2 platos de nigiri de salmón braseado.",
                TestEnvironment.Project,
                options);
#endif

            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            ConversationPrediction conversationPrediction = customConversationalTaskResult.Results.Prediction as ConversationPrediction;

            Console.WriteLine($"Project Kind: {customConversationalTaskResult.Results.Prediction.ProjectKind}");
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

                foreach (BaseResolution resolution in entity.Resolutions)
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

            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.TopIntent, Is.EqualTo("Read"));
        }

        [AsyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/26379")]
        public async Task AnalyzeConversationWithLanguageAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguageAsync
            TextConversationItem input = new TextConversationItem(
                participantId: "1",
                id: "1",
                text: "Tendremos 2 platos de nigiri de salmón braseado.")
            {
                Language = "es"
            };
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(input);

#if SNIPPET
            ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

            Response<AnalyzeConversationTaskResult> response = await client.AnalyzeConversationAsync(
                textConversationItem,
                conversationsProject,
                options);
#else
            Response<AnalyzeConversationTaskResult> response = await client.AnalyzeConversationAsync(
                "Tendremos 2 platos de nigiri de salmón braseado.",
                TestEnvironment.Project,
                options);
#endif

            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            ConversationPrediction conversationPrediction = customConversationalTaskResult.Results.Prediction as ConversationPrediction;

            Console.WriteLine($"Project Kind: {customConversationalTaskResult.Results.Prediction.ProjectKind}");
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

                foreach (BaseResolution resolution in entity.Resolutions)
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

            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(conversationPrediction.TopIntent, Is.EqualTo("Read"));
        }
    }
}
