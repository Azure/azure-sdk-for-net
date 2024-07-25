# Analyze a conversation with Conversation Summarization

This sample demonstrates how to analyze a conversation with Conversation Summarization. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

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

```C# Snippet:AnalyzeConversation_ConversationSummarization
MultiLanguageConversationInput data = new MultiLanguageConversationInput(
    new List<ConversationInput>
    {
        new TextConversation("1", "en", new List<TextConversationItem>()
        {
            new TextConversationItem(
                id: "1",
                participantId: "Agent_1",
                text: "Hello, how can I help you?")
                {
                    Role = ParticipantRole.Agent
                },
            new TextConversationItem(
                id: "2",
                participantId: "Customer_1",
                text: "How to upgrade Office? I am getting error messages the whole day.")
            {
                Role = ParticipantRole.Customer
            },
            new TextConversationItem(
                id : "3",
                participantId : "Agent_1",
                text : "Press the upgrade button please. Then sign in and follow the instructions.")
            {
                Role = ParticipantRole.Agent
            }
        })
    });
List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
    {
        new SummarizationOperationAction()
        {
            ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
            {
                SummaryAspect.Issue,
            }),
            Name = "Issue task",
        },
        new SummarizationOperationAction()
        {
            ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
            {
                SummaryAspect.Resolution,
            }),
            Name = "Resolution task",
        }
    };

Response<AnalyzeConversationOperationState> analyzeConversationOperation = client.AnalyzeConversations(data, actions);
AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;

foreach (AnalyzeConversationOperationResult operationResult in operationState.Actions.Items)
{
    Console.WriteLine($"Operation action name: {operationResult.Name}");
    if (operationResult is SummarizationOperationResult summarizationOperationResult)
    {
        SummaryResult results = summarizationOperationResult.Results;
        foreach (ConversationsSummaryResult conversation in results.Conversations)
        {
            Console.WriteLine($"Conversation: #{conversation.Id}");
            Console.WriteLine("Summaries:");
            foreach (SummaryResultItem summary in conversation.Summaries)
            {
                Console.WriteLine($"Text: {summary.Text}");
                Console.WriteLine($"Aspect: {summary.Aspect}");
            }
            if (conversation.Warnings != null && conversation.Warnings.Any())
            {
                Console.WriteLine("Warnings:");
                foreach (InputWarning warning in conversation.Warnings)
                {
                    Console.WriteLine($"Code: {warning.Code}");
                    Console.WriteLine($"Message: {warning.Message}");
                }
            }
            Console.WriteLine();
        }
    }
    if (operationState.Errors != null && operationState.Errors.Any())
    {
        Console.WriteLine("Errors:");
        foreach (ConversationError error in operationState.Errors)
        {
            Console.WriteLine($"Error: {error.Code} - {error}");
        }
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationSummarization
Response<AnalyzeConversationOperationState> analyzeConversationOperation = await client.AnalyzeConversationsAsync(data, actions);
```
