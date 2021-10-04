# Release History

## 1.20.0 (2021-10-01)

### Features Added

- Added the static `DelegatedTokenCredential` type with a `Create` method, which returns an instance of `TokenCredential` that uses the supplied delgates to produce an `AccessToken`. This would most typically be used when an token has previously been obtained from some other source and that token needs to be returned by a `TokenCredential` instance.
- Added `ResponseError` type to represent an Azure error type.
- Added an experimental `ActivitySource` support.

### Bugs Fixed

- Fixed an exception during EventSource creation on Xamarin.

## 1.19.0 (2021-09-07)

- Added `HttpAuthorization` to represent authentication information in Authorization, ProxyAuthorization, WWW-Authenticate, and Proxy-Authenticate header values.

## 1.18.0 (2021-08-18)


### Bugs Fixed

- Fixed a bug where a buffered error responses on .NET Framework were prematurely disposed
- Fixed relative redirect support.

## 1.17.0 (2021-08-10)

### Features Added

- Added `ClientOptions.Default` to configure defaults process-wide.
- Added `HttpPipelinePosition.BeforeTransport` to be able to add policies at the end of the pipeline before the transport.

### Fixed

- Fixed `NotSupportedException` when running in Unity.

## 1.16.0 (2021-06-30)

### Changed

- Added `TenantId` to the properties on `TokenRequestContext` to enable multi-tenant support in Azure.Identity.

## 1.15.0 (2021-06-08)

### Features Added

- Types to represent `GeoJson` primitives.

### Changed

- `Response.Content` no longer throws `InvalidOperationException` when the response is backed by a `MemoryStream` with a non publicly visible buffer.

## 1.14.0 (2021-05-11)

### Features Added

- Added additional methods to `BearerTokenAuthenticationPolicy`, which enables creation of authentication policies that can handle challenges.

## 1.13.0 (2021-04-07)

### Key Bug Fixes

- Fixed `NotSupportedException` when running using Blazor in the browser.
- Disable the response caching and enable the streaming when running using Blazor in the browser.

## 1.12.0 (2021-04-06)

### Features Added

- Added `HttpPipeline.CreateHttpMessagePropertiesScope` that can be used to inject scoped properties into `HttpMessage`.

## 1.11.0 (2021-03-22)

### Features Added

- `Operation` base class for operations that do not return a value.
- Added `Content` property to `Response` which returns the body of the response as a `BinaryData` if the body is buffered.
- `AzureNamedKeyCredential` has been implemented to cover scenarios where services require that a shared key name and the key value be used as a component of the algorithm to form the authorization token.

### Key Bug Fixes

- Check the `JsonIgnoreAttribute.Condition` property added in .NET 5 when discovering members with `JsonObjectSerializer`.
- `ETag` now returns `string.Empty` if it is constructed with a null value.
- Keep-Alive connections are recycled every 300 seconds to observe DNS changes.

## 1.10.0 (2021-03-09)

## Features Added

- Added `CloudEvent` type based on the [CloudEvent spec](https://github.com/cloudevents/spec/blob/master/spec.md).

## 1.9.0 (2021-02-09)

## Features Added
- Added Serialize overloads on `ObjectSerializer` that serialize to `BinaryData`.
- Added AzureCoreExtensions containing extensions methods for `BinaryData` that allow deserializing with an `ObjectSerializer`.

### Key Bug Fixes

- Avoid `ObjectDisposedException` when the request is cancelled during content upload over HTTPS.
- Fix exception while setting `If-Modified-Since` header on .NET Framework.

## 1.8.1 (2021-01-11)

### Key Bug Fixes

- Include `Microsoft.Bcl.AsyncInterfaces` dependency on .NET 5 to avoid build issues in applications targeting .NET 5.

## 1.8.0 (2021-01-06)

### Features Added
- `AzureSasCredential` and its respective policy.

### Key Bug Fixes
- Avoid a causing and ignoring an exception when setting network stream timeout on .NET Core 

## 1.7.0 (2020-12-14)

### New Features
- `System.Text.Json.JsonConverter` implementation for the `ETag`
- Synchronous `HttpClient` support on .NET 5.

### Key Bug Fixes
- System proxy settings are correctly applied on .NET Framework

## 1.6.0 (2020-10-28)

### Features Added
- The `HttpClientTransport(HttpMessageHandler)` constructor overload.
- The `JsonPatchDocument` type.

### Key Bugs Fixed
- The race condition in `AzureEventSourceListener` class that sometimes resulted in a `NullReferenceException` in the `EventSource`.
- The overflow exception when content length is larger than `int.MaxValue`.

## 1.5.1 (2020-10-01)

### Changed
- `ServicePointManager` Connection limit is automatically increased to `50` for Azure endpoints. 


## 1.5.0 (2020-09-03)

### Changed
- `ETag` now supports weak ETags and implements an overload for `ToString` that accepts a format string.

### Features Added
- HttpWebRequest-based transport implementation. Enabled by-default on .NET Framework. Can be disabled using `AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT` environment variable or `Azure.Core.Pipeline.DisableHttpWebRequestTransport` AppContext switch. To use the app context switch add the following snippet to your `.csproj`:

```xml
 <ItemGroup>
    <RuntimeHostConfigurationOption Include="Azure.Core.Pipeline.DisableHttpWebRequestTransport" Value="true" />
  </ItemGroup> 
```

When the environment variable or the switch are set the `HttpClientTransport` would be used by default instead.

## 1.4.1 (2020-08-18)

### Key Bugs Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 1.4.0 (2020-08-06)

### Features Added
- Added `ObjectSerializer` base class for serialization.
- Added `IMemberNameConverter` for converting member names to serialized property names.
- Added `JsonObjectSerializer` that implements `ObjectSerializer` for `System.Text.Json`.

### Key Bugs Fixed
- Connection leak for retried non-buffered requests on .NET Framework.

## 1.3.0 (2020-07-02)

### Features Added
- `HttpPipeline.CreateClientRequestIdScope` method to allow setting client request id on outgoing requests.

## 1.2.2 (2020-06-04)

### Key Bugs Fixed
- Retry server timeouts on .NET Framework.

## 1.2.1 (2020-04-30)

### Changed
- Read client request ID value used for logging and tracing off the initial request object if available.

### Key Bugs Fixed
- Fixed a bug when using Azure.Core based libraries in Blazor WebAssembly apps.

## 1.2.0 (2020-04-03)

### Features Added
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
