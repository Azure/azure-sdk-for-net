// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor
{
    /// <summary>
    /// A Class representing an AutoscaleSetting along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AutoscaleSettingResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAutoscaleSettingResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetAutoscaleSetting method.
    /// </summary>
    public partial class AutoscaleSettingResource : ArmResource
    {
        /// <summary>
        /// get predictive autoscale metric future data
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/autoscalesettings/{autoscaleSettingName}/predictiveMetrics
        /// Operation Id: PredictiveMetric_Get
        /// </summary>
        /// <param name="timespan"> The timespan of the query. It is a string with the following format &apos;startDateTime_ISO/endDateTime_ISO&apos;. </param>
        /// <param name="interval"> The interval (i.e. timegrain) of the query. </param>
        /// <param name="metricNamespace"> Metric namespace to query metric definitions for. </param>
        /// <param name="metricName"> The names of the metrics (comma separated) to retrieve. Special case: If a metricname itself has a comma in it then use %2 to indicate it. Eg: &apos;Metric,Name1&apos; should be **&apos;Metric%2Name1&apos;**. </param>
        /// <param name="aggregation"> The list of aggregation types (comma separated) to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timespan"/>, <paramref name="metricNamespace"/>, <paramref name="metricName"/> or <paramref name="aggregation"/> is null. </exception>
        public virtual async Task<Response<AutoscaleSettingPredicativeResult>> GetPredictiveMetricAsync(string timespan, TimeSpan interval, string metricNamespace, string metricName, string aggregation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(timespan, nameof(timespan));
            Argument.AssertNotNull(metricNamespace, nameof(metricNamespace));
            Argument.AssertNotNull(metricName, nameof(metricName));
            Argument.AssertNotNull(aggregation, nameof(aggregation));

            using var scope = _predictiveMetricClientDiagnostics.CreateScope("AutoscaleSettingResource.GetPredictiveMetric");
            scope.Start();
            try
            {
                var response = await _predictiveMetricRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, timespan, interval, metricNamespace, metricName, aggregation, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// get predictive autoscale metric future data
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/autoscalesettings/{autoscaleSettingName}/predictiveMetrics
        /// Operation Id: PredictiveMetric_Get
        /// </summary>
        /// <param name="timespan"> The timespan of the query. It is a string with the following format &apos;startDateTime_ISO/endDateTime_ISO&apos;. </param>
        /// <param name="interval"> The interval (i.e. timegrain) of the query. </param>
        /// <param name="metricNamespace"> Metric namespace to query metric definitions for. </param>
        /// <param name="metricName"> The names of the metrics (comma separated) to retrieve. Special case: If a metricname itself has a comma in it then use %2 to indicate it. Eg: &apos;Metric,Name1&apos; should be **&apos;Metric%2Name1&apos;**. </param>
        /// <param name="aggregation"> The list of aggregation types (comma separated) to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timespan"/>, <paramref name="metricNamespace"/>, <paramref name="metricName"/> or <paramref name="aggregation"/> is null. </exception>
        public virtual Response<AutoscaleSettingPredicativeResult> GetPredictiveMetric(string timespan, TimeSpan interval, string metricNamespace, string metricName, string aggregation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(timespan, nameof(timespan));
            Argument.AssertNotNull(metricNamespace, nameof(metricNamespace));
            Argument.AssertNotNull(metricName, nameof(metricName));
            Argument.AssertNotNull(aggregation, nameof(aggregation));

            using var scope = _predictiveMetricClientDiagnostics.CreateScope("AutoscaleSettingResource.GetPredictiveMetric");
            scope.Start();
            try
            {
                var response = _predictiveMetricRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, timespan, interval, metricNamespace, metricName, aggregation, cancellationToken);
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
