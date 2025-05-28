# Analyze an AI Conversation

This sample demonstrates how to analyze an utterance in an AIConversation. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

You can work with request and response content more easily by using our [Dynamic JSON](https://aka.ms/azsdk/net/dynamiccontent) feature. This is illustrated in the following sample.

Start by importing the namespace for the `ConversationAnalysisClient` and related classes:

```C# Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Conversations;
```

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:CreateConversationAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationsClientOptions options = new ConversationsClientOptions(ConversationsClientOptions.ServiceVersion.V2024_05_01);
ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential, options);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeAIConversation
string projectName = TestEnvironment.ProjectName;
string deploymentName = TestEnvironment.DeploymentName;

AnalyzeConversationInput data = new ConversationalAITask(
    new ConversationalAIAnalysisInput(
        conversations: new AIConversation[] {
            new AIConversation(
                id: "order",
                modality: InputModality.Text,
                language: "en-GB",
                conversationItems: new ConversationalAIItem[]
                {
                    new ConversationalAIItem(id: "1", participantId: "user", text: "Hi"),
                    new ConversationalAIItem(id: "2", participantId: "bot", text: "Hello, how can I help you?"),
                    new ConversationalAIItem(id: "3", participantId: "user", text: "I would like to book a flight.")
                }
            )
        }),
    new AIConversationLanguageUnderstandingActionContent(projectName, deploymentName)
    {
        // Use Utf16CodeUnit for strings in .NET.
        StringIndexType = StringIndexType.Utf16CodeUnit,
    });

Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
ConversationalAITaskResult ConversationalAITaskResult = response.Value as ConversationalAITaskResult;
ConversationalAIResult conversationalAIResult = ConversationalAITaskResult.Result;

foreach (var conversation in conversationalAIResult?.Conversations ?? Enumerable.Empty<ConversationalAIAnalysis>())
{
    Console.WriteLine($"Conversation ID: {conversation.Id}");

    Console.WriteLine("Intents:");
    foreach (var intent in conversation.Intents ?? Enumerable.Empty<ConversationalAIIntent>())
    {
        Console.WriteLine($"Name: {intent.Name}");
        Console.WriteLine($"Type: {intent.Type}");

        Console.WriteLine("Conversation Item Ranges:");
        foreach (var range in intent.ConversationItemRanges ?? Enumerable.Empty<ConversationItemRange>())
        {
            Console.WriteLine($" - Offset: {range.Offset}, Count: {range.Count}");
        }

        Console.WriteLine("Entities (Scoped to Intent):");
        foreach (var entity in intent.Entities ?? Enumerable.Empty<ConversationalAIEntity>())
        {
            Console.WriteLine($"Name: {entity.Name}");
            Console.WriteLine($"Text: {entity.Text}");
            Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
            Console.WriteLine($"Offset: {entity.Offset}, Length: {entity.Length}");
            Console.WriteLine($"Conversation Item ID: {entity.ConversationItemId}, Index: {entity.ConversationItemIndex}");

            if (entity.Resolutions != null)
            {
                foreach (var res in entity.Resolutions.OfType<DateTimeResolution>())
                {
                    Console.WriteLine($" - [DateTimeResolution] SubKind: {res.DateTimeSubKind}, Timex: {res.Timex}, Value: {res.Value}");
                }
            }

            if (entity.ExtraInformation != null)
            {
                foreach (var extra in entity.ExtraInformation.OfType<EntitySubtype>())
                {
                    Console.WriteLine($" - [EntitySubtype] Value: {extra.Value}");
                    foreach (var tag in extra.Tags ?? Enumerable.Empty<EntityTag>())
                    {
                        Console.WriteLine($"   • Tag: {tag.Name}, Confidence: {tag.ConfidenceScore}");
                    }
                }
            }

            Console.WriteLine();
        }
    }

    Console.WriteLine("Global Entities:");
    foreach (var entity in conversation.Entities ?? Enumerable.Empty<ConversationalAIEntity>())
    {
        Console.WriteLine($"Name: {entity.Name}");
        Console.WriteLine($"Text: {entity.Text}");
        Console.WriteLine($"Confidence: {entity.ConfidenceScore}");
        Console.WriteLine($"Offset: {entity.Offset}, Length: {entity.Length}");
        Console.WriteLine($"Conversation Item ID: {entity.ConversationItemId}, Index: {entity.ConversationItemIndex}");

        if (entity.ExtraInformation != null)
        {
            foreach (var extra in entity.ExtraInformation.OfType<EntitySubtype>())
            {
                Console.WriteLine($" - [EntitySubtype] Value: {extra.Value}");
                foreach (var tag in extra.Tags ?? Enumerable.Empty<EntityTag>())
                {
                    Console.WriteLine($"   • Tag: {tag.Name}, Confidence: {tag.ConfidenceScore}");
                }
            }
        }

        Console.WriteLine();
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:ConversationAnalysis_AnalyzeAIConversationAsync
Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
ConversationalAITaskResult ConversationalAITaskResult = response.Value as ConversationalAITaskResult;
```
