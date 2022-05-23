# Analyze a conversation

This sample demonstrates how to analyze a conversation with Conversation PII (Text input). To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can prepare the input:

```C# Snippet:StartAnalyzeConversation_ConversationPII_Text_Input
var textConversationItems = new List<TextConversationItem>()
{
    new TextConversationItem("1", "0", "Hi, I am John Doe."),
    new TextConversationItem("2", "1", "Hi John, how are you doing today?"),
    new TextConversationItem("3", "0", "Pretty good."),
};

var input = new List<TextConversation>()
{
    new TextConversation("1", "en", textConversationItems)
};

var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, null);

var tasks = new List<AnalyzeConversationLROTask>()
{
    new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
};
```

then you can start analyzing by calling the `AnalyzeConversation`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

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

```C# Snippet:StartAnalyzeConversation_ConversationPII_Text_Results
var jobResults = analyzeConversationOperation.Value;
foreach (var result in jobResults.Tasks.Items)
{
    var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;

    var results = analyzeConversationPIIResult.Results;

    Console.WriteLine("Conversations:");
    foreach (var conversation in results.Conversations)
    {
        Console.WriteLine($"Conversation #:{conversation.Id}");
        Console.WriteLine("Conversation Items: ");
        foreach (var conversationItem in conversation.ConversationItems)
        {
            Console.WriteLine($"Conversation Item #:{conversationItem.Id}");

            Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");

            Console.WriteLine("Entities:");
            foreach (var entity in conversationItem.Entities)
            {
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```