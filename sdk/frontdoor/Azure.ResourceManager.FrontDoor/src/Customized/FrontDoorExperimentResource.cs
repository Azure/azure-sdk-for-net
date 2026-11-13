// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.FrontDoor.Models;

namespace Azure.ResourceManager.FrontDoor
{
    // Back-compat customization for Reports_GetTimeseries (GetTimeSeriesReport[Async]).
    // The new TypeSpec mgmt generator only emits the expanded-parameters overload. Removing the
    // options-bag overload would be a source/binary breaking change for existing callers. The
    // overloads below reinstate the options-bag overload by delegating to the generated
    // expanded-parameters overload.
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
