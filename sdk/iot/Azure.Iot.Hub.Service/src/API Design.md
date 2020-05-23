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

## Import/Export Jobs APIs

Import and export operations take place in the context of Jobs that enable you to execute bulk service operations against an IoT hub. Exports are long-running jobs that use a customer-supplied blob container to save device identity data read from the identity registry. In addition, imports are long-running jobs that use data in a customer-supplied blob container to write device identity data into the identity registry.

```csharp
public class Jobs
{
    /// <summary>
    /// Creates a job to export device registrations to the container.
    /// </summary>
    /// <param name="exportJobProperties">Job parameters to export devices.</param>
    /// <param name="excludeKeys">If false, authorization keys are included in export output.  Keys are exported as null otherwise.</param>
    /// <param name="cancellationToken">Task cancellation token.</param>
    /// <returns>JobProperties of the newly created job.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleExportDevicesAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<JobProperties>> ExportDevicesAsync(ExportJobProperties exportJobProperties, bool excludeKeys, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a job to import device registrations into the IoT Hub.
    /// </summary>
    /// <param name="importJobProperties">Job parameters to import devices.</param>
    /// <param name="cancellationToken">Task cancellation token.</param>
    /// <returns>JobProperties of the newly created job.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleImportDevicesAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<JobProperties>> ImportDevicesAsync(ImportJobProperties importJobProperties, CancellationToken cancellationToken = default);

    /// <summary>
    /// List all import and export jobs for the IoT Hub.
    /// </summary>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>IEnumerable of JobProperties of all jobs for this IoT Hub.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleGetImportExportJobsAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<IReadOnlyList<JobProperties>>> GetImportExportJobsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the import or export job with the specified ID.
    /// </summary>
    /// <param name="jobId">Id of the Job object to retrieve</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>JobProperties of the job specified by the provided jobId.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleGetImportExportJobAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<JobProperties>> GetImportExportJobAsync(string jobId, CancellationToken cancellationToken);

    /// <summary>
    /// Cancels/Deletes the job with the specified ID.
    /// </summary>
    /// <param name="jobId">Id of the job to cancel</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>A response string object indicating result of the cancellation.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleCancelImportExportJobAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<string>> CancelImportExportJobAsync(string jobId, CancellationToken cancellationToken);

}

```

## Scheduled Jobs
Scheduled jobs execute device twin updates and direct methods against a set of devices at a scheduled time. You can use scheduled jobs to update desired properties, update tags and invoke direct methods.

