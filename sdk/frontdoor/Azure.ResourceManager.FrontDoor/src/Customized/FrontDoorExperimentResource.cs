// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.FrontDoor.Models;

namespace Azure.ResourceManager.FrontDoor
{
    public partial class FrontDoorExperimentResource
    {
        /// <summary>
        /// Gets a Timeseries for a given Experiment.
        /// </summary>
        /// <param name="options"> The options object containing the parameters for the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FrontDoorTimeSeriesInfo>> GetTimeSeriesReportAsync(FrontDoorExperimentResourceGetTimeSeriesReportOptions options, CancellationToken cancellationToken = default)
        {
            return await GetTimeSeriesReportAsync(options.StartOn, options.EndOn, options.AggregationInterval, options.TimeSeriesType, options.Endpoint, options.Country, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a Timeseries for a given Experiment.
        /// </summary>
        /// <param name="options"> The options object containing the parameters for the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FrontDoorTimeSeriesInfo> GetTimeSeriesReport(FrontDoorExperimentResourceGetTimeSeriesReportOptions options, CancellationToken cancellationToken = default)
        {
            return GetTimeSeriesReport(options.StartOn, options.EndOn, options.AggregationInterval, options.TimeSeriesType, options.Endpoint, options.Country, cancellationToken);
        }
    }
}
