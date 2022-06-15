# Analyze a conversation

This sample demonstrates how to analyze an utterance. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Enviar un email a Carol acerca de la presentación de mañana",
            language = "es",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,
        verbose = true,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Project Kind: {conversationPrediction.GetProperty("projectKind").GetString()}");
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

    if (!entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        continue;
    }

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
```

## Asynchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithLanguageAsync
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Enviar un email a Carol acerca de la presentación de mañana",
            language = "es",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,
        verbose = true,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

using JsonDocument result = await JsonDocument.ParseAsync(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Project Kind: {conversationPrediction.GetProperty("projectKind").GetString()}");
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

    if (!entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        continue;
    }

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
```