```csharp
public class Jobs
{
    /// <summary>
    /// Retrieves details of a scheduled job from the IoT Hub.
    /// </summary>
    /// <param name="jobId">Id of the Job to retrieve</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>The matching JobResponse object</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleGetScheduledJobJobAsync" language="csharp">
    /// </code>
    /// </example>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-jobs for more information.
    /// </remarks>
    public virtual Task<Response<JobResponse>> GetScheduledJobAsync(string jobId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new scheduled job to update twin tags and desired properties on one or multiple devices.
    /// </summary>
    /// <param name="jobId">Unique Job Id for this job</param>
    /// <param name="queryCondition">Query condition to evaluate which devices to run the job on</param>
    /// <param name="twin">Twin object to use for the update</param>
    /// <param name="startTimeUtc">Date time in Utc to start the job</param>
    /// <param name="maxExecutionTimeInSeconds">Max execution time in seconds, i.e., ttl duration the job can run</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>A JobResponse object</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleScheduleTwinUpdateJobAsync" language="csharp">
    /// </code>
    /// </example>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-jobs for more information.
    /// </remarks>
    public virtual Task<Response<JobResponse>> ScheduleTwinUpdateAsync(string jobId, string queryCondition, Twin twin, DateTime startTimeUtc, long maxExecutionTimeInSeconds, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new scheduled job to run a device method on one or multiple devices.
    /// </summary>
    /// <param name="jobId">Unique Job Id for this job</param>
    /// <param name="queryCondition">Query condition to evaluate which devices to run the job on</param>
    /// <param name="cloudToDeviceMethod">Method call parameters</param>
    /// <param name="startTimeUtc">Date time in Utc to start the job</param>
    /// <param name="maxExecutionTimeInSeconds">Max execution time in seconds, i.e., ttl duration the job can run</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>A JobResponse object</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleScheduleDeviceMethodJobAsync" language="csharp">
    /// </code>
    /// </example>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-jobs for more information.
    /// </remarks>
    public virtual Task<Response<JobResponse>> ScheduleDeviceMethodAsync(string jobId, string queryCondition, CloudToDeviceMethod cloudToDeviceMethod, DateTime startTimeUtc, long maxExecutionTimeInSeconds, CancellationToken cancellationToken);

    /// <summary>
    /// Cancels/Deletes the job with the specified ID.
    /// </summary>
    /// <param name="jobId">Id of the job to cancel</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>A JobResponse object</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleCancelScheduledJobAsync" language="csharp">
    /// </code>
    /// </example>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-jobs for more information.
    /// </remarks>
    public virtual Task<Response<JobResponse>> CancelJobAsync(string jobId, CancellationToken cancellationToken);

    /// <summary>
    /// Query the IoT hub to retrieve information regarding scheduled jobs.
    /// </summary>
    /// <param name="jobType">The job type to query.</param>
    /// <param name="jobStatus">The job status to query.</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>The pageable list of query results and the raw HTTP response.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleQueryScheduledJobsAsync" language="csharp">
    /// </code>
    /// </example>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-jobs for more information.
    /// </remarks>
    public virtual AsyncPageable<string> QueryScheduledJobsAsync(JobType? jobType = null, JobStatus? jobStatus = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// An object representing the properties needed in the payload to an export devices job.
/// </summary>
public class ExportJobProperties 
{
    /// <summary>
    /// URI containing SAS token to a blob container. This is used to output the status of the job and the results.
    /// </summary>
    public string OutputBlobContainerUri { get; set; }

    /// <summary>
    /// The name of the blob that will be created in the provided output blob container. This blob will contain the exported device registry information for the IoT Hub.
    /// </summary>
    public string OutputBlobName { get; set; }

    /// <summary>
    /// Specifies authentication type being used for connecting to storage account.
    /// </summary>
    public StorageAuthenticationType AuthenticationType { get; set; }
}

/// <summary>
/// An object representing the properties needed in the payload to an import devices job.
/// </summary>
public class ImportJobProperties : ExportJobProperties
{
    /// <summary>
    /// URI containing SAS token to a blob container that contains registry data to sync.
    /// </summary>
    public string ImportBlobContainerUri { get; set; }

    /// <summary>
    /// The name of the blob that will be used when importing from the provided input blob container.
    /// </summary>
    public string ImportBlobName { get; set; }
}

/// <summary>
/// The type of job to query for
/// </summary>
public static class JobType
{
    public const string ExportDevices = "export";
    public const string ImportDevices = "import";
    public const string ScheduleDeviceMethod = "scheduleDeviceMethod";
    public const string ScheduleUpdateTwin = "scheduleUpdateTwin";
}

/// <summary>
/// The job status to query for
/// </summary>
public static class JobStatus
{
    public const string UnknownValue = "unknown";
    public const string ExportValue = "export";
    public const string ImportValue = "import";
    public const string BackupValue = "backup";
    public const string ReadDevicePropertiesValue = "readDeviceProperties";
    public const string WriteDevicePropertiesValue = "writeDeviceProperties";
    public const string UpdateDeviceConfigurationValue = "updateDeviceConfiguration";
    public const string RebootDeviceValue = "rebootDevice";
    public const string FactoryResetDeviceValue = "factoryResetDevice";
    public const string FirmwareUpdateValue = "firmwareUpdate";
    public const string ScheduleDeviceMethodValue = "scheduleDeviceMethod";
    public const string ScheduleUpdateTwinValue = "scheduleUpdateTwin";
    public const string RestoreFromBackupValue = "restoreFromBackup";
    public const string FailoverDataCopyValue = "failoverDataCopy";
}
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
