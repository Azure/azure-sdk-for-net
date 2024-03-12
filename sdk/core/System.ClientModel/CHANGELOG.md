# Release History

## 1.1.0-beta.3 (Unreleased)

### Features Added

- Added protected `Apply(PipelineMessage)` method to `RequestOptions` so that derived types can extend its functionality.

### Breaking Changes

- Removed `[Serializable]` attribute and serialization constructor from `ClientResultException`.
- Made `value` parameter nullable in `PipelineMessage.SetProperty` method.

### Bugs Fixed

### Other Changes

## 1.1.0-beta.2 (2024-02-29)

### Features Added

- Added `ExtractResponse` method to `PipelineMessage` to enable returning an undisposed `PipelineResponse` from protocol methods.
- Added `CreateAsync` factory method to `ClientResultException` to allow creating exceptions in an async context.
- Added an implicit cast from `string` to `ApiKeyCredential`.
- Added an implicit cast from `ClientResult<T>` to `T`.

### Breaking Changes

- Changed `HttpClientPipelineTransport.Shared` and `ClientRetryPolicy.Default` from static readonly fields to static properties.
- Changed `PipelineResponse.Content` property from abstract to virtual.
- Removed the `ResponseBufferingPolicy` and moved response buffering functionality into `PipelineTransport`.

### Other Changes

- Made `CancellationToken` parameter passed to `BinaryContent.WriteTo` optional.

## 1.1.0-beta.1 (2024-02-01)

### Features Added

- Initial preview release of convenience types in the System.ClientModel namespace, including `ClientResult<T>`, `KeyCredential`, and `ClientResultException`.
- Initial preview release of pipeline types, including `ClientPipeline`, `PipelinePolicy`, and `PipelineMessage`.

## 1.0.0 (2024-01-03)

### Features Added

- Initial release of ModelReaderWriter APIs for reading and writing models in different formats.

## 1.0.0-beta.2 (2023-12-14)

### Breaking Changes

- `ModelReaderWriter` and `ModelReaderWriterOptions` have moved to System.ClientModel.Primitives namespace
- `JsonModelConverter` was removed.

## 1.0.0-beta.1 (2023-11-22)

### Features Added

- ModelReaderWriter APIs for reading and writing models in different formats.
