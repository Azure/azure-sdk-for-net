# Analyze a conversation with Conversation Summarization

This sample demonstrates how to analyze a conversation with Conversation Summarization. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:AnalyzeConversation_ConversationSummarization
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
                        text = "Hello, how can I help you?",
                        id = "1",
                        role = "Agent",
                        participantId = "Agent_1",
                    },
                    new
                    {
                        text = "How to upgrade Office? I am getting error messages the whole day.",
                        id = "2",
                        role = "Customer",
                        participantId = "Customer_1",
                    },
                    new
                    {
                        text = "Press the upgrade button please. Then sign in and follow the instructions.",
                        id = "3",
                        role = "Agent",
                        participantId = "Agent_1",
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
            taskName = "Issue task",
            kind = "ConversationalSummarizationTask",
            parameters = new
            {
                summaryAspects = new[]
                {
                    "issue",
                }
            },
        },
        new
        {
            taskName = "Resolution task",
            kind = "ConversationalSummarizationTask",
            parameters = new
            {
                summaryAspects = new[]
                {
                    "resolution",
                }
            },
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    Console.WriteLine($"Task name: {task.GetProperty("taskName").GetString()}");
    JsonElement results = task.GetProperty("results");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Summaries:");
        foreach (JsonElement summary in conversation.GetProperty("summaries").EnumerateArray())
        {
            Console.WriteLine($"Text: {summary.GetProperty("text").GetString()}");
            Console.WriteLine($"Aspect: {summary.GetProperty("aspect").GetString()}");
        }
        Console.WriteLine();
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationSummarization
Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
```
