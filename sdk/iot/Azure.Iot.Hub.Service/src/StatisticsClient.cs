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
        private readonly StatisticsRestClient _statisticsRestClient = null;

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

        public virtual Response<DeviceStatistics> GetDeviceStatistics(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetDeviceStatistics(cancellationToken);
        }

        public virtual Task<Response<DeviceStatistics>> GetDeviceStatisticsAsync(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetDeviceStatisticsAsync(cancellationToken);
        }

        public virtual Response<ServiceStatistics> GetServiceStatistics(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetServiceStatistics(cancellationToken);
        }

        public virtual Task<Response<ServiceStatistics>> GetServiceStatisticsAsync(CancellationToken cancellationToken = default)
        {
            return _statisticsRestClient.GetServiceStatisticsAsync(cancellationToken);
        }
    }
}
