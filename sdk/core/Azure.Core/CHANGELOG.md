# Release History

## 1.2.0-preview.1 (Unreleased)

### Added
- `AzureKeyCredential` and its respective policy.

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
