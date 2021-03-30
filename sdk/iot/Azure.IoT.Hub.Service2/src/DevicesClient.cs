// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.IoT.Hub.Service.Models;

namespace Azure.IoT.Hub.Service
{
    /// <summary>
    /// Devices client to interact with devices and device twins including CRUD operations and method invocations.
    /// See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-csharp-csharp-twin-getstarted"> Getting started with device identity</see>.
    /// </summary>
    public class DevicesClient
    {
        private const string HubDeviceQuery = "select * from devices";

        private readonly DevicesRestClient _devicesRestClient;
        private readonly QueryClient _queryClient;
        private readonly BulkRegistryRestClient _bulkRegistryClient;

        /// <summary>
        /// Initializes a new instance of DevicesClient.
        /// </summary>
        protected DevicesClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of DevicesClient.
        /// <param name="devicesRestClient"> The REST client to perform device, device twin, and bulk operations. </param>
        /// <param name="queryClient"> The convenience layer query client to perform query operations for the device. </param>
        /// <param name="bulkRegistryClient"> The convenience layer client to perform bulk operations on devices. </param>
        /// </summary>
        internal DevicesClient(DevicesRestClient devicesRestClient, QueryClient queryClient, BulkRegistryRestClient bulkRegistryClient)
        {
            Argument.AssertNotNull(devicesRestClient, nameof(devicesRestClient));
            Argument.AssertNotNull(queryClient, nameof(queryClient));
            Argument.AssertNotNull(bulkRegistryClient, nameof(bulkRegistryClient));

            _devicesRestClient = devicesRestClient;
            _queryClient = queryClient;
            _bulkRegistryClient = bulkRegistryClient;
        }

