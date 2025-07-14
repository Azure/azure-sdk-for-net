# Analyze a conversation

This sample demonstrates how to analyze an utterance using an Orchestration project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

You can work with request and response content more easily by using our [Dynamic JSON](https://aka.ms/azsdk/net/dynamiccontent) feature. This is illustrated in the following sample.

Start by importing the namespace for the `ConversationAnalysisClient` and related classes:

```C# Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Conversations;
using Azure.AI.Language.Conversations.Models;
```

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPrediction
string projectName = "TestWorkflow";
string deploymentName = "production";
 Console.WriteLine("=== Request Info ===");
 Console.WriteLine($"Project Name: {projectName}");
 Console.WriteLine($"Deployment Name: {deploymentName}");

AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
    new ConversationAnalysisInput(
        new TextConversationItem(
            id: "1",
            participantId: "participant1",
            text: "How are you?")),
    new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
    {
        StringIndexType = StringIndexType.Utf16CodeUnit,
    });
var serializedRequest = JsonSerializer.Serialize(data, new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    Converters = { new JsonStringEnumConverter() }
});

Console.WriteLine("Request payload:");
Console.WriteLine(serializedRequest);

Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
ConversationActionResult conversationResult = response.Value as ConversationActionResult;
OrchestrationPrediction orchestrationPrediction = conversationResult.Result.Prediction as OrchestrationPrediction;
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
```

## Accessing project specific results

Depending on the project chosen by your orchestration model, you may get results from either a Question Answering, Conversations, or LUIS project. You may access your responses as follows.

### Question Answering

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestrationPrediction.TopIntent;
Console.WriteLine($"Top intent: {respondingProjectName}");

TargetIntentResult targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult is QuestionAnsweringTargetIntentResult questionAnsweringTargetIntentResult)
{
    AnswersResult questionAnsweringResponse = questionAnsweringTargetIntentResult.Result;
    Console.WriteLine($"Question Answering Response:");
    foreach (KnowledgeBaseAnswer answer in questionAnsweringResponse.Answers)
    {
        Console.WriteLine(answer.Answer?.ToString());
    }
}
```

### Conversation

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestrationPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult is ConversationTargetIntentResult conversationTargetIntent)
{
    ConversationResult conversationResult = conversationTargetIntent.Result;
    ConversationPrediction conversationPrediction = conversationResult.Prediction;

    Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
    Console.WriteLine($"Intents:");
    foreach (ConversationIntent intent in conversationPrediction.Intents)
    {
        Console.WriteLine($"Intent Category: {intent.Category}");
        Console.WriteLine($"Confidence: {intent.Confidence}");
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
