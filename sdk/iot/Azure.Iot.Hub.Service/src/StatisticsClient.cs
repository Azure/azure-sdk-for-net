// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Statistics client to acquire information about IoT Hub statistics.
    /// </summary>
    public class StatisticsClient
    {
        private readonly StatisticsRestClient _statisticsRestClient;

        /// <summary>
        /// Initializes a new instance of StatisticsClient.
        /// </summary>
        protected StatisticsClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of StatisticsClient.
        /// <param name="statisticsRestClient"> The REST client to query statistics of the IoT Hub. </param>
        /// </summary>
        internal StatisticsClient(StatisticsRestClient statisticsRestClient)
        {
            Argument.AssertNotNull(statisticsRestClient, nameof(statisticsRestClient));

            _statisticsRestClient = statisticsRestClient;
        }

        /// <summary>
        /// Gets devices statistics of the IoT Hub identity registry.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The devices statistics of the IoT Hub.</returns>
        public virtual Response<DevicesStatistics> GetDevicesStatistics(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetDeviceStatistics(cancellationToken);
        }

        /// <summary>
        /// Gets devices statistics of the IoT Hub identity registry.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The devices statistics of the IoT Hub.</returns>
        public virtual Task<Response<DevicesStatistics>> GetDevicesStatisticsAsync(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetDeviceStatisticsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets service statistics of the IoT Hub.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The service statistics of the IoT Hub.</returns>
        public virtual Response<ServiceStatistics> GetServiceStatistics(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetServiceStatistics(cancellationToken);
        }

        /// <summary>
        /// Gets service statistics of the IoT Hub.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The service statistics of the IoT Hub.</returns>
        public virtual Task<Response<ServiceStatistics>> GetServiceStatisticsAsync(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetServiceStatisticsAsync(cancellationToken);
        }
    }
}