        /// <summary>
        /// Create or update a device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to create or update.</param>
        /// <param name="precondition">The condition on which to perform this operation.
        /// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
        /// In case of update, if no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created device identity and the http response <see cref="Response{T}"/>.</returns>
        /// <code snippet="Snippet:IotHubCreateDeviceIdentity">
        /// Response&lt;DeviceIdentity&gt; response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);
        ///
        /// SampleLogger.PrintSuccess($&quot;Successfully create a new device identity with Id: &apos;{response.Value.DeviceId}&apos;, ETag: &apos;{response.Value.Etag}&apos;&quot;);
        /// </code>
        /// <code snippet="Snippet:IotHubUpdateDeviceIdentity">
        /// Response&lt;DeviceIdentity&gt; getResponse = await IoTHubServiceClient.Devices.GetIdentityAsync(deviceId);
        ///
        /// DeviceIdentity deviceIdentity = getResponse.Value;
        /// Console.WriteLine($&quot;Current device identity: DeviceId: &apos;{deviceIdentity.DeviceId}&apos;, Status: &apos;{deviceIdentity.Status}&apos;, ETag: &apos;{deviceIdentity.Etag}&apos;&quot;);
        ///
        /// Console.WriteLine($&quot;Updating device identity with Id: &apos;{deviceIdentity.DeviceId}&apos;. Disabling device so it cannot connect to IoT Hub.&quot;);
        /// deviceIdentity.Status = DeviceStatus.Disabled;
        ///
        /// Response&lt;DeviceIdentity&gt; response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);
        ///
        /// DeviceIdentity updatedDevice = response.Value;
        ///
        /// SampleLogger.PrintSuccess($&quot;Successfully updated device identity: DeviceId: &apos;{updatedDevice.DeviceId}&apos;, DeviceId: &apos;{updatedDevice.DeviceId}&apos;, Status: &apos;{updatedDevice.Status}&apos;, ETag: &apos;{updatedDevice.Etag}&apos;&quot;);
        /// </code>
        public virtual Task<Response<DeviceIdentity>> CreateOrUpdateIdentityAsync(
            DeviceIdentity deviceIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _devicesRestClient.CreateOrUpdateIdentityAsync(deviceIdentity.DeviceId, deviceIdentity, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create or update a device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to create or update.</param>
        /// <param name="precondition">The condition on which to perform this operation.
        /// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
        /// In case of update, if no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created device identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<DeviceIdentity> CreateOrUpdateIdentity(
            DeviceIdentity deviceIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _devicesRestClient.CreateOrUpdateIdentity(deviceIdentity.DeviceId, deviceIdentity, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Get a single device identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device identity and the http response <see cref="Response{T}"/>.</returns>
        /// <code snippet="Snippet:IotHubGetDeviceIdentity">
        /// Response&lt;DeviceIdentity&gt; response = await IoTHubServiceClient.Devices.GetIdentityAsync(deviceId);
        ///
        /// DeviceIdentity deviceIdentity = response.Value;
        ///
        /// SampleLogger.PrintSuccess($&quot;\t- Device Id: &apos;{deviceIdentity.DeviceId}&apos;, ETag: &apos;{deviceIdentity.Etag}&apos;&quot;);
        /// </code>
        public virtual Task<Response<DeviceIdentity>> GetIdentityAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.GetIdentityAsync(deviceId, cancellationToken);
        }

        /// <summary>
        /// Get a single device identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<DeviceIdentity> GetIdentity(string deviceId, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.GetIdentity(deviceId, cancellationToken);
        }

        /// <summary>
        /// Delete a single device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to delete. If no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>."/>.</param>
        /// <param name="precondition">The condition on which to delete the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        /// <code snippet="Snippet:IotHubDeleteDeviceIdentity">
        /// Response response = await IoTHubServiceClient.Devices.DeleteIdentityAsync(deviceIdentity);
        ///
        /// SampleLogger.PrintSuccess($&quot;Successfully deleted device identity with Id: &apos;{deviceIdentity.DeviceId}&apos;&quot;);
        /// </code>
        public virtual Task<Response> DeleteIdentityAsync(
            DeviceIdentity deviceIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _devicesRestClient.DeleteIdentityAsync(deviceIdentity.DeviceId, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Delete a single device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to delete. If no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.</param>
        /// <param name="precondition">The condition on which to delete the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        public virtual Response DeleteIdentity(
            DeviceIdentity deviceIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _devicesRestClient.DeleteIdentity(deviceIdentity.DeviceId, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices with an initial twin. A maximum of 100 creations can be done per call, and each creation must have a unique device identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="devices">The pairs of devices and their twins that will be created. For fields such as deviceId
        /// where device and twin have a definition, the device value will override the twin value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> CreateIdentitiesWithTwinAsync(IDictionary<DeviceIdentity, TwinData> devices, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = devices
                .Select(x => new ExportImportDevice()
                {
                    Id = x.Key.DeviceId,
                    Authentication = x.Key.Authentication,
                    Capabilities = x.Key.Capabilities,
                    DeviceScope = x.Key.DeviceScope,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Key.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.Key.StatusReason,
                    ImportMode = ExportImportDeviceImportMode.Create
                }.WithTags(x.Value.Tags).WithPropertiesFrom(x.Value.Properties));

            return _bulkRegistryClient.UpdateRegistryAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices with an initial twin. A maximum of 100 creations can be done per call, and each creation must have a unique device identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="devices">The pairs of devices and their twins that will be created. For fields such as deviceId
        /// where device and twin have a definition, the device value will override the twin value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> CreateIdentitiesWithTwin(IDictionary<DeviceIdentity, TwinData> devices, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = devices
                .Select(x => new ExportImportDevice()
                {
                    Id = x.Key.DeviceId,
                    Authentication = x.Key.Authentication,
                    Capabilities = x.Key.Capabilities,
                    DeviceScope = x.Key.DeviceScope,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Key.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.Key.StatusReason,
                    ImportMode = ExportImportDeviceImportMode.Create
                }.WithTags(x.Value.Tags).WithPropertiesFrom(x.Value.Properties));

            return _bulkRegistryClient.UpdateRegistry(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices. A maximum of 100 creations can be done per call, and each device identity must be unique. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The device identities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> CreateIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _bulkRegistryClient.UpdateRegistryAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices. A maximum of 100 creations can be done per call, and each device identity must be unique. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The device identities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> CreateIdentities(IEnumerable<DeviceIdentity> deviceIdentities, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _bulkRegistryClient.UpdateRegistry(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices. A maximum of 100 updates can be done per call, and each operation must be done on a different identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>..
        /// </summary>
        /// <param name="deviceIdentities">The devices to update.</param>
        /// <param name="precondition">The condition on which to update each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> UpdateIdentitiesAsync(
            IEnumerable<DeviceIdentity> deviceIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    ETag = x.Etag,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Update : ExportImportDeviceImportMode.UpdateIfMatchETag
                });

            return _bulkRegistryClient.UpdateRegistryAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices. A maximum of 100 updates can be done per call, and each operation must be done on a different identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices to update.</param>
        /// <param name="precondition">The condition on which to update each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> UpdateIdentities(
            IEnumerable<DeviceIdentity> deviceIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    ETag = x.Etag,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Update : ExportImportDeviceImportMode.UpdateIfMatchETag
                });

            return _bulkRegistryClient.UpdateRegistry(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Delete multiple devices. A maximum of 100 deletions can be done per call. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices to delete.</param>
        /// <param name="precondition">The condition on which to delete each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk deletion and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> DeleteIdentitiesAsync(
            IEnumerable<DeviceIdentity> deviceIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional
                        ? ExportImportDeviceImportMode.Delete
                        : ExportImportDeviceImportMode.DeleteIfMatchETag
                });

            return _bulkRegistryClient.UpdateRegistryAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Delete multiple devices. A maximum of 100 deletions can be done per call. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices to delete.</param>
        /// <param name="precondition">The condition on which to delete each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk deletion and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> DeleteIdentities(
            IEnumerable<DeviceIdentity> deviceIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional
                        ? ExportImportDeviceImportMode.Delete
                        : ExportImportDeviceImportMode.DeleteIfMatchETag
                });

