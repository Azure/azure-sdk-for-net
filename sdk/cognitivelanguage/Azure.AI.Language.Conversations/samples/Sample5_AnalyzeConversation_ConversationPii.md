# Analyze a conversation with Conversation Summarization

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

## Synchronous

```C# Snippet:AnalyzeConversation_ConversationPii
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
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationPii
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
```
