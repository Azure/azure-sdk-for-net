// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void StartAnalyzeConversation_ConversationPII_Text()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:StartAnalyzeConversation_ConversationPII_Text_Input
            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "0", "Hi, I am John Doe."),
                new TextConversationItem("2", "1", "Hi John, how are you doing today?"),
                new TextConversationItem("3", "0", "Pretty good."),
            };

            var input = new List<TextConversation>()
            {
                new TextConversation("1", "en", textConversationItems)
            };

            var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, null);

            var tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
            };
            #endregion

            Operation<AnalyzeConversationJobState> analyzeConversationOperation = client.StartAnalyzeConversation(input, tasks);
            analyzeConversationOperation.WaitForCompletion();

            #region Snippet:StartAnalyzeConversation_ConversationPII_Text_Results
            AnalyzeConversationJobState jobResults = analyzeConversationOperation.Value;
            foreach (AnalyzeConversationJobResult result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;

                ConversationPIIResults results = analyzeConversationPIIResult.Results;

                Console.WriteLine("Conversations:");
                foreach (ConversationPIIResultsConversationsItem conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation #:{conversation.Id}");
                    Console.WriteLine("Conversation Items: ");
                    foreach (ConversationPIIItemResult conversationItem in conversation.ConversationItems)
                    {
                        Console.WriteLine($"Conversation Item #:{conversationItem.Id}");

                        Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");

                        Console.WriteLine("Entities:");
                        foreach (TextEntity entity in conversationItem.Entities)
                        {
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Confidence Score: {entity.Confidence}");
                            Console.WriteLine($"Length: {entity.Length}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
            #endregion
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task StartAnalyzeConversationAsync_ConversationPII_Text()
        {
            ConversationAnalysisClient client = Client;

            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "0", "Hi, I am John Doe."),
                new TextConversationItem("2", "1", "Hi John, how are you doing today?"),
                new TextConversationItem("3", "0", "Pretty good."),
            };

            var input = new List<TextConversation>()
            {
                new TextConversation("1", "en", textConversationItems)
            };

            var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, null);

            List<AnalyzeConversationLROTask> tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
            };

            Operation<AnalyzeConversationJobState> analyzeConversationOperation = await client.StartAnalyzeConversationAsync(input, tasks);
            await analyzeConversationOperation.WaitForCompletionAsync();

            AnalyzeConversationJobState jobResults = analyzeConversationOperation.Value;
            foreach (AnalyzeConversationJobResult result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;

                ConversationPIIResults results = analyzeConversationPIIResult.Results;

                Console.WriteLine("Conversations:");
                foreach (ConversationPIIResultsConversationsItem conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation #:{conversation.Id}");
                    Console.WriteLine("Conversation Items: ");
                    foreach (ConversationPIIItemResult conversationItem in conversation.ConversationItems)
                    {
                        Console.WriteLine($"Conversation Item #:{conversationItem.Id}");

                        Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");

                        Console.WriteLine("Entities:");
                        foreach (TextEntity entity in conversationItem.Entities)
                        {
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Confidence Score: {entity.Confidence}");
                            Console.WriteLine($"Length: {entity.Length}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
