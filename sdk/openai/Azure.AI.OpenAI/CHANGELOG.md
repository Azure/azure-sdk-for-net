# Release History

## 1.0.0-beta.14 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.13 (2024-02-01)

### Breaking Changes

- Removed the setter of the `Functions` property of the `ChatCompletionsOptions` class as per the guidelines for collection properties.

### Bugs Fixed

- Addressed an issue with the public constructor for `ChatCompletionsFunctionToolCall` that failed to set the tool call type in the corresponding request.

## 1.0.0-beta.12 (2023-12-15)

Like beta.11, beta.12 is another release that brings further refinements and fixes. It remains based on the `2023-12-01-preview` service API version for Azure OpenAI and does not add any new service capabilities.

### Features Added

**Updates for using streaming tool calls:**

- A new .NET-specific `StreamingToolCallUpdate` type has been added to better represent streaming tool call updates
  when using chat tools.
  - This new type includes an explicit `ToolCallIndex` property, reflecting `index` in the REST schema, to allow
    resilient deserialization of parallel function tool calling.
- A convenience constructor has been added for `ChatRequestAssistantMessage` that can automatically populate from a prior
  `ChatResponseMessage` when using non-streaming chat completions.
- A public constructor has been added for `ChatCompletionsFunctionToolCall` to allow more intuitive reconstruction of
  `ChatCompletionsToolCall` instances for use in `ChatRequestAssistantMessage` instances made from streaming responses.

**Other additions:**

- To facilitate reuse of user message contents, `ChatRequestUserMessage` now provides a public `Content` property (`string`) as well as a public `MultimodalContentItems` property (`IList<ChatMessageContentItem`).
  - `Content` is the conventional plain-text content and will be populated as non-null when the a `ChatRequestUserMessage()` constructor accepting a string is used to instantiate the message.
  - `MultimodalContentItems` is the new compound content type, currently only usable with `gpt-4-vision-preview`, that allows hybrid use of text and image references. It will be populated when an appropriate `ChatRequestUserMessage()` constructor accepting a collection of `ChatMessageContentItem` instances is used.
  - `Role` is also restored to common visibility to `ChatRequestUserMessage`.

### Breaking Changes

- The type of `ToolCallUpdate` on `StreamingChatCompletionsUpdate` has been changed from the non-streaming
  `ChatCompletionsToolCall` to the new `StreamingToolCallUpdate` type. The conversion is straightforward:
  - `ToolCallUpdate.Id` remains unchanged.
  - Instead of casting `ToolCallUpdate` to `ChatCompletionsFunctionToolCall`, cast it to `StreamingToolCallUpdate`.
  - Update cast instance use of `functionToolCallUpdate.Arguments` to accumulate `functionToolCallUpdate.ArgumentsUpdate`.
- Removed the parameterized constructor of the `ChatCompletionsOptions` class that only received the messages as a parameter in favor of the parameterized constructor that receives the deployment name as well. This makes it consistent with the implementation of other Options classes.
- Removed the setter of the `Input` property of the `EmbeddingsOptions` class as per the guidelines for collection properties.

### Bugs fixed

