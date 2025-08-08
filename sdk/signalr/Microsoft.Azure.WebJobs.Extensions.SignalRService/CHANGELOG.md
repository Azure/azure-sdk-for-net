# Release History

## 2.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.1.0 (2025-07-25)

### Features Added
* Enable retry policy for HTTP requests with transient errors by default.

### Other Changes
* Upgrade `Microsoft.Extensions.Azure` to 1.12.0.

## 2.0.1 (2025-03-12)

### Bugs Fixed
* Fix SignalR trigger completion message serialization for dotnet-isolated worker.

## 2.0.0 (2025-03-04)

### Breaking Changes
* Modify `AddDefaultAuth` method in `SignalRFunctionsHostBuilderExtensions.cs` to use `IServiceCollection` instead of `IFunctionsHostBuilder` to remove the dependency for legacy package `Microsoft.Azure.Functions.Extensions`.

### Bugs Fixed
* Correctly support returning result for SignalR invocation in MessagePack protocol from isolated-worker process.

### Other Changes
* Update `MessagePack` to 2.5.192
* Update `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` to 1.29.0

## 1.15.0 (2024-10-14)

### Bugs Fixed
* Fixed the issue that the function return value from isolated-worker process is not handled correctly.

## 1.14.0 (2024-05-24)

### Other Changes
* Update `System.IdentityModel.Tokens.Jwt` to 6.35.0
* Update `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` to 1.25.2

## 1.13.0 (2024-02-06)

### Other Changes
* Update `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` to 1.24.0
* Update `Microsoft.Azure.SignalR.Serverless.Protocols` to 1.10.0

## 1.12.0 (2023-11-07)
### Features Added
* Added `RetryOptions` to `SignalROptions` to configure retry policy for SignalR Service REST API calls. For more infomation about customize retry options, see samples.
* Added `HttpClientTimeout` to `SignalROptions` to configure HTTP client timeout for SignalR Service REST API calls. The default value is 100 seconds. User can also set "AzureSignalRHttpClientTimeout" in the app settings to override the default value.

### Bugs Fixed
* Fixed the issue when using customized server endpoint with Azure AD credential.
* Fixed the issue that SignalR trigger is not working with secondary connection string.

### Other Changes
* Upgraded  `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` from 1.21.6 to 1.22.0

## 1.11.2 (2023-09-12)

### Bugs Fixed
* Fixed the issue when using customized server endpoint with Azure AD credential.

### Other Changes
* Upgraded  `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` from 1.21.4 to 1.21.6

## 1.11.0 (2023-06-17)

### Bugs Fixed
* Fixed the bug that a wrong exception is thrown when the SignalR connection is not found using REST API to close a connection or add a connection to group.

### Other Changes
* Upgraded  `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` to 1.21.4

## 1.10.0 (2023-04-11)

### Features Added
* Support MessagePack hub protocol for both persistent mode and transient mode.

### Other Changes
* Upgraded `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` from 1.19.2 to 1.21.2

## 1.9.0 (2023-01-12)

### Bugs Fixed
* Fixed the bug that the arguments are required in a SignalR message for isolated-process

### Other Changes
* Upgraded `Microsoft.Azure.SignalR`, `Microsoft.Azure.SignalR.Management`, `Microsoft.Azure.SignalR.Protocols` from 1.16.1 to 1.19.2
* Upgraded MessagePack for performance and security improvements.

## 1.8.0 (2022-04-07)

### Features Added
* Added `SignalROptions`. Users can configure service endpoints, service transport type, and [JSON object serialization](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/signalr/Microsoft.Azure.WebJobs.Extensions.SignalRService/samples/Sample02_CustomizingJsonSerialization.md) with `SignalROptions` in the startup class.
* Support customizing client endpoint and server endpoint in multiple ways. It is useful when you want to integrate with application gateway. [Go here for more details.](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/signalr/Microsoft.Azure.WebJobs.Extensions.SignalRService/samples/Sample03_IntegrationWithAppGateway.md)

### Bugs Fixed
* Fixed the message order problem.
* Fixed the ack-able message timeout problem when multiple SignalR endpoints exist.

## 1.7.0 (2022-02-22)
**Following are the all changes in 1.7.0-beta.2 and 1.7.0-beta.1 versions.**

### Features Added
* `SignalRConnectionAttribute` can be used to customize the connection name of strongly typed serverless hub too. Usage:
    ```cs
    [SignalRConnection("SignalRConnection")]
    public class CustomConnectionHub : ServerlessHub<IChatClient>
    {
    }
    ```
    ```json
    {
        "Values":{
            "SignalRConnection":"Your-Connection-String"
        }
    }
    ```
* Added built-in string constants for SignalR trigger: `SignalRTriggerCategories.Connections` for "connections", `SignalRTriggerCategories.Messages` for "messages", `SignalRTriggerEvents.Connected` for "connected", `SignalRTriggerEvents.Disconnected` for "disconnected".
* Added strongly typed serverless hub. See [sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/signalr/Microsoft.Azure.WebJobs.Extensions.SignalRService/samples/Sample01_StronglyTypedHub.md) for more details.
* Enabled SignalR trigger to use identity-based connection.

### Bugs Fixed
* Fix a `ServiceEndpoints` binding bug that creating new persistent connections for each request.
* Fixed the bug that the function host could not be shutdown locally on Functions V3 runtime.
* Fixed the package restoring issue on .NET 5 and above.

## 1.7.0-beta.2 (2022-02-14)

### Features Added
* `SignalRConnectionAttribute` can be used to customize the connection name of strongly typed serverless hub too. Usage:
    ```cs
    [SignalRConnection("SignalRConnection")]
    public class CustomConnectionHub : ServerlessHub<IChatClient>
    {
    }
    ```
    ```json
    {
        "Values":{
            "SignalRConnection":"Your-Connection-String"
        }
    }
    ```
* Added built-in string constants for SignalR trigger: `SignalRTriggerCategories.Connections` for "connections", `SignalRTriggerCategories.Messages` for "messages", `SignalRTriggerEvents.Connected` for "connected", `SignalRTriggerEvents.Disconnected` for "disconnected".

### Bugs Fixed
* Fix a `ServiceEndpoints` binding bug that creating new persistent connections for each request.

### Other Changes
* Update dependency `Microsoft.Azure.SignalR.Management` version from 1.13.0 to 1.15.1.

## 1.7.0-beta.1 (2021-12-07)
### Features Added
* Added strongly typed serverless hub. See [sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/signalr/Microsoft.Azure.WebJobs.Extensions.SignalRService/samples/Sample01_StronglyTypedHub.md) for more details.
* Enabled SignalR trigger to use identity-based connection.

### Bugs Fixed
* Fixed the bug that the function host could not be shutdown locally on Functions V3 runtime.
* Fixed the package restoring issue on .NET 5 and above.

