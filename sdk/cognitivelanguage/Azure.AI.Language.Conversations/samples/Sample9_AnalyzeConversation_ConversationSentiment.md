# Analyze a conversation with Conversation Sentiment

This sample demonstrates how to analyze a conversation with a Conversation Sentiment task. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:AnalyzeConversation_ConversationSentiment
var data = new
{
    displayName = "Sentiment analysis from a call center conversation",
    analysisInput = new
    {
        conversations = new[]
        {
            new
            {
                id = "1",
                language = "en",
                modality = "transcript",
                conversationItems = new[]
                {
                    new
                    {
                        participantId = "1",
                        id = "1",
                        text = "I like the service. I do not like the food",
                        lexical = "i like the service i do not like the food",
                        itn = "",
                        maskedItn = "",
                    }
                },
            },
        }
    },
    tasks = new[]
    {
        new
        {
            taskName = "Conversation Sentiment Analysis",
            kind = "ConversationalSentimentTask",
            parameters = new
            {
                modelVersion = "latest",
                predictionSource = "text",
            },
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
foreach (dynamic task in jobResults.tasks.items)
{
    Console.WriteLine($"Task name: {task.taskName}");
    dynamic results = task.results;
    foreach (dynamic conversation in results.conversations)
    {
        Console.WriteLine($"Conversation: #{conversation.id}");
        Console.WriteLine("Conversation Items:");
        foreach (dynamic conversationItem in conversation.conversationItems)
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.id}");
            Console.WriteLine($"Sentiment: {conversationItem.sentiment}");

            dynamic confidenceScores = conversationItem.confidenceScores;
            Console.WriteLine($"Positive: {confidenceScores.positive}");
            Console.WriteLine($"Neutral: {confidenceScores.neutral}");
            Console.WriteLine($"Negative: {confidenceScores.negative}");
        }
        Console.WriteLine();
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationSentiment
Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
```
