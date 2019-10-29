
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for DeviceSettingsOperations.
    /// </summary>
    public static partial class DeviceSettingsOperationsExtensions
    {
            /// <summary>
            /// Gets the alert settings of the specified device.
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
            public static AlertSettings GetAlertSettings(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.GetAlertSettingsAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the alert settings of the specified device.
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
            public static async Task<AlertSettings> GetAlertSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAlertSettingsWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the alert settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The alert settings to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static AlertSettings CreateOrUpdateAlertSettings(this IDeviceSettingsOperations operations, string deviceName, AlertSettings parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAlertSettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the alert settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The alert settings to be added or updated.
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
            public static async Task<AlertSettings> CreateOrUpdateAlertSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, AlertSettings parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateAlertSettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the network settings of the specified device.
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
            public static NetworkSettings GetNetworkSettings(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.GetNetworkSettingsAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the network settings of the specified device.
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
            public static async Task<NetworkSettings> GetNetworkSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNetworkSettingsWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the network settings on the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The network settings to be updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static NetworkSettings UpdateNetworkSettings(this IDeviceSettingsOperations operations, string deviceName, NetworkSettingsPatch parameters, string resourceGroupName, string managerName)
            {
                return operations.UpdateNetworkSettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the network settings on the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The network settings to be updated.
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
            public static async Task<NetworkSettings> UpdateNetworkSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, NetworkSettingsPatch parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateNetworkSettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the Security properties of the specified device name.
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
            public static SecuritySettings GetSecuritySettings(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.GetSecuritySettingsAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the Security properties of the specified device name.
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
            public static async Task<SecuritySettings> GetSecuritySettingsAsync(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetSecuritySettingsWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Patch Security properties of the specified device name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The security settings properties to be patched.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static SecuritySettings UpdateSecuritySettings(this IDeviceSettingsOperations operations, string deviceName, SecuritySettingsPatch parameters, string resourceGroupName, string managerName)
            {
                return operations.UpdateSecuritySettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patch Security properties of the specified device name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The security settings properties to be patched.
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
            public static async Task<SecuritySettings> UpdateSecuritySettingsAsync(this IDeviceSettingsOperations operations, string deviceName, SecuritySettingsPatch parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateSecuritySettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// sync Remote management Certificate between appliance and Service
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
            public static void SyncRemotemanagementCertificate(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                operations.SyncRemotemanagementCertificateAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// sync Remote management Certificate between appliance and Service
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
            public static async Task SyncRemotemanagementCertificateAsync(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.SyncRemotemanagementCertificateWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets the time settings of the specified device.
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
            public static TimeSettings GetTimeSettings(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.GetTimeSettingsAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the time settings of the specified device.
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
            public static async Task<TimeSettings> GetTimeSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTimeSettingsWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the time settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The time settings to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static TimeSettings CreateOrUpdateTimeSettings(this IDeviceSettingsOperations operations, string deviceName, TimeSettings parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateTimeSettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the time settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The time settings to be added or updated.
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
            public static async Task<TimeSettings> CreateOrUpdateTimeSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, TimeSettings parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateTimeSettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the alert settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The alert settings to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static AlertSettings BeginCreateOrUpdateAlertSettings(this IDeviceSettingsOperations operations, string deviceName, AlertSettings parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAlertSettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the alert settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The alert settings to be added or updated.
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
            public static async Task<AlertSettings> BeginCreateOrUpdateAlertSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, AlertSettings parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateAlertSettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the network settings on the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The network settings to be updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static NetworkSettings BeginUpdateNetworkSettings(this IDeviceSettingsOperations operations, string deviceName, NetworkSettingsPatch parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginUpdateNetworkSettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the network settings on the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The network settings to be updated.
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
            public static async Task<NetworkSettings> BeginUpdateNetworkSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, NetworkSettingsPatch parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateNetworkSettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Patch Security properties of the specified device name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The security settings properties to be patched.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static SecuritySettings BeginUpdateSecuritySettings(this IDeviceSettingsOperations operations, string deviceName, SecuritySettingsPatch parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginUpdateSecuritySettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patch Security properties of the specified device name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The security settings properties to be patched.
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
            public static async Task<SecuritySettings> BeginUpdateSecuritySettingsAsync(this IDeviceSettingsOperations operations, string deviceName, SecuritySettingsPatch parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateSecuritySettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// sync Remote management Certificate between appliance and Service
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
            public static void BeginSyncRemotemanagementCertificate(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                operations.BeginSyncRemotemanagementCertificateAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// sync Remote management Certificate between appliance and Service
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
            public static async Task BeginSyncRemotemanagementCertificateAsync(this IDeviceSettingsOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginSyncRemotemanagementCertificateWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates or updates the time settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The time settings to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static TimeSettings BeginCreateOrUpdateTimeSettings(this IDeviceSettingsOperations operations, string deviceName, TimeSettings parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateTimeSettingsAsync(deviceName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the time settings of the specified device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='parameters'>
            /// The time settings to be added or updated.
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
            public static async Task<TimeSettings> BeginCreateOrUpdateTimeSettingsAsync(this IDeviceSettingsOperations operations, string deviceName, TimeSettings parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateTimeSettingsWithHttpMessagesAsync(deviceName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}

