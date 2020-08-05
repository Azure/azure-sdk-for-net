// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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
        /// Gets a configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configurationId">The unique identifier of the configuration.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>TwinConfiguration for a automatic device/module management</returns>
        public virtual async Task<Response<TwinConfiguration>> GetConfigurationAsync(string configurationId, CancellationToken cancellationToken = default)
        {

        }

        /// <summary>
        /// Creates a configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configuration">Twin configuration to create</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>TwinConfiguration for a automatic device/module management</returns>
        public virtual async Task<Response<TwinConfiguration>> CreateConfigurationAsync(TwinConfiguration configuration, CancellationToken cancellationToken = default)
        {

        }

        /// <summary>
        /// Updates a configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configurationId">The unique identifier of the configuration.</param>
        /// <param name="configuration">Twin configuration to update</param>
        /// <param name="precondition">The condition on which to perform this operation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>TwinConfiguration for a automatic device/module management</returns>
        public virtual async Task<Response<TwinConfiguration>> UpdateConfigurationAsync(string configurationId, TwinConfiguration configuration, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {

        }

        /// <summary>
        /// Deletes a configuration on the IoT Hub for automatic device/module management
        /// </summary>
        /// <param name="configurationId">The unique identifier of the configuration.</param>
        /// <param name="precondition">The condition on which to perform this operation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The Http Response</returns>
        public virtual async Task<Response> DeleteConfigurationAsync(string configurationId, IfMatchPrecondition precondition = IfMatchPrecondition.IfMatch, CancellationToken cancellationToken = default)
        {

        }

        /// <summary>
        /// Gets configurations on the IoT Hub for automatic device/module management. Pagination is not supported.
        /// </summary>
        /// <param name="count">The number of configurations to retrieve. TODO: Can value be overriden if too large?.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of TwinConfiguration for a automatic device/module management</returns>
        public virtual async Task<Response<IReadOnlyList<TwinConfiguration>>> GetConfigurationsAsync(int? count = null, CancellationToken cancellationToken = default)
        {

        }

        /// <summary>
        /// Validates target condition and custom metric queries for a configuration on the IoT Hub.
        /// </summary>
        /// <param name="configuration">The configuration for target condition and custom metric queries.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>TwinConfiguration for a automatic device/module management</returns>
        public virtual async Task<Response<ConfigurationQueriesTestResponse>> TestQueriesAsync(ConfigurationQueriesTestInput configuration, CancellationToken cancellationToken = default)
        {

        }

        /// <summary>
        /// Applies the provided configuration content to the specified edge device.
        /// </summary>
        /// <param name="id">The unique identifier of the edge device.  TODO service team: Is it just device or edge device?".</param>
        /// <param name="content">Configuration Content. TODO service team: Get more context</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>TODO service team: fix to return empty response</returns>
        public virtual async Task<Response<object>> ApplyOnEdgeDeviceAsync(string id, ConfigurationContent content, CancellationToken cancellationToken = default)
        {

        }
    }
}
