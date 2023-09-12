# Release History

## 1.0.0-beta.8 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
