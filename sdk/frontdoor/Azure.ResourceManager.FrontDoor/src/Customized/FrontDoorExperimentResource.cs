// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.FrontDoor.Models;

namespace Azure.ResourceManager.FrontDoor
{
    /// <summary>
    /// A Class representing a FrontDoorExperiment along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="FrontDoorExperimentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetFrontDoorExperimentResource method.
    /// Otherwise you can get one from its parent resource <see cref="FrontDoorNetworkExperimentProfileResource" /> using the GetFrontDoorExperiment method.
    /// </summary>
    public partial class FrontDoorExperimentResource : ArmResource
    {
        /// <summary>
        /// Gets a Timeseries for a given Experiment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries
        /// Operation Id: Reports_GetTimeseries
        /// </summary>
        /// <param name="startOn"> The start DateTime of the Timeseries in UTC. </param>
        /// <param name="endOn"> The end DateTime of the Timeseries in UTC. </param>
        /// <param name="aggregationInterval"> The aggregation interval of the Timeseries. </param>
        /// <param name="timeSeriesType"> The type of Timeseries. </param>
        /// <param name="endpoint"> The specific endpoint. </param>
        /// <param name="country"> The country associated with the Timeseries. Values are country ISO codes as specified here- https://www.iso.org/iso-3166-country-codes.html. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<FrontDoorTimeSeriesInfo>> GetTimeSeriesReportAsync(DateTimeOffset startOn, DateTimeOffset endOn, FrontDoorTimeSeriesAggregationInterval aggregationInterval, FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, CancellationToken cancellationToken = default) =>
            await GetTimeSeriesReportAsync(new FrontDoorExperimentResourceGetTimeSeriesReportOptions(startOn, endOn, aggregationInterval, timeSeriesType)
            {
                Endpoint = endpoint,
                Country = country
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a Timeseries for a given Experiment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries
        /// Operation Id: Reports_GetTimeseries
        /// </summary>
        /// <param name="startOn"> The start DateTime of the Timeseries in UTC. </param>
        /// <param name="endOn"> The end DateTime of the Timeseries in UTC. </param>
        /// <param name="aggregationInterval"> The aggregation interval of the Timeseries. </param>
        /// <param name="timeSeriesType"> The type of Timeseries. </param>
        /// <param name="endpoint"> The specific endpoint. </param>
        /// <param name="country"> The country associated with the Timeseries. Values are country ISO codes as specified here- https://www.iso.org/iso-3166-country-codes.html. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<FrontDoorTimeSeriesInfo> GetTimeSeriesReport(DateTimeOffset startOn, DateTimeOffset endOn, FrontDoorTimeSeriesAggregationInterval aggregationInterval, FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, CancellationToken cancellationToken = default) =>
            GetTimeSeriesReport(new FrontDoorExperimentResourceGetTimeSeriesReportOptions(startOn, endOn, aggregationInterval, timeSeriesType)
            {
                Endpoint = endpoint,
                Country = country
            }, cancellationToken);
    }
}
