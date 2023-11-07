# Azure OpenAI client library for .NET

The Azure OpenAI client library for .NET is an adaptation of OpenAI's REST APIs that provides an idiomatic interface
and rich integration with the rest of the Azure SDK ecosystem. It can connect to Azure OpenAI resources *or* to the
non-Azure OpenAI inference endpoint, making it a great choice for even non-Azure OpenAI development.

Use the client library for Azure OpenAI to:

* [Create a completion for text][msdocs_openai_completion]
* [Create a text embedding for comparisons][msdocs_openai_embedding]

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

#### Create OpenAIClient with an Azure Active Directory Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity]. To use the [DefaultAzureCredential][azure_identity_dac] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

```C# Snippet:CreateOpenAIClientTokenCredential
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

The main concept to understand is [Completions][azure_openai_completions_docs]. Briefly explained, completions provides its functionality in the form of a text prompt, which by using a specific [model](https://learn.microsoft.com/azure/cognitive-services/openai/concepts/models), will then attempt to match the context and patterns, providing an output text. The following code snippet provides a rough overview (more details can be found in the `GenerateChatbotResponsesWithToken` sample code):

```C# Snippet:UseAzureOrNonAzureOpenAI
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

### Generate chatbot response

The `GenerateChatbotResponse` method authenticates using a DefaultAzureCredential, then generates text responses to input prompts.

```C# Snippet:GenerateChatbotResponse
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

CompletionsOptions completionsOptions = new()
{
    DeploymentName = "text-davinci-003",
    Prompts = { "What is Azure OpenAI?" },
};

Response<Completions> completionsResponse = client.GetCompletions(completionsOptions);
string completion = completionsResponse.Value.Choices[0].Text;
Console.WriteLine($"Chatbot: {completion}");
```

### Generate multiple chatbot responses with subscription key

The `GenerateMultipleChatbotResponsesWithSubscriptionKey` method gives an example of generating text responses to input prompts using an Azure subscription key

```C# Snippet:GenerateMultipleChatbotResponsesWithSubscriptionKey
// Replace with your Azure OpenAI key
string key = "YOUR_AZURE_OPENAI_KEY";
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));

CompletionsOptions completionsOptions = new()
{
    DeploymentName = "text-davinci-003",
    Prompts =
    {
        "How are you today?",
        "What is Azure OpenAI?",
        "Why do children love dinosaurs?",
        "Generate a proof of Euler's identity",
        "Describe in single words only the good things that come into your mind about your mother."
    },
};

Response<Completions> completionsResponse = client.GetCompletions(completionsOptions);

foreach (Choice choice in completionsResponse.Value.Choices)
{
    Console.WriteLine($"Response for prompt {choice.Index}: {choice.Text}");
}
```

### Summarize text with completion

The `SummarizeText` method generates a summarization of the given input prompt.

