# Azure.AI.Client client library for .NET

The Azure AI Assistants client library for .NET is an adaptation of OpenAI's REST APIs that provides an idiomatic interface
and rich integration with the rest of the Azure SDK ecosystem. It will connect to Azure AI resources endpoint.

Use this library to:

- Create and manage assistants, threads, messages, and runs
- Configure and use tools with assistants
- Upload and manage files for use with assistants

## Getting started

### Prerequisites

To use Assistants capabilities, you'll need to use an Azure AI resource, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure AI access](https://learn.microsoft.com/azure/cognitive-services/openai/overview#how-do-i-get-access-to-azure-openai). This will allow you to create an Azure AI resource and get both a connection URL as well as API keys. For more information, see [Quickstart: Get started generating text using Azure AI Service](https://learn.microsoft.com/azure/cognitive-services/openai/quickstart).

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Assistants --prerelease
```

### Authenticate the client

See [AzureAI's "how assistants work"](https://platform.openai.com/docs/assistants/how-it-works) documentation for an
overview of the concepts and relationships used with assistants. This overview closely follows
[AzureAI's overview example](https://platform.openai.com/docs/assistants/overview) to demonstrate the basics of
creating, running, and using assistants and threads.

To get started, create an `AssistantsClient`:
```C# Snippet:OverviewCreateClient
AssistantsClient client = isAzureOpenAI
    ? new AssistantsClient(new Uri(azureResourceUrl), new AzureKeyCredential(azureApiKey))
    : new AssistantsClient(nonAzureApiKey);
```

> **NOTE**: The Assistants API should always be used from a trusted device. Because the same authentication mechanism for running threads also allows changing persistent resources like Assistant instructions, a malicious user could extract an API key and modify Assistant behavior for other customers.

## Key concepts

### Overview

For an overview of Assistants and the pertinent key concepts like Threads, Messages, Runs, and Tools, please see
[AzureAI's Assistants API overview](https://platform.openai.com/docs/assistants/overview).

## Usage

### Examples

With an authenticated client, an assistant can be created:
```C# Snippet:OverviewCreateAssistant
Response<Assistant> assistantResponse = await client.CreateAssistantAsync(
    new AssistantCreationOptions("gpt-4-1106-preview")
    {
        Name = "Math Tutor",
        Instructions = "You are a personal math tutor. Write and run code to answer math questions.",
        Tools = { new CodeInterpreterToolDefinition() }
    });
Assistant assistant = assistantResponse.Value;
```

Next, create a thread:
```C# Snippet:OverviewCreateThread
Response<AssistantThread> threadResponse = await client.CreateThreadAsync();
AssistantThread thread = threadResponse.Value;
```

With a thread created, messages can be created on it:
```C# Snippet:OverviewCreateMessage
Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
ThreadMessage message = messageResponse.Value;
```

A run can then be started that evaluates the thread against an assistant:
```C# Snippet:OverviewCreateRun
Response<ThreadRun> runResponse = await client.CreateRunAsync(
    thread.Id,
    new CreateRunOptions(assistant.Id)
    {
        AdditionalInstructions = "Please address the user as Jane Doe. The user has a premium account.",
    });
ThreadRun run = runResponse.Value;
```

Once the run has started, it should then be polled until it reaches a terminal status:
```C# Snippet:OverviewWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress);
```

Assuming the run successfully completed, listing messages from the thread that was run will now reflect new information
added by the assistant:
```C# Snippet:OverviewListUpdatedMessages
Response<PageableList<ThreadMessage>> afterRunMessagesResponse
    = await client.GetMessagesAsync(thread.Id);
IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

