// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
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
        private const string HubModuleQuery = "select * from modules";

        private readonly RegistryManagerRestClient _registryManagerClient;
        private readonly TwinRestClient _twinClient;
        private readonly DeviceMethodRestClient _deviceMethodClient;

        protected ModulesClient()
        {
        }

        internal ModulesClient(RegistryManagerRestClient registryManagerClient, TwinRestClient twinRestClient, DeviceMethodRestClient deviceMethodRestClient)
        {
            Argument.AssertNotNull(registryManagerClient, nameof(registryManagerClient));
            Argument.AssertNotNull(twinRestClient, nameof(twinRestClient));
            Argument.AssertNotNull(deviceMethodRestClient, nameof(deviceMethodRestClient));

            _registryManagerClient = registryManagerClient;
            _twinClient = twinRestClient;
            _deviceMethodClient = deviceMethodRestClient;
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
            return _registryManagerClient.CreateOrUpdateModuleAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, ifMatchHeaderValue, cancellationToken);
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
            return _registryManagerClient.CreateOrUpdateModule(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, ifMatchHeaderValue, cancellationToken);
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
            return _registryManagerClient.GetModuleAsync(deviceId, moduleId, cancellationToken);
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
            return _registryManagerClient.GetModule(deviceId, moduleId, cancellationToken);
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
            return _registryManagerClient.GetModulesOnDeviceAsync(deviceId, cancellationToken);
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
            return _registryManagerClient.GetModulesOnDevice(deviceId, cancellationToken);
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
            return _registryManagerClient.DeleteModuleAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId, ifMatchHeaderValue, cancellationToken);
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
            return _registryManagerClient.DeleteModule(moduleIdentity.DeviceId, moduleIdentity.ModuleId, ifMatchHeaderValue, cancellationToken);
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
                    await _registryManagerClient.QueryIotHubAsync(querySpecification, null, pageSizeHint?.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            async Task<Page<TwinData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification();

                Response<IReadOnlyList<TwinData>> response =
                    await _registryManagerClient.QueryIotHubAsync(querySpecification, nextLink, pageSizeHint?.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);

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

                Response<IReadOnlyList<TwinData>> response = _registryManagerClient.QueryIotHub(
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
                Response<IReadOnlyList<TwinData>> response = _registryManagerClient.QueryIotHub(
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
            return _twinClient.GetModuleTwinAsync(deviceId, moduleId, cancellationToken);
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
            return _twinClient.GetModuleTwin(deviceId, moduleId, cancellationToken);
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
            return _twinClient.UpdateModuleTwinAsync(twinUpdate.DeviceId, twinUpdate.ModuleId, twinUpdate, ifMatchHeaderValue, cancellationToken);
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
            return _twinClient.UpdateModuleTwin(twinUpdate.DeviceId, twinUpdate.ModuleId, twinUpdate, ifMatchHeaderValue, cancellationToken);
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
            return _deviceMethodClient.InvokeModuleMethodAsync(deviceId, moduleId, directMethodRequest, cancellationToken);
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
            return _deviceMethodClient.InvokeModuleMethod(deviceId, moduleId, directMethodRequest, cancellationToken);
        }
    }
}
