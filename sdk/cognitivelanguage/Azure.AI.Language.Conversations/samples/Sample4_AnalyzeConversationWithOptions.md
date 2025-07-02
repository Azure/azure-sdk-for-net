# Analyze a conversation

This sample demonstrates how to analyze an utterance with additional options. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

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

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptions
string projectName = "EmailApp";
string deploymentName = "production";

AnalyzeConversationInput data = new ConversationLanguageUnderstandingInput(
    new ConversationAnalysisInput(
        new TextConversationItem(
            id: "1",
            participantId: "participant1",
            text: "Send an email to Carol about tomorrow's demo")),
    new ConversationLanguageUnderstandingActionContent(projectName, deploymentName)
{
    // Use Utf16CodeUnit for strings in .NET.
    StringIndexType = StringIndexType.Utf16CodeUnit,
    Verbose = true,
});

Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptionsAsync
Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
```
