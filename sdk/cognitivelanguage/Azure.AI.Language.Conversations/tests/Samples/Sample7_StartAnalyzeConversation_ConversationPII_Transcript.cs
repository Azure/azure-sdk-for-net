// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void StartAnalyzeConversation_ConversationPII_Transcript()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:StartAnalyzeConversation_ConversationPII_Transcript_Input
            var transciprtConversationItemOne = new TranscriptConversationItem(
               id: "1",
               participantId: "speaker",
               itn: "hi",
               maskedItn: "hi",
               text: "Hi",
               lexical: "hi");
            transciprtConversationItemOne.AudioTimings.Add(new WordLevelTiming(4500000, 2800000, "hi"));

            var transciprtConversationItemTwo = new TranscriptConversationItem(
               id: "2",
               participantId: "speaker",
               itn: "jane doe",
               maskedItn: "jane doe",
               text: "Jane doe",
               lexical: "jane doe");
            transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(7100000, 4800000, "jane"));
            transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(12000000, 1700000, "jane"));

            var transciprtConversationItemThree = new TranscriptConversationItem(
                id: "3",
                participantId: "agent",
                itn: "hi jane what's your phone number",
                maskedItn: "hi jane what's your phone number",
                text: "Hi Jane, what's your phone number?",
                lexical: "hi jane what's your phone number");
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(7700000, 3100000, "hi"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(10900000, 5700000, "jane"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(17300000, 2600000, "what's"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(20000000, 1600000, "your"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(21700000, 1700000, "phone"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(23500000, 2300000, "number"));

            var transcriptConversationItems = new List<TranscriptConversationItem>()
            {
                transciprtConversationItemOne,
                transciprtConversationItemTwo,
                transciprtConversationItemThree,
            };

            var input = new List<TranscriptConversation>()
            {
                new TranscriptConversation("1", "en", transcriptConversationItems)
            };

            var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, TranscriptContentType.Lexical);

            var tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
            };
            #endregion

            var analyzeConversationOperation = client.StartAnalyzeConversation(input, tasks);
            analyzeConversationOperation.WaitForCompletion();

            #region Snippet:StartAnalyzeConversation_ConversationPII_Transcript_Results
            var jobResults = analyzeConversationOperation.Value;
            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;

                var results = analyzeConversationPIIResult.Results;

                Console.WriteLine("Conversations:");
                foreach (var conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation #:{conversation.Id}");
                    Console.WriteLine("Conversation Items: ");
                    foreach (var conversationItem in conversation.ConversationItems)
                    {
                        Console.WriteLine($"Conversation Item #:{conversationItem.Id}");

                        Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");
                        Console.WriteLine($"Redacted Lexical: {conversationItem.RedactedContent.Lexical}");
                        Console.WriteLine($"Redacted AudioTimings: {conversationItem.RedactedContent.AudioTimings}");
                        Console.WriteLine($"Redacted MaskedItn: {conversationItem.RedactedContent.MaskedItn}");

                        Console.WriteLine("Entities:");
                        foreach (var entity in conversationItem.Entities)
                        {
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
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
        public async Task StartAnalyzeConversationAsync_ConversationPII_Transcript()
        {
            ConversationAnalysisClient client = Client;

            var transciprtConversationItemOne = new TranscriptConversationItem(
               id: "1",
               participantId: "speaker",
               itn: "hi",
               maskedItn: "hi",
               text: "Hi",
               lexical: "hi");
            transciprtConversationItemOne.AudioTimings.Add(new WordLevelTiming(4500000, 2800000, "hi"));

            var transciprtConversationItemTwo = new TranscriptConversationItem(
               id: "2",
               participantId: "speaker",
               itn: "jane doe",
               maskedItn: "jane doe",
               text: "Jane doe",
               lexical: "jane doe");
            transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(7100000, 4800000, "jane"));
            transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(12000000, 1700000, "jane"));

            var transciprtConversationItemThree = new TranscriptConversationItem(
                id: "3",
                participantId: "agent",
                itn: "hi jane what's your phone number",
                maskedItn: "hi jane what's your phone number",
                text: "Hi Jane, what's your phone number?",
                lexical: "hi jane what's your phone number");
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(7700000, 3100000, "hi"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(10900000, 5700000, "jane"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(17300000, 2600000, "what's"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(20000000, 1600000, "your"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(21700000, 1700000, "phone"));
            transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(23500000, 2300000, "number"));

            var transcriptConversationItems = new List<TranscriptConversationItem>()
            {
                transciprtConversationItemOne,
                transciprtConversationItemTwo,
                transciprtConversationItemThree,
            };

            var input = new List<TranscriptConversation>()
            {
                new TranscriptConversation("1", "en", transcriptConversationItems)
            };

            var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, TranscriptContentType.Lexical);

            var tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
            };

            var analyzeConversationOperation = await client.StartAnalyzeConversationAsync(input, tasks);
            await analyzeConversationOperation.WaitForCompletionAsync();

            var jobResults = analyzeConversationOperation.Value;
            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;

                var results = analyzeConversationPIIResult.Results;

                Console.WriteLine("Conversations:");
                foreach (var conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation #:{conversation.Id}");
                    Console.WriteLine("Conversation Items: ");
                    foreach (var conversationItem in conversation.ConversationItems)
                    {
                        Console.WriteLine($"Conversation Item #:{conversationItem.Id}");

                        Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");
                        Console.WriteLine($"Redacted Lexical: {conversationItem.RedactedContent.Lexical}");
                        Console.WriteLine($"Redacted AudioTimings: {conversationItem.RedactedContent.AudioTimings}");
                        Console.WriteLine($"Redacted MaskedItn: {conversationItem.RedactedContent.MaskedItn}");

                        Console.WriteLine("Entities:");
                        foreach (var entity in conversationItem.Entities)
                        {
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
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
