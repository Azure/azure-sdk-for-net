
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
    /// Extension methods for BackupSchedulesOperations.
    /// </summary>
    public static partial class BackupSchedulesOperationsExtensions
    {
            /// <summary>
            /// Gets all the backup schedules in a backup policy.
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
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<BackupSchedule> ListByBackupPolicy(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName)
            {
                return operations.ListByBackupPolicyAsync(deviceName, backupPolicyName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the backup schedules in a backup policy.
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
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<BackupSchedule>> ListByBackupPolicyAsync(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByBackupPolicyWithHttpMessagesAsync(deviceName, backupPolicyName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the properties of the specified backup schedule name.
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
            /// <param name='backupScheduleName'>
            /// The name of the backup schedule to be fetched
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static BackupSchedule Get(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(deviceName, backupPolicyName, backupScheduleName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the properties of the specified backup schedule name.
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
            /// <param name='backupScheduleName'>
            /// The name of the backup schedule to be fetched
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
            public static async Task<BackupSchedule> GetAsync(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(deviceName, backupPolicyName, backupScheduleName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the backup schedule.
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
            public static BackupSchedule CreateOrUpdate(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, BackupSchedule parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(deviceName, backupPolicyName, backupScheduleName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the backup schedule.
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BackupSchedule> CreateOrUpdateAsync(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, BackupSchedule parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(deviceName, backupPolicyName, backupScheduleName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the backup schedule.
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
            /// <param name='backupScheduleName'>
            /// The name the backup schedule.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Delete(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(deviceName, backupPolicyName, backupScheduleName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the backup schedule.
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
            /// <param name='backupScheduleName'>
            /// The name the backup schedule.
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
            public static async Task DeleteAsync(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(deviceName, backupPolicyName, backupScheduleName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates or updates the backup schedule.
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
            public static BackupSchedule BeginCreateOrUpdate(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, BackupSchedule parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAsync(deviceName, backupPolicyName, backupScheduleName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the backup schedule.
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BackupSchedule> BeginCreateOrUpdateAsync(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, BackupSchedule parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(deviceName, backupPolicyName, backupScheduleName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the backup schedule.
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
            /// <param name='backupScheduleName'>
            /// The name the backup schedule.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginDelete(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName)
            {
                operations.BeginDeleteAsync(deviceName, backupPolicyName, backupScheduleName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the backup schedule.
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
            /// <param name='backupScheduleName'>
            /// The name the backup schedule.
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
            public static async Task BeginDeleteAsync(this IBackupSchedulesOperations operations, string deviceName, string backupPolicyName, string backupScheduleName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(deviceName, backupPolicyName, backupScheduleName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}

