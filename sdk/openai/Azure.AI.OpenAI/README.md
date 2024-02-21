# Azure OpenAI client library for .NET

The Azure OpenAI client library for .NET is an adaptation of OpenAI's REST APIs that provides an idiomatic interface
and rich integration with the rest of the Azure SDK ecosystem. It can connect to Azure OpenAI resources *or* to the
non-Azure OpenAI inference endpoint, making it a great choice for even non-Azure OpenAI development.

Use the client library for Azure OpenAI to:

* [Create chat completions using models like gpt-4 and gpt-35-turbo][msdocs_openai_chat_quickstart]
* [Generate images with dall-e-3][msdocs_openai_dalle_quickstart]
* [Transcribe or translate audio into text with whisper][msdocs_openai_whisper_quickstart]
* [Create a text embedding for comparisons][msdocs_openai_embedding]
* [Create a legacy completion for text using models like text-davinci-002][msdocs_openai_completion]

Azure OpenAI is a managed service that allows developers to deploy, tune, and generate content from OpenAI models on Azure resources.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.OpenAI) | [API reference documentation](https://learn.microsoft.com/azure/cognitive-services/openai/reference) | [Product documentation](https://learn.microsoft.com/azure/cognitive-services/openai/) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/tests/Samples)

## Getting started

### Prerequisites

If you'd like to use an Azure OpenAI resource, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/)
and [Azure OpenAI access](https://learn.microsoft.com/azure/cognitive-services/openai/overview#how-do-i-get-access-to-azure-openai).
This will allow you to create an Azure OpenAI resource and get both a connection URL as well as API keys. For more
information, see [Quickstart: Get started generating text using Azure OpenAI Service](https://learn.microsoft.com/azure/cognitive-services/openai/quickstart).

If you'd like to use the Azure OpenAI .NET client library to connect to non-Azure OpenAI, you'll need an API key
from a developer account at https://platform.openai.com/.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.OpenAI --prerelease
```

## Key concepts

### Chat completion
[From [OpenAI Capabilities: Chat completion](https://platform.openai.com/docs/guides/text-generation/chat-completions-api)]

Chat models take a list of messages as input and return a model-generated message as output. Although the chat format is
designed to make multi-turn conversations easy, it’s just as useful for single-turn tasks without any conversation.

### Image generation
[For more see [OpenAI Capabilities: Image
generation](https://platform.openai.com/docs/guides/images/introduction?context=node)]

### Audio transcription and translation
[For more see [OpenAI Capabilities: Speech to
text](https://platform.openai.com/docs/guides/speech-to-text/speech-to-text)]

### Text embeddings
[For more see [OpenAI Capabilities: Embeddings](https://platform.openai.com/docs/guides/embeddings/embeddings)]

### Vision (preview)
[For more see [OpenAI Capabilities: Vision](https://platform.openai.com/docs/guides/vision)]

## Getting started

### Authenticate the client

In order to interact with Azure OpenAI or OpenAI, you'll need to create an instance of the [OpenAIClient][openai_client_class]
class. To configure a client for use with Azure OpenAI, provide a valid endpoint URI to an Azure OpenAI resource
along with a corresponding key credential, token credential, or Azure identity credential that's authorized to use the
Azure OpenAI resource. To instead configure the client to connect to OpenAI's service, provide an API key from OpenAI's
developer portal.

```C# Snippet:MakeClientWithAzureOrNonAzureOpenAI
OpenAIClient client = useAzureOpenAI
    ? new OpenAIClient(
        new Uri("https://your-azure-openai-resource.com/"),
        new AzureKeyCredential("your-azure-openai-resource-api-key"))
    : new OpenAIClient("your-api-key-from-platform.openai.com");
```

#### Create OpenAIClient with a Microsoft Entra ID Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Microsoft Entra ID (formerly Azure Active Directory) using the [Azure Identity library][azure_identity]. To use the [DefaultAzureCredential][azure_identity_dac] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

```C# Snippet:CreateOpenAIClientTokenCredential
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/openai/Azure.AI.OpenAI/tests/Samples).

### Get a chat completion

```C# Snippet:SimpleChatResponse
Uri azureOpenAIResourceUri = new("https://my-resource.openai.azure.com/");
AzureKeyCredential azureOpenAIApiKey = new(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY"));
OpenAIClient client = new(azureOpenAIResourceUri, azureOpenAIApiKey);

var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
    Messages =
    {
        // The system message represents instructions or other guidance about how the assistant should behave
        new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate."),
        // User messages represent current or historical input from the end user
        new ChatRequestUserMessage("Can you help me?"),
        // Assistant messages represent historical responses from the assistant
        new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
        new ChatRequestUserMessage("What's the best way to train a parrot?"),
    }
};

Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
Console.WriteLine($"[{responseMessage.Role.ToString().ToUpperInvariant()}]: {responseMessage.Content}");
```

### Legacy completions

Although using chat completions is recommended, the library also supports using so-called "legacy" completions for older models.

```C# Snippet:UseAzureOrNonAzureOpenAIForCompletions
OpenAIClient client = useAzureOpenAI
    ? new OpenAIClient(
        new Uri("https://your-azure-openai-resource.com/"),
        new AzureKeyCredential("your-azure-openai-resource-api-key"))
    : new OpenAIClient("your-api-key-from-platform.openai.com");

Response<Completions> response = await client.GetCompletionsAsync(new CompletionsOptions()
{
    DeploymentName = "text-davinci-003", // assumes a matching model deployment or model name
    Prompts = { "Hello, world!" },
});

foreach (Choice choice in response.Value.Choices)
{
    Console.WriteLine(choice.Text);
}
```

### Stream chat messages with non-Azure OpenAI

```C# Snippet:StreamChatMessages
string nonAzureOpenAIApiKey = "your-api-key-from-platform.openai.com";
var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate."),
        new ChatRequestUserMessage("Can you help me?"),
        new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
        new ChatRequestUserMessage("What's the best way to train a parrot?"),
    }
};

await foreach (StreamingChatCompletionsUpdate chatUpdate in client.GetChatCompletionsStreaming(chatCompletionsOptions))
{
    if (chatUpdate.Role.HasValue)
    {
        Console.Write($"{chatUpdate.Role.Value.ToString().ToUpperInvariant()}: ");
    }
    if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
    {
        Console.Write(chatUpdate.ContentUpdate);
    }
}
```

When explicitly requesting more than one `Choice` while streaming, use the `ChoiceIndex` property on
`StreamingChatCompletionsUpdate` to determine which `Choice` each update corresponds to.

```C# Snippet:StreamChatMessagesWithMultipleChoices
// A ChoiceCount > 1 will feature multiple, parallel, independent text generations arriving on the
// same response. This may be useful when choosing between multiple candidates for a single request.
var chatCompletionsOptions = new ChatCompletionsOptions()
{
    Messages = { new ChatRequestUserMessage("Write a limerick about bananas.") },
    ChoiceCount = 4
};

await foreach (StreamingChatCompletionsUpdate chatUpdate
    in client.GetChatCompletionsStreaming(chatCompletionsOptions))
{
    // Choice-specific information like Role and ContentUpdate will also provide a ChoiceIndex that allows
    // StreamingChatCompletionsUpdate data for independent choices to be appropriately separated.
    if (chatUpdate.ChoiceIndex.HasValue)
    {
        int choiceIndex = chatUpdate.ChoiceIndex.Value;
        if (chatUpdate.Role.HasValue)
        {
            textBoxes[choiceIndex].Text += $"{chatUpdate.Role.Value.ToString().ToUpperInvariant()}: ";
        }
        if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
        {
            textBoxes[choiceIndex].Text += chatUpdate.ContentUpdate;
        }
    }
}
```

### Use chat tools

**Tools** extend chat completions by allowing an assistant to invoke defined functions and other capabilities in the
process of fulfilling a chat completions request. To use chat tools, start by defining a function tool:

```C# Snippet:ChatTools:DefineTool
var getWeatherTool = new ChatCompletionsFunctionToolDefinition()
{
    Name = "get_current_weather",
    Description = "Get the current weather in a given location",
    Parameters = BinaryData.FromObjectAsJson(
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
                Enum = new[] { "celsius", "fahrenheit" },
            }
        },
        Required = new[] { "location" },
    },
    new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
};
```

With the tool defined, include that new definition in the options for a chat completions request:

```C# Snippet:ChatTools:RequestWithFunctions
var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "gpt-35-turbo-1106",
    Messages = { new ChatRequestUserMessage("What's the weather like in Boston?") },
    Tools = { getWeatherTool },
};

Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
```

When the assistant decides that one or more tools should be used, the response message includes one or more "tool
calls" that must all be resolved via "tool messages" on the subsequent request. This resolution of tool calls into
new request messages can be thought of as a sort of "callback" for chat completions.

```C# Snippet:ChatTools:HandleToolCalls
// Purely for convenience and clarity, this standalone local method handles tool call responses.
ChatRequestToolMessage GetToolCallResponseMessage(ChatCompletionsToolCall toolCall)
{
    var functionToolCall = toolCall as ChatCompletionsFunctionToolCall;
    if (functionToolCall?.Name == getWeatherTool.Name)
    {
        // Validate and process the JSON arguments for the function call
        string unvalidatedArguments = functionToolCall.Arguments;
        var functionResultData = (object)null; // GetYourFunctionResultData(unvalidatedArguments);
        // Here, replacing with an example as if returned from "GetYourFunctionResultData"
        functionResultData = "31 celsius";
        return new ChatRequestToolMessage(functionResultData.ToString(), toolCall.Id);
    }
    else
    {
        // Handle other or unexpected calls
        throw new NotImplementedException();
    }
}
```

To provide tool call resolutions to the assistant to allow the request to continue, provide all prior historical
context -- including the original system and user messages, the response from the assistant that included the tool
calls, and the tool messages that resolved each of those tools -- when making a subsequent request.

```C# Snippet:ChatTools:HandleResponseWithToolCalls
ChatChoice responseChoice = response.Value.Choices[0];
if (responseChoice.FinishReason == CompletionsFinishReason.ToolCalls)
{
    // Add the assistant message with tool calls to the conversation history
    ChatRequestAssistantMessage toolCallHistoryMessage = new(responseChoice.Message);
    chatCompletionsOptions.Messages.Add(toolCallHistoryMessage);

    // Add a new tool message for each tool call that is resolved
    foreach (ChatCompletionsToolCall toolCall in responseChoice.Message.ToolCalls)
    {
        chatCompletionsOptions.Messages.Add(GetToolCallResponseMessage(toolCall));
    }

    // Now make a new request with all the messages thus far, including the original
}
```

When using tool calls with streaming responses, accumulate tool call details much like you'd accumulate the other
portions of streamed choices, in this case using the accumulated `StreamingToolCallUpdate` data to instantiate new
tool call messages for assistant message history. Note that the model will ignore `ChoiceCount` when providing tools
and that all streamed responses should map to a single, common choice index in the range of `[0..(ChoiceCount - 1)]`.

```C# Snippet:ChatTools:StreamingChatTools
Dictionary<int, string> toolCallIdsByIndex = new();
Dictionary<int, string> functionNamesByIndex = new();
Dictionary<int, StringBuilder> functionArgumentBuildersByIndex = new();
StringBuilder contentBuilder = new();

await foreach (StreamingChatCompletionsUpdate chatUpdate
    in await client.GetChatCompletionsStreamingAsync(chatCompletionsOptions))
{
    if (chatUpdate.ToolCallUpdate is StreamingFunctionToolCallUpdate functionToolCallUpdate)
    {
        if (functionToolCallUpdate.Id != null)
        {
            toolCallIdsByIndex[functionToolCallUpdate.ToolCallIndex] = functionToolCallUpdate.Id;
        }
        if (functionToolCallUpdate.Name != null)
        {
            functionNamesByIndex[functionToolCallUpdate.ToolCallIndex] = functionToolCallUpdate.Name;
        }
        if (functionToolCallUpdate.ArgumentsUpdate != null)
        {
            StringBuilder argumentsBuilder
                = functionArgumentBuildersByIndex.TryGetValue(
                    functionToolCallUpdate.ToolCallIndex,
                    out StringBuilder existingBuilder) ? existingBuilder : new StringBuilder();
            argumentsBuilder.Append(functionToolCallUpdate.ArgumentsUpdate);
            functionArgumentBuildersByIndex[functionToolCallUpdate.ToolCallIndex] = argumentsBuilder;
        }
    }
    if (chatUpdate.ContentUpdate != null)
    {
        contentBuilder.Append(chatUpdate.ContentUpdate);
    }
}

ChatRequestAssistantMessage assistantHistoryMessage = new(contentBuilder.ToString());
foreach (KeyValuePair<int, string> indexIdPair in toolCallIdsByIndex)
{
    assistantHistoryMessage.ToolCalls.Add(new ChatCompletionsFunctionToolCall(
        id: indexIdPair.Value,
        functionNamesByIndex[indexIdPair.Key],
        functionArgumentBuildersByIndex[indexIdPair.Key].ToString()));
}
chatCompletionsOptions.Messages.Add(assistantHistoryMessage);

// Add request tool messages and proceed just like non-streaming
```

Additionally: if you would like to control the behavior of tool calls, you can use the `ToolChoice` property on
`ChatCompletionsOptions` to do so.

- `ChatCompletionsToolChoice.Auto` is the default behavior when tools are provided and instructs the model to determine
  which, if any, tools it should call. If tools are selected, a `CompletionsFinishReason` of `ToolCalls` will be
  received on response `ChatChoice` instances and the corresponding `ToolCalls` properties will be populated.
- `ChatCompletionsToolChoice.None` instructs the model to not use any tools and instead always generate a message. Note
  that the model's generated message may still be informed by the provided tools even when they are not or cannot be
  called.
- Providing a reference to a named function definition or function tool definition, as below, will instruct the model
  to restrict its response to calling the corresponding tool. When calling tools in this configuration, response
  `ChatChoice` instances will report a `FinishReason` of `CompletionsFinishReason.Stopped` and the corresponding
  `ToolCalls` property will be populated. Note that, because the model was constrained to a specific tool, it does
  **NOT** report the same `CompletionsFinishReason` value of `ToolCalls` expected when using
  `ChatCompletionsToolChoice.Auto`.

```C# Snippet:ChatTools:UseToolChoice
chatCompletionsOptions.ToolChoice = ChatCompletionsToolChoice.Auto; // let the model decide
chatCompletionsOptions.ToolChoice = ChatCompletionsToolChoice.None; // don't call tools
chatCompletionsOptions.ToolChoice = getWeatherTool; // only use the specified tool
```

### Use chat functions

Chat Functions are a legacy form of chat tools. Although still supported by older models, the use of tools is encouraged
when available.

You can read more about Chat Functions on OpenAI's blog: https://openai.com/blog/function-calling-and-other-api-updates

**NOTE**: Chat Functions require model versions beginning with gpt-4 and gpt-3.5-turbo's `-0613` labels. They are not
available with older versions of the models.

**NOTE:** The concurrent use of Chat Functions and [Azure Chat Extensions](#use-your-own-data-with-azure-openai) on a single request is not yet supported. Supplying both will result in the Chat Functions information being ignored and the operation behaving as if only the Azure Chat Extensions were provided. To address this limitation, consider separating the evaluation of Chat Functions and Azure Chat Extensions across multiple requests in your solution design.

To use Chat Functions, you first define the function you'd like the model to be able to use when appropriate. Using
the example from the linked blog post, above:

```C# Snippet:ChatFunctions:DefineFunction
var getWeatherFuntionDefinition = new FunctionDefinition()
{
    Name = "get_current_weather",
    Description = "Get the current weather in a given location",
    Parameters = BinaryData.FromObjectAsJson(
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
                Enum = new[] { "celsius", "fahrenheit" },
            }
        },
        Required = new[] { "location" },
    },
    new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
};
```

With the function defined, it can then be used in a Chat Completions request via its options. Function data is
handled across multiple calls that build up data for subsequent stateless requests, so we maintain a list of chat
messages as a form of conversation history.

```C# Snippet:ChatFunctions:RequestWithFunctions
var conversationMessages = new List<ChatRequestMessage>()
{
    new ChatRequestUserMessage("What is the weather like in Boston?"),
};

var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "gpt-35-turbo-0613",
};
foreach (ChatRequestMessage chatMessage in conversationMessages)
{
    chatCompletionsOptions.Messages.Add(chatMessage);
}
chatCompletionsOptions.Functions.Add(getWeatherFuntionDefinition);

Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
```

If the model determines that it should call a Chat Function, a finish reason of 'FunctionCall' will be populated on
the choice and details will be present in the response message's `FunctionCall` property. Usually, the name of the
function call will be one that was provided and the arguments will be a populated JSON document matching the schema
included in the `FunctionDefinition` used; it is **not guaranteed** that this data is valid or even properly formatted,
however, so validation and error checking should always accompany function call processing.

To resolve the function call and continue the user-facing interaction, process the argument payload as needed and then
serialize appropriate response data into a new message with `ChatRole.Function`. Then make a new request with all of
the messages so far -- the initial `User` message, the first response's `FunctionCall` message, and the resolving
`Function` message generated in reply to the function call -- so the model can use the data to better formulate a chat
completions response.

Note that the function call response you provide does not need to follow any schema provided in the initial call. The
model will infer usage of the response data based on inferred context of names and fields.

```C# Snippet:ChatFunctions:HandleFunctionCall
ChatChoice responseChoice = response.Value.Choices[0];
if (responseChoice.FinishReason == CompletionsFinishReason.FunctionCall)
{
    // Include the FunctionCall message in the conversation history
    conversationMessages.Add(new ChatRequestAssistantMessage(responseChoice.Message.Content)
    {
        FunctionCall = responseChoice.Message.FunctionCall,
    });

    if (responseChoice.Message.FunctionCall.Name == "get_current_weather")
    {
        // Validate and process the JSON arguments for the function call
        string unvalidatedArguments = responseChoice.Message.FunctionCall.Arguments;
        var functionResultData = (object)null; // GetYourFunctionResultData(unvalidatedArguments);
        // Here, replacing with an example as if returned from GetYourFunctionResultData
        functionResultData = "31 degrees celsius";
        // Serialize the result data from the function into a new chat message with the 'Function' role,
        // then add it to the messages after the first User message and initial response FunctionCall
        var functionResponseMessage = new ChatRequestFunctionMessage(
            name: responseChoice.Message.FunctionCall.Name,
            content: JsonSerializer.Serialize(
                functionResultData,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
        conversationMessages.Add(functionResponseMessage);
        // Now make a new request using all three messages in conversationMessages
    }
}
```

When using streaming, capture streaming response components as they arrive and accumulate streaming function arguments
in the same manner used for streaming content. Then, in the place of using the `ChatMessage` from the non-streaming
response, instead add a new `ChatMessage` instance for history, created from the streamed information.

```C# Snippet::ChatFunctions::StreamingFunctions
string functionName = null;
StringBuilder contentBuilder = new();
StringBuilder functionArgumentsBuilder = new();
ChatRole? streamedRole = default;
CompletionsFinishReason? finishReason = default;

await foreach (StreamingChatCompletionsUpdate update
    in client.GetChatCompletionsStreaming(chatCompletionsOptions))
{
    functionName ??= update.FunctionName;
    streamedRole ??= update.Role;
    finishReason ??= update.FinishReason;
    contentBuilder.Append(update.ContentUpdate);
    functionArgumentsBuilder.Append(update.FunctionArgumentsUpdate);
}

if (finishReason == CompletionsFinishReason.FunctionCall)
{
    string lastContent = contentBuilder.ToString();
    string unvalidatedArguments = functionArgumentsBuilder.ToString();
    ChatRequestAssistantMessage chatMessageForHistory = new(contentBuilder.ToString())
    {
        FunctionCall = new(functionName, unvalidatedArguments),
    };
    conversationMessages.Add(chatMessageForHistory);

    // Handle from here just like the non-streaming case
}
```

Please note: while streamed function information (name, arguments) may be evaluated as it arrives, it should not be
considered complete or confirmed until the `FinishReason` of `FunctionCall` is received. It may be appropriate to make
best-effort attempts at "warm-up" or other speculative preparation based on a function name or particular key/value
appearing in the accumulated, partial JSON arguments, but no strong assumptions about validity, ordering, or other
details should be evaluated until the arguments are fully available and confirmed via `FinishReason`.

Additionally, if you would like to customize the way that the model calls provided functions, you can use the
`FunctionCall` property on `ChatCompletionsOptions` (not to be confused with the `FunctionCall` response message type!)
to do so.

- `FunctionDefinition.Auto` is the default when functions are provided and instructs the model to freely select between
  responding with a message or with a function call. When the model calls a function in this way, the
  `CompletionsFinishReason` value of `FunctionCall` will appear on response `ChatChoice`  instances and the
  corresponding `FunctionCall` will be populated.
- `FunctionDefinition.None` will instruct the model to not call functions and instead generate a message. Note that the
  response message contents may be still be influenced by the provided functions even when they are not or cannot be
  called.
- Providing a custom `FunctionDefinition` instance will instruct the model to restrict its response to the entry
  in `Functions` with a name that matches the one of the `FunctionDefinition`. When the model calls a function in
  this configuration, the `CompletionsFinishReason` value of `Stopped` will appear on the response `ChatChoice` and
  the corresponding `FunctionCall` will be populated. Because the model was constrained to the function,
  `CompletionsFinishReason.FunctionCall` will **NOT** be the `FinishReason` value in this case.

```C# Snippet::ChatFunctions::UseFunctionCall
chatCompletionsOptions.FunctionCall = FunctionDefinition.Auto; // let the model decide
chatCompletionsOptions.FunctionCall = FunctionDefinition.None; // don't call functions
chatCompletionsOptions.FunctionCall = getWeatherFuntionDefinition; // use only the specified function
```

### Use your own data with Azure OpenAI

The use your own data feature is unique to Azure OpenAI and won't work with a client configured to use the non-Azure service.
See [the Azure OpenAI using your own data quickstart](https://learn.microsoft.com/azure/ai-services/openai/use-your-data-quickstart) for conceptual background and detailed setup instructions.

**NOTE:** The concurrent use of [Chat Functions](#use-chat-functions) and Azure Chat Extensions on a single request is not yet supported. Supplying both will result in the Chat Functions information being ignored and the operation behaving as if only the Azure Chat Extensions were provided. To address this limitation, consider separating the evaluation of Chat Functions and Azure Chat Extensions across multiple requests in your solution design.

```C# Snippet:ChatUsingYourOwnData
AzureCognitiveSearchChatExtensionConfiguration contosoExtensionConfig = new()
{
    SearchEndpoint = new Uri("https://your-contoso-search-resource.search.windows.net"),
    Authentication = new OnYourDataApiKeyAuthenticationOptions("<your Cognitive Search resource API key>"),
};

ChatCompletionsOptions chatCompletionsOptions = new()
{
    DeploymentName = "gpt-35-turbo-0613",
    Messages =
    {
        new ChatRequestSystemMessage(
            "You are a helpful assistant that answers questions about the Contoso product database."),
        new ChatRequestUserMessage("What are the best-selling Contoso products this month?")
    },

    // The addition of AzureChatExtensionsOptions enables the use of Azure OpenAI capabilities that add to
    // the behavior of Chat Completions, here the "using your own data" feature to supplement the context
    // with information from an Azure Cognitive Search resource with documents that have been indexed.
    AzureExtensionsOptions = new AzureChatExtensionsOptions()
    {
        Extensions = { contosoExtensionConfig }
    }
};

Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
ChatResponseMessage message = response.Value.Choices[0].Message;

// The final, data-informed response still appears in the ChatMessages as usual
Console.WriteLine($"{message.Role}: {message.Content}");

// Responses that used extensions will also have Context information that includes special Tool messages
// to explain extension activity and provide supplemental information like citations.
Console.WriteLine($"Citations and other information:");

foreach (ChatResponseMessage contextMessage in message.AzureExtensionsContext.Messages)
{
    // Note: citations and other extension payloads from the "tool" role are often encoded JSON documents
    // and need to be parsed as such; that step is omitted here for brevity.
    Console.WriteLine($"{contextMessage.Role}: {contextMessage.Content}");
}
```

### Generate embeddings

```C# Snippet:GenerateEmbeddings
EmbeddingsOptions embeddingsOptions = new()
{
    DeploymentName = "text-embedding-ada-002",
    Input = { "Your text string goes here" },
};
Response<Embeddings> response = await client.GetEmbeddingsAsync(embeddingsOptions);

// The response includes the generated embedding.
EmbeddingItem item = response.Value.Data[0];
ReadOnlyMemory<float> embedding = item.Embedding;
``````

### Generate images with DALL-E image generation models

```C# Snippet:GenerateImages
Response<ImageGenerations> response = await client.GetImageGenerationsAsync(
    new ImageGenerationOptions()
    {
        DeploymentName = usingAzure ? "my-azure-openai-dall-e-3-deployment" : "dall-e-3",
        Prompt = "a happy monkey eating a banana, in watercolor",
        Size = ImageSize.Size1024x1024,
        Quality = ImageGenerationQuality.Standard
    });

ImageGenerationData generatedImage = response.Value.Data[0];
if (!string.IsNullOrEmpty(generatedImage.RevisedPrompt))
{
    Console.WriteLine($"Input prompt automatically revised to: {generatedImage.RevisedPrompt}");
}
Console.WriteLine($"Generated image available at: {generatedImage.Url.AbsoluteUri}");
```

### Transcribe audio data with Whisper speech models

```C# Snippet:TranscribeAudio
using Stream audioStreamFromFile = File.OpenRead("myAudioFile.mp3");

var transcriptionOptions = new AudioTranscriptionOptions()
{
    DeploymentName = "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
    AudioData = BinaryData.FromStream(audioStreamFromFile),
    ResponseFormat = AudioTranscriptionFormat.Verbose,
};

Response<AudioTranscription> transcriptionResponse
    = await client.GetAudioTranscriptionAsync(transcriptionOptions);
AudioTranscription transcription = transcriptionResponse.Value;

// When using Simple, SRT, or VTT formats, only transcription.Text will be populated
Console.WriteLine($"Transcription ({transcription.Duration.Value.TotalSeconds}s):");
Console.WriteLine(transcription.Text);
```

### Translate audio data to English with Whisper speech models

```C# Snippet:TranslateAudio
using Stream audioStreamFromFile = File.OpenRead("mySpanishAudioFile.mp3");

var translationOptions = new AudioTranslationOptions()
{
    DeploymentName = "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
    AudioData = BinaryData.FromStream(audioStreamFromFile),
    ResponseFormat = AudioTranslationFormat.Verbose,
};

Response<AudioTranslation> translationResponse = await client.GetAudioTranslationAsync(translationOptions);
AudioTranslation translation = translationResponse.Value;

// When using Simple, SRT, or VTT formats, only translation.Text will be populated
Console.WriteLine($"Translation ({translation.Duration.Value.TotalSeconds}s):");
// .Text will be translated to English (ISO-639-1 "en")
Console.WriteLine(translation.Text);
```

### Chat with images using gpt-4-vision-preview

The `gpt-4-vision-preview` model allows you to use images as input components into chat completions.

To do this, provide distinct content items on the user message(s) for the chat completions request:

```C# Snippet:AddImageToChat
const string rawImageUri = "<URI to your image>";
ChatCompletionsOptions chatCompletionsOptions = new()
{
    DeploymentName = "gpt-4-vision-preview",
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant that describes images."),
        new ChatRequestUserMessage(
            new ChatMessageTextContentItem("Hi! Please describe this image"),
            new ChatMessageImageContentItem(new Uri(rawImageUri))),
    },
};
```

Chat Completions will then proceed as usual, though the model may report the more informative `finish_details` in lieu
of `finish_reason`; this will converge as `gpt-4-vision-preview` is updated but checking for either one is recommended
in the interim:

```C# Snippet:GetResponseFromImages
Response<ChatCompletions> chatResponse = await client.GetChatCompletionsAsync(chatCompletionsOptions);
ChatChoice choice = chatResponse.Value.Choices[0];
if (choice.FinishDetails is StopFinishDetails stopDetails || choice.FinishReason == CompletionsFinishReason.Stopped)
{
    Console.WriteLine($"{choice.Message.Role}: {choice.Message.Content}");
}
```

### Customize HTTP behavior

As part of the Azure SDK, `OpenAIClient` integrates with Azure.Core's `HttpPipeline` and supports rich customization of
HTTP messaging behavior via instances of `HttpPipelinePolicy`. This allows traffic manipulation like proxy redirection,
API gateway use, insertion of custom query string parameters, and more.

To customize the HTTP behavior of OpenAIClient, first implement a class derived from
`Azure.Core.Pipeline.HttpPipelinePolicy` that performs any desired per-message operations before continuing pipeline
execution via `ProcessNext`/`ProcessNextAsync`. For example, this is a custom policy that adds a static query string
parameter key/value pair to all request URIs:

```C# Snippet:ImplementACustomHttpPipelinePolicy
public class SimpleQueryStringPolicy : HttpPipelinePolicy
{
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        message?.Request?.Uri?.AppendQuery("myParameterName", "valueForMyParameter");
        ProcessNext(message, pipeline);
    }

    public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        message?.Request?.Uri?.AppendQuery("myParameterName", "valueForMyParameter");
        return ProcessNextAsync(message, pipeline);
    }
}
```

Then, to apply the custom policy, add it to an instance of `OpenAIClientOptions` that is in turn used to instantiate an
`OpenAIClient` instance:

```C# Snippet:ConfigureClientsWithCustomHttpPipelinePolicy
OpenAIClientOptions clientOptions = new();
clientOptions.AddPolicy(
    policy: new SimpleQueryStringPolicy(),
    position: HttpPipelinePosition.PerRetry);

OpenAIClient client = new(
    endpoint: new Uri("https://myresource.openai.azure.com"),
    keyCredential: new AzureKeyCredential(myApiKey),
    clientOptions);
```

The above client will execute the custom policy on all requests, including retries, ensuring that the additional query
string parameter key/value pair is added.

## Troubleshooting

When you interact with Azure OpenAI using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][openai_rest] requests.

For example, if you try to create a client using an endpoint that doesn't match your Azure OpenAI Resource endpoint, a `404` error is returned, indicating `Resource Not Found`.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

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
[msdocs_openai_completion]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[msdocs_openai_embedding]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[openai_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src/Generated/OpenAIClient.cs
[openai_rest]: https://learn.microsoft.com/azure/cognitive-services/openai/reference
[azure_openai_completions_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[azure_openai_embeddgings_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[openai_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/openai/Azure.AI.OpenAI/README.png)
