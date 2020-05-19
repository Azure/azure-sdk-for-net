# Azure Iot Hub Service API Design Doc
This document outlines the APIs for the Azure Iot Hub Service SDK

<details><summary><b>Type definition names</b></summary>
    
```
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

```
</details>

<details><summary><b>Statistics</b></summary>
APIs for getting statistics about devices and modules, as well as service statistics

```csharp

```
</details>

<details><summary><b>Devices</b></summary>
APIs for managing device identities, device twins, and querying devices

```csharp

```
</details>

<details><summary><b>Modules</b></summary>
APIs for managing module identities, module twins, and querying modules

```csharp

public  class Modules
{
    /// <summary>
    /// Create a module.
    /// </summary>
    /// <param name="moduleIdentity">The module to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public virtual async Task<Response<ModuleIdentity>> CreateIdentityAsync(ModuleIdentity moduleIdentity, CancellationToken cancellationToken);

    /// <summary>
    /// Get a single device.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
    /// <param name="moduleId">The unique identifier of the module to get.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved device.</returns>
    public virtual async Task<Response<ModuleIdentity>> GetIdentityAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// List a set of device modules.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A pageable set of device modules.</returns>
    public virtual async AsyncPageable<ModuleIdentity> GetIdentitiesAsync(string deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a module.
    /// </summary>
    /// <param name="moduleIdentity">The module to update.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
    /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created or updated device module.</returns>
    public virtual async Task<Response<ModuleIdentity>> UpdateIdentityAsync(ModuleIdentity moduleIdentity, string ifMatch = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a single module.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
    /// <param name="moduleId">The unique identifier of the module to get.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
    /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The http response.</returns>
    public virtual async Task<Response> DeleteIdentityAsync(string deviceId, string moduleId, string ifMatch = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the module twin.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device.</param>
    /// <param name="moduleId">The unique identifier of the device module.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved module twin.</returns>
    public virtual async Task<Response<TwinData>> GetTwinAsync(string deviceId, string moduleId, CancellationToken cancellationToken);

    /// <summary>
    /// List a set of module twins.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A pageable set of module twins.</returns>
    public virtual async AsyncPageable<TwinData> GetTwinsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a module's twin.
    /// </summary>
    /// <param name="twinPatch">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this twin, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the twin has not been modified since it was last retrieved.
    /// To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The server's new representation of the device twin.</returns>
    public virtual async Task<Response<TwinData>> UpdateTwinAsync(TwinData twinPatch, string ifMatch = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invoke a method on a device module.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
    /// <param name="moduleId">The unique identifier of the module.</param>
    /// <param name="directMethodRequest">The details of the method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the method invocation.</returns>
    public virtual async Task<Response<CloudToDeviceMethodResult>> InvokeMethodAsync(string deviceId, string moduleId, CloudToDeviceMethod directMethodRequest, CancellationToken cancellationToken = default);
}
```
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
