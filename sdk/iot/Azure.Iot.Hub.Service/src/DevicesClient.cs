// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Devices client to interact with devices and device twins including CRUD operations and method invocations.
    /// See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-csharp-csharp-twin-getstarted"> Getting started with device identity</see>.
    /// </summary>
    public class DevicesClient
    {
        private const string ContinuationTokenHeader = "x-ms-continuation";
        private const string HubDeviceQuery = "select * from devices";

        private readonly DevicesRestClient _devicesRestClient;
        private readonly QueryRestClient _queryRestClient;

        /// <summary>
        /// Initializes a new instance of DevicesClient.
        /// </summary>
        protected DevicesClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of DevicesClient.
        /// <param name="devicesRestClient"> The REST client to perform device, device twin, and bulk operations. </param>
        /// <param name="queryRestClient"> The REST client to perform query operations for the device. </param>
        /// </summary>
        internal DevicesClient(DevicesRestClient devicesRestClient, QueryRestClient queryRestClient)
        {
            Argument.AssertNotNull(devicesRestClient, nameof(devicesRestClient));
            Argument.AssertNotNull(queryRestClient, nameof(queryRestClient));

            _devicesRestClient = devicesRestClient;
            _queryRestClient = queryRestClient;
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
        public virtual Task<Response<DeviceIdentity>> GetIdentityAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.GetDeviceAsync(deviceId, cancellationToken);
        }

        /// <summary>
        /// Get a single device identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<DeviceIdentity> GetIdentity(string deviceId, CancellationToken cancellationToken = default)
        {
            return _devicesRestClient.GetDevice(deviceId, cancellationToken);
        }

        /// <summary>
        /// Delete a single device identity.
        /// </summary>
        /// <param name="deviceIdentity">the device identity to delete. If no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>."/>.</param>
        /// <param name="precondition">The condition on which to delete the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
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
                }.WithTags(x.Value.Tags).WithPropertiesFrom(x.Value.Properties).WithParentScopes(x.Key.ParentScopes));

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
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
                }.WithTags(x.Value.Tags).WithPropertiesFrom(x.Value.Properties).WithParentScopes(x.Key.ParentScopes));

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
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
                }.WithParentScopes(x.ParentScopes));

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
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
                }.WithParentScopes(x.ParentScopes));

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
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
                }.WithParentScopes(x.ParentScopes));

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
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
                }.WithParentScopes(x.ParentScopes));

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
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

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
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

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
        }

        /// <summary>
        /// List a set of device twins.
        /// </summary>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device twins <see cref="AsyncPageable{T}"/>.</returns>
        public virtual AsyncPageable<TwinData> GetTwinsAsync(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TwinData>> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = HubDeviceQuery
                };
                Response<IReadOnlyList<TwinData>> response = await _queryRestClient.GetTwinsAsync(
                    querySpecification,
                    null,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken).ConfigureAwait(false);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            async Task<Page<TwinData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification()
                {
                    Query = HubDeviceQuery
                };
                Response<IReadOnlyList<TwinData>> response = await _queryRestClient.GetTwinsAsync(
                    querySpecification,
                    nextLink,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken).ConfigureAwait(false);

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
        /// <returns>A pageable set of device twins <see cref="Pageable{T}"/>.</returns>
        public virtual Pageable<TwinData> GetTwins(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            Page<TwinData> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = HubDeviceQuery
                };

                Response<IReadOnlyList<TwinData>> response = _queryRestClient.GetTwins(
                    querySpecification,
                    null,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            Page<TwinData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification()
                {
                    Query = HubDeviceQuery
                };
                Response<IReadOnlyList<TwinData>> response = _queryRestClient.GetTwins(
                    querySpecification,
                    nextLink,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken);

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
        /// <returns>The device's twin, including reported properties and desired properties and the http response <see cref="Response{T}"/>.</returns>
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

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
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

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
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