```C# Snippet:SummarizeText
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

string textToSummarize = @"
    Two independent experiments reported their results this morning at CERN, Europe's high-energy physics laboratory near Geneva in Switzerland. Both show convincing evidence of a new boson particle weighing around 125 gigaelectronvolts, which so far fits predictions of the Higgs previously made by theoretical physicists.

    ""As a layman I would say: 'I think we have it'. Would you agree?"" Rolf-Dieter Heuer, CERN's director-general, asked the packed auditorium. The physicists assembled there burst into applause.
:";

string summarizationPrompt = @$"
    Summarize the following text.

    Text:
    """"""
    {textToSummarize}
    """"""

    Summary:
";

Console.Write($"Input: {summarizationPrompt}");
var completionsOptions = new CompletionsOptions()
{
    DeploymentName = "text-davinci-003",
    Prompts = { summarizationPrompt },
};

Response<Completions> completionsResponse = client.GetCompletions(completionsOptions);
string completion = completionsResponse.Value.Choices[0].Text;
Console.WriteLine($"Summarization: {completion}");
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
        new ChatMessage(ChatRole.System, "You are a helpful assistant. You will talk like a pirate."),
        new ChatMessage(ChatRole.User, "Can you help me?"),
        new ChatMessage(ChatRole.Assistant, "Arrrr! Of course, me hearty! What can I do for ye?"),
        new ChatMessage(ChatRole.User, "What's the best way to train a parrot?"),
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
    Messages = { new ChatMessage(ChatRole.User, "Write a limerick about bananas.") },
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

### Use chat functions

Chat Functions allow a caller of Chat Completions to define capabilities that the model can use to extend its
functionality into external tools and data sources.

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
var conversationMessages = new List<ChatMessage>()
{
    new(ChatRole.User, "What is the weather like in Boston?"),
};

var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "gpt-35-turbo-0613",
};
foreach (ChatMessage chatMessage in conversationMessages)
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
    conversationMessages.Add(responseChoice.Message);

    if (responseChoice.Message.FunctionCall.Name == "get_current_weather")
    {
        // Validate and process the JSON arguments for the function call
        string unvalidatedArguments = responseChoice.Message.FunctionCall.Arguments;
        var functionResultData = (object)null; // GetYourFunctionResultData(unvalidatedArguments);
        // Here, replacing with an example as if returned from GetYourFunctionResultData
        functionResultData = new
        {
            Temperature = 31,
            Unit = "celsius",
        };
        // Serialize the result data from the function into a new chat message with the 'Function' role,
        // then add it to the messages after the first User message and initial response FunctionCall
        var functionResponseMessage = new ChatMessage(
            ChatRole.Function,
            JsonSerializer.Serialize(
                functionResultData,
                new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }))
        {
            Name = responseChoice.Message.FunctionCall.Name
        };
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
ChatRole streamedRole = default;
CompletionsFinishReason finishReason = default;

await foreach (StreamingChatCompletionsUpdate update
    in client.GetChatCompletionsStreaming(chatCompletionsOptions))
{
    contentBuilder.Append(update.ContentUpdate);
    functionName ??= update.FunctionName;
    functionArgumentsBuilder.Append(update.FunctionArgumentsUpdate);
    streamedRole = update.Role ?? default;
    finishReason = update.FinishReason ?? default;
}

if (finishReason == CompletionsFinishReason.FunctionCall)
{
    string lastContent = contentBuilder.ToString();
    string unvalidatedArguments = functionArgumentsBuilder.ToString();
    ChatMessage chatMessageForHistory = new(streamedRole, lastContent)
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

### Use your own data with Azure OpenAI

The use your own data feature is unique to Azure OpenAI and won't work with a client configured to use the non-Azure service.
See [the Azure OpenAI using your own data quickstart](https://learn.microsoft.com/azure/ai-services/openai/use-your-data-quickstart) for conceptual background and detailed setup instructions.

**NOTE:** The concurrent use of [Chat Functions](#use-chat-functions) and Azure Chat Extensions on a single request is not yet supported. Supplying both will result in the Chat Functions information being ignored and the operation behaving as if only the Azure Chat Extensions were provided. To address this limitation, consider separating the evaluation of Chat Functions and Azure Chat Extensions across multiple requests in your solution design.

```C# Snippet:ChatUsingYourOwnData
AzureCognitiveSearchChatExtensionConfiguration contosoExtensionConfig = new()
{
    SearchEndpoint = new Uri("https://your-contoso-search-resource.search.windows.net"),
    IndexName = "contoso-products-index",
};

contosoExtensionConfig.SetSearchKey("<your Cognitive Search resource API key>");

ChatCompletionsOptions chatCompletionsOptions = new()
{
    DeploymentName = "gpt-35-turbo-0613",
    Messages =
    {
        new ChatMessage(
            ChatRole.System,
            "You are a helpful assistant that answers questions about the Contoso product database."),
        new ChatMessage(ChatRole.User, "What are the best-selling Contoso products this month?")
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
ChatMessage message = response.Value.Choices[0].Message;

// The final, data-informed response still appears in the ChatMessages as usual
Console.WriteLine($"{message.Role}: {message.Content}");

// Responses that used extensions will also have Context information that includes special Tool messages
// to explain extension activity and provide supplemental information like citations.
Console.WriteLine($"Citations and other information:");

foreach (ChatMessage contextMessage in message.AzureExtensionsContext.Messages)
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
Response<ImageGenerations> imageGenerations = await client.GetImageGenerationsAsync(
    new ImageGenerationOptions()
    {
        Prompt = "a happy monkey eating a banana, in watercolor",
        Size = ImageSize.Size256x256,
    });

// Image Generations responses provide URLs you can use to retrieve requested images
Uri imageUri = imageGenerations.Value.Data[0].Url;
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
