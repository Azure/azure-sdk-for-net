# Meeting Transcript Segmentation

This sample demonstrates how to do topic segmentation task only with Conversation Summarization API. To get started, you'll need to create a Cognitive Language service endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

## Import Nuget Packages
```
  <ItemGroup>
    <PackageReference Include="Azure.AI.Language.Conversations" Version="1.1.0-beta.2" />
    <PackageReference Include="Azure.Identity" Version="1.8.1" />
  </ItemGroup>
```

## Sample Code
```C#
using Azure;
using Azure.AI.Language.Conversations;
using Azure.Core;
using Azure.Identity;
using System.Text.Json;

var endpoint = Environment.GetEnvironmentVariable("LanguageServiceEndpoint");
var credential = new DefaultAzureCredential();
var client = new ConversationAnalysisClient(new Uri(endpoint), credential);
var data = new
{
    analysisInput = new
    {
        conversations = new[]
        {
            new
            {
                conversationItems = new[]
                {
                    new
                    {
                        participantId = "speaker 1",
                        id = "1",
                        text = "Let's get started.",
                        lexical = "",
                        itn = "",
                        maskedItn = "",
                        conversationItemLevelTiming = new {
                            offset = 0,
                            duration = 20000000
                        }
                    },
                    new
                    {
                        participantId = "speaker 2",
                        id = "2",
                        text = "OK. How many remaining bugs do we have now?",
                        lexical = "",
                        itn = "",
                        maskedItn = "",
                        conversationItemLevelTiming = new {
                            offset = 20000000,
                            duration = 50000000
                        }
                    },
                    new 
                    {
                        participantId = "speaker 3",
                        id = "3",
                        text = "Only 3.",
                        lexical = "",
                        itn = "",
                        maskedItn = "",
                        conversationItemLevelTiming = new
                        {
                            offset = 50000000,
                            duration = 60000000
                        }
                    }
                },
                id = "1",
                language = "en",
                modality = "transcript",
            },
        }
    },
    tasks = new[]
    {
        new
        {
            taskName = "Meeting Segmentation",
            kind = "ConversationalSummarizationTask",
            parameters = new
            {
                labFeatures = new
                {
                    EnableTopicNaming = "false",
                },
                summaryAspects = new[]
                {
                    "chapterTitle",
                }
            },
        }
    },
};

Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data)).ConfigureAwait(false);

using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    Console.WriteLine($"Task name: {task.GetProperty("taskName").GetString()}");
    JsonElement results = task.GetProperty("results");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Summaries:");
        foreach (JsonElement summary in conversation.GetProperty("summaries").EnumerateArray())
        {
            Console.WriteLine($"Text: {summary.GetProperty("text").GetString()}");
            Console.WriteLine($"Aspect: {summary.GetProperty("aspect").GetString()}");
            foreach (JsonElement context in summary.GetProperty("contexts").EnumerateArray())
            {
                Console.WriteLine($"Context: {context.GetProperty("conversationItemId").GetString()}");
            }
        }
        Console.WriteLine();
    }
}
```
Notes
1. The code above uses `DefaultAzureCredential` which is recommended. If you prefer APIKEY, use `AzureKeyCredential` instead. See example:
```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```
2. Use `labFeatures` to disable chapter title generation, which can speed up the API call significantly: `EnableTopicNaming = "false"`. The output summary text is populated as a GUID as placeholder instead.
3. The `utteranceLevelAudioTiming` is helpful to make the topic segmentaion more accurate.