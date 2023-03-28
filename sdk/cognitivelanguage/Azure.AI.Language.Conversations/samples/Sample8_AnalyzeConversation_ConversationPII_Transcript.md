# Analyze a conversation with Conversation PII using transcript input

This sample demonstrates how to analyze a conversation with Conversation PII (Transcript input). To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:AnalyzeConversation_ConversationPII_Transcript
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
                        itn = "hi",
                        maskedItn = "hi",
                        text = "Hi",
                        lexical = "hi",
                        audioTimings = new[]
                        {
                            new
                            {
                                word = "hi",
                                offset = 4500000,
                                duration = 2800000,
                            },
                        },
                        id = "1",
                        participantId = "speaker",
                    },
                    new
                    {
                        itn = "jane doe",
                        maskedItn = "jane doe",
                        text = "Jane Doe",
                        lexical = "jane doe",
                        audioTimings = new[]
                        {
                            new
                            {
                                word = "jane",
                                offset = 7100000,
                                duration = 4800000,
                            },
                            new
                            {
                                word = "doe",
                                offset = 12000000,
                                duration = 1700000,
                            },
                        },
                        id = "3",
                        participantId = "agent",
                    },
                    new
                    {
                        itn = "hi jane what's your phone number",
                        maskedItn = "hi jane what's your phone number",
                        text = "Hi Jane, what's your phone number?",
                        lexical = "hi jane what's your phone number",
                        audioTimings = new[]
                        {
                            new
                            {
                              word = "hi",
                              offset = 7700000,
                              duration= 3100000,
                            },
                            new
                            {
                              word= "jane",
                              offset= 10900000,
                              duration= 5700000,
                            },
                            new
                            {
                              word= "what's",
                              offset= 17300000,
                              duration= 2600000,
                            },
                            new
                            {
                              word= "your",
                              offset= 20000000,
                              duration= 1600000,
                            },
                            new
                            {
                              word= "phone",
                              offset= 21700000,
                              duration= 1700000,
                            },
                            new
                            {
                              word= "number",
                              offset= 23500000,
                              duration= 2300000,
                            },
                        },
                        id = "2",
                        participantId = "speaker",
                    },
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
            parameters = new
            {
                piiCategories = new[]
                {
                    "All",
                },
                includeAudioRedaction = false,
                redactionSource = "lexical",
                modelVersion = "2022-05-15-preview",
                loggingOptOut = false,
            },
            kind = "ConversationalPIITask",
            taskName = "analyze",
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
foreach (dynamic task in jobResults.tasks.items)
{
    dynamic results = task.results;

    Console.WriteLine("Conversations:");
    foreach (dynamic conversation in results.conversations)
    {
        Console.WriteLine($"Conversation: #{conversation.id}");
        Console.WriteLine("Conversation Items:");
        foreach (dynamic conversationItem in conversation.conversationItems)
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.id}");

            dynamic redactedContent = conversationItem.redactedContent;
            Console.WriteLine($"Redacted Text: {redactedContent.text}");
            Console.WriteLine($"Redacted Lexical: {redactedContent.lexical}");
            Console.WriteLine($"Redacted MaskedItn: {redactedContent.maskedItn}");

            Console.WriteLine("Entities:");
            foreach (dynamic entity in conversationItem.entities)
            {
                Console.WriteLine($"Text: {entity.text}");
                Console.WriteLine($"Offset: {entity.offset}");
                Console.WriteLine($"Category: {entity.category}");
                Console.WriteLine($"Confidence Score: {entity.confidenceScore}");
                Console.WriteLine($"Length: {entity.length}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```

## Asynchronous

Using the same `data` definition above, you can make an asynchronous request by calling `AnalyzeConversationAsync`:

```C# Snippet:AnalyzeConversationAsync_ConversationPII_Transcript
Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
```
