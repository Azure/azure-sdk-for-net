
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
    /// Extension methods for BackupPoliciesOperations.
    /// </summary>
    public static partial class BackupPoliciesOperationsExtensions
    {
            /// <summary>
            /// Gets all the backup policies in a device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<BackupPolicy> ListByDevice(this IBackupPoliciesOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.ListByDeviceAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the backup policies in a device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<BackupPolicy>> ListByDeviceAsync(this IBackupPoliciesOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByDeviceWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the properties of the specified backup policy name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static BackupPolicy Get(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(deviceName, backupPolicyName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the properties of the specified backup policy name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BackupPolicy> GetAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(deviceName, backupPolicyName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static BackupPolicy CreateOrUpdate(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, BackupPolicy parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(deviceName, backupPolicyName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BackupPolicy> CreateOrUpdateAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, BackupPolicy parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(deviceName, backupPolicyName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static void Delete(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(deviceName, backupPolicyName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(deviceName, backupPolicyName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Backup the backup policy now.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static void BackupNow(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string backupType, string resourceGroupName, string managerName)
            {
                operations.BackupNowAsync(deviceName, backupPolicyName, backupType, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Backup the backup policy now.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BackupNowAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string backupType, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BackupNowWithHttpMessagesAsync(deviceName, backupPolicyName, backupType, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates or updates the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static BackupPolicy BeginCreateOrUpdate(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, BackupPolicy parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAsync(deviceName, backupPolicyName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BackupPolicy> BeginCreateOrUpdateAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, BackupPolicy parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(deviceName, backupPolicyName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static void BeginDelete(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName)
            {
                operations.BeginDeleteAsync(deviceName, backupPolicyName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the backup policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(deviceName, backupPolicyName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Backup the backup policy now.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static void BeginBackupNow(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string backupType, string resourceGroupName, string managerName)
            {
                operations.BeginBackupNowAsync(deviceName, backupPolicyName, backupType, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Backup the backup policy now.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginBackupNowAsync(this IBackupPoliciesOperations operations, string deviceName, string backupPolicyName, string backupType, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginBackupNowWithHttpMessagesAsync(deviceName, backupPolicyName, backupType, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}

