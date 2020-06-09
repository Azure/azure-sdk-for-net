// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Device Client place holder
    /// </summary>
    public class DevicesClient
    {
        private const string ContinuationTokenHeader = "x-ms-continuation";

        private readonly RegistryManagerRestClient _registryManagerClient;
        private readonly TwinRestClient _twinClient;
        private readonly DeviceMethodRestClient _deviceMethodClient;

        protected DevicesClient()
        {
        }

        internal DevicesClient(RegistryManagerRestClient registryManagerClient, TwinRestClient twinRestClient, DeviceMethodRestClient deviceMethodRestClient)
        {
            Argument.AssertNotNull(registryManagerClient, nameof(registryManagerClient));
            Argument.AssertNotNull(twinRestClient, nameof(twinRestClient));
            Argument.AssertNotNull(deviceMethodRestClient, nameof(deviceMethodRestClient));

            _registryManagerClient = registryManagerClient;
            _twinClient = twinRestClient;
            _deviceMethodClient = deviceMethodRestClient;
        }

        /// <summary>
        /// Create or update a device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to create.</param>
        /// <param name="precondition">The condition on which to perform this operation. To create a device identity, this value must be equal to <see cref="IfMatchPrecondition.Unconditional"/>.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created device identity.</returns>
        public virtual Task<Response<DeviceIdentity>> CreateOrUpdateIdentityAsync(DeviceIdentity deviceIdentity, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _registryManagerClient.CreateOrUpdateDeviceAsync(deviceIdentity.DeviceId, deviceIdentity, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create or update a device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to create.</param>
        /// <param name="precondition">The condition on which to perform this operation. To create a device identity, this value must be equal to <see cref="IfMatchPrecondition.Unconditional"/>.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created device identity.</returns>
        public virtual Response<DeviceIdentity> CreateOrUpdateIdentity(DeviceIdentity deviceIdentity, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _registryManagerClient.CreateOrUpdateDevice(deviceIdentity.DeviceId, deviceIdentity, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Get a single device identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device identity.</returns>
        public virtual Task<Response<DeviceIdentity>> GetIdentityAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.GetDeviceAsync(deviceId, cancellationToken);
        }

        /// <summary>
        /// Get a single device identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device identity.</returns>
        public virtual Response<DeviceIdentity> GetIdentity(string deviceId, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.GetDevice(deviceId, cancellationToken);
        }

        /// <summary>
        /// Delete a single device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to delete. If no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.Unconditional"/> or equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/></param>
        /// <param name="precondition">The condition on which to delete the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        public virtual Task<Response> DeleteIdentityAsync(DeviceIdentity deviceIdentity, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _registryManagerClient.DeleteDeviceAsync(deviceIdentity.DeviceId, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Delete a single device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to delete. If no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.Unconditional"/> or equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/></param>
        /// <param name="precondition">The condition on which to delete the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        public virtual Response DeleteIdentity(DeviceIdentity deviceIdentity, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deviceIdentity, nameof(deviceIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, deviceIdentity.Etag);
            return _registryManagerClient.DeleteDevice(deviceIdentity.DeviceId, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices with an initial twin. A maximum of 100 creations can be done per call, and each creation must have a unique device identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="devices">The pairs of devices their twins that will be created. For fields such as deviceId
        /// where device and twin have a definition, the device value will override the twin value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> CreateIdentitiesWithTwinAsync(IDictionary<DeviceIdentity, TwinData> devices, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = devices
                .Select(x => new ExportImportDevice()
                {
                    Id = x.Key.DeviceId,
                    Authentication = x.Key.Authentication,
                    Capabilities = x.Key.Capabilities,
                    DeviceScope = x.Key.DeviceScope,
                    ParentScopes = x.Key.ParentScopes,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Key.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.Key.StatusReason,
                    Tags = x.Value.Tags,
                    Properties = new PropertyContainer(x.Value.Properties?.Desired, x.Value.Properties?.Reported),
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _registryManagerClient.BulkDeviceCrudAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices with an initial twin. A maximum of 100 creations can be done per call, and each creation must have a unique device identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="devices">The pairs of devices their twins that will be created. For fields such as deviceId
        /// where device and twin have a definition, the device value will override the twin value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Response<BulkRegistryOperationResponse> CreateIdentitiesWithTwin(IDictionary<DeviceIdentity, TwinData> devices, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = devices
                .Select(x => new ExportImportDevice()
                {
                    Id = x.Key.DeviceId,
                    Authentication = x.Key.Authentication,
                    Capabilities = x.Key.Capabilities,
                    DeviceScope = x.Key.DeviceScope,
                    ParentScopes = x.Key.ParentScopes,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Key.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.Key.StatusReason,
                    Tags = x.Value.Tags,
                    Properties = new PropertyContainer(x.Value.Properties?.Desired, x.Value.Properties?.Reported),
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _registryManagerClient.BulkDeviceCrud(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices. A maximum of 100 creations can be done per call, and each device identity must be unique. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices identities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> CreateIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    ParentScopes = x.ParentScopes,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _registryManagerClient.BulkDeviceCrudAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple devices. A maximum of 100 creations can be done per call, and each device identity must be unique. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The device identities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Response<BulkRegistryOperationResponse> CreateIdentities(IEnumerable<DeviceIdentity> deviceIdentities, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    ParentScopes = x.ParentScopes,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _registryManagerClient.BulkDeviceCrud(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices. A maximum of 100 updates can be done per call, and each operation must be done on a different identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>..
        /// </summary>
        /// <param name="deviceIdentities">The devices to update.</param>
        /// <param name="precondition">The condition on which to update each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> UpdateIdentiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    ParentScopes = x.ParentScopes,
                    ETag = x.Etag,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Update : ExportImportDeviceImportMode.UpdateIfMatchETag
                });

            return _registryManagerClient.BulkDeviceCrudAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices. A maximum of 100 updates can be done per call, and each operation must be done on a different identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices to update.</param>
        /// <param name="precondition">The condition on which to update each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Response<BulkRegistryOperationResponse> UpdateIdenties(IEnumerable<DeviceIdentity> deviceIdentities, BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Authentication = x.Authentication,
                    Capabilities = x.Capabilities,
                    DeviceScope = x.DeviceScope,
                    ParentScopes = x.ParentScopes,
                    ETag = x.Etag,
                    Status = string.Equals(ExportImportDeviceStatus.Disabled.ToString(), x.Status?.ToString(), StringComparison.OrdinalIgnoreCase)
                                ? ExportImportDeviceStatus.Disabled
                                : ExportImportDeviceStatus.Enabled,
                    StatusReason = x.StatusReason,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Update : ExportImportDeviceImportMode.UpdateIfMatchETag
                });

            return _registryManagerClient.BulkDeviceCrud(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Delete multiple devices. A maximum of 100 deletions can be done per call. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices to delete.</param>
        /// <param name="precondition">The condition on which to delete each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk deletion.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> DeleteIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities, BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Delete : ExportImportDeviceImportMode.DeleteIfMatchETag
                });

            return _registryManagerClient.BulkDeviceCrudAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Delete multiple devices. A maximum of 100 deletions can be done per call. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="deviceIdentities">The devices to delete.</param>
        /// <param name="precondition">The condition on which to delete each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk deletion.</returns>
        public virtual Response<BulkRegistryOperationResponse> DeleteIdentities(IEnumerable<DeviceIdentity> deviceIdentities, BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = deviceIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Delete : ExportImportDeviceImportMode.DeleteIfMatchETag
                });

            return _registryManagerClient.BulkDeviceCrud(registryOperations, cancellationToken);
        }

        /// <summary>
        /// List a set of device twins.
        /// </summary>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device twins.</returns>
        public virtual AsyncPageable<TwinData> GetTwinsAsync(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TwinData>> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = "select * from devices"
                };
                Response<IReadOnlyList<TwinData>> response = await _registryManagerClient.QueryIotHubAsync(querySpecification, null, pageSizeHint?.ToString(), cancellationToken).ConfigureAwait(false);
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            async Task<Page<TwinData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification();
                Response<IReadOnlyList<TwinData>> response = await _registryManagerClient.QueryIotHubAsync(querySpecification, nextLink, pageSizeHint?.ToString(), cancellationToken).ConfigureAwait(false);
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc, pageSize);
        }

        /// <summary>
        /// List a set of device twins.
        /// </summary>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device twins.</returns>
        public virtual Pageable<TwinData> GetTwins(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            Page<TwinData> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = "select * from devices"
                };

                Response<IReadOnlyList<TwinData>> response = _registryManagerClient.QueryIotHub(querySpecification, null, pageSizeHint?.ToString(), cancellationToken);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            Page<TwinData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification();
                Response<IReadOnlyList<TwinData>> response = _registryManagerClient.QueryIotHub(querySpecification, nextLink, pageSizeHint?.ToString(), cancellationToken);
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc, pageSize);
        }

        /// <summary>
        /// Get a device's twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get the twin of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The device's twin, including reported properties and desired properties.</returns>
        public virtual Task<Response<TwinData>> GetTwinAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return _twinClient.GetDeviceTwinAsync(deviceId, cancellationToken);
        }

        /// <summary>
        /// Get a device's twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get the twin of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The device's twin, including reported properties and desired properties.</returns>
        public virtual Response<TwinData> GetTwin(string deviceId, CancellationToken cancellationToken = default)
        {
            return _twinClient.GetDeviceTwin(deviceId, cancellationToken);
        }

        /// <summary>
        /// Update a device's twin.
        /// </summary>
        /// <param name="twinUpdate">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="precondition">The condition for which this operation will execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new representation of the device twin.</returns>
        public virtual Task<Response<TwinData>> UpdateTwinAsync(TwinData twinUpdate, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twinUpdate, nameof(twinUpdate));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, twinUpdate.Etag);
            return _twinClient.UpdateDeviceTwinAsync(twinUpdate.DeviceId, twinUpdate, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Update a device's twin.
        /// </summary>
        /// <param name="twinUpdate">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="precondition">The condition for which this operation will execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new representation of the device twin.</returns>
        public virtual Response<TwinData> UpdateTwin(TwinData twinUpdate, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twinUpdate, nameof(twinUpdate));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, twinUpdate.Etag);
            return _twinClient.UpdateDeviceTwin(twinUpdate.DeviceId, twinUpdate, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different device twin. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="twinUpdates">The new twins to replace the twins on existing devices.</param>
        /// <param name="precondition">The condition on which to update each device twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> UpdateTwinsAsync(IEnumerable<TwinData> twinUpdates, BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = twinUpdates
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Tags = x.Tags,
                    Properties = new PropertyContainer(x.Properties?.Desired, x.Properties?.Reported),
                    TwinETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.UpdateTwin : ExportImportDeviceImportMode.UpdateTwinIfMatchETag
                });

            return _registryManagerClient.BulkDeviceCrudAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple devices' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different device twin. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="twinUpdates">The new twins to replace the twins on existing devices.</param>
        /// <param name="precondition">The condition on which to update each device twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation.</returns>
        public virtual Response<BulkRegistryOperationResponse> UpdateTwins(IEnumerable<TwinData> twinUpdates, BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = twinUpdates
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    Tags = x.Tags,
                    Properties = new PropertyContainer(x.Properties?.Desired, x.Properties?.Reported),
                    TwinETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.UpdateTwin : ExportImportDeviceImportMode.UpdateTwinIfMatchETag
                });

            return _registryManagerClient.BulkDeviceCrud(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Invoke a method on a device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to invoke the method on.</param>
        /// <param name="directMethodRequest">The details of the method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the method invocation.</returns>
        public virtual Task<Response<CloudToDeviceMethodResponse>> InvokeMethodAsync(string deviceId, CloudToDeviceMethodRequest directMethodRequest, CancellationToken cancellationToken = default)
        {
            return _deviceMethodClient.InvokeDeviceMethodAsync(deviceId, directMethodRequest, cancellationToken);
        }

        /// <summary>
        /// Invoke a method on a device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to invoke the method on.</param>
        /// <param name="directMethodRequest">The details of the method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the method invocation.</returns>
        public virtual Response<CloudToDeviceMethodResponse> InvokeMethod(string deviceId, CloudToDeviceMethodRequest directMethodRequest, CancellationToken cancellationToken = default)
        {
            return _deviceMethodClient.InvokeDeviceMethod(deviceId, directMethodRequest, cancellationToken);
        }
    }
}
