# Analyze a conversation

This sample demonstrates how to analyze a conversation with Conversation PII (Text input). To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can prepare the input:

```C# Snippet:SubmitJob_ConversationPII_Text_Input
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
```

Then you can start analyzing by calling the `SubmitJob`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

## Synchronous

```C# Snippet:SubmitJob_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = client.SubmitJob(WaitUntil.Started, RequestContent.Create(data));
analyzeConversationOperation.WaitForCompletion();
```

## Asynchronous

```C# Snippet:SubmitJobAsync_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = await client.SubmitJobAsync(WaitUntil.Started, RequestContent.Create(data));
await analyzeConversationOperation.WaitForCompletionAsync();
```

You can finally print the results:

```C# Snippet:SubmitJob_ConversationPII_Text_Results
using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    JsonElement results = task.GetProperty("results");

    Console.WriteLine("Conversations:");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Conversation Items:");
        foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");

            Console.WriteLine($"Redacted Text: {conversationItem.GetProperty("redactedContent").GetProperty("text").GetString()}");

            Console.WriteLine("Entities:");
            foreach (JsonElement entity in conversationItem.GetProperty("entities").EnumerateArray())
            {
                Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                Console.WriteLine($"Confidence Score: {entity.GetProperty("confidenceScore").GetSingle()}");
                Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```
