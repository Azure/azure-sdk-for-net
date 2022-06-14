# Analyze a conversation

This sample demonstrates how to analyze a conversation with Conversation Summarization. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can prepare the input:

```C# Snippet:SubmitJob_ConversationSummarization_Input
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
                        participantId = "Agent",
                    },
                    new
                    {
                        text = "How to upgrade Office? I am getting error messages the whole day.",
                        id = "2",
                        participantId = "Customer",
                    },
                    new
                    {
                        text = "Press the upgrade button please. Then sign in and follow the instructions.",
                        id = "3",
                        participantId = "Agent",
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
                summaryAspects = new[]
                {
                    "issue",
                    "resolution",
                }
            },
            kind = "ConversationalSummarizationTask",
            taskName = "1",
        },
    },
};
```

then you can start analyzing by calling the `SubmitJob`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

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

```C# Snippet:SubmitJob_ConversationSummarization_Results
using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    JsonElement results = task.GetProperty("results");

    Console.WriteLine("Conversations:");
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
