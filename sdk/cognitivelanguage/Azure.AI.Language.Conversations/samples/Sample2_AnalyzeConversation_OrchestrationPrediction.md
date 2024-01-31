# Analyze a conversation

This sample demonstrates how to analyze an utterance using an Orchestration project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

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

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPrediction
string projectName = "DomainOrchestrator";
string deploymentName = "production";

var data = new
{
    AnalysisInput = new
    {
        ConversationItem = new
        {
            Text = "How are you?",
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
dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
dynamic orchestrationPrediction = conversationalTaskResult.Result.Prediction;
```

## Accessing project specific results

Depending on the project chosen by your orchestration model, you may get results from either a Question Answering, Conversations, or LUIS project. You may access your responses as follows.

### Question Answering

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestrationPrediction.TopIntent;
dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
{
    Console.WriteLine($"Top intent: {respondingProjectName}");

    dynamic questionAnsweringResponse = targetIntentResult.Result;
    Console.WriteLine($"Question Answering Response:");
    foreach (dynamic answer in questionAnsweringResponse.Answers)
    {
        Console.WriteLine(answer.Answer?.ToString());
    }
}
```

### Conversation

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestrationPrediction.TopIntent;
dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
{
    dynamic questionAnsweringResult = targetIntentResult.Result;

    Console.WriteLine($"Answers:");
    foreach (dynamic answer in questionAnsweringResult.Answers)
    {
        Console.WriteLine($"{answer.Answer}");
        Console.WriteLine($"Confidence: {answer.ConfidenceScore}");
        Console.WriteLine();
    }
}
```

### LUIS

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
string respondingProjectName = orchestrationPrediction.TopIntent;
dynamic targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == "Luis")
{
    dynamic luisResponse = targetIntentResult.Result;
    Console.WriteLine($"LUIS Response: {luisResponse}");
}
```
