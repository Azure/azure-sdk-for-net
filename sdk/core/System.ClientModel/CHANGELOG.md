# Release History

## 1.7.0 (2025-09-22)

### Features Added

- Added `ClientConnection` constructor, accepting credentials and metadata.

- Added `JsonPatch` which allows for applying JSON Patch operations to JSON documents.
## 1.6.1 (2025-08-20)

### Features Added

- Fix the behavior of Roslyn not properly handling partial classes with attributes in different files

## 1.6.0 (2025-08-11)

### Features Added

- Added `UserAgentPolicy` pipeline policy to allow adding the user agent to the request headers.

### Other Changes

- Various updates to the `System.ClientModel.SourceGeneration` package to support `ModelReaderWriterBuildableAttribute`.

## 1.5.1 (2025-07-14)

### Bugs Fixed

- Fixed an issue where System.ClientModel.SourceGeneration was running slowly for large projects with many dependencies.

### Breaking Changes

- The System.ClientModel.SourceGeneration used to auto-discover `IJsonModel<T>`'s that were in the project as well as any types `T` used in `ModelReaderWriter.Read<T>` and `ModelReaderWriter.Write<T>`.  Now you must explicitly add a `ModelReaderWriterBuildableAttribute` with each type that needs to have AOT friendly reading and writing.

## 1.5.0 (2025-07-07)

### Features Added

- Added the following types for 3rd-party Authentication support: `AuthenticationTokenProvider`, `GetTokenOptions`, `AuthenticationToken`, `AuthenticationPolicy`, and `BearerTokenPolicy`.

### Breaking Changes

- **Source Breaking Change**: Updated `IJsonModel<T>.Create` and `IPersistableModel<T>.Create` method return types from `T` to `T?` to allow returning `null` when deserialization fails. This change only affects code with nullable reference types enabled.
  - **For consumers calling these methods**: To fix compilation errors, either:
    - Use null-conditional operators (`?.`) when calling these methods, or
    - Add null-forgiving operators (`!`) if you're certain the result won't be null, or
    - Add explicit null checks before using the returned value
  - **For implementers of these interfaces**: Update method signatures in your models to return `T?` instead of `T`, and decide whether to return `null` or throw exceptions in error scenarios

## 1.5.0-beta.1 (2025-06-13)

### Features Added

- Added the following types for 3rd-party Authentication support: `AuthenticationTokenProvider`, `GetTokenOptions`, `AuthenticationToken`, `AuthenticationPolicy`, and `BearerTokenPolicy`.

## 1.4.2 (2025-06-05)

### Bugs Fixed

- First part of performance improvements for System.ClientModel.SourceGeneration to shorten lengthy builds.

## 1.4.1 (2025-05-09)

### Bugs Fixed

- Fixed an issue when a model builder was both IEnumerable and IPersistable.

## 1.4.0 (2025-05-02)

### Features Added

- Added additional supported scenarios to System.ClientModel.SourceGeneration.

### Other Changes

- Upgraded versions of dependencies on System.Diagnostics.DiagnosticSource, System.Text.Json, and Microsoft.Extensions.Logging.Abstractions.
- Renamed `ActivityExtensions.MarkFailed` to `ActivityExtensions.MarkClientActivityFailed`.
- Made `int maxSize` parameter to `ClientCache` constructor required and removed default value.
- Changed `IEquatable<object> clientId` parameter to `object clientId` in `ClientCache.GetClient`
- Renamed `ConnectionCollection` to `ClientConnectionCollection`
- Renamed `ConnectionProvider` to `ClientConnectionProvider`
- Renamed `ToCollection` to `ConvertCollectionBuilder` in `ModelReadWriteTypeBuilder`
- Renamed `AddKeyValuePair` to `AddItemWithKey` in `ModelReadWriteTypeBuilder`

## 1.4.0-beta.6 (2025-04-28)

### Features Added

- Added additional supported scenarios to System.ClientModel.SourceGeneration.

## 1.4.0-beta.5 (2025-04-23)

### Features Added

- Added additional supported scenarios to System.ClientModel.SourceGeneration.

## 1.4.0-beta.4 (2025-04-21)

### Features Added

- Added additional supported scenarios to System.ClientModel.SourceGeneration.

## 1.4.0-beta.3 (2025-04-16)

### Bugs Fixed

- System.ClientModel.SourceGeneration adds the Default property even when no type builders exist.

## 1.4.0-beta.2 (2025-04-14)

### Features Added

- Added extensions to `System.Diagnostics.Activity` and `System.Diagnostics.ActivitySource` to simplify instrumentation of client libraries
- Added new overloads to `System.ClientModel.ModelReaderWriter` which take in a new
[ModelReaderWriterContext](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md)
which allows reading and writing of collections of `IPersistableModel<>`.  In addition any calls to the new overloads are AOT compatible.

## 1.4.0-beta.1 (2025-03-06)

### Features Added

- Added new connection management types in the `System.ClientModel.Primitives` namespace:
  - `ConnectionProvider`: Abstract base class for managing client connections, including retrieval of connection settings and subclient caching.
  - `ClientConnection`: Readonly struct that encapsulates connection options with support for API key, token, or no authentication.
  - `ConnectionCollection`: A keyed collection of client connections, supporting JSON serialization and providing an enhanced debugger view.
  - `ClientCache`: Implements an LRU-based cache for efficient reuse of client instances and optimized retrieval.

### Bugs Fixed

- Removed debugging statement in pipeline creation when applying the `ClientLoggingOptions.AllowedHeaderNames` option.

