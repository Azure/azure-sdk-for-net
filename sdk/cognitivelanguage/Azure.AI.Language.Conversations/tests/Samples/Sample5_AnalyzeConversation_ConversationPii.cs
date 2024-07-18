// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        [ServiceVersion(Min = ConversationAnalysisClientOptions.ServiceVersion.V2024_05_01)]
        public void AnalyzeConversation_ConversationPii()
        {
            ConversationAnalysisClient client = Client;
            List<NamedEntity> entitiesDetected = new();

            #region Snippet:AnalyzeConversation_ConversationPii
            var data = new AnalyzeConversationOperationInput(
                new MultiLanguageConversationInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            new TextConversationItem("1", "Agent_1", "Can you provide you name?"),
                            new TextConversationItem("2", "Customer_1", "Hi, my name is John Doe."),
                            new TextConversationItem("3", "Agent_1", "Thank you John, that has been updated in our system.")
                        })
                    }),
                    new List<AnalyzeConversationOperationAction>
                    {
                        new PiiOperationAction()
                        {
                            ActionContent = new ConversationPiiActionContent(),
                            Name = "Conversation PII task",
                        }
                    });

            Response<AnalyzeConversationOperationState> analyzeConversationOperation = client.AnalyzeConversationOperation(data);

            AnalyzeConversationOperationState operationResults = analyzeConversationOperation.Value;

            foreach (ConversationPiiOperationResult task in operationResults.Actions.Items.Cast<ConversationPiiOperationResult>())
            {
                Console.WriteLine($"Operation name: {task.Name}");

                foreach (ConversationalPiiResultWithResultBase conversation in task.Results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Detected Entities:");
                    foreach (ConversationPiiItemResult item in conversation.ConversationItems)
                    {
                        foreach (NamedEntity entity in item.Entities)
                        {
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Subcategory: {entity.Subcategory}");
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Length: {entity.Length}");
                            Console.WriteLine($"Confidence score: {entity.ConfidenceScore}");
                            Console.WriteLine();
#if !SNIPPET
                            entitiesDetected.Add(entity);
#endif
                        }
                    }
                    if (conversation.Warnings != null && conversation.Warnings.Any())
                    {
                        Console.WriteLine("Warnings:");
                        foreach (dynamic warning in conversation.Warnings)
                        {
                            Console.WriteLine($"Code: {warning.Code}");
                            Console.WriteLine($"Message: {warning.Message}");
                        }
                    }
                    Console.WriteLine();
                }
                if (operationResults.Errors != null && operationResults.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (dynamic error in operationResults.Errors)
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
            }
            #endregion

            Assert.NotZero(entitiesDetected.Count);
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationAnalysisClientOptions.ServiceVersion.V2024_05_01)]
        public async Task AnalyzeConversationAsync_ConversationPii()
        {
            ConversationAnalysisClient client = Client;
            List<NamedEntity> entitiesDetected = new();

            #region Snippet:AnalyzeConversationAsync_ConversationPii
            var data = new AnalyzeConversationOperationInput(
                new MultiLanguageConversationInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            new TextConversationItem("1", "Agent_1", "Can you provide you name?"),
                            new TextConversationItem("2", "Customer_1", "Hi, my name is John Doe."),
                            new TextConversationItem("3", "Agent_1", "Thank you John, that has been updated in our system.")
                        })
                    }),
                    new List<AnalyzeConversationOperationAction>
                    {
                        new PiiOperationAction()
                        {
                            ActionContent = new ConversationPiiActionContent(),
                            Name = "Conversation PII task",
                        }
                    });

            Response<AnalyzeConversationOperationState> analyzeConversationOperation = await client.AnalyzeConversationOperationAsync(data);
            AnalyzeConversationOperationState operationResults = analyzeConversationOperation.Value;

            foreach (ConversationPiiOperationResult task in operationResults.Actions.Items.Cast<ConversationPiiOperationResult>())
            {
                Console.WriteLine($"Operation name: {task.Name}");

                foreach (ConversationalPiiResultWithResultBase conversation in task.Results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Detected Entities:");
                    foreach (ConversationPiiItemResult item in conversation.ConversationItems)
                    {
                        foreach (NamedEntity entity in item.Entities)
                        {
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Subcategory: {entity.Subcategory}");
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Length: {entity.Length}");
                            Console.WriteLine($"Confidence score: {entity.ConfidenceScore}");
                            Console.WriteLine();
#if !SNIPPET
                            entitiesDetected.Add(entity);
#endif
                        }
                    }
                    if (conversation.Warnings != null && conversation.Warnings.Any())
                    {
                        Console.WriteLine("Warnings:");
                        foreach (dynamic warning in conversation.Warnings)
                        {
                            Console.WriteLine($"Code: {warning.Code}");
                            Console.WriteLine($"Message: {warning.Message}");
                        }
                    }
                    Console.WriteLine();
                }
                if (operationResults.Errors != null && operationResults.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (dynamic error in operationResults.Errors)
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
            }
            #endregion

            Assert.NotZero(entitiesDetected.Count);
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
