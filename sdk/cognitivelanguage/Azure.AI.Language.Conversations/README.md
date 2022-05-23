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

* An [Azure subscription][azure_subscription]
* An existing Azure Language Service Resource

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

To analyze a conversation, you can call the `client.AnalyzeConversation()` method which takes a `TextConversationItem` and `ConversationsProject` as parameters.

```C# Snippet:ConversationAnalysis_AnalyzeConversation
ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
    "Send an email to Carol about the tomorrow's demo.",
    conversationsProject);

CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
ConversationPrediction conversationPrediction = customConversationalTaskResult.Result.Prediction as ConversationPrediction;

Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

Console.WriteLine("Intents:");
foreach (ConversationIntent intent in conversationPrediction.Intents)
{
    Console.WriteLine($"Category: {intent.Category}");
    Console.WriteLine($"Confidence: {intent.Confidence}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (ConversationEntity entity in conversationPrediction.Entities)
{
    Console.WriteLine($"Category: {entity.Category}");
    Console.WriteLine($"Text: {entity.Text}");
    Console.WriteLine($"Offset: {entity.Offset}");
    Console.WriteLine($"Length: {entity.Length}");
    Console.WriteLine($"Confidence: {entity.Confidence}");
    Console.WriteLine();

    foreach (BaseResolution resolution in entity.Resolutions)
    {
        if (resolution is DateTimeResolution dateTimeResolution)
        {
            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
            Console.WriteLine($"Value: {dateTimeResolution.Value}");
            Console.WriteLine();
        }
    }
}
```

The specified parameters can also be used to initialize a `AnalyzeConversationOptions` instance. You can then call `AnalyzeConversation()` using the options object as a parameter as shown below.

You can also set the verbose parameter in the `AnalyzeConversation()` method.

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptions
TextConversationItem input = new TextConversationItem(
    participantId: "1",
    id: "1",
    text: "Send an email to Carol about the tomorrow's demo.");
AnalyzeConversationOptions options = new AnalyzeConversationOptions(input)
{
    Verbose = true
};

ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
    "Send an email to Carol about the tomorrow's demo.",
    conversationsProject,
    options);

CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
ConversationPrediction conversationPrediction = customConversationalTaskResult.Result.Prediction as ConversationPrediction;

Console.WriteLine($"Project Kind: {customConversationalTaskResult.Result.Prediction.ProjectKind}");
Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

