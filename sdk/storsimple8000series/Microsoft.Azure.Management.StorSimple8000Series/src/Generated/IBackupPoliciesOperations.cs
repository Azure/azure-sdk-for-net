
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
    /// BackupPoliciesOperations operations.
    /// </summary>
    public partial interface IBackupPoliciesOperations
    {
        /// <summary>
        /// Gets all the backup policies in a device.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
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
        Task<AzureOperationResponse<IEnumerable<BackupPolicy>>> ListByDeviceWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the properties of the specified backup policy name.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The name of backup policy to be fetched.
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
        Task<AzureOperationResponse<BackupPolicy>> GetWithHttpMessagesAsync(string deviceName, string backupPolicyName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the backup policy.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The name of the backup policy to be created/updated.
        /// </param>
        /// <param name='parameters'>
        /// The backup policy.
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
        Task<AzureOperationResponse<BackupPolicy>> CreateOrUpdateWithHttpMessagesAsync(string deviceName, string backupPolicyName, BackupPolicy parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the backup policy.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The name of the backup policy.
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
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string deviceName, string backupPolicyName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Backup the backup policy now.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupType'>
        /// The backup Type. This can be cloudSnapshot or localSnapshot.
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
        Task<AzureOperationResponse> BackupNowWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupType, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the backup policy.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The name of the backup policy to be created/updated.
        /// </param>
        /// <param name='parameters'>
        /// The backup policy.
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
        Task<AzureOperationResponse<BackupPolicy>> BeginCreateOrUpdateWithHttpMessagesAsync(string deviceName, string backupPolicyName, BackupPolicy parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the backup policy.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The name of the backup policy.
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
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string deviceName, string backupPolicyName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Backup the backup policy now.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='backupPolicyName'>
        /// The backup policy name.
        /// </param>
        /// <param name='backupType'>
        /// The backup Type. This can be cloudSnapshot or localSnapshot.
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
        Task<AzureOperationResponse> BeginBackupNowWithHttpMessagesAsync(string deviceName, string backupPolicyName, string backupType, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

