
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
    /// DeviceSettingsOperations operations.
    /// </summary>
    public partial interface IDeviceSettingsOperations
    {
        /// <summary>
        /// Gets the alert settings of the specified device.
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
        Task<AzureOperationResponse<AlertSettings>> GetAlertSettingsWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the alert settings of the specified device.
        /// </summary>
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
        Task<AzureOperationResponse<AlertSettings>> CreateOrUpdateAlertSettingsWithHttpMessagesAsync(string deviceName, AlertSettings parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the network settings of the specified device.
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
        Task<AzureOperationResponse<NetworkSettings>> GetNetworkSettingsWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the network settings on the specified device.
        /// </summary>
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
        Task<AzureOperationResponse<NetworkSettings>> UpdateNetworkSettingsWithHttpMessagesAsync(string deviceName, NetworkSettingsPatch parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns the Security properties of the specified device name.
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
        Task<AzureOperationResponse<SecuritySettings>> GetSecuritySettingsWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Patch Security properties of the specified device name.
        /// </summary>
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
        Task<AzureOperationResponse<SecuritySettings>> UpdateSecuritySettingsWithHttpMessagesAsync(string deviceName, SecuritySettingsPatch parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// sync Remote management Certificate between appliance and Service
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
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> SyncRemotemanagementCertificateWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the time settings of the specified device.
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
        Task<AzureOperationResponse<TimeSettings>> GetTimeSettingsWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the time settings of the specified device.
        /// </summary>
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
        Task<AzureOperationResponse<TimeSettings>> CreateOrUpdateTimeSettingsWithHttpMessagesAsync(string deviceName, TimeSettings parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the alert settings of the specified device.
        /// </summary>
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
        Task<AzureOperationResponse<AlertSettings>> BeginCreateOrUpdateAlertSettingsWithHttpMessagesAsync(string deviceName, AlertSettings parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the network settings on the specified device.
        /// </summary>
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
        Task<AzureOperationResponse<NetworkSettings>> BeginUpdateNetworkSettingsWithHttpMessagesAsync(string deviceName, NetworkSettingsPatch parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Patch Security properties of the specified device name.
        /// </summary>
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
        Task<AzureOperationResponse<SecuritySettings>> BeginUpdateSecuritySettingsWithHttpMessagesAsync(string deviceName, SecuritySettingsPatch parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// sync Remote management Certificate between appliance and Service
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
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginSyncRemotemanagementCertificateWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or updates the time settings of the specified device.
        /// </summary>
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
        Task<AzureOperationResponse<TimeSettings>> BeginCreateOrUpdateTimeSettingsWithHttpMessagesAsync(string deviceName, TimeSettings parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