Console.WriteLine("Intents:");
foreach (ConversationIntent intent in conversationPrediction.Intents)
{
    Console.WriteLine($"Category: {intent.Category}");
    Console.WriteLine($"Confidence: {intent.Confidence}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (ConversationEntity entity in conversationPrediction.Entities)
{
    Console.WriteLine($"Category: {entity.Category}");
    Console.WriteLine($"Text: {entity.Text}");
    Console.WriteLine($"Offset: {entity.Offset}");
    Console.WriteLine($"Length: {entity.Length}");
    Console.WriteLine($"Confidence: {entity.Confidence}");
    Console.WriteLine();

    foreach (BaseResolution resolution in entity.Resolutions)
    {
        if (resolution is DateTimeResolution dateTimeResolution)
        {
            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
            Console.WriteLine($"Value: {dateTimeResolution.Value}");
            Console.WriteLine();
        }
    }
}
```

### Analyze a conversation in a different language

The language property in the `TextConversationItem` can be used to specify the language of the conversation.

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage
TextConversationItem input = new TextConversationItem(
    participantId: "1",
    id: "1",
    text: "Tendremos 2 platos de nigiri de salmón braseado.")
{
    Language = "es"
};
AnalyzeConversationOptions options = new AnalyzeConversationOptions(input);

ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");

Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
    textConversationItem,
    conversationsProject,
    options);

CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
ConversationPrediction conversationPrediction = customConversationalTaskResult.Result.Prediction as ConversationPrediction;

Console.WriteLine($"Project Kind: {customConversationalTaskResult.Result.Prediction.ProjectKind}");
Console.WriteLine($"Top intent: {conversationPrediction.TopIntent}");

Console.WriteLine("Intents:");
foreach (ConversationIntent intent in conversationPrediction.Intents)
{
    Console.WriteLine($"Category: {intent.Category}");
    Console.WriteLine($"Confidence: {intent.Confidence}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (ConversationEntity entity in conversationPrediction.Entities)
{
    Console.WriteLine($"Category: {entity.Category}");
    Console.WriteLine($"Text: {entity.Text}");
    Console.WriteLine($"Offset: {entity.Offset}");
    Console.WriteLine($"Length: {entity.Length}");
    Console.WriteLine($"Confidence: {entity.Confidence}");
    Console.WriteLine();

    foreach (BaseResolution resolution in entity.Resolutions)
    {
        if (resolution is DateTimeResolution dateTimeResolution)
        {
            Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
            Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
            Console.WriteLine($"Value: {dateTimeResolution.Value}");
            Console.WriteLine();
        }
    }
}
```

Other optional properties can be set such as verbosity and whether service logging is enabled.

### Analyze a conversation - Orchestration Project
To analyze a conversation using an orchestration project, you can then call the `client.AnalyzeConversation()` just like the conversation project. But you have to cast the prediction to `OrchestratorPrediction`. Also, you have to cast the intent type into the one you need.

### Orchestration Project - Conversation Prediction
```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionConversation
string respondingProjectName = orchestratorPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == TargetProjectKind.Conversation)
{
    ConversationTargetIntentResult cluTargetIntentResult = targetIntentResult as ConversationTargetIntentResult;

    ConversationResult conversationResult = cluTargetIntentResult.Result;
    ConversationPrediction conversationPrediction = conversationResult.Prediction;

    Console.WriteLine($"Top Intent: {conversationResult.Prediction.TopIntent}");
    Console.WriteLine($"Intents:");
    foreach (ConversationIntent intent in conversationPrediction.Intents)
    {
        Console.WriteLine($"Intent Category: {intent.Category}");
        Console.WriteLine($"Confidence: {intent.Confidence}");
        Console.WriteLine();
    }

    Console.WriteLine($"Entities:");
    foreach (ConversationEntity entity in conversationPrediction.Entities)
    {
        Console.WriteLine($"Entity Text: {entity.Text}");
        Console.WriteLine($"Entity Category: {entity.Category}");
        Console.WriteLine($"Confidence: {entity.Confidence}");
        Console.WriteLine($"Starting Position: {entity.Offset}");
        Console.WriteLine($"Length: {entity.Length}");
        Console.WriteLine();

        foreach (BaseResolution resolution in entity.Resolutions)
        {
            if (resolution is DateTimeResolution dateTimeResolution)
            {
                Console.WriteLine($"Datetime Sub Kind: {dateTimeResolution.DateTimeSubKind}");
                Console.WriteLine($"Timex: {dateTimeResolution.Timex}");
                Console.WriteLine($"Value: {dateTimeResolution.Value}");
                Console.WriteLine();
            }
        }
    }
}
```

### Orchestration Project - QuestionAnswering Prediction
```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestratorPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == TargetProjectKind.QuestionAnswering)
{
    Console.WriteLine($"Top intent: {respondingProjectName}");

    QuestionAnsweringTargetIntentResult qnaTargetIntentResult = targetIntentResult as QuestionAnsweringTargetIntentResult;

    BinaryData questionAnsweringResponse = qnaTargetIntentResult.Result;
    Console.WriteLine($"Qustion Answering Response: {questionAnsweringResponse.ToString()}");
}
```

### Orchestration Project - Luis Prediction
```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionLuis
string respondingProjectName = orchestratorPrediction.TopIntent;
TargetIntentResult targetIntentResult = orchestratorPrediction.Intents[respondingProjectName];

if (targetIntentResult.TargetProjectKind == TargetProjectKind.Luis)
{
    LuisTargetIntentResult luisTargetIntentResult = targetIntentResult as LuisTargetIntentResult;
    BinaryData luisResponse = luisTargetIntentResult.Result;

    Console.WriteLine($"LUIS Response: {luisResponse.ToString()}");
}
```

### Analyze a conversation - Conversation Summarization

First, you should prepare the input:

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

Then you can start analyzing by calling the `StartAnalyzeConversation`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

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

### Analyze a conversation - Conversation PII - Text Input

First, you should prepare the input:

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

Then you can start analyzing by calling the `StartAnalyzeConversation`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

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

### Analyze a conversation - Conversation PII - Transcript Input

First, you should prepare the input:

```C# Snippet:StartAnalyzeConversation_ConversationPII_Transcript_Input
var transciprtConversationItemOne = new TranscriptConversationItem(
   id: "1",
   participantId: "speaker",
   itn: "hi",
   maskedItn: "hi",
   text: "Hi",
   lexical: "hi");
transciprtConversationItemOne.AudioTimings.Add(new WordLevelTiming(4500000, 2800000, "hi"));

var transciprtConversationItemTwo = new TranscriptConversationItem(
   id: "2",
   participantId: "speaker",
   itn: "jane doe",
   maskedItn: "jane doe",
   text: "Jane doe",
   lexical: "jane doe");
transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(7100000, 4800000, "jane"));
transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(12000000, 1700000, "jane"));

var transciprtConversationItemThree = new TranscriptConversationItem(
    id: "3",
    participantId: "agent",
    itn: "hi jane what's your phone number",
    maskedItn: "hi jane what's your phone number",
    text: "Hi Jane, what's your phone number?",
    lexical: "hi jane what's your phone number");
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(7700000, 3100000, "hi"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(10900000, 5700000, "jane"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(17300000, 2600000, "what's"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(20000000, 1600000, "your"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(21700000, 1700000, "phone"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(23500000, 2300000, "number"));

var transcriptConversationItems = new List<TranscriptConversationItem>()
{
    transciprtConversationItemOne,
    transciprtConversationItemTwo,
    transciprtConversationItemThree,
};

var input = new List<TranscriptConversation>()
{
    new TranscriptConversation("1", "en", transcriptConversationItems)
};

var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, TranscriptContentType.Lexical);

var tasks = new List<AnalyzeConversationLROTask>()
{
    new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
};
```

Then you can start analyzing by calling the `StartAnalyzeConversation`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

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

```C# Snippet:StartAnalyzeConversation_ConversationPII_Transcript_Results
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
            Console.WriteLine($"Redacted Lexical: {conversationItem.RedactedContent.Lexical}");
            Console.WriteLine($"Redacted AudioTimings: {conversationItem.RedactedContent.AudioTimings}");
            Console.WriteLine($"Redacted MaskedItn: {conversationItem.RedactedContent.MaskedItn}");

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

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a utterance to a non-existant project, a `400` error is returned indicating "Bad Request".

```C# Snippet:ConversationAnalysisClient_BadRequest
try
{
    ConversationsProject conversationsProject = new ConversationsProject("invalid-project", "production");
    Response<AnalyzeConversationTaskResult> response = client.AnalyzeConversation(
        "Send an email to Carol about the tomorrow's demo",
        conversationsProject);
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

* View our [samples][conversationanalysis_samples].
* Read about the different [features][conversationanalysis_docs_features] of the Conversations service.
* Try our service [demos][conversationanalysis_docs_demos].

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
