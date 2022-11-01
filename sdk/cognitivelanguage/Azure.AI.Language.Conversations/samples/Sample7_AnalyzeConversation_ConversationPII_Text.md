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

var jobResults = analyzeConversationOperation.Value.ToDynamic();
foreach (var task in jobResults.Tasks.Items)
{
    var results = task.Results;

    Console.WriteLine("Conversations:");
    foreach (var conversation in results.Conversations)
    {
        Console.WriteLine($"Conversation: #{conversation.Id}");
        Console.WriteLine("Conversation Items:");
        foreach (var conversationItem in conversation.ConversationItems)
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.Id}");

            Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");

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
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationPII_Text
Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
```
