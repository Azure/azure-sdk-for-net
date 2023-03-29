# Analyze a conversation

This sample demonstrates how to analyze an utterance. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversation
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Send an email to Carol about tomorrow's demo",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));

dynamic conversationalTaskResult = response.Content.ToDynamic();
dynamic conversationPrediction = conversationalTaskResult.result.prediction;

Console.WriteLine($"Top intent: {conversationPrediction.topIntent}");

Console.WriteLine("Intents:");
foreach (dynamic intent in conversationPrediction.intents)
{
    Console.WriteLine($"Category: {intent.category}");
    Console.WriteLine($"Confidence: {intent.confidenceScore}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (dynamic entity in conversationPrediction.entities)
{
    Console.WriteLine($"Category: {entity.category}");
    Console.WriteLine($"Text: {entity.text}");
    Console.WriteLine($"Offset: {entity.offset}");
    Console.WriteLine($"Length: {entity.length}");
    Console.WriteLine($"Confidence: {entity.confidenceScore}");
    Console.WriteLine();

    if (entity.resolutions is not null)
    {
        foreach (dynamic resolution in entity.resolutions)
        {
            if (resolution.resolutionKind == "DateTimeResolution")
            {
                Console.WriteLine($"Datetime Sub Kind: {resolution.dateTimeSubKind}");
                Console.WriteLine($"Timex: {resolution.timex}");
                Console.WriteLine($"Value: {resolution.value}");
                Console.WriteLine();
            }
        }
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationAsync
Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));
```
