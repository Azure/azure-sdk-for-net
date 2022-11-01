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

var conversationalTaskResult = response.Content.ToDynamic();
var orchestrationPrediction = conversationalTaskResult.Result.Prediction;
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
Response response = await client.AnalyzeConversationAsync(RequestContent.Create(data));

var conversationalTaskResult = response.Content.ToDynamic();
var orchestrationPrediction = conversationalTaskResult.Result.Prediction;
```

## Accessing project specific results

Depending on the project chosen by your orchestration model, you may get results from either a Question Answering, Conversations, or LUIS project. You may access your responses as follows.

### Question Answering

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestrationPrediction.TopIntent;
var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];
if (targetIntentResult.TargetProjectKind == "QuestionAnswering")
{
    Console.WriteLine($"Top intent: {respondingProjectName}");

    var questionAnsweringResponse = targetIntentResult.Result;
    Console.WriteLine($"Question Answering Response:");
    foreach (var answer in questionAnsweringResponse.Answers)
    {
        Console.WriteLine(answer.Answer);
    }
}
```

### Conversation

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestrationPrediction.TopIntent;
var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == "Conversation")
{
    var conversationResult = targetIntentResult.Result;
    var conversationPrediction = conversationResult.Prediction;

    Console.WriteLine($"Top Intent: {conversationPrediction.TopIntent}");
    Console.WriteLine($"Intents:");
    foreach (var intent in conversationPrediction.Intents)
    {
        Console.WriteLine($"Intent Category: {intent.Category}");
        Console.WriteLine($"Confidence: {intent.ConfidenceScore}");
        Console.WriteLine();
    }

    Console.WriteLine($"Entities:");
    foreach (var entity in conversationPrediction.Entities)
    {
        Console.WriteLine($"Entity Text: {entity.Text}");
        Console.WriteLine($"Entity Category: {entity.Category}");
        Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
        Console.WriteLine($"Starting Position: {entity.Offset}");
        Console.WriteLine($"Length: {entity.Length}");
        Console.WriteLine();

        if (entity.Resolutions != null)
        {
            foreach (var resolution in entity.Resolutions)
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
}
```

### LUIS

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
string respondingProjectName = orchestrationPrediction.TopIntent;
var targetIntentResult = orchestrationPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == "Luis")
{
    var luisResponse = targetIntentResult.Result;
    Console.WriteLine($"LUIS Response: {(string)luisResponse}");
}
```
