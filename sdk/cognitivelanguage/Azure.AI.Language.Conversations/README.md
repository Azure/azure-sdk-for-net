# Azure Cognitive Language Services Conversations client library for .NET

Conversational Language Understanding - aka CLU for short - is a cloud-based conversational AI service which provides many language understanding capabilities like:

- Conversation App: It's used in extracting intents and entities in conversations
- Workflow app: Acts like an orchestrator to select the best candidate to analyze conversations to get best response from apps like Qna, Luis, and Conversation App
- Conversational Issue Summarization: Used to summarize conversations in the form of issues, and final resolutions
- Conversational PII: Used to extract and redact personally-identifiable info (PII)

[Source code][conversationanalysis_client_src] | [Package (NuGet)][conversationanalysis_nuget_package] | [API reference documentation][conversationanalysis_refdocs] | [Product documentation][conversationanalysis_docs] | [Samples][conversationanalysis_samples]

## Getting started

### Install the package

Install the Azure Cognitive Language Services Conversations client library for .NET with [NuGet][nuget]:

```powershell
dotnet add package Azure.AI.Language.Conversations --prerelease
```

### Prerequisites

- An [Azure subscription][azure_subscription]
- An existing Azure Language Service Resource

### Authenticate the client

In order to interact with the Conversations service, you'll need to create an instance of the [`ConversationAnalysisClient`][conversationanalysis_client_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Cognitive Services resource in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] command shown below to get the API key from the Cognitive Service resource.

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Create a ConversationAnalysisClient

Once you've determined your **endpoint** and **API key** you can instantiate a `ConversationAnalysisClient`:

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

## Key concepts

### ConversationAnalysisClient

The [`ConversationAnalysisClient`][conversationanalysis_client_class] is the primary interface for making predictions using your deployed Conversations models. It provides both synchronous and asynchronous APIs to submit queries.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The Azure.AI.Language.Conversations client library provides both synchronous and asynchronous APIs.

