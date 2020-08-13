// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// Modules client to interact with device modules and module twins including CRUD operations and method invocations.
    /// See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-portal-csharp-module-twin-getstarted"> Getting started with module identity</see>.
    /// </summary>
    public class ModulesClient
    {
        private const string ContinuationTokenHeader = "x-ms-continuation";
        private const string HubModuleQuery = "select * from devices.modules";

        private readonly DevicesRestClient _devicesRestClient;
        private readonly ModulesRestClient _modulesRestClient;
        private readonly QueryRestClient _queryRestClient;

        /// <summary>
        /// Initializes a new instance of ModulesClient.
        /// </summary>
        protected ModulesClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of DevicesClient.
        /// <param name="devicesRestClient"> The REST client to perform bulk operations on the module. </param>
        /// <param name="modulesRestClient"> The REST client to perform module and module twin operations. </param>
        /// <param name="queryRestClient"> The REST client to perform query operations for the device. </param>
        /// </summary>
        internal ModulesClient(DevicesRestClient devicesRestClient, ModulesRestClient modulesRestClient, QueryRestClient queryRestClient)
        {
            Argument.AssertNotNull(devicesRestClient, nameof(devicesRestClient));
            Argument.AssertNotNull(modulesRestClient, nameof(modulesRestClient));
            Argument.AssertNotNull(queryRestClient, nameof(queryRestClient));

            _devicesRestClient = devicesRestClient;
            _modulesRestClient = modulesRestClient;
            _queryRestClient = queryRestClient;
        }

        /// <summary>
        /// Create a module identity.
        /// </summary>
        /// <param name="moduleIdentity">The module identity to create or update.</param>
        /// <param name="precondition">The condition on which to perform this operation.
        /// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
        /// In case of update, if no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created module identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<ModuleIdentity>> CreateOrUpdateIdentityAsync(
            ModuleIdentity moduleIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(moduleIdentity, nameof(moduleIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, moduleIdentity.Etag);
            return _modulesRestClient.CreateOrUpdateIdentityAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create a module identity.
        /// </summary>
        /// <param name="moduleIdentity">The module identity to create or update.</param>
        /// <param name="precondition">The condition on which to perform this operation.
        /// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
        /// In case of update, if no ETag is present on the device, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created module identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<ModuleIdentity> CreateOrUpdateIdentity(
            ModuleIdentity moduleIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(moduleIdentity, nameof(moduleIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, moduleIdentity.Etag);
            return _modulesRestClient.CreateOrUpdateIdentity(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Get a single module identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved module identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<ModuleIdentity>> GetIdentityAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return _modulesRestClient.GetIdentityAsync(deviceId, moduleId, cancellationToken);
        }

        /// <summary>
        /// Get a single module identity.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved module identity and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<ModuleIdentity> GetIdentity(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return _modulesRestClient.GetIdentity(deviceId, moduleId, cancellationToken);
        }

        /// <summary>
        /// Get a set of module identities for a specific device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of modules identities within a device and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<IReadOnlyList<ModuleIdentity>>> GetIdentitiesAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deviceId, nameof(deviceId));
            return _modulesRestClient.GetModulesOnDeviceAsync(deviceId, cancellationToken);
        }

        /// <summary>
        /// Get a set of module identities for a specific device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of modules identities within a device and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<IReadOnlyList<ModuleIdentity>> GetIdentities(string deviceId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deviceId, nameof(deviceId));
            return _modulesRestClient.GetModulesOnDevice(deviceId, cancellationToken);
        }

        /// <summary>
        /// Delete a single module identity.
        /// </summary>
        /// <param name="moduleIdentity">The module identity to delete. If no ETag is present on the module identity, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.</param>
        /// <param name="precondition">The condition on which to delete the module identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response> DeleteIdentityAsync(
            ModuleIdentity moduleIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(moduleIdentity, nameof(moduleIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, moduleIdentity.Etag);
            return _modulesRestClient.DeleteIdentityAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Delete a single module identity.
        /// </summary>
        /// <param name="moduleIdentity">The module identity to delete. If no ETag is present on the module identity, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.</param>
        /// <param name="precondition">The condition on which to delete the module identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        public virtual Response DeleteIdentity(
            ModuleIdentity moduleIdentity,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(moduleIdentity, nameof(moduleIdentity));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, moduleIdentity.Etag);
            return _modulesRestClient.DeleteIdentity(moduleIdentity.DeviceId, moduleIdentity.ModuleId, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create multiple modules with an initial twin. A maximum of 100 creations can be done per call,
        /// and each creation must have a unique module identity. Multiple modules may be created on a single device.
        /// All devices that these new modules will belong to must already exist.
        /// For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="modules">The pairs of modules and their twins that will be created. For fields such as deviceId
        /// where device and twin have a definition, the device value will override the twin value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> CreateIdentitiesWithTwinAsync(IDictionary<ModuleIdentity, TwinData> modules, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = modules
                .Select(x => new ExportImportDevice()
                {
                    Id = x.Key.DeviceId,
                    ModuleId = x.Key.ModuleId,
                    Authentication = x.Key.Authentication,
                    ImportMode = ExportImportDeviceImportMode.Create
                }.WithTags(x.Value.Tags).WithPropertiesFrom(x.Value.Properties));

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple modules with an initial twin. A maximum of 100 creations can be done per call,
        /// and each creation must have a unique module identity. Multiple modules may be created on a single device.
        /// All devices that these new modules will belong to must already exist.
        /// For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="modules">The pairs of modules and their twins that will be created. For fields such as deviceId
        /// where device and twin have a definition, the device value will override the twin value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> CreateIdentitiesWithTwin(IDictionary<ModuleIdentity, TwinData> modules, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = modules
                .Select(x => new ExportImportDevice()
                {
                    Id = x.Key.DeviceId,
                    ModuleId = x.Key.ModuleId,
                    Authentication = x.Key.Authentication,
                    ImportMode = ExportImportDeviceImportMode.Create
                }.WithTags(x.Value.Tags).WithPropertiesFrom(x.Value.Properties));

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple modules. A maximum of 100 creations can be done per call, and each module identity must be unique.
        /// All devices that these modules will belong to must already exist. Multiple modules can be created at a time on a single device.
        /// For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="moduleIdentities">The module identities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> CreateIdentitiesAsync(IEnumerable<ModuleIdentity> moduleIdentities, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = moduleIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ModuleId = x.ModuleId,
                    Authentication = x.Authentication,
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Create multiple modules. A maximum of 100 creations can be done per call, and each module identity must be unique.
        /// All devices that these modules will belong to must already exist. Multiple modules can be created at a time on a single device.
        /// For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="moduleIdentities">The module identities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> CreateIdentities(IEnumerable<ModuleIdentity> moduleIdentities, CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = moduleIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ModuleId = x.ModuleId,
                    Authentication = x.Authentication,
                    ImportMode = ExportImportDeviceImportMode.Create
                });

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple modules. A maximum of 100 updates can be done per call, and each operation must be done on a different module identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>..
        /// </summary>
        /// <param name="moduleIdentities">The modules to update.</param>
        /// <param name="precondition">The condition on which to update each module identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> UpdateIdentitiesAsync(
            IEnumerable<ModuleIdentity> moduleIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = moduleIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ModuleId = x.ModuleId,
                    Authentication = x.Authentication,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Update : ExportImportDeviceImportMode.UpdateIfMatchETag
                });

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple modules. A maximum of 100 updates can be done per call, and each operation must be done on a different module identity. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>..
        /// </summary>
        /// <param name="moduleIdentities">The modules to update.</param>
        /// <param name="precondition">The condition on which to update each module identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk operation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> UpdateIdentities(
            IEnumerable<ModuleIdentity> moduleIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = moduleIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ModuleId = x.ModuleId,
                    Authentication = x.Authentication,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.Update : ExportImportDeviceImportMode.UpdateIfMatchETag
                });

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Delete multiple modules. A maximum of 100 deletions can be done per call. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="moduleIdentities">The modules to delete.</param>
        /// <param name="precondition">The condition on which to delete each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk deletion and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<BulkRegistryOperationResponse>> DeleteIdentitiesAsync(
            IEnumerable<ModuleIdentity> moduleIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = moduleIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ModuleId = x.ModuleId,
                    ETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional
                        ? ExportImportDeviceImportMode.Delete
                        : ExportImportDeviceImportMode.DeleteIfMatchETag
                });

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Delete multiple modules. A maximum of 100 deletions can be done per call. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
        /// </summary>
        /// <param name="moduleIdentities">The devices to delete.</param>
        /// <param name="precondition">The condition on which to delete each device identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the bulk deletion and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<BulkRegistryOperationResponse> DeleteIdentities(
            IEnumerable<ModuleIdentity> moduleIdentities,
            BulkIfMatchPrecondition precondition = BulkIfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ExportImportDevice> registryOperations = moduleIdentities
                .Select(x => new ExportImportDevice()
                {
                    Id = x.DeviceId,
                    ModuleId = x.ModuleId,
                    ETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional
                        ? ExportImportDeviceImportMode.Delete
                        : ExportImportDeviceImportMode.DeleteIfMatchETag
                });

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
        }

        /// <summary>
        /// List a set of module twins.
        /// </summary>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of module twins <see cref="AsyncPageable{T}"/>.</returns>
        public virtual AsyncPageable<TwinData> GetTwinsAsync(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TwinData>> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = HubModuleQuery
                };

                Response<IReadOnlyList<TwinData>> response =
                    await _queryRestClient.GetTwinsAsync(querySpecification, null, pageSizeHint?.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            async Task<Page<TwinData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification();

                Response<IReadOnlyList<TwinData>> response =
                    await _queryRestClient.GetTwinsAsync(querySpecification, nextLink, pageSizeHint?.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc, pageSize);
        }

        /// <summary>
        /// List a set of module twins.
        /// </summary>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of module twins <see cref="Pageable{T}"/>.</returns>
        public virtual Pageable<TwinData> GetTwins(int? pageSize = null, CancellationToken cancellationToken = default)
        {
            Page<TwinData> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = HubModuleQuery
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
                var querySpecification = new QuerySpecification();
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
        /// Get a module's twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity.</param>
        /// <param name="moduleId">The unique identifier of the module identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The module's twin, including reported properties and desired properties and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<TwinData>> GetTwinAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return _modulesRestClient.GetTwinAsync(deviceId, moduleId, cancellationToken);
        }

        /// <summary>
        /// Get a module's twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device identity.</param>
        /// <param name="moduleId">The unique identifier of the module identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The module's twin, including reported properties and desired properties and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<TwinData> GetTwin(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return _modulesRestClient.GetTwin(deviceId, moduleId, cancellationToken);
        }

        /// <summary>
        /// Update a module's twin.
        /// </summary>
        /// <param name="twinUpdate">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="precondition">The condition for which this operation will execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new representation of the module's twin and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<TwinData>> UpdateTwinAsync(
            TwinData twinUpdate,
            IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twinUpdate, nameof(twinUpdate));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, twinUpdate.Etag);
            return _modulesRestClient.UpdateTwinAsync(twinUpdate.DeviceId, twinUpdate.ModuleId, twinUpdate, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Update a module's twin.
        /// </summary>
        /// <param name="twinUpdate">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="precondition">The condition for which this operation will execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new representation of the module's twin and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<TwinData> UpdateTwin(TwinData twinUpdate, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twinUpdate, nameof(twinUpdate));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, twinUpdate.Etag);
            return _modulesRestClient.UpdateTwin(twinUpdate.DeviceId, twinUpdate.ModuleId, twinUpdate, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Update multiple modules' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different module twin. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
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
                    ModuleId = x.ModuleId,
                    TwinETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional ? ExportImportDeviceImportMode.UpdateTwin : ExportImportDeviceImportMode.UpdateTwinIfMatchETag
                }.WithTags(x.Tags).WithPropertiesFrom(x.Properties));

            return _devicesRestClient.BulkRegistryOperationsAsync(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Update multiple modules' twins. A maximum of 100 updates can be done per call, and each operation must be done on a different device twin. For larger scale operations, consider using <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-identity-registry#import-and-export-device-identities">IoT Hub jobs</see>.
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
                    ModuleId = x.ModuleId,
                    TwinETag = x.Etag,
                    ImportMode = precondition == BulkIfMatchPrecondition.Unconditional
                        ? ExportImportDeviceImportMode.UpdateTwin
                        : ExportImportDeviceImportMode.UpdateTwinIfMatchETag
                }.WithTags(x.Tags).WithPropertiesFrom(x.Properties));

            return _devicesRestClient.BulkRegistryOperations(registryOperations, cancellationToken);
        }

        /// <summary>
        /// Invoke a method on a module.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="moduleId">The unique identifier of the module identity to invoke the method on.</param>
        /// <param name="directMethodRequest">The details of the method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the method invocation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response<CloudToDeviceMethodResponse>> InvokeMethodAsync(
            string deviceId,
            string moduleId,
            CloudToDeviceMethodRequest directMethodRequest,
            CancellationToken cancellationToken = default)
        {
            return _modulesRestClient.InvokeMethodAsync(deviceId, moduleId, directMethodRequest, cancellationToken);
        }

        /// <summary>
        /// Invoke a method on a module.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="moduleId">The unique identifier of the module identity to invoke the method on.</param>
        /// <param name="directMethodRequest">The details of the method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the method invocation and the http response <see cref="Response{T}"/>.</returns>
        public virtual Response<CloudToDeviceMethodResponse> InvokeMethod(
            string deviceId,
            string moduleId,
            CloudToDeviceMethodRequest directMethodRequest,
            CancellationToken cancellationToken = default)
        {
            return _modulesRestClient.InvokeMethod(deviceId, moduleId, directMethodRequest, cancellationToken);
        }
    }
}
