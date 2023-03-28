# Analyze a conversation with Conversation PII using text input

This sample demonstrates how to analyze a conversation with Conversation PII (Text input). To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:AnalyzeConversation_ConversationPII_Text
var data = new
{
    analysisInput = new
    {
        conversations = new[]
        {
            new
            {
                conversationItems = new[]
                {
                    new
                    {
                        text = "Hi, I am John Doe.",
                        id = "1",
                        participantId = "0",
                    },
                    new
                    {
                        text = "Hi John, how are you doing today?",
                        id = "2",
                        participantId = "1",
                    },
                    new
                    {
                        text = "Pretty good.",
                        id = "3",
                        participantId = "0",
                    },
                },
                id = "1",
                language = "en",
                modality = "text",
            },
        }
    },
    tasks = new[]
    {
        new
        {
            parameters = new
            {
                piiCategories = new[]
                {
                    "All",
                },
                includeAudioRedaction = false,
                modelVersion = "2022-05-15-preview",
                loggingOptOut = false,
            },
            kind = "ConversationalPIITask",
            taskName = "analyze",
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
foreach (dynamic task in jobResults.tasks.items)
{
    dynamic results = task.results;

    Console.WriteLine("Conversations:");
    foreach (dynamic conversation in results.conversations)
    {
        Console.WriteLine($"Conversation: #{conversation.id}");
        Console.WriteLine("Conversation Items:");
        foreach (dynamic conversationItem in conversation.conversationItems)
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.id}");

            Console.WriteLine($"Redacted Text: {conversationItem.redactedContent.text}");

            Console.WriteLine("Entities:");
            foreach (dynamic entity in conversationItem.entities)
            {
                Console.WriteLine($"Text: {entity.text}");
                Console.WriteLine($"Offset: {entity.offset}");
                Console.WriteLine($"Category: {entity.category}");
                Console.WriteLine($"Confidence Score: {entity.confidenceScore}");
                Console.WriteLine($"Length: {entity.length}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationPII_Text
Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
```
