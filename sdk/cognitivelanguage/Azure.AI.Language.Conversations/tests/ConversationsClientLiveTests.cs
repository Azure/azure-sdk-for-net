// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationsClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationsClientLiveTests(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Send an email to Carol about the tomorrow's demo",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.ProjectName,
                    DeploymentName = TestEnvironment.DeploymentName,
                },
                Kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Conversation", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Send", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic conversationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)conversationPrediction.Intents);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Conversation()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about the tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("EmailIntent", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("Conversation", (string)topIntent.TargetProjectKind);

            // assert entities and intents
            Assert.IsNotEmpty((IEnumerable)topIntent.Result.Prediction.Entities);
            Assert.IsNotEmpty((IEnumerable)topIntent.Result.Prediction.Intents);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Reserve a table for 2 at the Italian restaurant",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("Luis", (string)topIntent.TargetProjectKind);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_QuestionAnswering()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "How are you?",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.OrchestrationProjectName,
                    deploymentName = TestEnvironment.OrchestrationDeploymentName,
                },
                kind = "Conversation",
            };
            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Orchestration", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)orchestrationPrediction.Intents);

            // cast top intent
            dynamic topIntent = orchestrationPrediction.Intents[(string)orchestrationPrediction.TopIntent];
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual("QuestionAnswering", (string)topIntent.TargetProjectKind);
        }

        [RecordedTest]
        [ServiceVersion(Max = ConversationsClientOptions.ServiceVersion.V2022_05_01)] // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29600
        public async Task SupportsAadAuthentication()
        {
            ConversationAnalysisClient client = CreateClient<ConversationAnalysisClient>(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(
                    new ConversationsClientOptions(ServiceVersion)));

            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about the tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.ProjectName,
                    deploymentName = TestEnvironment.DeploymentName,
                },
                kind = "Conversation",
            };

            Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.That((string)conversationalTaskResult.Result.Prediction.TopIntent, Is.EqualTo("Send"));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeConversation_ConversationSummarization()
        {
            MultiLanguageConversationInput input = new MultiLanguageConversationInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                            new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                            new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.")
                        })
                    });
            List<AnalyzeConversationOperationAction> actions =  new List<AnalyzeConversationOperationAction>
                    {
                        new SummarizationOperationAction()
                        {
                            ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Issue,
                            }),
                            Name = "Issue task",
                        },
                        new SummarizationOperationAction()
                        {
                            ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Resolution,
                            }),
                            Name = "Resolution task",
                        }
                    };

            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);

            Response<AnalyzeConversationOperationState> analyzeConversationOperation = await Client.AnalyzeConversationsAsync(data);
            Assert.NotNull(analyzeConversationOperation);

            AnalyzeConversationOperationState jobResults = analyzeConversationOperation.Value;
            Assert.IsNotNull(jobResults.Actions);

            foreach (SummarizationOperationResult task in jobResults.Actions.Items.Cast<SummarizationOperationResult>())
            {
                SummaryResult results = task.Results;

                Assert.NotNull(results);

                foreach (ConversationsSummaryResult conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (SummaryResultItem summary in conversation.Summaries)
                    {
                        Assert.NotNull(summary.Text);
                        Assert.That((string)summary.Aspect, Is.EqualTo("issue").Or.EqualTo("resolution"));
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2024_11_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationPii_WithCharacterMaskPolicy()
        {
            // Arrange: Initialize client and input
            ConversationAnalysisClient client = Client;
            List<string> redactedTexts = new();

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
                            string redactedText = item.RedactedContent?.Text ?? string.Empty;
                            Console.WriteLine($"Redacted Text: {redactedText}");

                            // Only verify redaction if the original sentence had PII
                            if (item.Entities.Any())
                            {
                                foreach (var entity in item.Entities)
                                {
                                    Assert.That(redactedText, Does.Not.Contain(entity.Text),
                                        $"Expected entity '{entity.Text}' to be redacted but found in: {redactedText}");

                                    Assert.That(redactedText, Does.Contain("*"),
                                        $"Expected redacted text to contain '*' but got: {redactedText}");
                                }
                            }
                        }
                    }
                }
            }

            // Verify the HTTP response is successful
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2024_11_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationPii_WithEntityMaskPolicy()
        {
            // Arrange: Initialize client and input
            ConversationAnalysisClient client = Client;
            List<string> redactedTexts = new();
            // Create an EntityMaskTypePolicyType
            var redactionPolicy = new EntityMaskTypePolicyType();

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

            // Add action with EntityMaskTypePolicyType
            List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
            {
                new PiiOperationAction
                {
                    ActionContent = new ConversationPiiActionContent
                    {
                        RedactionPolicy = redactionPolicy
                    },
                    Name = "Conversation PII with Entity Mask Policy"
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
                            string redactedText = item.RedactedContent?.Text ?? string.Empty;
                            Console.WriteLine($"Redacted Text: {redactedText}");

                            // Only verify redaction if the original sentence had PII
                            if (item.Entities.Any())
                            {
                                foreach (var entity in item.Entities)
                                {
                                    Assert.That(redactedText, Does.Not.Contain(entity.Text),
                                    $"Expected entity '{entity.Text}' to be redacted but found in: {redactedText}");

                                    // Case-insensitive pattern to match entity mask variations
                                    string expectedMaskPattern = $@"\[{entity.Category}-?\d*\]";

                                    // Perform case-insensitive regex match
                                    StringAssert.IsMatch("(?i)" + expectedMaskPattern, redactedText,
                                    $"Expected redacted text to contain an entity mask similar to '[{entity.Category}]' but got: {redactedText}");
                                }
                            }
                        }
                    }
                }
            }
            // Verify the HTTP response is successful
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2024_11_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationPii_WithNoMaskPolicy()
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
            // Ensure PII was detected
            Assert.NotZero(detectedEntities.Count);

            // Verify the HTTP response is successful
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2025_05_15_Preview)]
        public async Task AnalyzeConversationAsync_AIConversation()
        {
            // Arrange: Initialize client and input
            ConversationAnalysisClient client = Client;
            string projectName = TestEnvironment.ProjectName;
            string deploymentName = TestEnvironment.DeploymentName;

            AnalyzeConversationInput data = new ConversationalAITask(
                new ConversationalAIAnalysisInput(
                    conversations: new TextConversation[] {
                        new TextConversation(
                            id: "order",
                            language: "en-GB",
                            conversationItems: new TextConversationItem[]
                            {
                                new TextConversationItem(id: "1", participantId: "user", text: "Hi"),
                                new TextConversationItem(id: "2", participantId: "bot", text: "Hello, how can I help you?"),
                                new TextConversationItem(id: "3", participantId: "user", text: "I would like to book a flight.")
                            }
                        )
                    }),
                new AIConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    // Use Utf16CodeUnit for strings in .NET.
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
            ConversationalAITaskResult ConversationalAITaskResult = response.Value as ConversationalAITaskResult;

            ConversationalAIResult conversationalAIResult = ConversationalAITaskResult.Result;

            IReadOnlyList<ConversationalAIAnalysis> conversations = conversationalAIResult?.Conversations;
            Assert.That(conversations, Is.Not.Null);
            Assert.That(conversations.Count, Is.GreaterThan(0));

            ConversationalAIAnalysis conversation = conversations[0];
            Assert.That(conversation.Id, Is.Not.Null);
            Assert.That(conversation.Intents, Is.Not.Null);
        }
    }
}