## 1.3.0 (2025-02-11)

### Features Added

- Added default logging with sanitization to Event Source.
  - Added new logging options type to configure logging behavior, disable all logging, or opt to use ILogger instead.

### Other Changes

- Use `BinaryData.Empty` for `PipelineResponse.Content` when HTTP message has no content ([#46669](https://github.com/Azure/azure-sdk-for-net/pull/46669)).

## 1.2.1 (2024-10-09)

### Bugs Fixed

- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix ([#46134](https://github.com/Azure/azure-sdk-for-net/pull/46508)).

## 1.2.0 (2024-10-03)

### Other Changes

- Upgraded `System.Memory.Data` package dependency to 6.0.0 ([#46134](https://github.com/Azure/azure-sdk-for-net/pull/46134)).

## 1.1.0 (2024-09-17)

### Other Changes

- Removed implicit cast from `string` to `ApiKeyCredential` ([#45554](https://github.com/Azure/azure-sdk-for-net/pull/45554)).
- Upgraded `System.Text.Json` package dependency to 6.0.9 ([#45416](https://github.com/Azure/azure-sdk-for-net/pull/45416)).
- Removed `PageCollection<T>` and related types in favor of using `CollectionResult<T>` and related types as the return values from paginated service endpoints ([#45961](https://github.com/Azure/azure-sdk-for-net/pull/45961)).

## 1.1.0-beta.7 (2024-08-14)

### Features Added

- Added `JsonModelConverter` to allow integration with System.Text.Json.

### Other Changes

- Removed `ReturnWhen` enum in favor of using bool `waitUntilCompleted` parameter in third-party client LRO method signatures.
- Added abstract `UpdateStatus` method to `OperationResult`.

## 1.1.0-beta.6 (2024-08-01)

### Features Added

- Added `OperationResult` and `ReturnWhen` types to support long-running operations.

### Bugs Fixed

- Added support for delaying retrying a request until after the interval specified on a response `Retry-After` header.

## 1.1.0-beta.5 (2024-07-11)

### Features Added

- Added `AsyncPageCollection<T>` and `PageCollection<T>` types as return types from paginated service operations, and `ContinuationToken` type for resuming collection state across processes.

### Other Changes

- Renamed `AsyncResultCollection<T>` and `ResultCollection<T>` to `AsyncCollectionResult<T>` and `CollectionResult<T>` to standardize use of the `Result` suffix in type names.
- Removed `AsyncPageableCollection<T>` and `PageableCollection<T>` that previously represented collections of items rather than collections of pages of items, and renamed `ResultPage<T>` to `PageResult<T>`.

## 1.1.0-beta.4 (2024-05-16)

### Features Added

- Added `BufferResponse` property to `RequestOptions` so protocol method callers can turn off response buffering if desired.
- Added `AsyncResultCollection<T>` and `ResultCollection<T>` for clients to return from service methods where the service response contains a collection of values.
- Added `AsyncPageableCollection<T>`, `PageableCollection<T>` and `ResultPage<T>` for clients to return from service methods where collection values are delivered to the client over one or more service responses.
- Added `SetRawResponse` method to `ClientResult` to allow the response held by the result to be changed, for example by derived types that obtain multiple responses from polling the service.

### Other Changes

- `ClientResult.GetRawResponse` will now throw `InvalidOperationException` if called before the result's raw response is set, for example by collection result types that delay sending a request to the service until the collection is enumerated.

## 1.1.0-beta.3 (2024-04-04)

### Features Added

- Added protected `Apply(PipelineMessage)` method to `RequestOptions` so that derived types can extend its functionality.
- Added `Create(Stream)` overload to `BinaryContent`.

### Other Changes

- Removed `[Serializable]` attribute and serialization constructor from `ClientResultException`.
- Made `value` parameter nullable in `PipelineMessage.SetProperty` method.
- Made `options` parameter to `PipelineMessage.Apply` nullable.

## 1.1.0-beta.2 (2024-02-29)

### Features Added

- Added `ExtractResponse` method to `PipelineMessage` to enable returning an undisposed `PipelineResponse` from protocol methods.
- Added `CreateAsync` factory method to `ClientResultException` to allow creating exceptions in an async context.
- Added an implicit cast from `string` to `ApiKeyCredential`.
- Added an implicit cast from `ClientResult<T>` to `T`.

### Other Changes

- Changed `HttpClientPipelineTransport.Shared` and `ClientRetryPolicy.Default` from static readonly fields to static properties.
- Changed `PipelineResponse.Content` property from abstract to virtual.
- Removed the `ResponseBufferingPolicy` and moved response buffering functionality into `PipelineTransport`.
- Made `CancellationToken` parameter passed to `BinaryContent.WriteTo` optional.

## 1.1.0-beta.1 (2024-02-01)

### Features Added

- Initial preview release of convenience types in the System.ClientModel namespace, including `ClientResult<T>`, `KeyCredential`, and `ClientResultException`.
- Initial preview release of pipeline types, including `ClientPipeline`, `PipelinePolicy`, and `PipelineMessage`.

## 1.0.0 (2024-01-03)

### Features Added

- Initial release of ModelReaderWriter APIs for reading and writing models in different formats.

## 1.0.0-beta.2 (2023-12-14)

### Other Changes

- `ModelReaderWriter` and `ModelReaderWriterOptions` have moved to System.ClientModel.Primitives namespace
- `JsonModelConverter` was removed.

## 1.0.0-beta.1 (2023-11-22)

### Features Added

- ModelReaderWriter APIs for reading and writing models in different formats.
