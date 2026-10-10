// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class MetricTrigger
    {
        private IList<AutoscaleRuleMetricDimension> _dimensions;

        // TypeSpec now generates ComparisonOperator with a new enum to avoid preserving the old enum's numeric values.
        // Keep the old Operator surface backed by the generated property for binary/source compatibility.
        /// <summary> Initializes a new instance of <see cref="MetricTrigger"/>. </summary>
        /// <param name="metricName"> The name of the metric that defines what the rule monitors. </param>
        /// <param name="metricResourceId"> The resource identifier of the resource the rule monitors. </param>
        /// <param name="timeGrain"> The granularity of metrics the rule monitors. </param>
        /// <param name="statistic"> The metric statistic type. </param>
        /// <param name="timeWindow"> The range of time in which instance data is collected. </param>
        /// <param name="timeAggregation"> The time aggregation type. </param>
        /// <param name="operator"> The operator that is used to compare the metric data and the threshold. </param>
        /// <param name="threshold"> The threshold of the metric that triggers the scale action. </param>
        [Obsolete("This API is no longer supported. Use the constructor overload that takes MetricTriggerComparisonOperator instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetricTrigger(string metricName, ResourceIdentifier metricResourceId, TimeSpan timeGrain, MetricStatisticType statistic, TimeSpan timeWindow, MetricTriggerTimeAggregationType timeAggregation, MetricTriggerComparisonOperation @operator, double threshold)
            : this(metricName, metricResourceId, timeGrain, statistic, timeWindow, timeAggregation, MetricTriggerComparisonOperationHelper.FromLegacyComparisonOperation(@operator), threshold)
        {
        }

        /// <summary> The operator that is used to compare the metric data and the threshold. </summary>
        [Obsolete("This API is no longer supported. Use ComparisonOperator instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetricTriggerComparisonOperation Operator
        {
            get => MetricTriggerComparisonOperationHelper.ToLegacyComparisonOperation(ComparisonOperator);
            set => ComparisonOperator = MetricTriggerComparisonOperationHelper.FromLegacyComparisonOperation(value);
        }

        /// <summary> List of dimension conditions. </summary>
        public IList<AutoscaleRuleMetricDimension> Dimensions
        {
            get
            {
                if (_dimensions is null)
                {
                    _dimensions = new ChangeTrackingList<AutoscaleRuleMetricDimension>();
                }
                return _dimensions;
            }
            set => _dimensions = value;
        }
    }
}
