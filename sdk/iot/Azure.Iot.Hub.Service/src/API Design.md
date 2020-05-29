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
public class Devices
{
    /// <summary>
    /// Create a device identity.
    /// </summary>
    /// <param name="deviceIdentity">The device to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created device.</returns>
    public virtual async Task<Response<DeviceIdentity>> CreateIdentityAsync(DeviceIdentity deviceIdentity, CancellationToken cancellationToken = default)

    /// <summary>
    /// Update a device identity.
    /// </summary>
    /// <param name="deviceIdentity">The device to update.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this device, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the device has not been modified since it was last retrieved.
    /// The current ETag can be retrieved from the device identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created or updated device.</returns>
    public virtual async Task<Response<DeviceIdentity>> UpdateIdentityAsync(DeviceIdentity deviceIdentity, string ifMatch = null, CancellationToken cancellationToken = default)

    /// <summary>
    /// Get a single device identity.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device to get.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved device.</returns>
    public virtual async Task<Response<DeviceIdentity>> GetIdentityAsync(string deviceId, CancellationToken cancellationToken = default)

    /// <summary>
    /// Delete a single device identity.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device to delete.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this device, as per RFC7232. The delete operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the device has not been modified since it was last retrieved.
	/// The current ETag can be retrieved from the device identity last retrieved from the service. To force an unconditional delete, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The http response.</returns>
    public virtual async Task<Response> DeleteIdentityAsync(string deviceId, string ifMatch = null, CancellationToken cancellationToken = default)

    /// <summary>
    /// Create multiple device identities with an initial twin. A maximum of 100 creations can be done per call, and each creation must have a unique device identity. For larger scale operations, consider using IoT Hub jobs (https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities).
    /// </summary>
    /// <param name="devices">The pairs of devices their twins that will be created. For fields such as deviceId
    /// where device and twin have a definition, the device value will override the twin value.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the bulk operation.</returns>
    public async Task<Response<BulkRegistryOperationResult>> CreateIdentitiesWithTwinAsync(IDictionary<DeviceIdentity, TwinData> devices, CancellationToken cancellationToken = default)

    /// <summary>
    /// Create multiple device identities. A maximum of 100 creations can be done per call, and each device identity must be unique. For larger scale operations, consider using IoT Hub jobs (https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities).
    /// </summary>
    /// <param name="deviceIdentities">The devices to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the bulk operation.</returns>
    public virtual async Task<Response<BulkRegistryOperationResult>> CreateIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, CancellationToken cancellationToken = default)

    /// <summary>
    /// Update multiple device identities. A maximum of 100 updates can be done per call, and each operation must be done on a different identity. For larger scale operations, consider using IoT Hub jobs (https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities).
    /// </summary>
    /// <param name="deviceIdentities">The devices to update.</param>
    /// <param name="force">If true, the devices will be updated even if their ETag is out of date.
    /// If false, each device will only be updated if its ETag is up to date.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the bulk operation.</returns>
    public virtual async Task<Response<BulkRegistryOperationResult>> UpdateIdentiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, bool force, CancellationToken cancellationToken = default)
    
    /// <summary>
    /// Delete multiple device identities. A maximum of 100 deletions can be done per call. For larger scale operations, consider using IoT Hub jobs (https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities).
    /// </summary>
    /// <param name="deviceIdentities">The devices to delete.</param>
    /// <param name="force">If true, the devices will be deleted even if their ETag is out of date.
    /// If false, each device will only be deleted if its ETag is up to date.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the bulk deletion.</returns>
    public virtual async Task<Response<BulkRegistryOperationResult>> DeleteIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, bool force, CancellationToken cancellationToken = default)

    /// <summary>
    /// List a set of device twins.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A pageable set of device twins.</returns>
    public virtual AsyncPageable<TwinData> GetTwinsAsync(CancellationToken cancellationToken = default)

    /// <summary>
    /// Get a device's twin.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device to get the twin of.</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The device's twin, including reported properties and desired properties.</returns>
    public virtual async Task<Response<TwinData>> GetTwinAsync(string deviceId, CancellationToken cancellationToken = default)

    /// <summary>
    /// Update a device's twin.
    /// </summary>
    /// <param name="twinPatch">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this twin, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the twin has not been modified since it was last retrieved.
    /// To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The server's new representation of the device twin.</returns>
    public virtual async Task<Response<TwinData>> UpdateTwinAsync(TwinData twinPatch, string ifMatch = null, CancellationToken cancellationToken = default)

    /// <summary>
    /// Update multiple devices' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different device twin. For larger scale operations, consider using IoT Hub jobs (https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities).
    /// </summary>
    /// <param name="twinUpdates">The new twins to replace the twins on existing devices</param>
    /// <param name="force">If true, all the update operations will ignore the provided twin ETags and will
    /// force the update. If false, each update operation will fail if the provided ETag for the update is out of date.</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The result of the bulk operation.</returns>
    public virtual async Task<Response<BulkRegistryOperationResult>> UpdateTwinsAsync(IEnumerable<TwinData> twinUpdates, bool force, CancellationToken cancellationToken = default)

    /// <summary>
    /// Invoke a method on a device.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device to invoke the method on.</param>
    /// <param name="directMethodRequest">The details of the method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the method invocation.</returns>
    public virtual async Task<Response<CloudToDeviceMethodResult>> InvokeMethodAsync(string deviceId, CloudToDeviceMethod directMethodRequest, CancellationToken cancellationToken = default)
}
```
</details>

<details><summary><b>Modules</b></summary>
APIs for managing module identities, module twins, and querying modules

```csharp

