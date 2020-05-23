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
    /// <param name="outputBlobContainerUri">URI containing SAS token to a blob container. This is used to output the status of the job and the results.</param>
    /// <param name="outputBlobName">The name of the blob that will be created in the provided output blob container. This blob will contain the exported device registry information for the IoT Hub.</param>
    /// <param name="excludeKeys">If false, authorization keys are included in export output.  Keys are exported as null otherwise.</param>
    /// <param name="storageAuthenticationType">Specifies authentication type being used for connecting to storage account.</param>
    /// <param name="cancellationToken">Task cancellation token.</param>
    /// <returns>JobProperties of the newly created job.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleExportDevicesAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<JobProperties>> ExportDevicesAsync(string outputBlobContainerUri, string outputBlobName, bool excludeKeys, StorageAuthenticationType storageAuthenticationType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a job to import device registrations into the IoT Hub.
    /// </summary>
    /// <param name="importBlobContainerUri">URI containing SAS token to a blob container that contains registry data to sync.</param>
    /// <param name="importBlobName">The blob name to be used when importing from the provided input blob container.</param>
    /// <param name="outputBlobContainerUri">URI containing SAS token to a blob container. This is used to output the status of the job.</param>
    /// <param name="outputBlobName">The name of the blob that will be created in the provided output blob container.</param>
    /// <param name="storageAuthenticationType">Specifies authentication type being used for connecting to storage account.</param>
    /// <param name="cancellationToken">Task cancellation token.</param>
    /// <returns>JobProperties of the newly created job.</returns>
    /// <example>
    /// <code snippet="Snippet:JobsSampleImportDevicesAsync" language="csharp">
    /// </code>
    /// </example>
    public virtual Task<Response<JobProperties>> ImportDevicesAsync(string importBlobContainerUri, string importBlobName, string outputBlobContainerUri, string outputBlobName, StorageAuthenticationType storageAuthenticationType, CancellationToken cancellationToken = default);

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