            return _bulkRegistryClient.UpdateRegistry(registryOperations, cancellationToken);
        }

        /// <summary>
        /// List a set of device twins.
        /// </summary>
        /// <remarks>
        /// This service request returns the full set of device twins. To get a subset of device twins, you can use the <see cref="QueryClient.QueryAsync(string, int?, CancellationToken)">query API</see> that this method uses but with additional qualifiers for selection.
        /// </remarks>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device twins <see cref="AsyncPageable{T}"/>.</returns>
        public virtual AsyncPageable<TwinData> GetTwinsAsync(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            return _queryClient.QueryAsync(HubDeviceQuery, pageSize, cancellationToken);
        }

        /// <summary>
        /// List a set of device twins.
        /// </summary>
        /// <remarks>
        /// This service request returns the full set of device twins. To get a subset of device twins, you can use the <see cref="QueryClient.Query(string, int?, CancellationToken)">query API</see> that this method uses but with additional qualifiers for selection.
        /// </remarks>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device twins <see cref="Pageable{T}"/>.</returns>
        public virtual Pageable<TwinData> GetTwins(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            return _queryClient.Query(HubDeviceQuery, pageSize, cancellationToken);
        }

        /// <summary>
        /// Get a device's twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get the twin of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The device's twin, including reported properties and desired properties and the http response <see cref="Response{T}"/>.</returns>
        /// <code snippet="Snippet:IotHubGetDeviceTwin">
        /// Response&lt;TwinData&gt; response = await IoTHubServiceClient.Devices.GetTwinAsync(deviceId);
        ///
        /// SampleLogger.PrintSuccess($&quot;\t- Device Twin: DeviceId: &apos;{response.Value.DeviceId}&apos;, Status: &apos;{response.Value.Status}&apos;, ETag: &apos;{response.Value.Etag}&apos;&quot;);
        /// </code>
        public virtual Task<Response<TwinData>> GetTwinAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.GetTwinAsync(deviceId, cancellationToken);
        }

        /// <summary>
        /// Get a device's twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get the twin of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The device's twin, including reported properties and desired properties.</returns>
        public virtual Response<TwinData> GetTwin(string deviceId, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.GetTwin(deviceId, cancellationToken);
        }

        /// <summary>
        /// Update a device's twin.
        /// </summary>
        /// <param name="twinUpdate">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="precondition">The condition for which this operation will execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new representation of the device twin and the http response <see cref="Response{T}"/>.</returns>
        /// <code snippet="Snippet:IotHubUpdateDeviceTwin">
        /// Response&lt;TwinData&gt; getResponse = await IoTHubServiceClient.Devices.GetTwinAsync(deviceId);
        /// TwinData deviceTwin = getResponse.Value;
        ///
        /// Console.WriteLine($&quot;Updating device twin: DeviceId: &apos;{deviceTwin.DeviceId}&apos;, ETag: &apos;{deviceTwin.Etag}&apos;&quot;);
        /// Console.WriteLine($&quot;Setting a new desired property {userPropName} to: &apos;{Environment.UserName}&apos;&quot;);
        ///
        /// deviceTwin.Properties.Desired.Add(new KeyValuePair&lt;string, object&gt;(userPropName, Environment.UserName));
        ///
        /// Response&lt;TwinData&gt; response = await IoTHubServiceClient.Devices.UpdateTwinAsync(deviceTwin);
        ///
        /// TwinData updatedTwin = response.Value;
        ///
        /// var userPropValue = (string)updatedTwin.Properties.Desired
        ///     .Where(p =&gt; p.Key == userPropName)
        ///     .First()
        ///     .Value;
        ///
        /// SampleLogger.PrintSuccess($&quot;Successfully updated device twin: DeviceId: &apos;{updatedTwin.DeviceId}&apos;, desired property: [&apos;{userPropName}&apos;: &apos;{userPropValue}&apos;], ETag: &apos;{updatedTwin.Etag}&apos;,&quot;);
        /// </code>
        public virtual Task<Response<TwinData>> UpdateTwinAsync(TwinData twinUpdate, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twinUpdate, nameof(twinUpdate));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, twinUpdate.Etag);
            return _devicesRestClient.UpdateTwinAsync(twinUpdate.DeviceId, twinUpdate, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Update a device's twin.
        /// </summary>
        /// <param name="twinUpdate">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="precondition">The condition for which this operation will execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new representation of the device twin and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<TwinData> UpdateTwin(TwinData twinUpdate, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twinUpdate, nameof(twinUpdate));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, twinUpdate.Etag);
            return _devicesRestClient.UpdateTwin(twinUpdate.DeviceId, twinUpdate, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different device twin. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="twinUpdates">The new twins to replace the twins on existing devices.</param>
        /// <param name="precondition">The condition on which to update each device twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> UpdateTwinsAsync(
            IEnumerable<TwinData> twinUpdates,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = twinUpdates
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    TwinETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.UpdateTwin : ExportImportDeviceImportMode.UpdateTwinIfMatchETag
                }.WithTags(x.Tags).WithPropertiesFrom(x.Properties));

            return _bulkRegistryClient.UpdateRegistryAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different device twin. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="twinUpdates">The new twins to replace the twins on existing devices.</param>
        /// <param name="precondition">The condition on which to update each device twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> UpdateTwins(
            IEnumerable<TwinData> twinUpdates,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = twinUpdates
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    TwinETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional
                        ? ExportImportDeviceImportMode.UpdateTwin
                        : ExportImportDeviceImportMode.UpdateTwinIfMatchETag
                }.WithTags(x.Tags).WithPropertiesFrom(x.Properties));

            return _bulkRegistryClient.UpdateRegistry(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Invoke a method on a device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to invoke the method on.</param>
        /// <param name="directMethodRequest">The details of the method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the method invocation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<CloudToDeviceMethodResponse>> InvokeMethodAsync(string deviceId, CloudToDeviceMethodRequest directMethodRequest, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.InvokeMethodAsync(deviceId, directMethodRequest, cancellationToken);
        }

        /// <summary>
        /// Invoke a method on a device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to invoke the method on.</param>
        /// <param name="directMethodRequest">The details of the method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the method invocation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<CloudToDeviceMethodResponse> InvokeMethod(string deviceId, CloudToDeviceMethodRequest directMethodRequest, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.InvokeMethod(deviceId, directMethodRequest, cancellationToken);
        }
    }
}
