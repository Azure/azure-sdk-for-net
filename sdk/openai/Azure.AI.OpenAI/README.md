# Azure OpenAI client library for .NET

The Azure OpenAI client library for .NET is a companion to the offical [OpenAI .NET client library](https://github.com/openai/openai-dotnet) that configures client for use with Azure OpenAI and provides additional, strongly-typed extension support for request and response models specific to Azure OpenAI scenarios.

Azure OpenAI is a managed service that allows developers to deploy, tune, and generate content from OpenAI models on Azure resources.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.OpenAI) | [API reference documentation](https://learn.microsoft.com/azure/cognitive-services/openai/reference) | [Product documentation](https://learn.microsoft.com/azure/cognitive-services/openai/) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/tests/Samples)

## Getting started

### Prerequisites

If you'd like to use an Azure OpenAI resource, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/)
and [Azure OpenAI access](https://learn.microsoft.com/azure/cognitive-services/openai/overview#how-do-i-get-access-to-azure-openai).
This will allow you to create an Azure OpenAI resource and get both a connection URL as well as API keys. For more
information, see [Quickstart: Get started generating text using Azure OpenAI Service](https://learn.microsoft.com/azure/cognitive-services/openai/quickstart).

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.OpenAI --prerelease
```

The `Azure.AI.OpenAI` package builds on the official `OpenAI` package and it will be automatically included as a dependency.

## Key concepts

### Assistants (beta)
[For more, see [OpenAI's Assistants API overview](https://platform.openai.com/docs/assistants/overview).]

### Audio transcription/translation and text-to-speech generation
[For more see [OpenAI Capabilities: Speech to
text](https://platform.openai.com/docs/guides/speech-to-text/speech-to-text)]

### Batch
[For more, see [OpenAI's Batch API guide](https://platform.openai.com/docs/guides/batch).]

### Chat completion
Chat models take a list of messages as input and return a model-generated message as output. Although the chat format is
designed to make multi-turn conversations easy, it’s just as useful for single-turn tasks without any conversation.

[For more, see  [OpenAI Capabilities: Chat completion](https://platform.openai.com/docs/guides/text-generation/chat-completions-api)]

### Image generation
[For more, see [OpenAI Capabilities: Image
generation](https://platform.openai.com/docs/guides/images/introduction?context=node)]

### Files
[For more, see [OpenAI's Files API reference](https://platform.openai.com/docs/api-reference/files).]

### Text embeddings
[For more see [OpenAI Capabilities: Embeddings](https://platform.openai.com/docs/guides/embeddings/embeddings)]

## Getting started

### Authenticate the client

In order to interact with Azure OpenAI or OpenAI, you'll need to create an instance of the [AzureOpenAIClient][azure_openai_client_class]
class.

```C# Snippet:ConfigureClient:WithAOAITopLevelClient
string keyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

AzureOpenAIClient azureClient = new(
    new Uri("https://your-azure-openai-resource.com"),
    new AzureKeyCredential(keyFromEnvironment));
ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");
```

#### Create OpenAIClient with a Microsoft Entra ID Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Microsoft Entra ID (formerly Azure Active Directory) using the [Azure Identity library][azure_identity]. To use the [DefaultAzureCredential][azure_identity_dac] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

```C# Snippet:ConfigureClient:WithEntra
AzureOpenAIClient azureClient = new(
    new Uri("https://your-azure-openai-resource.com"),
    new DefaultAzureCredential());
ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");
```

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples from OpenAI's .NET library](https://github.com/openai/openai-dotnet/tree/main/examples) or [Azure.AI.OpenAI-specific samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/openai/Azure.AI.OpenAI/tests/Samples). The vast majority of OpenAI capabilities are available on both Azure OpenAI and OpenAI using the same scenario clients and methods, so not all scenarios will be redundantly covered here.

### Get a chat completion

```C# Snippet:SimpleChatResponse
AzureOpenAIClient azureClient = new(
    new Uri("https://your-azure-openai-resource.com"),
    new DefaultAzureCredential());
ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

ChatCompletion completion = chatClient.CompleteChat(
    [
        // System messages represent instructions or other guidance about how the assistant should behave
        new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
        // User messages represent user input, whether historical or the most recen tinput
        new UserChatMessage("Hi, can you help me?"),
        // Assistant messages in a request represent conversation history for responses
        new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
        new UserChatMessage("What's the best way to train a parrot?"),
    ]);

Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
```

### Stream chat messages

Streaming chat completions use the `CompleteChatStreaming` and `CompleteChatStreamingAsync` method, which return a `ResultCollection<StreamingChatCompletionUpdate>` or `AsyncResultCollection<StreamingChatCompletionUpdate>` instead of a `ClientResult<ChatCompletion>`. These result collections can be iterated over using `foreach` or `await foreach`, with each update arriving as new data is available from the streamed response.

```C# Snippet:StreamChatMessages
AzureOpenAIClient azureClient = new(
    new Uri("https://your-azure-openai-resource.com"),
    new DefaultAzureCredential());
ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

ResultCollection<StreamingChatCompletionUpdate> completionUpdates = chatClient.CompleteChatStreaming(
    [
        new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
        new UserChatMessage("Hi, can you help me?"),
        new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
        new UserChatMessage("What's the best way to train a parrot?"),
    ]);

foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
{
    foreach (ChatMessageContentPart contentPart in completionUpdate.ContentUpdate)
    {
        Console.Write(contentPart.Text);
    }
}
```

### Use chat tools

**Tools** extend chat completions by allowing an assistant to invoke defined functions and other capabilities in the
process of fulfilling a chat completions request. To use chat tools, start by defining a function tool. Here, we root the tools in local methods for clarity and convenience:

```C# Snippet:ChatTools:DefineTool
static string GetCurrentLocation()
{
    // Call the location API here.
    return "San Francisco";
}

static string GetCurrentWeather(string location, string unit = "celsius")
{
    // Call the weather API here.
    return $"31 {unit}";
}

ChatTool getCurrentLocationTool = ChatTool.CreateFunctionTool(
    functionName: nameof(GetCurrentLocation),
    functionDescription: "Get the user's current location"
);

ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
    functionName: nameof(GetCurrentWeather),
    functionDescription: "Get the current weather in a given location",
    functionParameters: BinaryData.FromString("""
    {
        "type": "object",
        "properties": {
            "location": {
                "type": "string",
                "description": "The city and state, e.g. Boston, MA"
            },
            "unit": {
                "type": "string",
                "enum": [ "celsius", "fahrenheit" ],
                "description": "The temperature unit to use. Infer this from the specified location."
            }
        },
        "required": [ "location" ]
    }
    """)
);
```

With the tool defined, include that new definition in the options for a chat completions request:

```C# Snippet:ChatTools:RequestWithFunctions
ChatCompletionOptions options = new()
{
    Tools = { getCurrentLocationTool, getCurrentWeatherTool },
};

List<ChatMessage> conversationMessages =
    [
        new UserChatMessage("What's the weather like in Boston?"),
    ];
ChatCompletion completion = chatClient.CompleteChat(conversationMessages);
```

When the assistant decides that one or more tools should be used, the response message includes one or more "tool
calls" that must all be resolved via "tool messages" on the subsequent request. This resolution of tool calls into
new request messages can be thought of as a sort of "callback" for chat completions.

To provide tool call resolutions to the assistant to allow the request to continue, provide all prior historical
context -- including the original system and user messages, the response from the assistant that included the tool
calls, and the tool messages that resolved each of those tools -- when making a subsequent request.

```C# Snippet:ChatTools:HandleToolCalls
// Purely for convenience and clarity, this standalone local method handles tool call responses.
string GetToolCallContent(ChatToolCall toolCall)
{
    if (toolCall.FunctionName == getCurrentWeatherTool.FunctionName)
    {
        // Validate arguments before using them; it's not always guaranteed to be valid JSON!
        try
        {
            using JsonDocument argumentsDocument = JsonDocument.Parse(toolCall.FunctionArguments);
            if (!argumentsDocument.RootElement.TryGetProperty("location", out JsonElement locationElement))
            {
                // Handle missing required "location" argument
            }
            else
            {
                string location = locationElement.GetString();
                if (argumentsDocument.RootElement.TryGetProperty("unit", out JsonElement unitElement))
                {
                    return GetCurrentWeather(location, unitElement.GetString());
                }
                else
                {
                    return GetCurrentWeather(location);
                }
            }
        }
        catch (JsonException)
        {
            // Handle the JsonException (bad arguments) here
        }
    }
    // Handle unexpected tool calls
    throw new NotImplementedException();
}

if (completion.FinishReason == ChatFinishReason.ToolCalls)
{
    // Add a new assistant message to the conversation history that includes the tool calls
    conversationMessages.Add(new AssistantChatMessage(completion));

    foreach (ChatToolCall toolCall in completion.ToolCalls)
    {
        conversationMessages.Add(new ToolChatMessage(toolCall.Id, GetToolCallContent(toolCall)));
    }

    // Now make a new request with all the messages thus far, including the original
}
```

When using tool calls with streaming responses, accumulate tool call details much like you'd accumulate the other
portions of streamed choices, in this case using the accumulated `StreamingToolCallUpdate` data to instantiate new
tool call messages for assistant message history. Note that the model will ignore `ChoiceCount` when providing tools
and that all streamed responses should map to a single, common choice index in the range of `[0..(ChoiceCount - 1)]`.

```C# Snippet:ChatTools:StreamingChatTools
Dictionary<int, string> toolCallIdsByIndex = [];
Dictionary<int, string> functionNamesByIndex = [];
Dictionary<int, StringBuilder> functionArgumentBuildersByIndex = [];
StringBuilder contentBuilder = new();

foreach (StreamingChatCompletionUpdate streamingChatUpdate
    in chatClient.CompleteChatStreaming(conversationMessages, options))
{
    foreach (ChatMessageContentPart contentPart in streamingChatUpdate.ContentUpdate)
    {
        contentBuilder.Append(contentPart.Text);
    }
    foreach (StreamingChatToolCallUpdate toolCallUpdate in streamingChatUpdate.ToolCallUpdates)
    {
        if (!string.IsNullOrEmpty(toolCallUpdate.Id))
        {
            toolCallIdsByIndex[toolCallUpdate.Index] = toolCallUpdate.Id;
        }
        if (!string.IsNullOrEmpty(toolCallUpdate.FunctionName))
        {
            functionNamesByIndex[toolCallUpdate.Index] = toolCallUpdate.FunctionName;
        }
        if (!string.IsNullOrEmpty(toolCallUpdate.FunctionArgumentsUpdate))
        {
            StringBuilder argumentsBuilder
                = functionArgumentBuildersByIndex.TryGetValue(toolCallUpdate.Index, out StringBuilder existingBuilder)
                    ? existingBuilder
                    : new();
            argumentsBuilder.Append(toolCallUpdate.FunctionArgumentsUpdate);
            functionArgumentBuildersByIndex[toolCallUpdate.Index] = argumentsBuilder;
        }
    }
}

List<ChatToolCall> toolCalls = [];
foreach (KeyValuePair<int, string> indexToIdPair in toolCallIdsByIndex)
{
    toolCalls.Add(ChatToolCall.CreateFunctionToolCall(
        indexToIdPair.Value,
        functionNamesByIndex[indexToIdPair.Key],
        functionArgumentBuildersByIndex[indexToIdPair.Key].ToString()));
}

conversationMessages.Add(new AssistantChatMessage(toolCalls, contentBuilder.ToString()));

// Placeholder: each tool call must be resolved, like in the non-streaming case
string GetToolCallOutput(ChatToolCall toolCall) => null;

foreach (ChatToolCall toolCall in toolCalls)
{
    conversationMessages.Add(new ToolChatMessage(toolCall.Id, GetToolCallOutput(toolCall)));
}

// Repeat with the history and all tool call resolution messages added
```

### Use your own data with Azure OpenAI

The use your own data feature is unique to Azure OpenAI and won't work with a client configured to use the non-Azure service.
See [the Azure OpenAI using your own data quickstart](https://learn.microsoft.com/azure/ai-services/openai/use-your-data-quickstart) for conceptual background and detailed setup instructions.

**NOTE:** The concurrent use of [Chat Functions](#use-chat-functions) and Azure Chat Extensions on a single request is not yet supported. Supplying both will result in the Chat Functions information being ignored and the operation behaving as if only the Azure Chat Extensions were provided. To address this limitation, consider separating the evaluation of Chat Functions and Azure Chat Extensions across multiple requests in your solution design.

```C# Snippet:ChatUsingYourOwnData
// Extension methods to use data sources with options are subject to SDK surface changes. Suppress the
// warning to acknowledge and this and use the subject-to-change AddDataSource method.
#pragma warning disable AOAI001

ChatCompletionOptions options = new();
options.AddDataSource(new AzureSearchChatDataSource()
{
    Endpoint = new Uri("https://your-search-resource.search.windows.net"),
    IndexName = "contoso-products-index",
    Authentication = DataSourceAuthentication.FromApiKey(
        Environment.GetEnvironmentVariable("OYD_SEARCH_KEY")),
});

ChatCompletion completion = chatClient.CompleteChat(
    [
        new UserChatMessage("What are the best-selling Contoso products this month?"),
    ]);

AzureChatMessageContext onYourDataContext = completion.GetAzureMessageContext();

if (onYourDataContext?.Intent is not null)
{
    Console.WriteLine($"Intent: {onYourDataContext.Intent}");
}
foreach (AzureChatCitation citation in onYourDataContext?.Citations ?? [])
{
    Console.WriteLine($"Citation: {citation.Content}");
}
```

### Use Assistants and stream a run

[Assistants](https://platform.openai.com/docs/assistants/overview) provide a stateful, service-persisted conversational
model that can be enriched with a larger array of tools than Chat Completions.

Creating an `AssistantClient` is similar to other scenario clients. An important difference is that Assistants features
are marked as `[Experimental]` to reflect the API's beta status, and thus you'll need to suppress the corresponding
warning to instantiate a client. This can be done in the `.csproj` file via the `<NoWarn>` element or, as below, in
the code itself with a `#pragma` directive.

```C# Snippet:Assistants:CreateClient
AzureOpenAIClient azureClient = new(
    new Uri("https://your-azure-openai-resource.com"),
    new DefaultAzureCredential());

// The Assistants feature area is in beta, with API specifics subject to change.
// Suppress the [Experimental] warning via .csproj or, as here, in the code to acknowledge.
#pragma warning disable OPENAI001
AssistantClient assistantClient = azureClient.GetAssistantClient();
```

With a client, you can then create Assistants, Threads, and new Messages on a thread in preparation to start a run.
Note that, as is the case for other shared API surfaces, you should use an Azure OpenAI model deployment name wherever
a model name is requested.

```C# Snippet:Assistants:PrepareToRun
Assistant assistant = await assistantClient.CreateAssistantAsync(
    model: "my-gpt-4o-deployment",
    new AssistantCreationOptions()
    {
        Name = "My Friendly Test Assistant",
        Instructions = "You politely help with math questions. Use the code interpreter tool when asked to "
            + "visualize numbers.",
        Tools = { ToolDefinition.CreateCodeInterpreter() },
    });
ThreadInitializationMessage initialMessage = new(
    [
        "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9."
    ]);
AssistantThread thread = await assistantClient.CreateThreadAsync(new ThreadCreationOptions()
{
    InitialMessages = { initialMessage },
});
```

You can then start a run and stream updates as they arrive using the `Streaming` method variants, handling the updates
you're interested in using the enumerated kind of event it is and/or one of the several derived types for the streaming
update class, as shown here for content:

```C# Snippet:Assistants:StreamRun
RunCreationOptions runOptions = new()
{
    AdditionalInstructions = "When possible, talk like a pirate."
};
await foreach (StreamingUpdate streamingUpdate
    in assistantClient.CreateRunStreamingAsync(thread, assistant, runOptions))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine($"--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        Console.Write(contentUpdate.Text);
        if (contentUpdate.ImageFileId is not null)
        {
            Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
        }
    }
}
```

Remember that things like Assistants, Threads, and Vector Stores are persistent resources: you can save their IDs to
reuse them later or, as below, delete them when no longer desired.

```C# Snippet:Assistants:Cleanup
// Optionally, delete persistent resources that are no longer needed.
_ = await assistantClient.DeleteAssistantAsync(assistant);
_ = await assistantClient.DeleteThreadAsync(thread);
```

## Next steps

## Troubleshooting

When you interact with Azure OpenAI using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][openai_rest] requests.

For example, if you try to create a client using an endpoint that doesn't match your Azure OpenAI Resource endpoint, a `404` error is returned, indicating `Resource Not Found`.

## Contributing

See the [OpenAI CONTRIBUTING.md][openai_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[msdocs_openai_chat_quickstart]: https://learn.microsoft.com/azure/ai-services/openai/chatgpt-quickstart?pivots=programming-language-csharp
[msdocs_openai_dalle_quickstart]: https://learn.microsoft.com/azure/ai-services/openai/dall-e-quickstart?pivots=programming-language-csharp
[msdocs_openai_whisper_quickstart]: https://learn.microsoft.com/azure/ai-services/openai/whisper-quickstart
[msdocs_openai_tts_quickstart]: https://learn.microsoft.com/azure/ai-services/openai/text-to-speech-quickstart
[msdocs_openai_completion]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[msdocs_openai_embedding]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[azure_openai_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src/Custom/AzureOpenAIClient.cs
[openai_rest]: https://learn.microsoft.com/azure/cognitive-services/openai/reference
[azure_openai_completions_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[azure_openai_embeddgings_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[openai_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/openai/Azure.AI.OpenAI/README.png)
