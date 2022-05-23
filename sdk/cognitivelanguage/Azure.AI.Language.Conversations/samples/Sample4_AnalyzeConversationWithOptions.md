# Analyze a conversation

This sample demonstrates how to analyze an utterance with additional options. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptions
TextConversationItem input = new TextConversationItem(
    participantId: "1",
    id: "1",
    text: "Send an email to Carol about the tomorrow's demo.");
AnalyzeConversationOptions options = new AnalyzeConversationOptions(input)
{
    Verbose = true
};

ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
    "Send an email to Carol about the tomorrow's demo.",
    conversationsProject,
    options);

CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
ConversationPrediction conversationPrediction = customConversationalTaskResult.Result.Prediction as ConversationPrediction;

Console.WriteLine($"Project Kind: {customConversationalTaskResult.Result.Prediction.ProjectKind}");
Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

Console.WriteLine("Intents:");
foreach (ConversationIntent intent in conversationPrediction.Intents)
{
    Console.WriteLine($"Category: {intent.Category}");
    Console.WriteLine($"Confidence: {intent.Confidence}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (ConversationEntity entity in conversationPrediction.Entities)
{
    Console.WriteLine($"Category: {entity.Category}");
    Console.WriteLine($"Text: {entity.Text}");
    Console.WriteLine($"Offset: {entity.Offset}");
    Console.WriteLine($"Length: {entity.Length}");
    Console.WriteLine($"Confidence: {entity.Confidence}");
    Console.WriteLine();

    foreach (BaseResolution resolution in entity.Resolutions)
    {
        if (resolution is DateTimeResolution dateTimeResolution)
        {
            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
            Console.WriteLine($"Value: {dateTimeResolution.Value}");
            Console.WriteLine();
        }
    }
}
```

## Asynchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptionsAsync
TextConversationItem input = new TextConversationItem(
    participantId: "1",
    id: "1",
    text: "Send an email to Carol about the tomorrow's demo.");
AnalyzeConversationOptions options = new AnalyzeConversationOptions(input)
{
    Verbose = true
};

ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

Response<AnalyzeConversationTaskResult> response = await client.AnalyzeConversationAsync(
    "Send an email to Carol about the tomorrow's demo.",
    conversationsProject,
    options);

CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
ConversationPrediction conversationPrediction = customConversationalTaskResult.Result.Prediction as ConversationPrediction;

Console.WriteLine($"Project Kind: {customConversationalTaskResult.Result.Prediction.ProjectKind}");
Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

Console.WriteLine("Intents:");
foreach (ConversationIntent intent in conversationPrediction.Intents)
{
    Console.WriteLine($"Category: {intent.Category}");
    Console.WriteLine($"Confidence: {intent.Confidence}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (ConversationEntity entity in conversationPrediction.Entities)
{
    Console.WriteLine($"Category: {entity.Category}");
    Console.WriteLine($"Text: {entity.Text}");
    Console.WriteLine($"Offset: {entity.Offset}");
    Console.WriteLine($"Length: {entity.Length}");
    Console.WriteLine($"Confidence: {entity.Confidence}");
    Console.WriteLine();

    foreach (BaseResolution resolution in entity.Resolutions)
    {
        if (resolution is DateTimeResolution dateTimeResolution)
        {
            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
            Console.WriteLine($"Value: {dateTimeResolution.Value}");
            Console.WriteLine();
        }
    }
}
```
