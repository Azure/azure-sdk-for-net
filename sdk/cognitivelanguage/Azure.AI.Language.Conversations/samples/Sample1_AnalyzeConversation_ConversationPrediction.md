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

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

Console.WriteLine("Intents:");
foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
{
    Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
{
    Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
    Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
    Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();

    if (entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        foreach (JsonElement resolution in resolutions.EnumerateArray())
        {
            if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
            {
                Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
                Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
                Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
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