// Note: messages iterate from newest to oldest, with the messages[0] being the most recent
foreach (ThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            Console.Write(textItem.Text);
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

Example output from this sequence:
```
2023-11-14 20:21:23 -  assistant: The solution to the equation \(3x + 11 = 14\) is \(x = 1\).
2023-11-14 20:21:18 -       user: I need to solve the equation `3x + 11 = 14`. Can you help me?
```

### Working with files for retrieval

Files can be uploaded and then referenced by assistants or messages. First, use the generalized upload API with a
purpose of 'assistants' to make a file ID available:
```C# Snippet:UploadAssistantFilesToUse
File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
Response<OpenAIFile> uploadAssistantFileResponse = await client.UploadFileAsync(
    localFilePath: "sample_file_for_upload.txt",
    purpose: OpenAIFilePurpose.Assistants);
OpenAIFile uploadedAssistantFile = uploadAssistantFileResponse.Value;
```

Once uploaded, the file ID can then be provided to an assistant upon creation. Note that file IDs will only be used
if an appropriate tool like Code Interpreter or Retrieval is enabled.
```C# Snippet:CreateAssistantWithFiles
Response<Assistant> assistantResponse = await client.CreateAssistantAsync(
    new AssistantCreationOptions("gpt-4-1106-preview")
    {
        Name = "SDK Test Assistant - Retrieval",
        Instructions = "You are a helpful assistant that can help fetch data from files you know about.",
        Tools = { new RetrievalToolDefinition() },
        FileIds = { uploadedAssistantFile.Id },
    });
Assistant assistant = assistantResponse.Value;
```

With a file ID association and a supported tool enabled, the assistant will then be able to consume the associated
data when running threads.


### Using function tools and parallel function calling

As [described in OpenAI's documentation for assistant tools](https://platform.openai.com/docs/assistants/tools/function-calling),
tools that reference caller-defined capabilities as functions can be provided to an assistant to allow it to
dynamically resolve and disambiguate during a run.

Here, outlined is a simple assistant that "knows how to," via caller-provided functions:

1. Get the user's favorite city
1. Get a nickname for a given city
1. Get the current weather, optionally with a temperature unit, in a city

To do this, begin by defining the functions to use -- the actual implementations here are merely representative stubs.

```C# Snippet:FunctionsDefineFunctionTools
// Example of a function that defines no parameters
string GetUserFavoriteCity() => "Seattle, WA";
FunctionToolDefinition getUserFavoriteCityTool = new("getUserFavoriteCity", "Gets the user's favorite city.");
// Example of a function with a single required parameter
string GetCityNickname(string location) => location switch
{
    "Seattle, WA" => "The Emerald City",
    _ => throw new NotImplementedException(),
};
FunctionToolDefinition getCityNicknameTool = new(
    name: "getCityNickname",
    description: "Gets the nickname of a city, e.g. 'LA' for 'Los Angeles, CA'.",
    parameters: BinaryData.FromObjectAsJson(
        new
        {
            Type = "object",
            Properties = new
            {
                Location = new
                {
                    Type = "string",
                    Description = "The city and state, e.g. San Francisco, CA",
                },
            },
            Required = new[] { "location" },
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
// Example of a function with one required and one optional, enum parameter
string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
{
    "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
    _ => throw new NotImplementedException()
};
FunctionToolDefinition getCurrentWeatherAtLocationTool = new(
    name: "getCurrentWeatherAtLocation",
    description: "Gets the current weather at a provided location.",
    parameters: BinaryData.FromObjectAsJson(
        new
        {
            Type = "object",
            Properties = new
            {
                Location = new
                {
                    Type = "string",
                    Description = "The city and state, e.g. San Francisco, CA",
                },
                Unit = new
                {
                    Type = "string",
                    Enum = new[] { "c", "f" },
                },
            },
            Required = new[] { "location" },
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
```

With the functions defined in their appropriate tools, an assistant can be now created that has those tools enabled:

```C# Snippet:FunctionsCreateAssistantWithFunctionTools
Response<Assistant> assistantResponse = await client.CreateAssistantAsync(
    // note: parallel function calling is only supported with newer models like gpt-4-1106-preview
    new AssistantCreationOptions("gpt-4-1106-preview")
    {
        Name = "SDK Test Assistant - Functions",
        Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
        Tools =
        {
            getUserFavoriteCityTool,
            getCityNicknameTool,
            getCurrentWeatherAtLocationTool,
        },
    });
Assistant assistant = assistantResponse.Value;
```

If the assistant calls tools, the calling code will need to resolve `ToolCall` instances into matching
`ToolOutput` instances. For convenience, a basic example is extracted here:

```C# Snippet:FunctionsHandleFunctionCalls
ToolOutput GetResolvedToolOutput(RequiredToolCall toolCall)
{
    if (toolCall is RequiredFunctionToolCall functionToolCall)
    {
        if (functionToolCall.Name == getUserFavoriteCityTool.Name)
        {
            return new ToolOutput(toolCall, GetUserFavoriteCity());
        }
        using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
        if (functionToolCall.Name == getCityNicknameTool.Name)
        {
            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
            return new ToolOutput(toolCall, GetCityNickname(locationArgument));
        }
        if (functionToolCall.Name == getCurrentWeatherAtLocationTool.Name)
        {
            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
            if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
            {
                string unitArgument = unitElement.GetString();
                return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument, unitArgument));
            }
            return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument));
        }
    }
    return null;
}
```

To handle user input like "what's the weather like right now in my favorite city?", polling the response for completion
should be supplemented by a `RunStatus` check for `RequiresAction` or, in this case, the presence of the
`RequiredAction` property on the run. Then, the collection of `ToolOutputSubmissions` should be submitted to the
run via the `SubmitRunToolOutputs` method so that the run can continue:

```C# Snippet:FunctionsHandlePollingWithRequiredAction
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);

    if (runResponse.Value.Status == RunStatus.RequiresAction
        && runResponse.Value.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
    {
        List<ToolOutput> toolOutputs = new();
        foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
        {
            toolOutputs.Add(GetResolvedToolOutput(toolCall));
        }
        runResponse = await client.SubmitToolOutputsToRunAsync(runResponse.Value, toolOutputs);
    }
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress);
```

Note that, when using supported models, the assistant may request that several functions be called in parallel. Older
models may only call one function at a time.

Once all needed function calls have been resolved, the run will proceed normally and the completed messages on the
thread will contain model output supplemented by the provided function tool outputs.

## Troubleshooting

When you interact with Azure OpenAI using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][openai_rest] requests.

For example, if you try to create a client using an endpoint that doesn't match your Azure OpenAI Resource endpoint, a `404` error is returned, indicating `Resource Not Found`.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

See the [Azure SDK CONTRIBUTING.md][openai_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[msdocs_openai_completion]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[msdocs_openai_embedding]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[openai_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src/Generated/OpenAIClient.cs
[openai_rest]: https://learn.microsoft.com/azure/cognitive-services/openai/reference
[azure_openai_completions_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[azure_openai_embeddings_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[openai_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/openai/Azure.AI.OpenAI/README.png)


Azure.AI.Client is a managed service that helps developers get secret simply and securely.

Use the client library for to:

* [Get secret](https://docs.microsoft.com/azure)

[Source code][source_root] | [Package (NuGet)][package] | [API reference documentation][reference_docs] | [Product documentation][azconfig_docs] | [Samples][source_samples]

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Client/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `dotnet add package package-name`, but should enable a developer to successfully install the package from NuGet, npm, or even cloning a GitHub repository.

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Client --prerelease
```

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

### Authenticate the client

If your library requires authentication for use, such as for Azure services, include instructions and example code needed for initializing and authenticating.

For example, include details on obtaining an account key and endpoint URI, setting environment variables for each, and initializing the client object.

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:Create<YourService>ClientForSpecificApiVersion
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
<YourService>ClientOptions options = new <YourService>ClientOptions(<YourService>ClientOptions.ServiceVersion.<API Version>)
var client = new <YourService>Client(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

## Key concepts

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

Include the *Thread safety* and *Additional concepts* sections below at the end of your *Key concepts* section. You may remove or add links depending on what your library makes use of:

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Client/samples).

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Client/README.png)
