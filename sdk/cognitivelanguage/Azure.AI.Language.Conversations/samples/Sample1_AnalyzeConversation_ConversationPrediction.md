# Analyze a conversation

This sample demonstrates how to analyze an utterance. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

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

```C# Snippet:ConversationAnalysis_AnalyzeConversation
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    AnalysisInput = new
    {
        ConversationItem = new
        {
            Text = "Send an email to Carol about tomorrow's demo",
            Id = "1",
            ParticipantId = "1",
        }
    },
    Parameters = new
    {
        ProjectName = projectName,
        DeploymentName = deploymentName,

        // Use Utf16CodeUnit for strings in .NET.
        StringIndexType = "Utf16CodeUnit",
    },
    Kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data, JsonPropertyNames.CamelCase));

dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
dynamic conversationPrediction = conversationalTaskResult.Result.Prediction;

Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

Console.WriteLine("Intents:");
foreach (dynamic intent in conversationPrediction.Intents)
{
    Console.WriteLine($"Category: {intent.Category}");
    Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (dynamic entity in conversationPrediction.Entities)
{
    Console.WriteLine($"Category: {entity.Category}");
    Console.WriteLine($"Text: {entity.Text}");
    Console.WriteLine($"Offset: {entity.Offset}");
    Console.WriteLine($"Length: {entity.Length}");
    Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
    Console.WriteLine();

    if (entity.Resolutions is not null)
    {
        foreach (dynamic resolution in entity.Resolutions)
        {
            if (resolution.ResolutionKind == "DateTimeResolution")
            {
                Console.WriteLine($"Datetime Sub Kind: {resolution.DateTimeSubKind}");
                Console.WriteLine($"Timex: {resolution.Timex}");
                Console.WriteLine($"Value: {resolution.Value}");
                Console.WriteLine();
            }
        }
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationAsync
Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));
```
