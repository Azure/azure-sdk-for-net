# Azure Iot Hub Service API Design Doc

This document outlines the APIs for the Azure Iot Hub Service SDK.

#### Type definition names

<details>

```text
Configuration - TwinConfiguration
Module - ModuleIdentity
Device - DeviceIdentity
Twin - TwinData
Interface - PnpInterface
Property - PnpProperty
Reported - PnpReported
Desired - PnpDesired
```

</details>

#### Constructors

<details>

We can get the shared access policy and the shared access key from the Azure portal. Alternatively, we can also get the connection string directly from the Azure portal.

```csharp
string connectionString = "HostName=<hub_hostname>.azure-devices.net;SharedAccessKeyName=<shared_access_policy>;SharedAccessKey=<shared_access_key>";
```

The client can now be initialized using:

Option 1:

```csharp
var endpoint = new Uri("http:<hub_hostname>.azure-devices.net");
// TimeSpan.FromMinutes(5) is the sas token time to live (optional).
var credential = new IotHubSasCredential("shared_access_policy", "shared_access_key", TimeSpan.FromMinutes(5));
var client = new IotHubServiceClient(endpoint, credential);
```

Option 2:

```csharp
var client = new IotHubServiceClient(connectionString);
```

```csharp
/// <summary>
/// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
/// </summary>
/// <param name="connectionString">
/// The IoT Hub connection string, with either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
/// For more information, see <see href="https://learn.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
/// </param>
public IotHubServiceClient(string connectionString) {}

/// <summary>
/// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
/// </summary>
/// <param name="connectionString">
/// The IoT Hub connection string, with either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
/// For more information, see <see href="https://learn.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
/// </param>
/// <param name="options">
/// Options that allow configuration of requests sent to the IoT Hub service.
/// </param>
public IotHubServiceClient(string connectionString, IotHubServiceClientOptions options) {}

/// <summary>
/// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
/// </summary>
/// <param name="endpoint">
/// The IoT Hub service instance endpoint to connect to.
/// </param>
/// <param name="credential">
/// The IoT Hub credentials, to be used for authenticating against an IoT Hub instance via SAS tokens.
/// </param>
/// <param name="options">
/// Options that allow configuration of requests sent to the IoT Hub service.
/// </param>
public IotHubServiceClient(Uri endpoint, IotHubSasCredential credential, IotHubServiceClientOptions options = default) {}

// TODO: Will be added once service implements OAuth support

/// <summary>
/// Initializes a new instance of the <see cref="IotHubServiceClient"/> class.
/// </summary>
/// <param name="endpoint">
/// The IoT Hub service instance endpoint to connect to.
/// </param>
/// <param name="credential">
/// The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.
///</param>
/// <param name="options">
/// Options that allow configuration of requests sent to the IoT Hub service.
/// </param>
public IotHubServiceClient(Uri endpoint, TokenCredential credential, IotHubServiceClientOptions options = default) {}
```

</details>

#### Configurations
APIs for managing configurations for devices and modules.

<details>

```csharp
/// <summary>
/// Gets a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configurationId">The unique identifier of the configuration.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The retrieved automatic device/module management twin configuration</returns>
public virtual async Task<Response<TwinConfiguration>> GetConfigurationAsync(string configurationId, CancellationToken cancellationToken = default)

/// <summary>
/// Create or update a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configuration">Twin configuration to update</param>
/// <param name="precondition">The condition on which to perform this operation</param>
/// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
/// In case of update, if no ETag is present on the twin configuration, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The created automatic device/module management twin configuration</returns>
public virtual async Task<Response<TwinConfiguration>> CreateOrUpdateConfigurationAsync(TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)

/// <summary>
/// Deletes a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configuration">Twin configuration to delete</param>
/// <param name="precondition">The condition on which to perform this operation. If no ETag is present on the twin configuration, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>."/>.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The http response <see cref="Response{T}"/>.</returns>
public virtual async Task<Response> DeleteConfigurationAsync(TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)

/// <summary>
/// Gets configurations on the IoT Hub for automatic device/module management. Pagination is not supported.
/// </summary>
/// <param name="count">The number of configurations to retrieve. TODO: Can value be overriden if too large?.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The retrieved list of automatic device/module management twin configurations</returns>
public virtual async Task<Response<IReadOnlyList<TwinConfiguration>>> GetConfigurationsAsync(int? count = null, CancellationToken cancellationToken = default)

/// <summary>
/// Validates target condition and custom metric queries for a configuration on the IoT Hub.
/// </summary>
/// <param name="configuration">The configuration for target condition and custom metric queries.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The result of validated test queries of automatic device/module management twin configuration</returns>
public virtual async Task<Response<ConfigurationQueriesTestResponse>> TestQueriesAsync(ConfigurationQueriesTestInput configuration, CancellationToken cancellationToken = default)

/// <summary>
/// Applies the provided configuration content to the specified edge device.
/// </summary>
/// <param name="deviceId">The unique identifier of the edge device.  TODO <service team>: Is it just device or edge device?".</param>
/// <param name="content">Configuration Content. TODO <service team>: Get more context</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The http response <see cref="Response{T}"/>.</returns>
public virtual async Task<Response> ApplyOnEdgeDeviceAsync(string deviceId, ConfigurationContent content, CancellationToken cancellationToken = default)
```

</details>

#### Statistics
APIs for getting statistics about devices and modules, as well as service statistics.

<details>

```csharp

```

</details>

#### Devices
APIs for managing device identities, device twins, and querying devices.

This sub-client has been implemented. Refer to [DevicesClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/iot/Azure.IoT.Hub.Service/src/DevicesClient.cs).

#### Modules
APIs for managing module identities, module twins, and querying modules.

This sub-client has been implemented. Refer to [ModulesClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/iot/Azure.IoT.Hub.Service/src/ModulesClient.cs).

#### Jobs
APIs for using IotHub v2 jobs.

<details>

```csharp

```

</details>

#### Messages
Sending cloud to device messages (missing from current swagger), feedback messages, and purging cloud to device message queue.

<details>

```csharp
```
</details>

#### Files
APIs for getting file upload notifications (missing from current swagger).

<details>

```csharp
```

</details>

#### Fault Injection
We will not be exposing these.

<details>

```csharp
```

</details>

#### Query
APIs for querying on device or module identities.

<details>

```csharp
```

</details>
