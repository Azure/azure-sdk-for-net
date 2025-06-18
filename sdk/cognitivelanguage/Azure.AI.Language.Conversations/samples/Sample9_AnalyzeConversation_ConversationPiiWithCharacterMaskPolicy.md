# Analyze a Conversation for PII Using Character Masking

This sample demonstrates how to detect and redact personally identifiable information (PII) in a conversation using Character Mask Policy with Conversation PII analysis. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

Start by importing the namespace for the `ConversationAnalysisClient` and related classes:

```C# Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Conversations;
using Azure.AI.Language.Conversations.Models;
```

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Asynchronous

```C# Snippet:AnalyzeConversation_ConversationPiiWithCharacterMaskPolicy
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
```

## Synchronous

Using the same `data` definition above, you can make a synchronous request by calling `AnalyzeConversationOperation`:

```C# Snippet:AnalyzeConversation_ConversationPiiWithCharacterMaskPolicySync
AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;
```
