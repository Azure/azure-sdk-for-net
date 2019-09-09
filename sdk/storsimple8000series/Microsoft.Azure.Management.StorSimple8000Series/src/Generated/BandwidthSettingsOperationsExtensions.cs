
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
    /// Extension methods for BandwidthSettingsOperations.
    /// </summary>
    public static partial class BandwidthSettingsOperationsExtensions
    {
            /// <summary>
            /// Retrieves all the bandwidth setting in a manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<BandwidthSetting> ListByManager(this IBandwidthSettingsOperations operations, string resourceGroupName, string managerName)
            {
                return operations.ListByManagerAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all the bandwidth setting in a manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            public static async Task<IEnumerable<BandwidthSetting>> ListByManagerAsync(this IBandwidthSettingsOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByManagerWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the properties of the specified bandwidth setting name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The name of bandwidth setting to be fetched.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static BandwidthSetting Get(this IBandwidthSettingsOperations operations, string bandwidthSettingName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(bandwidthSettingName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the properties of the specified bandwidth setting name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The name of bandwidth setting to be fetched.
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
            public static async Task<BandwidthSetting> GetAsync(this IBandwidthSettingsOperations operations, string bandwidthSettingName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(bandwidthSettingName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The bandwidth setting name.
            /// </param>
            /// <param name='parameters'>
            /// The bandwidth setting to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static BandwidthSetting CreateOrUpdate(this IBandwidthSettingsOperations operations, string bandwidthSettingName, BandwidthSetting parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(bandwidthSettingName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The bandwidth setting name.
            /// </param>
            /// <param name='parameters'>
            /// The bandwidth setting to be added or updated.
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
            public static async Task<BandwidthSetting> CreateOrUpdateAsync(this IBandwidthSettingsOperations operations, string bandwidthSettingName, BandwidthSetting parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(bandwidthSettingName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The name of the bandwidth setting.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Delete(this IBandwidthSettingsOperations operations, string bandwidthSettingName, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(bandwidthSettingName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The name of the bandwidth setting.
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
            public static async Task DeleteAsync(this IBandwidthSettingsOperations operations, string bandwidthSettingName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(bandwidthSettingName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates or updates the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The bandwidth setting name.
            /// </param>
            /// <param name='parameters'>
            /// The bandwidth setting to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static BandwidthSetting BeginCreateOrUpdate(this IBandwidthSettingsOperations operations, string bandwidthSettingName, BandwidthSetting parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAsync(bandwidthSettingName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The bandwidth setting name.
            /// </param>
            /// <param name='parameters'>
            /// The bandwidth setting to be added or updated.
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
            public static async Task<BandwidthSetting> BeginCreateOrUpdateAsync(this IBandwidthSettingsOperations operations, string bandwidthSettingName, BandwidthSetting parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(bandwidthSettingName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The name of the bandwidth setting.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginDelete(this IBandwidthSettingsOperations operations, string bandwidthSettingName, string resourceGroupName, string managerName)
            {
                operations.BeginDeleteAsync(bandwidthSettingName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the bandwidth setting
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='bandwidthSettingName'>
            /// The name of the bandwidth setting.
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
            public static async Task BeginDeleteAsync(this IBandwidthSettingsOperations operations, string bandwidthSettingName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(bandwidthSettingName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}