- [[QUERY] Azure.AI.OpenAI_1.0.0-beta.10 no longer exposes message content on base ChatRequestMessage](https://github.com/Azure/azure-sdk-for-net/issues/40634)
- [[BUG] Null Reference Exception in OpenAIClient.GetChatCompletionsAsync](https://github.com/Azure/azure-sdk-for-net/issues/40810)

## 1.0.0-beta.11 (2023-12-07)

This is a fast-following bug fix update to address some of the biggest issues reported by the community. Thank you
sharing your experiences!

### Breaking Changes

- The type of `ChatCompletionsOptions.ToolChoice` has been updated from `BinaryData` to a new `ChatCompletionsToolChoice` type. Please use `ChatCompletionsToolChoice.None`, `ChatCompletionsToolChoice.Auto`, or provide a reference to a function or function tool definition to migrate.

### Bugs Fixed

- `ChatCompletionsOptions.ResponseFormat` now serializes correctly and will not result in "not of type 'object" errors
- `ChatCompletionsOptions.FunctionCall` is fixed to again work with `FunctionDefinition.None` and `FunctionDefinition.Auto` instead of resulting in not finding a named "none" or "auto" function
- `ChatCompletionsOptions.ToolChoice` previously defaulted to a `BinaryData` type and has now been corrected to use a custom `ChatCompletionsToolChoice` type that parallels `FunctionDefinition` for older function calling.

## 1.0.0-beta.10 (2023-12-06)

Following OpenAI's November Dev Day and Microsoft's 2023 Ignite conference, this update brings a slew of new
features and changes to the SDK.

### Features Added

- `-1106` model feature support for `gpt-35-turbo` and `gpt-4-turbo`, including use of `seed`, `system_fingerprint`,
    parallel function calling via tools, "JSON mode" for guaranteed function outputs, and more
- `dall-e-3` image generation capabilities via `GetImageGenerations`, featuring higher model quality, automatic prompt
    revisions by `gpt-4`, and customizable quality/style settings
- Greatly expanded "On Your Data" capabilities in Azure OpenAI, including many new data source options and authentication
    mechanisms
- Early support for `gpt-4-vision-preview`, which allows the hybrid use of text and images as input to enable scenarios
    like "describe this image for me"
- Support for Azure enhancements to `gpt-4-vision-preview` results that include grounding and OCR features

### Breaking Changes

`ChatMessage` changes:

- The singular `ChatMessage` type has been replaced by `ChatRequestMessage` and `ChatResponseMessage`, the former of
    which is an abstract, polymorphic type with concrete derivations like `ChatRequestSystemMessage` and
    `ChatRequestUserMessage`. This requires conversion from old `ChatMessages` into the new types. While this is
    usually a straightforward string replacement, converting a response message into a request message (e.g. when
    propagating an assistant response to continue the conversation) will require creating a new instance of the
    appropriate request message with the response message's data. See the examples for details.

Dall-e-3:

- Azure OpenAI now uses `dall-e-3` model deployments for its image generation API and such a valid deployment must
    be provided into the options for the `GetImageGenerations` method to receive results.

### Other changes

- Audio transcription and translation (via `GetAudioTranscription()` and `GetAudioTranslation()` now allow specification of an optional `Filename` in addition to the binary audio data. This is used purely as an identifier and does not functionally alter the transcription/translation behavior in any way.

## 1.0.0-beta.9 (2023-11-06)

### Breaking Changes

This update includes a number of version-to-version breaking changes to the API.

#### Streaming for completions and chat completions

Streaming Completions and Streaming Chat Completions have been significantly updated to use simpler, shallower usage
patterns and data representations. The goal of these changes is to make streaming much easier to consume in common
cases while still retaining full functionality in more complex ones (e.g. with multiple choices requested).
- A new `StreamingResponse<T>` type is introduced that implicitly exposes an `IAsyncEnumerable<T>` derived from
  the underlying response.
- `OpenAI.GetCompletionsStreaming()` now returns a `StreamingResponse<Completions>` that may be directly
  enumerated over. `StreamingCompletions`, `StreamingChoice`, and the corresponding methods are removed.
- Because Chat Completions use a distinct structure for their streaming response messages, a new
  `StreamingChatCompletionsUpdate` type is introduced that encapsulates this update data.
- Correspondingly, `OpenAI.GetChatCompletionsStreaming()` now returns a
  `StreamingResponse<StreamingChatCompletionsUpdate>` that may be enumerated over directly.
  `StreamingChatCompletions`, `StreamingChatChoice`, and related methods are removed.
- For more information, please see
  [the related pull request description](https://github.com/Azure/azure-sdk-for-net/pull/39347) as well as the
  updated snippets in the project README.

#### `deploymentOrModelName` moved to `*Options.DeploymentName`

`deploymentOrModelName` and related method parameters on `OpenAIClient` have been moved to `DeploymentName`
properties in the corresponding method options. This is intended to promote consistency across scenario,
language, and Azure/non-Azure OpenAI use.

As an example, the following:

```csharp
ChatCompletionsOptions chatCompletionsOptions = new()
{
    Messages = { new(ChatRole.User, "Hello, assistant!") },
};
Response<ChatCompletions> response = client.GetChatCompletions("gpt-4", chatCompletionsOptions);
```

...is now re-written as:

```csharp
ChatCompletionsOptions chatCompletionsOptions = new()
{
    DeploymentName = "gpt-4",
    Messages = { new(ChatRole.User, "Hello, assistant!") },
};
Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);
```

#### Consistency in complex method options type constructors

With the migration of `DeploymentName` into method complex options types, these options types have now been snapped to
follow a common pattern: each complex options type will feature a default constructor that allows `init`-style setting
of properties as well as a single additional constructor that accepts *all* required parameters for the corresponding
method. Existing constructors that no longer meet that "all" requirement, including those impacted by the addition of
`DeploymentName`, have been removed. The "convenience" constructors that represented required parameter data
differently -- for example, `EmbeddingsOptions(string)`, have also been removed in favor of the consistent "set of
directly provide" choice.

More exhaustively, *removed* are:

- `AudioTranscriptionOptions(BinaryData)`
- `AudioTranslationOptions(BinaryData)`
- `ChatCompletionsOptions(IEnumerable<ChatMessage>)`
- `CompletionsOptions(IEnumerable<string>)`
- `EmbeddingsOptions(string)`
- `EmbeddingsOptions(IEnumerable<string>)`

And *added* as replacements are:

- `AudioTranscriptionOptions(string, BinaryData)`
- `AudioTranslationOptions(string, BinaryData)`
- `ChatCompletionsOptions(string, IEnumerable<ChatMessage>)`
- `CompletionsOptions(string, IEnumerable<string>)`
- `EmbeddingsOptions(string, IEnumerable<string>)`

#### Embeddings now represented as `ReadOnlyMemory<float>`

Changed the representation of embeddings (specifically, the type of the `Embedding` property of the `EmbeddingItem` class)
from `IReadOnlyList<float>` to `ReadOnlyMemory<float>` as part of a broader effort to establish consistency across the
.NET ecosystem.

#### `SearchKey` and `EmbeddingKey` properties replaced by `SetSearchKey` and `SetEmbeddingKey` methods

Replaced the `SearchKey` and `EmbeddingKey` properties of the `AzureCognitiveSearchChatExtensionConfiguration` class with
new `SetSearchKey` and `SetEmbeddingKey` methods respectively. These methods simplify the configuration of the Azure Cognitive
Search chat extension by receiving a plain string instead of an `AzureKeyCredential`, promote more sensible key and secret
management, and align with the Azure SDK guidelines.

## 1.0.0-beta.8 (2023-09-21)

### Features Added

- Audio Transcription and Audio Translation using OpenAI Whisper models is now supported. See [OpenAI's API
  reference](https://platform.openai.com/docs/api-reference/audio) or the [Azure OpenAI
  quickstart](https://learn.microsoft.com/azure/ai-services/openai/whisper-quickstart) for detailed overview and
  background information.
  - The new methods `GetAudioTranscription` and `GetAudioTranscription` expose these capabilities on `OpenAIClient`
  - Transcription produces text in the primary, supported, spoken input language of the audio data provided, together
    with any optional associated metadata
  - Translation produces text, translated to English and reflective of the audio data provided, together with any
    optional associated metadata
  - These methods work for both Azure OpenAI and non-Azure `api.openai.com` client configurations

### Breaking Changes

- The underlying representation of `PromptFilterResults` (for `Completions` and `ChatCompletions`) has had its response
  body key changed from `prompt_annotations` to `prompt_filter_results`
- **Prior versions of the `Azure.AI.OpenAI` library may no longer populate `PromptFilterResults` as expected** and it's
  highly recommended to upgrade to this version if the use of Azure OpenAI content moderation annotations for input data
  is desired
- If a library version upgrade is not immediately possible, it's advised to use `Response<T>.GetRawResponse()` and manually
  extract the `prompt_filter_results` object from the top level of the `Completions` or `ChatCompletions` response `Content`
  payload

### Bugs Fixed

- Support for the described breaking change for `PromptFilterResults` was added and this library version will now again
  deserialize `PromptFilterResults` appropriately
- `PromptFilterResults` and `ContentFilterResults` are now exposed on the result classes for streaming Completions and
  Chat Completions. `Streaming(Chat)Completions.PromptFilterResults` will report an index-sorted list of all prompt
  annotations received so far while `Streaming(Chat)Choice.ContentFilterResults` will reflect the latest-received
  content annotations that were populated and received while streaming

## 1.0.0-beta.7 (2023-08-25)

### Features Added

- The Azure OpenAI "using your own data" feature is now supported. See [the Azure OpenAI using your own data quickstart](https://learn.microsoft.com/azure/ai-services/openai/use-your-data-quickstart) for conceptual background and detailed setup instructions.
  - Azure OpenAI chat extensions are configured via a new `AzureChatExtensionsOptions` property on `ChatCompletionsOptions`. When an `AzureChatExtensionsOptions` is provided, configured requests will only work with clients configured to use the Azure OpenAI service, as the capabilities are unique to that service target.
  - `AzureChatExtensionsOptions` then has `AzureChatExtensionConfiguration` instances added to its `Extensions` property, with these instances representing the supplementary information needed for Azure OpenAI to use desired data sources to supplement chat completions behavior.
  - `ChatChoice` instances on a `ChatCompletions` response value that used chat extensions will then also have their `Message` property supplemented by an `AzureChatExtensionMessageContext` instance. This context contains a collection of supplementary `Messages` that describe the behavior of extensions that were used and supplementary response data, such as citations, provided along with the response.
  - See the README sample snippet for a simplified example of request/response use with "using your own data"

## 1.0.0-beta.6 (2023-07-19)

### Features Added

- DALL-E image generation is now supported. See [the Azure OpenAI quickstart](https://learn.microsoft.com/azure/cognitive-services/openai/dall-e-quickstart) for conceptual background and detailed setup instructions.
  - `OpenAIClient` gains a new `GetImageGenerations` method that accepts an `ImageGenerationOptions` and produces an `ImageGenerations` via its response. This response object encapsulates the temporary storage location of generated images for future retrieval.
  - In contrast to other capabilities, DALL-E image generation does not require explicit creation or specification of a deployment or model. Its surface as such does not include this concept.
- Functions for chat completions are now supported: see [OpenAI's blog post on the topic](https://openai.com/blog/function-calling-and-other-api-updates) for much more detail.
  - A list of `FunctionDefinition` objects may be populated on `ChatCompletionsOptions` via its `Functions` property. These definitions include a name and description together with a serialized JSON Schema representation of its parameters; these parameters can be generated easily via `BinaryData.FromObjectAsJson` with dynamic objects -- see the README for example usage.
  - **NOTE**: Chat Functions requires a minimum of the `-0613` model versions for `gpt-4` and `gpt-3.5-turbo`/`gpt-35-turbo`. Please ensure you're using these later model versions, as Functions are not supported with older model revisions. For Azure OpenAI, you can update a deployment's model version or create a new model deployment with an updated version via the Azure AI Studio interface, also accessible through Azure Portal.
- (Azure OpenAI specific) Completions and Chat Completions responses now include embedded content filter annotations for prompts and responses
- A new `Azure.AI.OpenAI.AzureOpenAIModelFactory` is now present for mocking.

### Breaking Changes

- `ChatMessage`'s one-parameter constructor has been replaced with a no-parameter constructor. Please replace any hybrid construction with one of these two options that either completely rely on property setting or completely rely on constructor parameters.

## 1.0.0-beta.5 (2023-03-22)

This is a significant release that brings GPT-4 model support (chat) and the ability to use non-Azure OpenAI (not just Azure OpenAI resources) to the .NET library. It also makes a number of clarifying adjustments to request properties for completions.

### Features Added
- GPT-4 models are now supported via new `GetChatCompletions` and `GetChatCompletionsStreaming` methods on `OpenAIClient`. These use the `/chat/completions` REST endpoint and represent the [OpenAI Chat messages format](https://platform.openai.com/docs/guides/chat).
    - The `gpt-3.5-model` can also be used with Chat completions; prior models like text-davinci-003 cannot be used with Chat completions and should still use the `GetCompletions` methods.
- Support for using OpenAI's endpoint via valid API keys obtained from https://platform.openai.com has been added. `OpenAIClient` has new constructors that accept an OpenAI API key instead of an Azure endpoint URI and credential; once configured, Completions, Chat Completions, and Embeddings can be used with identical calling patterns.

### Breaking Changes

A number of Completions request properties have been renamed and further documented for clarity.
- `CompletionsOptions` (REST request payload):
    - `CacheLevel` and `CompletionConfig` are removed.
    - `LogitBias` (REST: `logit_bias`), previously a `<string, int>` Dictionary, is now an `<int, int>` Dictionary named `TokenSelectionBiases`.
    - `LogProbability` (REST: `logprobs`) is renamed to `LogProbabilityCount`.
    - `Model` is removed (in favor of the method-level parameter for deployment or model name)
    - `Prompt` is renamed to `Prompts`
    - `SnippetCount` (REST: `n`) is renamed to `ChoicesPerPrompt`.
    - `Stop` is renamed to `StopSequences`.
- Method and property documentation are broadly updated, with renames from REST schema (like `n` becoming `ChoicesPerPrompt`) specifically noted in `<remarks>`.

## 1.0.0-beta.4 (2023-02-23)

### Bugs fixed
- Addressed issues that sometimes caused `beta.3`'s new `GetStreamingCompletions` method to execute indefinitely

## 1.0.0-beta.3 (2023-02-17)

### Features Added
- Support for streaming Completions responses, a capability that parallels setting `stream=true` in the REST API, is now available. A new `GetStreamingCompletions` method on `OpenAIClient` provides a response value `StreamingCompletions` type. This, in turn, exposes a collection of `StreamingChoice` objects as an `IAsyncEnumerable` that will update as a streamed response progresses. `StreamingChoice` further exposes an `IAsyncEnumerable` of streaming text elements via a `GetTextStreaming` method. Used together, this facilitates providing faster, live-updating responses for Completions via the convenient `await foreach` pattern.
- ASP.NET integration via `Microsoft.Extensions.Azure`'s `IAzureClientBuilder` interfaces is available. `OpenAIClient` is now a supported client type for these extension methods.

### Breaking Changes
- `CompletionsLogProbability.TokenLogProbability`, available on `Choice` elements of a `Completions` response value's `.Choices` collection when a non-zero `LogProbability` value is provided via `CompletionsOptions`, is now an `IReadOnlyList<float?>` vs. its previous type of `IReadOnlyList<float>`. This nullability addition accomodates circumstances where some tokens produce expected null values in log probability arrays.

### Bugs Fixed
- Setting `CompletionsOptions.Echo` to true while also setting a non-zero `CompletionsOptions.LogProbability` no longer results in a deserialization error during response processing.

## 1.0.0-beta.2 (2023-02-08)
### Bugs Fixed
- Adjusted bad name `finishReason` to `finish_reason` in deserializer class

## 1.0.0-beta.1 (2023-02-06)

### Features Added

- This is the initial preview release for Azure OpenAI inference capabilities, including completions and embeddings.
