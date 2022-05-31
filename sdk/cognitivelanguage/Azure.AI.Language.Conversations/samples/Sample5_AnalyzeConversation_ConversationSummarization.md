# Analyze a conversation

This sample demonstrates how to analyze a conversation with Conversation Summarization. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can prepare the input:

```C# Snippet:StartAnalyzeConversation_ConversationSummarization_Input
var textConversationItems = new List<TextConversationItem>()
{
    new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
    new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
    new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions."),
};

var input = new List<TextConversation>()
{
    new TextConversation("1", "en", textConversationItems)
};

var conversationSummarizationTaskParameters = new ConversationSummarizationTaskParameters(new List<SummaryAspect>() { SummaryAspect.Issue, SummaryAspect.Resolution });

var tasks = new List<AnalyzeConversationLROTask>()
{
    new AnalyzeConversationSummarizationTask("1", AnalyzeConversationLROTaskKind.ConversationalSummarizationTask, conversationSummarizationTaskParameters),
};
```

then you can start analyzing by calling the `StartAnalyzeConversation`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

## Synchronous

```C# Snippet:StartAnalyzeConversation_StartAnalayzing
var analyzeConversationOperation = client.StartAnalyzeConversation(input, tasks);
analyzeConversationOperation.WaitForCompletion();
```

## Asynchronous

```C# Snippet:StartAnalyzeConversationAsync_StartAnalayzing
var analyzeConversationOperation = await client.StartAnalyzeConversationAsync(input, tasks);
await analyzeConversationOperation.WaitForCompletionAsync();
```

You can finally print the results:

```C# Snippet:StartAnalyzeConversation_ConversationSummarization_Results
var jobResults = analyzeConversationOperation.Value;
foreach (var result in jobResults.Tasks.Items)
{
    var analyzeConversationSummarization = result as AnalyzeConversationSummarizationResult;

    var results = analyzeConversationSummarization.Results;

    Console.WriteLine("Conversations:");
    foreach (var conversation in results.Conversations)
    {
        Console.WriteLine($"Conversation #:{conversation.Id}");
        Console.WriteLine("Summaries:");
        foreach (var summary in conversation.Summaries)
        {
            Console.WriteLine($"Text: {summary.Text}");
            Console.WriteLine($"Aspect: {summary.Aspect}");
        }
        Console.WriteLine();
    }
}
```