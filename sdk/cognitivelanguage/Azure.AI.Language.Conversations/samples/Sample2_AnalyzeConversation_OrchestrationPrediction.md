# Analyze a conversation

This sample demonstrates how to analyze an utterance using an Orchestration project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

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
    analysisInput = new
    {
        conversationItem = new
        {
            text = "How are you?",
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
dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

dynamic conversationalTaskResult = response.Content.ToDynamic();
dynamic orchestrationPrediction = conversationalTaskResult.result.prediction;
```

## Accessing project specific results

Depending on the project chosen by your orchestration model, you may get results from either a Question Answering, Conversations, or LUIS project. You may access your responses as follows.

### Question Answering

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestrationPrediction.topIntent;
dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

if (targetIntentResult.targetProjectKind == "QuestionAnswering")
{
    Console.WriteLine($"Top intent: {respondingProjectName}");

    dynamic questionAnsweringResponse = targetIntentResult.result;
    Console.WriteLine($"Question Answering Response:");
    foreach (dynamic answer in questionAnsweringResponse.answers)
    {
        Console.WriteLine(answer.answer?.ToString());
    }
}
```

### Conversation

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestrationPrediction.topIntent;
dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

if (targetIntentResult.targetProjectKind == "Conversation")
{
    dynamic conversationResult = targetIntentResult.result;
    dynamic conversationPrediction = conversationResult.prediction;

    Console.WriteLine($"Top Intent: {conversationPrediction.topIntent}");
    Console.WriteLine($"Intents:");
    foreach (dynamic intent in conversationPrediction.intents)
    {
        Console.WriteLine($"Intent Category: {intent.category}");
        Console.WriteLine($"Confidence: {intent.confidenceScore}");
        Console.WriteLine();
    }

    Console.WriteLine($"Entities:");
    foreach (dynamic entity in conversationPrediction.entities)
    {
        Console.WriteLine($"Entity Text: {entity.text}");
        Console.WriteLine($"Entity Category: {entity.category}");
        Console.WriteLine($"Confidence: {entity.confidenceScore}");
        Console.WriteLine($"Starting Position: {entity.offset}");
        Console.WriteLine($"Length: {entity.length}");
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
}
```

### LUIS

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
string respondingProjectName = orchestrationPrediction.topIntent;
dynamic targetIntentResult = orchestrationPrediction.intents[respondingProjectName];

if (targetIntentResult.targetProjectKind == "Luis")
{
    dynamic luisResponse = targetIntentResult.result;
    Console.WriteLine($"LUIS Response: {luisResponse}");
}
```
