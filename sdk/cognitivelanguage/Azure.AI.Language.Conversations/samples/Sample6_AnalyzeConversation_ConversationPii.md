# Analyze a conversation with Conversation PII

This sample demonstrates how to detect and redact personally identifiable information from a conversation with Conversation Pii. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

Start by importing the namespace for the `ConversationAnalysisClient` and related classes:

```C# Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Conversations;
```

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Asynchronous

```C# Snippet:AnalyzeConversation_ConversationPii
MultiLanguageConversationInput input = new MultiLanguageConversationInput(
    new List<ConversationInput>
    {
        new TextConversation("1", "en", new List<TextConversationItem>()
        {
            new TextConversationItem(id: "1", participantId: "Agent_1", text: "Can you provide you name?"),
            new TextConversationItem(id: "2", participantId: "Customer_1", text: "Hi, my name is John Doe."),
            new TextConversationItem(id : "3", participantId : "Agent_1", text : "Thank you John, that has been updated in our system.")
        })
    });
List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
    {
        new PiiOperationAction()
        {
            ActionContent = new ConversationPiiActionContent(),
            Name = "Conversation PII",
        }
    };
AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);

Response<AnalyzeConversationOperationState> analyzeConversationOperation = await client.AnalyzeConversationsAsync(data);

AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;

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
                    Console.WriteLine($"  Category: {entity.Category}");
                    Console.WriteLine($"  Subcategory: {entity.Subcategory}");
                    Console.WriteLine($"  Text: {entity.Text}");
                    Console.WriteLine($"  Offset: {entity.Offset}");
                    Console.WriteLine($"  Length: {entity.Length}");
                    Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
                    Console.WriteLine();
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
```

## Synchronous

Using the same `data` definition above, you can make a synchronous request by calling `AnalyzeConversationOperation`:

```C# Snippet:AnalyzeConversation_ConversationPiiSync
AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;
```
