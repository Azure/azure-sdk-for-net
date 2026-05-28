# Release History

## 2.5.0-beta.1 (2025-10-03)

This update restores compatibility with the latest `2.5.0` release of `OpenAI` and enables access to the latest features. For details, please see [the full OpenAI 2.5.0 release notes](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md#250-2025-09-23).

### Features Added

- A substantial number of new features are carried forward from the `OpenAI` library. Please see [the full OpenAI 2.5.0 release notes](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md#250-2025-09-23) for details.

## 2.3.0-beta.2 (2025-08-21)

### Features Added

This small update includes `[Experimental]` additions to `AzureOpenAIClientOptions` that enables providing custom key/value pairs for headers and query string parameters via `DefaultHeaders` and `DefaultQueryParameters`, respectively.

## 2.3.0-beta.1 (2025-08-07)

This update restores compatibility with the latest `2.3.0` release of `OpenAI` and enables access to the latest features. For details, please see [the full OpenAI 2.3.0 release notes](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md#230-2025-08-01).

### Features Added

- A substantial number of new features are carried forward from the `OpenAI` library. Please see [the full OpenAI 2.3.0 release notes](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md#230-2025-08-01) for details.

## 2.2.0-beta.5 (2025-07-11)

This update converges new feature updates from the recent `2.2.0` release of `OpenAI` together with support based on the contemporary `2025-04-01-preview` Azure OpenAI Service API label.

### Features Added

- A substantial number of new features are carried forward from the `OpenAI` library. Please see [the full 2.2.0 release notes](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md#220-2025-07-02) for details.

### Breaking Changes (Preview APIs)

The following are carried forward from changes in the 2.2.0 release of `OpenAI`. Please see [the changelog](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md#220-2025-07-02) for full details.

- Removed the implicit operator from all models that converts a model to `BinaryContent`.
- Removed the explicit operator from all models that converts a `ClientResult` to a model.
- OpenAI:
  - Renamed the `GetRealtimeConversationClient` method from `OpenAIClient` to `GetRealtimeClient`.
- OpenAI.FineTuning:
  - Renamed the `FineTuningJobOperation` class to `FineTuningJob`.
  - Removed protocol methods for `CreateFineTuningJob`, `GetJob`, and `GetJobs` and added convenience methods for them.
- OpenAI.Realtime:
  - Updated namespace from `OpenAI.Conversations` to `OpenAI.Realtime`. All APIs and types related to real-time conversations have been moved to the new `OpenAI.Realtime` namespace.
- OpenAI.Responses:
  - Removed the `SummaryTextParts` property of `ReasoningResponseItem` in favor a new property called `SummaryParts`.
  - Removed the following public constructors:
    - `FileSearchCallResponseItem(IEnumerable<string> queries, IEnumerable<FileSearchCallResult> results)`
    - `FunctionCallOutputResponseItem(string callId, string functionOutput)`
    - `FunctionCallResponseItem(string callId, string functionName, BinaryData functionArguments)`
  - Made several properties read-only that were previously settable:
    - `CallId` and `Output` in `ComputerCallOutputResponseItem`
    - `Action`, `CallId`, and `Status` in `ComputerCallResponseItem`
    - `Results` and `Status` in `FileSearchCallResponseItem`
    - `CallId` in `FunctionCallOutputResponseItem`
    - `CallId` in `FunctionCallResponseItem`
  - Changed the following property types:
    - `Attributes` in `FileSearchCallResult` is now `IReadOnlyDictionary<string, BinaryData>` instead of `IDictionary<string, BinaryData>`.
    - `Status` properties are now nullable in multiple response item types.
    - `Code` in `ResponseError` is now `ResponseErrorCode` instead of `string`.
  - Renamed the `WebSearchToolContextSize` extensible enum to `WebSearchContextSize`.
  - Renamed the `WebSearchToolLocation` class to `WebSearchUserLocation`.
- OpenAI.VectorStores:
  - Renamed method parameters from `vectorStore` to `options` in `CreateVectorStore` and `ModifyVectorStore` methods in `VectorStoreClient`.

## 2.2.0-beta.4 (2025-03-18)

This update brings compatibility with the `2025-03-01-preview` service API version, including support for the new `/responses` API via `OpenAIResponseClient`.

### Features Added

- To use the new `/responses` endpoint, call `GetOpenAIResponseClient()` on an `AzureOpenAIClient` instance, following the same pattern as other operations. Using the overload without a deployment name will not be able to create new responses, only retrieve and list existing response data.

In addition to the new features transitive via the `OpenAI` library:

- Azure OpenAI file upload for batch (`FileUploadPurpose.Batch`) now supports the specification of a custom expiration policy in supported regions. To use this capability, call one of the supplied extension method overloads of `UploadFile()` that accepts an `AzureFileExpirationOptions` parameter.

### Breaking Changes

- Transitive from the OpenAI package, several types in the `[Experimental]` attributed `Assistants`, `VectorStores`, and `RealtimeConversation` namespaces have removed use of the `required` keyword, standardizing their constructor-based required input patterns with the rest of the library. To address these build breaks, use one of the new constructor signatures that accepts required parameters previously provided via property `init`.

## 2.2.0-beta.2 (2025-02-18)

### Bugs fixed

- Addressed a problem calling the `SetNewMaxCompletionTokensPropertyEnabled()` method, needed for o1/o3 model support, on `ChatCompletionOptions` instances prior to use in a method call. Related issue: [azure-sdk-for-net#46545](https://github.com/Azure/azure-sdk-for-net/issues/46545) with thanks to the PR  [azure-sdk-for-net#48218](https://github.com/Azure/azure-sdk-for-net/pull/48218).

## 2.2.0-beta.1 (2025-02-07)

This preview release aligns with the corresponding `2.2.0` beta of `OpenAI` and the `2025-01-01-Preview` Azure OpenAI Service API version.

New features include since 2.1.0-beta.2 include:

- Audio input for Chat Completions using `gpt-4o-audio-preview` or other compatible models: provide input audio via `ChatMessageContentPart.CreateInputAudioPart()`, set `AudioOptions` and `ResponseModalities` on `ChatCompletionOptions`, retrieve response audio via `OutputAudio` on `ChatCompletion`, and reference audio history from the assistant by using the `AssistantChatMessage(ChatCompletion)` constructor or using `ChatMessageContentPart.CreateAudioPart(string)`. For more information, refer to the examples in [the OpenAI README](https://github.com/openai/openai-dotnet/blob/main/README.md). 
- Predicted outputs in Chat Completions: `ChatCompletionOptions` accepts an `OutputPrediction` property that can be used via `ChatOutputPrediction.CreateStaticContentPrediction()` with text content to optimize operation efficiency for scenarios like code completion. For more information, see [OpenAI's predicted outputs announcement](https://community.openai.com/t/introducing-predicted-outputs/1004502).
- Chat Completions `o`-series model feature support: the new `developer` message role via `DeveloperChatMessage` (used just like `SystemChatMessage`), `ReasoningEffortLevel` on Chat Completion options
- [AOAI exclusive] `UserSecurityContext` integration with [Defender for Cloud](https://learn.microsoft.com/azure/defender-for-cloud/gain-end-user-context-ai); add a `UserSecurityContext` instance to `ChatCompletionOptions` with `SetUserSecurityContext()`

### Breaking Changes

- **Batch**: files uploaded for batch operations (`UploadFile` with `FileUploadPurpose.Batch`) will now report a `status` of `processed`, matching expected behavior against OpenAI's `/v1` endpoint. This is a change from past behavior where such files would initially report `pending` and a later `processed`, `error`, or other status depending on operation progress. Batch input validation is instead consistently performed from the batch client.

## 2.1.0 (2024-12-05)

This GA library release aligns functionality with the latest `2024-10-21` stable service API label.

> [!NOTE]
> For consistency and reliability, GA releases of the `Azure.AI.OpenAI` library will always map to stable Azure OpenAI service API versions. Because stable service API versions omit volatile surfaces such as beta features, GA library releases will also not contain the full set of preview functionality. To use beta and preview features, please use the latest prerelease version of the library.

### Features Added

**Chat**

- [GA] The `2024-10-21` API version brings GA AOAI support for streaming token usage in chat completions; `Usage` is now automatically populated in `StreamingChatCompletionUpdate` instances.
  - Note 1: this feature is not yet compatible when using On Your Data features (after invoking the `.AddDataSource()` extension method on `ChatCompletionOptions`)
  - Note 2: this feature is not yet compatible when using image input (a `ChatMessageContentPart` of `Kind` `Image`)
- [GA] The `AllowParallelToolCalls` property on `ChatCompletionOptions`, which can be set to `false` to disable the invocation of multiple tools on a single chat completion response, is now supported.
- [GA] Structured outputs, via the use of `ChatResponseFormat.CreateJsonSchemaFormat()`, is now supported.
- When using `o1-preview` and `o1-mini` models, `max_completion_tokens` may now be configured by calling the `[Experimental] SetNewMaxCompletionTokensPropertyEnabled()` extension method on `ChatCompletionOptions`.
  - This extension method will be removed in a future service API version, when it becomes unnecessary once all models support the `max_completion_tokens` property

**Batch**

The `2024-10-21` service API label introduces stable support for batch chat completions to Azure OpenAI. This library release exposes low-level support for batch:

- `AzureOpenAIClient`'s `GetOpenAIFileClient()` will now return a valid, configured instance of `FileClient` that supports uploading files with `FileUploadPurpose.Batch`. This can be used to upload the contents of a valid `.jsonl` file for batch processing.
- `AzureOpenAIClient`'s `GetBatchClient()` will now return a valid, configured instance of `BatchClient` that can produce a `CreateBatchOperation` given an uploaded file ID using protocol methods.
- Strongly typed convenience surfaces for `BatchClient` will arrive in a future update.

### Breaking Changes

> [!NOTE]
> GA library releases only permit breaking changes to items marked with an `[Experimental]` attribute and these changes will be minimized whenever possible.

- `[Experimental]` `GetBatchClient(string deploymentName)` on `AzureOpenAIClient` is removed, as the Azure OpenAI batch API now aligns with OpenAI's in not using a deployment-based request URI path. Please use `GetBatchClient()`, instead.
- `[Experimental]` the `Uri` property of type `System.Uri` in `ChatCitation` and `ChatRetrievedDocument` has been replaced by a `Url` property of type `string`. This contains the same information but properly handles document paths that don't conform to a valid RFC 3986 identifier.

## 2.1.0-beta.2 (2024-11-04)

This update brings compatibility with the Azure OpenAI `2024-10-01-preview` service API version as well as the `2.1.0-beta.2` release of the `OpenAI` library.

### Features Added

- The included update via `2024-09-01-preview` brings AOAI support for streaming token usage in chat completions; `Usage` is now automatically populated in `StreamingChatCompletionUpdate` instances.
  - Note 1: this feature is not yet compatible when using On Your Data features (after invoking the `.AddDataSource()` extension method on `ChatCompletionOptions`)
  - Note 2: this feature is not yet compatible when using image input (a `ChatMessageContentPart` of `Kind` `Image`)
- `2024-10-01-preview` further adds support for ungrounded content detection in chat completion content filter results via the `UngroundedMaterial` property on `ResponseContentFilterResult`, as retrieved from a chat completion via the `GetResponseContentFilterResult()` extension method.

## Breaking Changes

- `[Experimental]` `ChatCitation` and `ChatRetrievedDocument` have each replaced the `Uri` property of type `System.Uri` with a `string` property named `Url`. This aligns with the REST specification and accounts for the wire value of `url` not always providing a valid RFC 3986 identifier [[azure-sdk-for-net \#46793](https://github.com/Azure/azure-sdk-for-net/issues/46793)]

## Bugs Fixed

- Addressed an issue that caused `ChatCitation` and `ChatRetrievedDocument` to sometimes throw on deserialization, specifically when a returned value in the `url` JSON field was not populated with an RFC 3986 compliant identifier for `System.Uri` [[azure-sdk-for-net \#46793](https://github.com/Azure/azure-sdk-for-net/issues/46793)]

## 2.1.0-beta.1 (2024-10-01)

Relative to the prior GA release, this update restores preview surfaces, re-targeting to the latest `2024-08-01-preview` service `api-version` label. It also brings early support for the newly-announced `/realtime` capabilities with `gpt-4o-realtime-preview`. You can read more about Azure OpenAI support for `/realtime` in the announcement post here: https://azure.microsoft.com/blog/announcing-new-products-and-features-for-azure-openai-service-including-gpt-4o-realtime-preview-with-audio-and-speech-capabilities/

### Features Added

- Added a new `RealtimeConversationClient` in a corresponding scenario namespace. ([ff75da4](https://github.com/openai/openai-dotnet/commit/ff75da4167bc83fa85eb69ac142cab88a963ed06))
  - This maps to the new `/realtime` beta endpoint and is thus marked with a new `[Experimental("OPENAI002")]` diagnostic tag. 
  - This is a very early version of the convenience surface and thus subject to significant change
  - Documentation and samples will arrive soon; in the interim, see the scenario test files (in `/tests`) for basic usage
  - You can also find an external sample employing this client, together with Azure OpenAI support, at https://github.com/Azure-Samples/aoai-realtime-audio-sdk/tree/main/dotnet/samples

## 2.0.0 (2024-09-30)

This update marks the first stable library version for `Azure.AI.OpenAI`. It snaps its dependency to `OpenAI`'s matched `2.0.0` stable version and targets the latest Azure OpenAI Service stable `api-version` label of `2024-06-01`. As a GA label, the `2.0.0` stable version exposes a subset of preview features, with preview library labels continuing to support preview features.

Specifically included in the GA library release:

- `AudioClient`, supporting transcription and translation using the `whisper` model
- `ChatClient`, supporting chat completions, including Azure-specific features:
  - Embedded request and response content filter annotations
  - Azure Search and Cosmos DB data sources for Azure OpenAI On Your Data
- `EmbeddingClient`, supporting `text-embedding` model embedding operations
- `ImageClient`, supporting `dall-e-3` image generation

Assistants, Audio Generation, Batch, Files, Fine-Tuning, and Vector Stores are not yet included in the GA surface; they will continue to be available in preview library releases and the originating Azure OpenAI Service `api-version` labels.

### Breaking Changes

- `AzureOpenAIClient` constructors accepting `AzureKeyCredential` have been removed; please use the `ApiKeyCredential` constructors, instead. Note that `AzureKeyCredential` will inherit from `ApiKeyCredential` in a future update and that `AzureKeyCredential` has [a non-browsable Key property](https://github.com/Azure/azure-sdk-for-net/blob/448d80d80ad0f3df69b96df080da6cf8b537e9d2/sdk/core/Azure.Core/src/AzureKeyCredential.cs#L19) that may be used for conversion in the interim.
- The `AzureOpenAIClientOptions` `ApplicationId` has been renamed to a more descriptive `UserAgentApplicationId`.

**From OpenAI 2.0.0 stable**

- Implemented `ChatMessageContent` to encapsulate the representation of content parts in `ChatMessage`, `ChatCompletion`, and `StreamingChatCompletionUpdate`. (commit_hash)
- Changed the representation of function arguments to `BinaryData` in `ChatToolCall`, `StreamingChatToolCallUpdate`, `ChatFunctionCall`, and `StreamingChatFunctionCallUpdate`. (commit_hash)
- Renamed `OpenAIClientOptions`'s `ApplicationId` to `UserAgentApplicationId` (commit_hash)
- Renamed `StreamingChatToolCallUpdate`'s `Id` to `ToolCallId` (commit_hash)
- Renamed `StreamingChatCompletionUpdate`'s `Id` to `CompletionId` (commit_hash)
- Replaced `Auto` and `None` in the deprecated `ChatFunctionChoice` with `CreateAutoChoice()` and `CreateNoneChoice()` (commit_hash)
- Replaced the deprecated `ChatFunctionChoice(ChatFunction)` constructor with `CreateNamedChoice(string functionName)` (commit_hash)
- Renamed `FileClient` to `OpenAIFileClient` and the corresponding `GetFileClient()` method in `OpenAIClient` to `GetOpenAIFileClient()`. (commit_hash)
- Renamed `ModelClient` to `OpenAIModelClient` and the corresponding `GetModelClient()` method in `OpenAIClient` to `GetOpenAIModelClient()`. (commit_hash)

## 2.0.0-beta.6 (2024-09-23)

This version increments library compatibility to `OpenAI 2.0.0-beta.12`, including support for `o1` models with reasoning tokens and a number of breaking changes to method names.

### Features Added

- The library now includes support for the new [OpenAI o1](https://openai.com/o1/) model family. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - `ChatCompletionOptions` will automatically apply its `MaxOutputTokenCount` value (renamed from `MaxTokens`) to the new `max_completion_tokens` request body property
  - `Usage` includes a new `OutputTokenDetails` property with a `ReasoningTokenCount` value that will reflect `o1` model use of this new subcategory of output tokens.
  - Note that `OutputTokenCount` (`completion_tokens`) is the *sum* of displayed tokens generated by the model *and* (when applicable) these new reasoning tokens
- Assistants file search now includes support for `RankingOptions`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - Use of the `include[]` query string parameter and retrieval of run step detail result content is currently only available via protocol methods
- Added support for the Uploads API in `FileClient`. This `Experimental` feature allows uploading large files in multiple parts. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - The feature is supported by the `CreateUpload`, `AddUploadPart`, `CompleteUpload`, and `CancelUpload` protocol methods.

### Breaking Changes

- Renamed `ChatMessageContentPart`'s `CreateTextMessageContentPart` factory method to `CreateTextPart`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed `ChatMessageContentPart`'s `CreateImageMessageContentPart` factory method to `CreateImagePart`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed `ChatMessageContentPart`'s `CreateRefusalMessageContentPart` factory method to `CreateRefusalPart`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed `ImageChatMessageContentPartDetail` to `ChatImageDetailLevel`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Removed `ChatMessageContentPart`'s `ToString` overload. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed the `MaxTokens` property in `ChatCompletionOptions` to `MaxOutputTokenCount`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed properties in `ChatTokenUsage`:
  - `InputTokens` is renamed to `InputTokenCount`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - `OutputTokens` is renamed to `OutputTokenCount`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - `TotalTokens` is renamed to `TotalTokenCount`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Removed the common `ListOrder` enum from the top-level `OpenAI` namespace in favor of individual enums in their corresponding sub-namespace. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed the `PageSize` property to `PageSizeLimit`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Updated deletion methods to return a result object instead of a `bool`. Affected methods:
  - `DeleteAssitant`, `DeleteMessage`, and `DeleteThread` in `AssistantClient`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - `DeleteVectorStore` and `RemoveFileFromStore` in `VectorStoreClient`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - `DeleteModel` in `ModelClient`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
  - `DeleteFile` in `FileClient`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Removed setters from collection properties. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed `ChatTokenLogProbabilityInfo` to `ChatTokenLogProbabilityDetails`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed `ChatTokenTopLogProbabilityInfo` to `ChatTokenTopLogProbabilityDetails`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed the `Utf8ByteValues` properties of `ChatTokenLogProbabilityDetails` and `ChatTokenTopLogProbabilityDetails` to `Utf8Bytes` and changed their type from `IReadOnlyList<int>` to `ReadOnlyMemory<byte>?`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed the `Start` and `End` properties of `TranscribedSegment` and `TranscribedWord` to `StartTime` and `EndTime`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Changed the type of `TranscribedSegment`'s `AverageLogProbability` and `NoSpeechProbability` properties from `double` to `float`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Changed the type of `TranscribedSegment`'s `SeekOffset` property from `long` to `int`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Changed the type of `TranscribedSegment`'s `TokenIds` property from `IReadOnlyList<long>` to `IReadOnlyList<int>`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Updated the `Embedding.Vector` property to the `Embedding.ToFloats()` method. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Removed the optional parameter from the constructors of `VectorStoreCreationHelper`, `AssistantChatMessage`, and `ChatFunction`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Removed the optional `purpose` parameter from `FileClient.GetFilesAsync` and `FileClient.GetFiles` methods, and added overloads where `purpose` is required. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Renamed `ModerationClient`'s `ClassifyTextInput` methods to `ClassifyText`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Removed duplicated `Created` property from `GeneratedImageCollection`. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))

### Bugs Fixed

- Addressed an issue that caused multi-page queries of fine-tuning jobs, checkpoints, and events to fail. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- `ChatCompletionOptions` can now be serialized via `ModelReaderWriter.Write()` prior to calling `CompleteChat` using the options. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))

### Other Changes

- Added support for `CancellationToken` to `ModelClient` methods. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))
- Applied the `Obsolete` attribute where appropriate to align with the existing deprecations in the REST API. ([2ab1a94](https://github.com/openai/openai-dotnet/commit/2ab1a94269125e6bed45d134a402ad8addd8fea4))

## 2.0.0-beta.5 (2024-09-03)

This update increments library compatibility to `OpenAI 2.0.0-beta.11`, including several breaking changes.

### Features Added

- Added the `OpenAIChatModelFactory` in the `OpenAI.Chat` namespace (a static class that can be used to instantiate OpenAI models for mocking in non-live test scenarios). ([79014ab](https://github.com/openai/openai-dotnet/commit/79014abc01a00e13d5a334d3f6529ed590b8ee98))

### Breaking Changes

- Updated fine-tuning pagination methods `GetJobs`, `GetEvents`, and `GetJobCheckpoints` to return `IEnumerable<ClientResult>` instead of `ClientResult`. ([5773292](https://github.com/openai/openai-dotnet/commit/57732927575c6c48f30bded0afb9f5b16d4f30da))
- Updated the batching pagination method `GetBatches` to return `IEnumerable<ClientResult>` instead of `ClientResult`. ([5773292](https://github.com/openai/openai-dotnet/commit/57732927575c6c48f30bded0afb9f5b16d4f30da))
- Changed `GeneratedSpeechVoice` from an enum to an "extensible enum". ([79014ab](https://github.com/openai/openai-dotnet/commit/79014abc01a00e13d5a334d3f6529ed590b8ee98))
- Changed `GeneratedSpeechFormat` from an enum to an "extensible enum". ([cc9169a](https://github.com/openai/openai-dotnet/commit/cc9169ad2ff92bb7312eed3b7e64e45da5da1d18))
- Renamed `SpeechGenerationOptions`'s `Speed` property to `SpeedRatio`. ([cc9169a](https://github.com/openai/openai-dotnet/commit/cc9169ad2ff92bb7312eed3b7e64e45da5da1d18))

### Bugs Fixed

- Corrected an internal deserialization issue that caused recent updates to Assistants `file_search` to fail when streaming a run. Strongly typed support for `ranking_options` is not included but will arrive soon. ([cc9169a](https://github.com/openai/openai-dotnet/commit/cc9169ad2ff92bb7312eed3b7e64e45da5da1d18))
- Mitigated a .NET runtime issue that prevented `ChatResponseFormat` from serializing correct on targets including Unity. ([cc9169a](https://github.com/openai/openai-dotnet/commit/cc9169ad2ff92bb7312eed3b7e64e45da5da1d18))

## 2.0.0-beta.4 (2024-08-30)

This small release increments library compatibility to the latest `OpenAI 2.0.0-beta.10`. Prior to this update, interactions with the two breaking changes described below prevented full interoperability.

### Breaking Changes

- `AudioClient`'s `GenerateSpeechFromText()` method is renamed to `GenerateSpeech()`
- `OpenAIFileInfo`'s `SizeInBytes` is now of type `int?` (previously `long?`)

## 2.0.0-beta.3 (2024-08-23)

This change updates the library for compatibility with the latest `2.0.0-beta.9` of the `OpenAI` package and the `2024-07-01-preview` Azure OpenAI service API version label, as published on 8/5.

### Features Added

- The library now directly supports alternative authentication audiences, including Azure Government. This can be specified by providing an appropriate `AzureOpenAIAudience` value to the `AzureOpenAIClientOptions.Audience` property when creating a client. See the client configuration section of the README for more details.

Additional new features from the `OpenAI` package can be found in [the OpenAI changelog](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md).

**Please note**: Structured Outputs support is not yet available with the `2024-07-01-preview` service API version. This means that attempting to use the feature with this library version will fail with an unrecognized property for either `response_format` or `strict` in request payloads; all existing functionality is unaffected. Azure OpenAI support for Structured Outputs is coming soon.

### Breaking Changes

No Azure-specific breaking changes are present in this update.

The update from `OpenAI` `2.0.0-beta.7` to `2.0.0-beta.9` does bring a number of breaking changes, however, as described in [the OpenAI changelog](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md):

- Removed client constructors that do not explicitly take an API key parameter or an endpoint via an `OpenAIClientOptions` parameter, making it clearer how to appropriately instantiate a client. ([13a9c68](https://github.com/openai/openai-dotnet/commit/13a9c68647c8d54475f1529a63b13ad711bd4ba6))
- Removed the endpoint parameter from all client constructors, making it clearer that an alternative endpoint must be specified via the `OpenAIClientOptions` parameter. ([13a9c68](https://github.com/openai/openai-dotnet/commit/13a9c68647c8d54475f1529a63b13ad711bd4ba6))
- Removed `OpenAIClient`'s `Endpoint` `protected` property. ([13a9c68](https://github.com/openai/openai-dotnet/commit/13a9c68647c8d54475f1529a63b13ad711bd4ba6))
- Made `OpenAIClient`'s constructor that takes a `ClientPipeline` parameter `protected internal` instead of just `protected`. ([13a9c68](https://github.com/openai/openai-dotnet/commit/13a9c68647c8d54475f1529a63b13ad711bd4ba6))
- Renamed the `User` property in applicable Options classes to `EndUserId`, making its purpose clearer. ([13a9c68](https://github.com/openai/openai-dotnet/commit/13a9c68647c8d54475f1529a63b13ad711bd4ba6))
- Changed name of return types from methods returning streaming collections from `ResultCollection` to `CollectionResult`. ([7bdecfd](https://github.com/openai/openai-dotnet/commit/7bdecfd8d294be933c7779c7e5b6435ba8a8eab0))
- Changed return types from methods returning paginated collections from `PageableCollection` to `PageCollection`. ([7bdecfd](https://github.com/openai/openai-dotnet/commit/7bdecfd8d294be933c7779c7e5b6435ba8a8eab0))
- Users must now call `GetAllValues` on the collection of pages to enumerate collection items directly. Corresponding protocol methods return `IEnumerable<ClientResult>` where each collection item represents a single service response holding a page of values. ([7bdecfd](https://github.com/openai/openai-dotnet/commit/7bdecfd8d294be933c7779c7e5b6435ba8a8eab0))
- Updated `VectorStoreFileCounts` and `VectorStoreFileAssociationError` types from `readonly struct` to `class`. ([58f93c8](https://github.com/openai/openai-dotnet/commit/58f93c8d5ea080adfee8b37ae3cc034ebb06c79f))

### Bugs Fixed

- Removed an inappropriate null check in `FileClient.GetFiles()` (azure-sdk-for-net 44912)
- Addressed issues with automatic retry behavior, including for HTTP 429 rate limit errors:
  - Authorization headers are now appropriately reapplied to retried requests
  - Automatic retry behavior will now honor header-based intervals from `Retry-After` and related response headers
- The client will now originate an `x-ms-client-request-id` header to match prior library behavior and facilitate troubleshooting

Additional, non-Azure-specific bug fixes can be found in [the OpenAI changelog](https://github.com/openai/openai-dotnet/blob/main/CHANGELOG.md).

## 2.0.0-beta.2 (2024-06-14)

### Features Added

- Per changes to the [OpenAI .NET client library](https://github.com/openai/openai-dotnet), most convenience methods now provide the direct ability to provide optional `CancellationTokens`, removing the need to use protocol methods

### Breaking Changes

- In support of `CancellationToken`s in methods, an overriden method signature for streaming chat completions was changed and a new minimum version dependency of 2.0.0-beta.5 is established for the OpenAI dependency. These styles of breaks will be extraordinarily rare.

### Bugs Fixed

- See breaking changes: when streaming chat completions, an error of "Unrecognized request argument supplied: stream_options" is introduced when using Azure.AI.OpenAI 2.0.0-beta.1 with OpenAI 2.0.0-beta.5+. This is fixed with the new version.

## 2.0.0-beta.1 (2024-06-07)

**Please note**: This update brings a *major* set of changes to the Azure.AI.OpenAI library.

With the release of the official [OpenAI .NET client library](https://github.com/openai/openai-dotnet), the `Azure.AI.OpenAI` library has migrated to become a companion to OpenAI's package that offers Azure client configuration and strongly-typed extension support for Azure-specific request and response models.

**We'd love your feedback:** our goal is to move the new `OpenAI` .NET library and its refreshed `Azure.AI.OpenAI` companion into a General Availability status as quickly as we can; we've heard loud and clear that the perpetual preview/prerelease status is an adoption blocker. To reach that goal, your feedback -- either on the issues here, in `azure-sdk-for-net`, or the issues on the new `openai-dotnet` OpenAI repository -- will be invaluable.

### Features Added

**OpenAI parity**: built on the OpenAI .NET library, full parity support is available for the breadth of common features, including:

- Assistants V2 with streaming
- Audio transcription/translation and text-to-speech generation
- (Coming soon) Batch
- Chat completion
- Embeddings
- Files
- Fine-tuning
- Image generation with dall-e-3
- Vector stores

**Azure OpenAI**: updated to the latest `2024-05-01-preview` service API, new features include:

- Assistants v2 with streaming
- Improved configuration for On Your Data
- Expanded Responsible AI content filter annotations

### Breaking Changes

Given the nature of this update, breaking changes are extensive. Please see the README and the [OpenAI library README](https://github.com/openai/openai-dotnet/blob/master/README.md) for usage details. OpenAI's library carries forward many of the same design concepts as the Azure.AI.OpenAI library used as a standalone library, but considerable improvements have been made to the surface that will require significant code adjustments.

## 1.0.0-beta.17 (2024-05-03)

### Features Added

- Image input support for `gpt-4-turbo` chat completions now works with image data in addition to internet URLs.
  Images may be now be used as `gpt-4-turbo` message content items via one of three constructors:
  - `ChatMessageImageContent(Uri)` -- the existing constructor, used for URL-based image references
  - `ChatMessageImageContent(Stream,string)` -- (new) used with a stream and known MIME type (like `image/png`)
  - `ChatMessageImageContent(BinaryData,string)` -- (new) used with a BinaryData instance and known MIME type
  Please see the [readme example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md#chat-with-images-using-gpt-4-turbo) for more details.

### Breaking Changes

- Public visibility of the `ChatMessageImageUrl` type is removed to promote more flexible use of data sources in
  `ChatMessageImageContent`. Code that previously created a `ChatMessageImageUrl` using a `Uri` should simply provide
  the `Uri` to the `ChatMessageImageContent` constructor directly.

## 1.0.0-beta.16 (2024-04-11)

### Features Added

**Audio**

- `GetAudioTranscription()` now supports word-level timestamp granularities via `AudioTranscriptionOptions`:
  - The `Verbose` option for `ResponseFormat` must be used for any timing information to be populated
  - `TimestampGranularityFlags` accepts a combination of the `.Word` and `.Segment` granularity values in
    `AudioTimestampGranularity`, joined when needed via the single-pipe `|` operator
    - For example, `TimestampGranularityFlags = AudioTimestampGranularity.Word | AudioTimestampGranularity.Segment`
      will request that both word-level and segment-level timestamps are provided on the transcription result
  - If not otherwise specified, `Verbose` format will default to using segment-level timestamp information
  - Corresponding word-level information is found on the `.Words` collection of `AudioTranscription`, peer to the
    existing `.Segments` collection
  - Note that word-level timing information incurs a small amount of additional processing latency; segment-level
    timestamps do not encounter this behavior
- `GenerateSpeechFromText()` can now use `Wav` and `Pcm` values from `SpeechGenerationResponseFormat`, these new
  options providing alternative uncompressed formats to `Flac`

**Chat**

- `ChatCompletions` and `StreamingChatCompletionsUpdate` now include the reported `Model` value from the response
- Log probability information is now included in `StreamingChatCompletionsUpdate` when `logprobs` are requested on
  `GetChatCompletionsStreaming()`
- [AOAI] Custom Blocklist information in content filter results is now represented in a more structured
  `ContentFilterDetailedResults` type
- [AOAI] A new `IndirectAttack` content filter entry is now present on content filter results for prompts

### Breaking Changes

- [AOAI] `AzureChatExtensionMessageContext`'s `RequestContentFilterResults`  now uses the new
  `ContentFilterDetailedResults` type, changed from the previous `IReadOnlyList<ContentFilterBlockListIdResult>`. The
  previous list is now present on `CustomBlockLists.Details`, supplemented with a new `CustomBlockLists.Filtered`
  property.

### Bugs Fixed

- [AOAI] An issue that sometimes caused `StreamingChatCompletionUpdates` from Azure OpenAI to inappropriately exclude
  top-level information like `Id` and `CreatedAt` has been addressed

## 1.0.0-beta.15 (2024-03-20)

This release targets the latest `2024-03-01-preview` service API label and brings support for the `Dimensions` property when using new embedding models.

### Features Added

- `EmbeddingsOptions` now includes the `Dimensions` property, new to Azure OpenAI's `2024-03-01-preview` service API.

### Bugs Fixed

- Several issues with the `ImageGenerations` response object being treated as writeable are fixed:
  - `ImageGenerations` no longer has an erroneous public constructor
  - `ImageGenerations.Created` no longer has a public setter
  - `ImageGenerations.Data` is now an `IReadOnlyList` instead of an `IList`
  - A corresponding replacement factory method for mocks is added to `AzureOpenAIModelFactory`

## 1.0.0-beta.14 (2024-03-04)

### Features Added

- Text-to-speech using OpenAI TTS models is now supported. See [OpenAI's API reference](https://platform.openai.com/docs/api-reference/audio/createSpeech) or the [Azure OpenAI quickstart](https://learn.microsoft.com/azure/ai-services/openai/text-to-speech-quickstart) for detailed overview and background information.
  - The new method `GenerateSpeechFromText` exposes this capability on `OpenAIClient`.
  - Text-to-speech converts text into lifelike spoken audio in a chosen voice, together with other optional configurations.
  - This method works for both Azure OpenAI and non-Azure `api.openai.com` client configurations

### Breaking Changes

"On Your Data" changes:

- Introduced a new type `AzureChatExtensionDataSourceResponseCitation` for a more structured representation of citation data.
- Correspondingly, updated `AzureChatExtensionsMessageContext`:
  - Replaced `Messages` with `Citations` of type `AzureChatExtensionDataSourceResponseCitation`.
  - Added `Intent` as a string type.
- Renamed "AzureCognitiveSearch" to "AzureSearch":
  - `AzureCognitiveSearchChatExtensionConfiguration` is now `AzureSearchChatExtensionConfiguration`.
  - `AzureCognitiveSearchIndexFieldMappingOptions` is now `AzureSearchIndexFieldMappingOptions`.
- Check the project README for updated code snippets.

### Other Changes

- New properties in `ChatCompletionsOptions`:
  - `EnableLogProbabilities`: Allows retrieval of log probabilities (REST: `logprobs`)
  - `LogProbabilitiesPerToken`: The number of most likely tokens to return per token (REST: `top_logprobs`)
- Introduced a new property in `CompletionsOptions`:
  - `Suffix`: Defines the suffix that follows the completion of inserted text (REST: `suffix`)
- Image generation response now includes content filtering details (specific to Azure OpenAI endpoint):
  - `ImageGenerationData.ContentFilterResults`: Information about the content filtering results. (REST: `content_filter_results`)
  - `ImageGenerationData.PromptFilterResults`: Information about the content filtering category (REST: `prompt_filter_results`)
  
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
  - **NOTE**: Chat Functions requires a minimum of the `-0613` model versions for `gpt-4` and `gpt-3.5-turbo`/`gpt-35-turbo`. Please ensure you're using these later model versions, as Functions are not supported with older model revisions. For Azure OpenAI, you can update a deployment's model version or create a new model deployment with an updated version via the Azure AI Foundry interface, also accessible through Azure Portal.
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
- `CompletionsLogProbability.TokenLogProbability`, available on `Choice` elements of a `Completions` response value's `.Choices` collection when a non-zero `LogProbability` value is provided via `CompletionsOptions`, is now an `IReadOnlyList<float?>` vs. its previous type of `IReadOnlyList<float>`. This nullability addition accommodates circumstances where some tokens produce expected null values in log probability arrays.

### Bugs Fixed
- Setting `CompletionsOptions.Echo` to true while also setting a non-zero `CompletionsOptions.LogProbability` no longer results in a deserialization error during response processing.

## 1.0.0-beta.2 (2023-02-08)
### Bugs Fixed
- Adjusted bad name `finishReason` to `finish_reason` in deserializer class

## 1.0.0-beta.1 (2023-02-06)

### Features Added

- This is the initial preview release for Azure OpenAI inference capabilities, including completions and embeddings.
