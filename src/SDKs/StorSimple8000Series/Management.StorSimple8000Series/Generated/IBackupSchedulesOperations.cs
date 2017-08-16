
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BackupSchedulesOperations operations.
    /// </summary>
    public partial interface IBackupSchedulesOperations
    {
        /// <summary>
        /// Gets all the backup schedules in a backup policy.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<BackupSchedule>>> ListByBackupPolicyWithHttpMessagesAsync(string deviceName, string backupPolicyName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the properties of the specified backup schedule name.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupScheduleName'>
        /// The name of the backup schedule to be fetched
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BackupSchedule>> GetWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the backup schedule.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupScheduleName'>
        /// The backup schedule name.
        /// </param>
        /// <param name='parameters'>
        /// The backup schedule.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BackupSchedule>> CreateOrUpdateWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupScheduleName, BackupSchedule parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the backup schedule.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupScheduleName'>
        /// The name the backup schedule.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the backup schedule.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupScheduleName'>
        /// The backup schedule name.
        /// </param>
        /// <param name='parameters'>
        /// The backup schedule.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BackupSchedule>> BeginCreateOrUpdateWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupScheduleName, BackupSchedule parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the backup schedule.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupScheduleName'>
        /// The name the backup schedule.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

