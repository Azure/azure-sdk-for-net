// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.FrontDoor.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.ResourceManager.FrontDoor
{
    public partial class FrontDoorExperimentResource
    {
        /// <summary>
        /// Gets a Timeseries for a given Experiment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Reports_GetTimeseries</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="startOn"> The start DateTime of the Timeseries in UTC. </param>
        /// <param name="endOn"> The end DateTime of the Timeseries in UTC. </param>
        /// <param name="aggregationInterval"> The aggregation interval of the Timeseries. </param>
        /// <param name="timeSeriesType"> The type of Timeseries. </param>
        /// <param name="endpoint"> The specific endpoint. </param>
        /// <param name="country"> The country associated with the Timeseries. Values are country ISO codes as specified here- https://www.iso.org/iso-3166-country-codes.html. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FrontDoorTimeSeriesInfo>> GetTimeSeriesReportAsync(DateTimeOffset startOn, DateTimeOffset endOn, FrontDoorTimeSeriesAggregationInterval aggregationInterval, FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, CancellationToken cancellationToken = default)
        {
            FrontDoorExperimentResourceGetTimeSeriesReportOptions options = new FrontDoorExperimentResourceGetTimeSeriesReportOptions(startOn, endOn, aggregationInterval, timeSeriesType);
            options.Endpoint = endpoint;
            options.Country = country;

            return await GetTimeSeriesReportAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a Timeseries for a given Experiment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Reports_GetTimeseries</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="startOn"> The start DateTime of the Timeseries in UTC. </param>
        /// <param name="endOn"> The end DateTime of the Timeseries in UTC. </param>
        /// <param name="aggregationInterval"> The aggregation interval of the Timeseries. </param>
        /// <param name="timeSeriesType"> The type of Timeseries. </param>
        /// <param name="endpoint"> The specific endpoint. </param>
        /// <param name="country"> The country associated with the Timeseries. Values are country ISO codes as specified here- https://www.iso.org/iso-3166-country-codes.html. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FrontDoorTimeSeriesInfo> GetTimeSeriesReport(DateTimeOffset startOn, DateTimeOffset endOn, FrontDoorTimeSeriesAggregationInterval aggregationInterval, FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, CancellationToken cancellationToken = default)
        {
            FrontDoorExperimentResourceGetTimeSeriesReportOptions options = new FrontDoorExperimentResourceGetTimeSeriesReportOptions(startOn, endOn, aggregationInterval, timeSeriesType);
            options.Endpoint = endpoint;
            options.Country = country;

            return GetTimeSeriesReport(options, cancellationToken);
        }
    }
}
