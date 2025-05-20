﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2024_11_15_Preview)]
        public void AnalyzeConversation_ConversationPii_WithNoMaskPolicy()
        {
            // Arrange: Initialize client and input
            ConversationAnalysisClient client = Client;
            List<string> detectedEntities = new();

            // Create a NoMaskPolicyType (PII should be detected but not redacted)
            var redactionPolicy = new NoMaskPolicyType();

            // Simulate input conversation
            MultiLanguageConversationInput input = new MultiLanguageConversationInput(
                new List<ConversationInput>
                {
                    new TextConversation("1", "en", new List<TextConversationItem>
                    {
                        new TextConversationItem(id: "1", participantId: "Agent_1", text: "Can you provide your name?"),
                        new TextConversationItem(id: "2", participantId: "Customer_1", text: "Hi, my name is John Doe."),
                        new TextConversationItem(id: "3", participantId: "Agent_1", text: "Thank you John, that has been updated in our system.")
                    })
                });

            // Add action with NoMaskPolicyType
            List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
            {
                new PiiOperationAction
                {
                    ActionContent = new ConversationPiiActionContent
                    {
                        RedactionPolicy = redactionPolicy
                    },
                    Name = "Conversation PII with No Mask Policy"
                }
            };

            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);

            Response<AnalyzeConversationOperationState> analyzeConversationOperation = client.AnalyzeConversations(data);

            #region Snippet:AnalyzeConversation_ConversationPiiWithNoMaskPolicySync
            AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;
            #endregion
            // Assert: Validate the results
            foreach (AnalyzeConversationOperationResult operationResult in operationState.Actions.Items)
            {
                Console.WriteLine($"Operation action name: {operationResult.Name}");

                if (operationResult is ConversationPiiOperationResult piiOperationResult)
                {
                    foreach (ConversationalPiiResult conversation in piiOperationResult.Results.Conversations)
                    {
                        Console.WriteLine($"Conversation: #{conversation.Id}");
                        foreach (ConversationPiiItemResult item in conversation.ConversationItems)
                        {
                            string originalText = item.RedactedContent?.Text ?? string.Empty;
                            Console.WriteLine($"Original Text: {originalText}");

                            // Ensure PII is detected
                            if (item.Entities.Any())
                            {
                                foreach (var entity in item.Entities)
                                {
                                    detectedEntities.Add(entity.Text);
                                    Assert.That(originalText, Does.Contain(entity.Text),
                                        $"Expected entity '{entity.Text}' to be present but was not found in: {originalText}");
                                }
                            }
                        }
                    }
                }
            }
            // Ensure PII was detected
            Assert.NotZero(detectedEntities.Count);

            // Verify the HTTP response is successful
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2024_11_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationPii_WithNoMaskPolicy()
        {
            // Arrange: Initialize client and input
            ConversationAnalysisClient client = Client;
            List<string> detectedEntities = new();

            #region Snippet:AnalyzeConversation_ConversationPiiWithNoMaskPolicy
            var redactionPolicy = new NoMaskPolicyType();

            // Simulate input conversation
            MultiLanguageConversationInput input = new MultiLanguageConversationInput(
                new List<ConversationInput>
                {
                    new TextConversation("1", "en", new List<TextConversationItem>
                    {
                        new TextConversationItem(id: "1", participantId: "Agent_1", text: "Can you provide your name?"),
                        new TextConversationItem(id: "2", participantId: "Customer_1", text: "Hi, my name is John Doe."),
                        new TextConversationItem(id: "3", participantId: "Agent_1", text: "Thank you John, that has been updated in our system.")
                    })
                });

            // Add action with NoMaskPolicyType
            List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
            {
                new PiiOperationAction
                {
                    ActionContent = new ConversationPiiActionContent
                    {
                        RedactionPolicy = redactionPolicy
                    },
                    Name = "Conversation PII with No Mask Policy"
                }
            };

            // Create input for analysis
            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);

            // Act: Perform the PII analysis
            Response<AnalyzeConversationOperationState> analyzeConversationOperation = await client.AnalyzeConversationsAsync(data);
            AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;

            // Assert: Validate the results
            foreach (AnalyzeConversationOperationResult operationResult in operationState.Actions.Items)
            {
                Console.WriteLine($"Operation action name: {operationResult.Name}");

                if (operationResult is ConversationPiiOperationResult piiOperationResult)
                {
                    foreach (ConversationalPiiResult conversation in piiOperationResult.Results.Conversations)
                    {
                        Console.WriteLine($"Conversation: #{conversation.Id}");
                        foreach (ConversationPiiItemResult item in conversation.ConversationItems)
                        {
                            string originalText = item.RedactedContent?.Text ?? string.Empty;
                            Console.WriteLine($"Original Text: {originalText}");

                            // Ensure PII is detected
                            if (item.Entities.Any())
                            {
                                foreach (var entity in item.Entities)
                                {
                                    detectedEntities.Add(entity.Text);
                                    Assert.That(originalText, Does.Contain(entity.Text),
                                        $"Expected entity '{entity.Text}' to be present but was not found in: {originalText}");
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            Assert.NotZero(detectedEntities.Count);
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
