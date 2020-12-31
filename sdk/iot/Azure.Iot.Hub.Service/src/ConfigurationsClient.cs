// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Configuration client for automatic device/module management (ADM)
    /// See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-automatic-device-management"> Getting started with automatic device management</see>.
    /// </summary>
    public class ConfigurationsClient
    {
        private readonly ConfigurationRestClient _configurationRestClient;

        /// <summary>
        /// Initializes a new instance of ConfigurationsClient.
        /// </summary>
        protected ConfigurationsClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of ConfigurationsClient.
        /// <param name="configurationRestClient"> The REST client to perform configurations operations. </param>
        /// </summary>
        internal ConfigurationsClient(ConfigurationRestClient configurationRestClient)
        {
            Argument.AssertNotNull(configurationRestClient, nameof(configurationRestClient));

            _configurationRestClient = configurationRestClient;
        }

        /// <summary>
        /// Gets a twin configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configurationId">The unique identifier of the configuration.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved automatic device/module management twin configuration</returns>
        public virtual Task<Response<TwinConfiguration>> GetConfigurationAsync(string configurationId, CancellationToken cancellationToken = default)
        {
            return _configurationRestClient.GetAsync(configurationId, cancellationToken);
        }

        /// <summary>
        /// Gets a twin configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configurationId">The unique identifier of the configuration.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved automatic device/module management twin configuration</returns>
        public virtual Response<TwinConfiguration> GetConfiguration(string configurationId, CancellationToken cancellationToken = default)
        {
            return _configurationRestClient.Get(configurationId, cancellationToken);
        }

        /// <summary>
        /// Create or update a twin configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configuration">Twin configuration to update</param>
        /// <param name="precondition">The condition on which to perform this operation</param>
        /// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
        /// In case of update, if no ETag is present on the twin configuration, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created automatic device/module management twin configuration</returns>
        public virtual Task<Response<TwinConfiguration>> CreateOrUpdateConfigurationAsync(TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(configuration, nameof(configuration));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, configuration.Etag);
            return _configurationRestClient.CreateOrUpdateAsync(configuration.Id, configuration,ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Create or update a twin configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configuration">Twin configuration to update</param>
        /// <param name="precondition">The condition on which to perform this operation</param>
        /// In case of create, the condition must be equal to <see cref="IfMatchPrecondition.IfMatch"/>.
        /// In case of update, if no ETag is present on the twin configuration, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>.
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created automatic device/module management twin configuration</returns>
        public virtual Response<TwinConfiguration> CreateOrUpdateConfiguration(TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(configuration, nameof(configuration));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, configuration.Etag);
            return _configurationRestClient.CreateOrUpdate(configuration.Id, configuration, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Deletes a twin configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configuration">Twin configuration to delete</param>
        /// <param name="precondition">The condition on which to perform this operation. If no ETag is present on the twin configuration, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>."/>.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        public virtual Task<Response> DeleteConfigurationAsync(TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(configuration, nameof(configuration));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, configuration.Etag);
            return _configurationRestClient.DeleteAsync(configuration.Id, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Deletes a twin configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configuration">Twin configuration to delete</param>
        /// <param name="precondition">The condition on which to perform this operation. If no ETag is present on the twin configuration, then the condition must be equal to <see cref="IfMatchPrecondition.UnconditionalIfMatch"/>."/>.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        public virtual Response DeleteConfiguration(TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(configuration, nameof(configuration));
            string ifMatchHeaderValue = IfMatchPreconditionExtensions.GetIfMatchHeaderValue(precondition, configuration.Etag);
            return _configurationRestClient.Delete(configuration.Id, ifMatchHeaderValue, cancellationToken);
        }

        /// <summary>
        /// Gets twin configurations on the IoT Hub for automatic device/module management. Pagination is not supported.
        /// </summary>
        /// <param name="count">The number of configurations to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved list of automatic device/module management twin configurations</returns>
        public virtual Task<Response<IReadOnlyList<TwinConfiguration>>> GetConfigurationsAsync(int? count = null, CancellationToken cancellationToken = default)
        {
            return _configurationRestClient.GetConfigurationsAsync(count, cancellationToken);
        }

        /// <summary>
        /// Gets twin configurations on the IoT Hub for automatic device/module management. Pagination is not supported.
        /// </summary>
        /// <param name="count">The number of configurations to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved list of automatic device/module management twin configurations</returns>
        public virtual Response<IReadOnlyList<TwinConfiguration>> GetConfigurations(int? count = null, CancellationToken cancellationToken = default)
        {
            return _configurationRestClient.GetConfigurations(count, cancellationToken);
        }

        /// <summary>
        /// Validates target condition and custom metric queries for a twin configuration on the IoT Hub.
        /// </summary>
        /// <param name="configuration">The configuration for target condition and custom metric queries.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of validated test queries of automatic device/module management twin configuration</returns>
        public virtual Task<Response<ConfigurationQueriesTestResponse>> TestQueries(ConfigurationQueriesTestInput configuration, CancellationToken cancellationToken = default)
        {
            return _configurationRestClient.TestQueriesAsync(configuration, cancellationToken);
        }

        /// <summary>
        /// Validates target condition and custom metric queries for a twin configuration on the IoT Hub.
        /// </summary>
        /// <param name="configuration">The configuration for target condition and custom metric queries.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of validated test queries of automatic device/module management twin configuration</returns>
        public virtual Response<ConfigurationQueriesTestResponse> TestQueriesAsync(ConfigurationQueriesTestInput configuration, CancellationToken cancellationToken = default)
        {
            return _configurationRestClient.TestQueries(configuration, cancellationToken);
        }
    }
}
