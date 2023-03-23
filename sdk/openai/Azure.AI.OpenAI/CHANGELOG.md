# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
