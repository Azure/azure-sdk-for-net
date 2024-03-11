# Analyze a conversation with Conversation Summarization

This sample demonstrates how to analyze a conversation with Conversation Summarization. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

You can work with request and response content more easily by using our [Dynamic JSON](https://aka.ms/azsdk/net/dynamiccontent) feature. This is illustrated in the following sample.

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

```C# Snippet:AnalyzeConversation_ConversationSummarization
var data = new
{
    AnalysisInput = new
    {
        Conversations = new[]
        {
            new
            {
                ConversationItems = new[]
                {
                    new
                    {
                        Text = "Hello, how can I help you?",
                        Id = "1",
                        Role = "Agent",
                        ParticipantId = "Agent_1",
                    },
                    new
                    {
                        Text = "How to upgrade Office? I am getting error messages the whole day.",
                        Id = "2",
                        Role = "Customer",
                        ParticipantId = "Customer_1",
                    },
                    new
                    {
                        Text = "Press the upgrade button please. Then sign in and follow the instructions.",
                        Id = "3",
                        Role = "Agent",
                        ParticipantId = "Agent_1",
                    },
                },
                Id = "1",
                Language = "en",
                Modality = "text",
            },
        }
    },
    Tasks = new[]
    {
        new
        {
            TaskName = "Issue task",
            Kind = "ConversationalSummarizationTask",
            Parameters = new
            {
                SummaryAspects = new[]
                {
                    "issue",
                }
            },
        },
        new
        {
            TaskName = "Resolution task",
            Kind = "ConversationalSummarizationTask",
            Parameters = new
            {
                SummaryAspects = new[]
                {
                    "resolution",
                }
            },
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversations(WaitUntil.Completed, RequestContent.Create(data, JsonPropertyNames.CamelCase));

dynamic jobResults = analyzeConversationOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
foreach (dynamic task in jobResults.Tasks.Items)
{
    Console.WriteLine($"Task name: {task.TaskName}");
    dynamic results = task.Results;
    foreach (dynamic conversation in results.Conversations)
    {
        Console.WriteLine($"Conversation: #{conversation.Id}");
        Console.WriteLine("Summaries:");
        foreach (dynamic summary in conversation.Summaries)
        {
            Console.WriteLine($"Text: {summary.Text}");
            Console.WriteLine($"Aspect: {summary.Aspect}");
        }
        if (results.Warnings != null)
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
    if (results.Errors != null)
    {
        Console.WriteLine("Errors:");
        foreach (dynamic error in results.Errors)
        {
            Console.WriteLine($"Error: {error}");
        }
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationSummarization
Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationsAsync(WaitUntil.Completed, RequestContent.Create(data, JsonPropertyNames.CamelCase));
```
