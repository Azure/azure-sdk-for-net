# Analyze a conversation

This sample demonstrates how to analyze an utterance using an Orchestration project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPrediction
ConversationsProject orchestrationProject = new ConversationsProject("DomainOrchestrator", "production");
Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
    "Where are the calories per recipe?",
    orchestrationProject);

OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;
```

## Asynchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionAsync
ConversationsProject orchestrationProject = new ConversationsProject("DomainOrchestrator", "production");
Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
    "Where are the calories per recipe?",
    orchestrationProject);

OrchestratorPrediction orchestratorPrediction = response.Value.Prediction as OrchestratorPrediction;
```

## Accessing project specific results

Depending on the project chosen by your orchestration model, you may get results from either a Question Answering, Conversations, or LUIS project. You may access your responses as follows.

### Question Answering

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestratorPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetKind == TargetKind.QuestionAnswering)
{
    QuestionAnsweringTargetIntentResult qnaTargetIntentResult = targetIntentResult as QuestionAnsweringTargetIntentResult;

    KnowledgeBaseAnswers qnaAnswers = qnaTargetIntentResult.Result;

    Console.WriteLine("Answers: \n");
    foreach (KnowledgeBaseAnswer answer in qnaAnswers.Answers)
    {
        Console.WriteLine($"Answer: {answer.Answer}");
        Console.WriteLine($"Confidence: {answer.Confidence}");
        Console.WriteLine($"Source: {answer.Source}");
        Console.WriteLine();
    }
}
```

### Conversation

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestratorPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetKind == TargetKind.Conversation)
{
    ConversationTargetIntentResult cluTargetIntentResult = targetIntentResult as ConversationTargetIntentResult;

    ConversationResult conversationResult = cluTargetIntentResult.Result;
    ConversationPrediction conversationPrediction = conversationResult.Prediction;

    if (!String.IsNullOrEmpty(conversationResult.DetectedLanguage))
        Console.WriteLine($"Detected Language: {conversationResult.DetectedLanguage}");

    Console.WriteLine($"Top Intent: {conversationResult.Prediction.TopIntent}");
    Console.WriteLine($"Intents:");
    foreach (ConversationIntent intent in conversationPrediction.Intents)
    {
        Console.WriteLine($"Intent Category: {intent.Category}");
        Console.WriteLine($"Confidence: {intent.Confidence}");
        Console.WriteLine();
    }

    Console.WriteLine($"Entities:");
    foreach (ConversationEntity entitiy in conversationPrediction.Entities)
    {
        Console.WriteLine($"Entity Text: {entitiy.Text}");
        Console.WriteLine($"Entity Category: {entitiy.Category}");
        Console.WriteLine($"Confidence: {entitiy.Confidence}");
        Console.WriteLine($"Starting Position: {entitiy.Offset}");
        Console.WriteLine($"Length: {entitiy.Length}");
        Console.WriteLine();
    }
}
```

### LUIS

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
string respondingProjectName = orchestratorPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetKind == TargetKind.Luis)
{
    LuisTargetIntentResult luisTargetIntentResult = targetIntentResult as LuisTargetIntentResult;
    BinaryData luisResponse = luisTargetIntentResult.Result;

    Console.WriteLine($"LUIS Response: {luisResponse.ToString()}");
}
```
