# Release History

## 1.4.1 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 1.4.0 (2020-08-06)

### Added
- Added `ObjectSerializer` base class for serialization.
- Added `IMemberNameConverter` for converting member names to serialized property names.
- Added `JsonObjectSerializer` that implements `ObjectSerializer` for `System.Text.Json`.

### Fixed
- Connection leak for retried non-buffered requests on .NET Framework.

## 1.3.0 (2020-07-02)

### Added
- `HttpPipeline.CreateClientRequestIdScope` method to allow setting client request id on outgoing requests.

## 1.2.2 (2020-06-04)

### Bugfix
- Retry server timeouts on .NET Framework.

## 1.2.1  (2020-04-30)

### Changed
- Read client request ID value used for logging and tracing off the initial request object if available.

### Bugfix
- Fixed a bug when using Azure.Core based libraries in Blazor WebAssembly apps.

## 1.2.0 (2020-04-03)

### Added
- `AzureKeyCredential` and its respective policy.

### Changed
- Response trace messages are properly identified.
- Content type "application/x-www-form-urlencoded" is decoded in trace messages.

## 1.1.0 (2020-03-05)

### Fixes and improvements
- Add OPTIONS and TRACE HTTP request methods.
- Add `NetworkTimeout` property to `RetryOptions` and apply it to network operations like sending request or reading from the response stream.
- Implement serialization for RequestFailedException.

## 1.0.2 (2020-01-10)

- Block bearer token authentication for non TLS protected endpoints.
- Add support for retrying on request timeouts.
- Add support for retrying on 408, 500, 502, 504 status codes.
- Remove commit hash from User-Agent telemetry.

## 1.0.1

- Fix issues with log redaction where first query character was replaced with '?' character.
- Exclude EventCounter events from AzureEventSourceListener.
- Add `AZURE_TRACING_DISABLED` environment variable support.

## 1.0.0

- Updating versioning and packaging for general availability.
- Make types and namespace names consistent.

## 1.0.0-preview.9

- Added console and trace logger listener.
- Added additional content and header logging options.
- Moved commonly used types to Azure namespace.

## 1.0.0-preview.8

- Minor improvements and bug fixes.

## 1.0.0-preview.7

- Support for distributed tracing added.
- Support for TokenCredential in ASP.NET Core integration added.
Shared types for long running operations and async collections added.
- .NET Core dependencies updated to preview7.
- Bug fixes.
