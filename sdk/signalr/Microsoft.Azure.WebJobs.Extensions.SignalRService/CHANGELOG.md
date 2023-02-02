# Release History

## 1.10.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
* Fixed the ackable message timeout problem when multiple SignalR endpoints exist.

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