The following examples show common scenarios using the `client` [created above](#create-a-conversationanalysisclient).

### Analyze a conversation

To analyze a conversation, you can call the `client.AnalyzeConversation()` method:

```C# Snippet:ConversationAnalysis_AnalyzeConversation
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Send an email to Carol about tomorrow's demo",
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

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

Console.WriteLine("Intents:");
foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
{
    Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
{
    Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
    Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
    Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();

    if (!entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        continue;
    }

    foreach (JsonElement resolution in resolutions.EnumerateArray())
    {
        if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
        {
            Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
            Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
            Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
            Console.WriteLine();
        }
    }
}
```

Additional options can be passed to `AnalyzeConversation` like enabling more verbose output:

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptions
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Send an email to Carol about tomorrow's demo",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,
        verbose = true,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Project Kind: {conversationPrediction.GetProperty("projectKind").GetString()}");
Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

Console.WriteLine("Intents:");
foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
{
    Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
{
    Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
    Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
    Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();

    if (!entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        continue;
    }

    foreach (JsonElement resolution in resolutions.EnumerateArray())
    {
        if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
        {
            Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
            Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
            Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
            Console.WriteLine();
        }
    }
}
```

### Analyze a conversation in a different language

The `language` property can be set to specify the language of the conversation:

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Enviar un email a Carol acerca de la presentación de mañana",
            language = "es",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,
        verbose = true,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Project Kind: {conversationPrediction.GetProperty("projectKind").GetString()}");
Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

Console.WriteLine("Intents:");
foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
{
    Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
{
    Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
    Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
    Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();

    if (!entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        continue;
    }

    foreach (JsonElement resolution in resolutions.EnumerateArray())
    {
        if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
        {
            Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
            Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
            Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
            Console.WriteLine();
        }
    }
}
```

Other optional properties can be set such as verbosity and whether service logging is enabled.

### Analyze a conversation - Orchestration Project

To analyze a conversation using an orchestration project, you can call the `client.AnalyzeConversation()` method just like the conversation project.

### Orchestration Project - Conversation Prediction

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "Conversation")
{
    JsonElement conversationResult = targetIntentResult.GetProperty("result");
    JsonElement conversationPrediction = conversationResult.GetProperty("prediction");

    Console.WriteLine($"Top Intent: {conversationPrediction.GetProperty("topIntent").GetString()}");
    Console.WriteLine($"Intents:");
    foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
    {
        Console.WriteLine($"Intent Category: {intent.GetProperty("category").GetString()}");
        Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
        Console.WriteLine();
    }

    Console.WriteLine($"Entities:");
    foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
    {
        Console.WriteLine($"Entity Text: {entity.GetProperty("text").GetString()}");
        Console.WriteLine($"Entity Category: {entity.GetProperty("category").GetString()}");
        Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
        Console.WriteLine($"Starting Position: {entity.GetProperty("offset").GetInt32()}");
        Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
        Console.WriteLine();

        if (!entity.TryGetProperty("resolutions", out JsonElement resolutions))
        {
            continue;
        }

        foreach (JsonElement resolution in resolutions.EnumerateArray())
        {
            if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
            {
                Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
                Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
                Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
                Console.WriteLine();
            }
        }
    }
}
```

### Orchestration Project - QuestionAnswering Prediction

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "QuestionAnswering")
{
    Console.WriteLine($"Top intent: {respondingProjectName}");

    JsonElement questionAnsweringResponse = targetIntentResult.GetProperty("result");
    Console.WriteLine($"Question Answering Response:");
    foreach (JsonElement answer in questionAnsweringResponse.GetProperty("answers").EnumerateArray())
    {
        Console.WriteLine(answer.GetProperty("answer").GetString());
    }
}
```

### Orchestration Project - Luis Prediction

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "Luis")
{
    JsonElement luisResponse = targetIntentResult.GetProperty("result");
    Console.WriteLine($"LUIS Response: {luisResponse.GetRawText()}");
}
```

### Analyze a conversation - Conversation Summarization

First, you should prepare the input:

```C# Snippet:SubmitJob_ConversationSummarization_Input
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
                        text = "Hello, how can I help you?",
                        id = "1",
                        participantId = "Agent",
                    },
                    new
                    {
                        text = "How to upgrade Office? I am getting error messages the whole day.",
                        id = "2",
                        participantId = "Customer",
                    },
                    new
                    {
                        text = "Press the upgrade button please. Then sign in and follow the instructions.",
                        id = "3",
                        participantId = "Agent",
                    },
                },
                id = "1",
                language = "en",
                modality = "text",
            },
        }
    },
    tasks = new[]
    {
        new
        {
            parameters = new
            {
                summaryAspects = new[]
                {
                    "issue",
                    "resolution",
                }
            },
            kind = "ConversationalSummarizationTask",
            taskName = "1",
        },
    },
};
```

Then you can start analyzing by calling the `SubmitJob`, and because this is a long running operation you'll have to wait until it's finished by calling `WaitForCompletion` function.

## Synchronous

```C# Snippet:SubmitJob_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = client.SubmitJob(WaitUntil.Started, RequestContent.Create(data));
analyzeConversationOperation.WaitForCompletion();
```

## Asynchronous

```C# Snippet:SubmitJobAsync_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = await client.SubmitJobAsync(WaitUntil.Started, RequestContent.Create(data));
await analyzeConversationOperation.WaitForCompletionAsync();
```

You can finally print the results:

```C# Snippet:SubmitJob_ConversationSummarization_Results
using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    JsonElement results = task.GetProperty("results");

    Console.WriteLine("Conversations:");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Summaries:");
        foreach (JsonElement summary in conversation.GetProperty("summaries").EnumerateArray())
        {
            Console.WriteLine($"Text: {summary.GetProperty("text").GetString()}");
            Console.WriteLine($"Aspect: {summary.GetProperty("aspect").GetString()}");
        }
        Console.WriteLine();
    }
}
```

### Analyze a conversation - Conversation PII - Text Input

First, you should prepare the input:

```C# Snippet:SubmitJob_ConversationPII_Text_Input
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
                        text = "Hi, I am John Doe.",
                        id = "1",
                        participantId = "0",
                    },
                    new
                    {
                        text = "Hi John, how are you doing today?",
                        id = "2",
                        participantId = "1",
                    },
                    new
                    {
                        text = "Pretty good.",
                        id = "3",
                        participantId = "0",
                    },
                },
                id = "1",
                language = "en",
                modality = "text",
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
                modelVersion = "2022-05-15-preview",
                loggingOptOut = false,
            },
            kind = "ConversationalPIITask",
            taskName = "analyze",
        },
    },
};
```

Then you can start analyzing by calling the `SubmitJob`, and because this is a long running operation you'll have to wait until it's finished by calling `WaitForCompletion` function.

## Synchronous

```C# Snippet:SubmitJob_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = client.SubmitJob(WaitUntil.Started, RequestContent.Create(data));
analyzeConversationOperation.WaitForCompletion();
```

## Asynchronous

```C# Snippet:SubmitJobAsync_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = await client.SubmitJobAsync(WaitUntil.Started, RequestContent.Create(data));
await analyzeConversationOperation.WaitForCompletionAsync();
```

You can finally print the results:

```C# Snippet:SubmitJob_ConversationPII_Text_Results
using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    JsonElement results = task.GetProperty("results");

    Console.WriteLine("Conversations:");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Conversation Items:");
        foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");

            Console.WriteLine($"Redacted Text: {conversationItem.GetProperty("redactedContent").GetProperty("text").GetString()}");

            Console.WriteLine("Entities:");
            foreach (JsonElement entity in conversationItem.GetProperty("entities").EnumerateArray())
            {
                Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                Console.WriteLine($"Confidence Score: {entity.GetProperty("confidenceScore").GetSingle()}");
                Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```

### Analyze a conversation - Conversation PII - Transcript Input

First, you should prepare the input:

```C# Snippet:SubmitJob_ConversationPII_Transcript_Input
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
```

Then you can start analyzing by calling the `SubmitJob`, and because this is a long running operation you'll have to wait until it's finished by calling `WaitForCompletion` function.

## Synchronous

```C# Snippet:SubmitJob_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = client.SubmitJob(WaitUntil.Started, RequestContent.Create(data));
analyzeConversationOperation.WaitForCompletion();
```

## Asynchronous

```C# Snippet:SubmitJobAsync_StartAnalayzing
Operation<BinaryData> analyzeConversationOperation = await client.SubmitJobAsync(WaitUntil.Started, RequestContent.Create(data));
await analyzeConversationOperation.WaitForCompletionAsync();
```

You can finally print the results:

```C# Snippet:SubmitJob_ConversationPII_Transcript_Results
using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    JsonElement results = task.GetProperty("results");

    Console.WriteLine("Conversations:");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Conversation Items:");
        foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");

            JsonElement redactedContent = conversationItem.GetProperty("redactedContent");
            Console.WriteLine($"Redacted Text: {redactedContent.GetProperty("text").GetString()}");
            Console.WriteLine($"Redacted Lexical: {redactedContent.GetProperty("lexical").GetString()}");
            Console.WriteLine($"Redacted MaskedItn: {redactedContent.GetProperty("maskedItn").GetString()}");

            Console.WriteLine("Entities:");
            foreach (JsonElement entity in conversationItem.GetProperty("entities").EnumerateArray())
            {
                Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                Console.WriteLine($"Confidence Score: {entity.GetProperty("confidenceScore").GetSingle()}");
                Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a utterance to a non-existant project, a `400` error is returned indicating "Bad Request".

```C# Snippet:ConversationAnalysisClient_BadRequest
try
{
    var data = new
    {
        analysisInput = new
        {
            conversationItem = new
            {
                text = "Send an email to Carol about tomorrow's demo",
                id = "1",
                participantId = "1",
            }
        },
        parameters = new
        {
            projectName = "invalid-project",
            deploymentName = "production",

            // Use Utf16CodeUnit for strings in .NET.
            stringIndexType = "Utf16CodeUnit",
        },
        kind = "Conversation",
    };

    Response response = client.AnalyzeConversation(RequestContent.Create(data));
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```text
Azure.RequestFailedException: The input parameter is invalid.
Status: 400 (Bad Request)
ErrorCode: InvalidArgument

Content:
{
  "error": {
    "code": "InvalidArgument",
    "message": "The input parameter is invalid.",
    "innerError": {
      "code": "InvalidArgument",
      "message": "The input parameter \"payload\" cannot be null or empty."
    }
  }
}

Headers:
Transfer-Encoding: chunked
pragma: no-cache
request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
apim-request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
x-envoy-upstream-service-time: 15
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
x-content-type-options: nosniff
Cache-Control: no-store, proxy-revalidate, no-cache, max-age=0, private
Content-Type: application/json
```

### Setting up console logging

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console use the `AzureEventSourceListener.CreateConsoleLogger` method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][core_logging].

## Next steps

- View our [samples][conversationanalysis_samples].
- Read about the different [features][conversationanalysis_docs_features] of the Conversations service.
- Try our service [demos][conversationanalysis_docs_demos].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure/
[azure_portal]: https://portal.azure.com/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[core_logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[nuget]: https://www.nuget.org/

[conversationanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/ConversationAnalysisClient.cs
[conversationanalysis_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/
[conversationanalysis_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/
[conversationanalysis_nuget_package]: https://www.nuget.org/packages/Azure.AI.Language.Conversations/1.0.0-beta.1
[conversationanalysis_docs]: https://docs.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/overview
[conversationanalysis_docs_demos]: https://docs.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/quickstart
[conversationanalysis_docs_features]: https://docs.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/overview
[conversationanalysis_refdocs]: https://review.docs.microsoft.com/dotnet/api/azure.ai.language.conversations