public  class Modules
{
    /// <summary>
    /// Create a device module identity.
    /// </summary>
    /// <param name="moduleIdentity">The module to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The newly created device module identity</returns>
    public virtual async Task<Response<ModuleIdentity>> CreateIdentityAsync(ModuleIdentity moduleIdentity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a single device module identity.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
    /// <param name="moduleId">The unique identifier of the module to get.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved device module identity.</returns>
    public virtual async Task<Response<ModuleIdentity>> GetIdentityAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// List a set of device's module identities.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A pageable set of device module identities.</returns>
    public virtual async Task<Response<IReadOnlyList<ModuleIdentity>>> GetIdentitiesAsync(string deviceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a device module identity.
    /// </summary>
    /// <param name="moduleIdentity">The module to update.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
    /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The updated device module identity.</returns>
    public virtual async Task<Response<ModuleIdentity>> UpdateIdentityAsync(ModuleIdentity moduleIdentity, string ifMatch = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a single device module identity.
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
    /// Get a device module twin.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device.</param>
    /// <param name="moduleId">The unique identifier of the device module.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved module twin.</returns>
    public virtual async Task<Response<TwinData>> GetTwinAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// List a set of device module twins.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A pageable set of device module twins.</returns>
    public virtual async AsyncPageable<TwinData> GetTwinsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a module's twin.
    /// </summary>
    /// <param name="twinPatch">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
    /// <param name="ifMatch">A string representing a weak ETag for this twin, as per RFC7232. The update operation is performed
    /// only if this ETag matches the value maintained by the server, indicating that the twin has not been modified since it was last retrieved.
    /// To force an unconditional update, set If-Match to the wildcard character (*).</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The server's new representation of the device module twin.</returns>
    public virtual async Task<Response<TwinData>> UpdateTwinAsync(TwinData twinPatch, string ifMatch = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invoke a method on a device module.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
    /// <param name="moduleId">The unique identifier of the module.</param>
    /// <param name="directMethodRequest">The details of the method to invoke.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the method invocation.</returns>
    public virtual async Task<Response<CloudToDeviceMethodResponse>> InvokeMethodAsync(string deviceId, string moduleId, CloudToDeviceMethodRequest cloudToDeviceMethodRequest, CancellationToken cancellationToken = default);
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
