# Azure Iot Hub Service API Design Doc

This document outlines the APIs for the Azure Iot Hub Service SDK

<details><summary><b>Type definition names</b></summary>

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

<details><summary><b>Constructors</b></summary>

```csharp

```

</details>

<details><summary><b>Configurations</b></summary>

APIs for managing configurations for devices and modules

```csharp
/// <summary>
/// Gets a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configurationId">The unique identifier of the configuration.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>TwinConfiguration for a automatic device/module management</returns>
public virtual async Task<Response<TwinConfiguration>> GetConfigurationAsync(string configurationId, CancellationToken cancellationToken = default)

/// <summary>
/// Creates a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configurationId">The unique identifier of the configuration.</param>
/// <param name="configuration">Twin configuration to create</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>TwinConfiguration for a automatic device/module management</returns>
public virtual async Task<Response<TwinConfiguration>> CreateConfigurationAsync(string configurationId, TwinConfiguration configuration, CancellationToken cancellationToken = default)

/// <summary>
/// Updates a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configurationId">The unique identifier of the configuration.</param>
/// <param name="configuration">Twin configuration to update</param>
/// <param name="precondition">The condition on which to perform this operation</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>TwinConfiguration for a automatic device/module management</returns>
public virtual async Task<Response<TwinConfiguration>> UpdateConfigurationAsync(string configurationId, TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)

/// <summary>
/// Deletes a configuration on the IoT Hub for automatic device/module management
/// </summary>
/// <param name="configurationId">The unique identifier of the configuration.</param>
/// <param name="precondition">The condition on which to perform this operation</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The Http Response</returns>
public virtual async Task<Response> DeleteConfigurationAsync(string configurationId, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)

/// <summary>
/// Gets configurations on the IoT Hub for automatic device/module management. Pagination is not supported.
/// </summary>
/// <param name="count">The number of configurations to retrieve. TODO: Can value be overriden if too large?.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>A list of TwinConfiguration for a automatic device/module management</returns>
public virtual async Task<Response<IReadOnlyList<TwinConfiguration>>> GetConfigurationsAsync(int? count = null, CancellationToken cancellationToken = default)

/// <summary>
/// Validates target condition and custom metric queries for a configuration on the IoT Hub.
/// </summary>
/// <param name="input">The configuration for target condition and custom metric queries.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>TwinConfiguration for a automatic device/module management</returns>
public virtual async Task<Response<ConfigurationQueriesTestResponse>> TestQueriesAsync(ConfigurationQueriesTestInput input, CancellationToken cancellationToken = default)

/// <summary>
/// Applies the provided configuration content to the specified edge device.
/// </summary>
/// <param name="id">The unique identifier of the edge device.  TODO <service team>: Is it just device or edge device?".</param>
/// <param name="content">Configuration Content. TBD: Get more context</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>TBD : What should the response be?</returns>
public virtual async Task<Response<object>> ApplyOnEdgeDeviceAsync(string id, ConfigurationContent content, CancellationToken cancellationToken = default)

```

</details>

<details><summary><b>Statistics</b></summary>

APIs for getting statistics about devices and modules, as well as service statistics

```csharp

```

</details>

<details><summary><b>Devices</b></summary>
APIs for managing device identities, device twins, and querying devices

This sub-client has been implemented. Refer to [DevicesClient](./DevicesClient.cs).

</details>

<details><summary><b>Modules</b></summary>

APIs for managing module identities, module twins, and querying modules

This sub-client has been implemented. Refer to [ModulesClient](./ModulesClient.cs).

</details>

<details><summary><b>Jobs</b></summary>
APIs for using IotHub v2 jobs

```csharp

```

</details>

<details><summary><b>Messages</b></summary>
Feedback messages, sending cloud to device messages (missing from current swagger), and purging cloud to device message queue
```csharp
```
</details>

<details><summary><b>Files</b></summary>
APIs for getting file upload notifications (missing from current swagger)

```csharp
```

</details>

<details><summary><b>Fault Injection</b></summary>
Not sure if we'll expose these

```csharp
```

</details>

<details><summary><b>Query</b></summary>
APIs for querying on device or module identities

```csharp
```

</details>
