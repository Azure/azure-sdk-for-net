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
        /// Gets a Latency Scorecard for a given Experiment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/LatencyScorecard
        /// Operation Id: Reports_GetLatencyScorecards
        /// </summary>
        /// <param name="aggregationInterval"> The aggregation interval of the Latency Scorecard. </param>
        /// <param name="endOn"> The end DateTime of the Latency Scorecard in UTC. </param>
        /// <param name="country"> The country associated with the Latency Scorecard. Values are country ISO codes as specified here- https://www.iso.org/iso-3166-country-codes.html. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LatencyScorecard>> GetLatencyScorecardsReportAsync(LatencyScorecardAggregationInterval aggregationInterval, DateTimeOffset? endOn = null, string country = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reportsClientDiagnostics.CreateScope("FrontDoorExperimentResource.GetLatencyScorecardsReport");
            scope.Start();
            try
            {
                var response = await _reportsRestClient.GetLatencyScorecardsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, aggregationInterval, endOn, country, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a Latency Scorecard for a given Experiment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/LatencyScorecard
        /// Operation Id: Reports_GetLatencyScorecards
        /// </summary>
        /// <param name="aggregationInterval"> The aggregation interval of the Latency Scorecard. </param>
        /// <param name="endOn"> The end DateTime of the Latency Scorecard in UTC. </param>
        /// <param name="country"> The country associated with the Latency Scorecard. Values are country ISO codes as specified here- https://www.iso.org/iso-3166-country-codes.html. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LatencyScorecard> GetLatencyScorecardsReport(LatencyScorecardAggregationInterval aggregationInterval, DateTimeOffset? endOn = null, string country = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reportsClientDiagnostics.CreateScope("FrontDoorExperimentResource.GetLatencyScorecardsReport");
            scope.Start();
            try
            {
                var response = _reportsRestClient.GetLatencyScorecards(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, aggregationInterval, endOn, country, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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
        public virtual async Task<Response<FrontDoorTimeSeriesInfo>> GetTimeSeriesReportAsync(DateTimeOffset startOn, DateTimeOffset endOn, FrontDoorTimeSeriesAggregationInterval aggregationInterval, FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reportsClientDiagnostics.CreateScope("FrontDoorExperimentResource.GetTimeSeriesReport");
            scope.Start();
            try
            {
                var response = await _reportsRestClient.GetTimeSeriesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, startOn, endOn, aggregationInterval, timeSeriesType, endpoint, country, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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
        public virtual Response<FrontDoorTimeSeriesInfo> GetTimeSeriesReport(DateTimeOffset startOn, DateTimeOffset endOn, FrontDoorTimeSeriesAggregationInterval aggregationInterval, FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reportsClientDiagnostics.CreateScope("FrontDoorExperimentResource.GetTimeSeriesReport");
            scope.Start();
            try
            {
                var response = _reportsRestClient.GetTimeSeries(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, startOn, endOn, aggregationInterval, timeSeriesType, endpoint, country, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
