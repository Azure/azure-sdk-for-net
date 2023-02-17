# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added
- Support for streaming Completions responses, a capability that parallels setting `stream=true` in the REST API, is now available. A new `GetStreamingCompletions` method on `OpenAIClient` provides a response value `StreamingCompletions` type. This, in turn, exposes a collection of `StreamingChoice` objects as an `IAsyncEnumerable` that will update as a streamed response progresses. `StreamingChoice` further exposes an `IAsyncEnumerable` of streaming text elements via a `GetTextStreaming` method. Used together, this facilitates providing faster, live-updating responses for Completions via the convenient `await foreach` pattern.
- ASP.NET integration via `Microsoft.Extensions.Azure`'s `IAzureClientBuilder` interfaces is available. `OpenAIClient` is now a supported client type for these extension methods.

### Breaking Changes
- `CompletionsLogProbability.TokenLogProbability`, available on `Choice` elements of a `Completions` response value's `.Choices` collection when a non-zero `LogProbability` value is provided via `CompletionsOptions`, is now an `IReadOnlyList<float?>` vs. its previous type of `IReadOnlyList<float>`. This nullability addition accomodates circumstances where some tokens produce expected null values in log probability arrays.

### Bugs Fixed
- Setting `CompletionsOptions.Echo` to true while also setting a non-zero `CompletionsOptions.LogProbability` no longer results in a deserialization error during response processing.

### Other Changes

## 1.0.0-beta.2 (2023-02-08)
### Bugs Fixed
- Adjusted bad name `finishReason` to `finish_reason` in deserializer class

## 1.0.0-beta.1 (2023-02-06)

### Features Added

- This is the initial preview release for Azure OpenAI inference capabilities, including completions and embeddings.
