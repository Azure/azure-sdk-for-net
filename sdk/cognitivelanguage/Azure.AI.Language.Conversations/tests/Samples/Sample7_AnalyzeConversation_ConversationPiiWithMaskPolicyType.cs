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
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2024_11_01)]
        public void AnalyzeConversation_ConversationPii_WithCharacterMaskPolicy()
        {
            // Arrange: Initialize client and input
            ConversationAnalysisClient client = Client;
            List<NamedEntity> entitiesDetected = new();

            // Create a CharacterMaskPolicyType with a custom masking character
            var redactionPolicy = new CharacterMaskPolicyType
            {
                RedactionCharacter = RedactionCharacter.Asterisk
            };

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

            // Add action with CharacterMaskPolicyType
            List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
            {
                new PiiOperationAction
                {
                    ActionContent = new ConversationPiiActionContent
                    {
                        RedactionPolicy = redactionPolicy
                    },
                    Name = "Conversation PII with Character Mask Policy"
                }
            };

            // Create input for analysis
            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);

            // Act: Perform the PII analysis
            Response<AnalyzeConversationOperationState> analyzeConversationOperation = client.AnalyzeConversations(data);
            #region Snippet:AnalyzeConversation_ConversationPiiSync
            AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;
            #endregion
            foreach (AnalyzeConversationOperationResult operationResult in operationState.Actions.Items)
            {
                Console.WriteLine($"Operation action name: {operationResult.Name}");

                if (operationResult is ConversationPiiOperationResult piiOperationResult)
                {
                    foreach (ConversationalPiiResult conversation in piiOperationResult.Results.Conversations)
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

                                // Verify the redacted text uses the '*' character
                                //Assert.That(entity.Text, Does.Not.Contain("John")); // Original text should be redacted
                                Assert.That(entity.Text, Does.Contain("*")); // Redacted text should contain the mask character
#if !SNIPPET
                                entitiesDetected.Add(entity);
#endif
                            }
                        }
                        if (conversation.Warnings != null && conversation.Warnings.Any())
                        {
                            Console.WriteLine("Warnings:");
                            foreach (InputWarning warning in conversation.Warnings)
                            {
                                Console.WriteLine($"Code: {warning.Code}");
                                Console.WriteLine($"Message: {warning.Message}");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                if (operationState.Errors != null && operationState.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (ConversationError error in operationState.Errors)
                    {
                        Console.WriteLine($"Error: {error.Code} - {error}");
                    }
                }
            }

            Assert.NotZero(entitiesDetected.Count);
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
