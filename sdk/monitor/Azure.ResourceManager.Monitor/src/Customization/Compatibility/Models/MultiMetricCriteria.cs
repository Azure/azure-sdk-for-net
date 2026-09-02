// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class MultiMetricCriteria
    {
        // The new generated constructor includes the discriminator. Keep the shipped overload without that
        // discriminator parameter and delegate to the generated constructor with the static criterion value.
        /// <summary> Initializes a new instance of <see cref="MultiMetricCriteria"/>. </summary>
        /// <param name="name"> Name of the criteria. </param>
        /// <param name="metricName"> Name of the metric. </param>
        /// <param name="timeAggregation"> The criteria time aggregation types. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="name"/> or <paramref name="metricName"/> is null. </exception>
        public MultiMetricCriteria(string name, string metricName, MetricCriteriaTimeAggregationType timeAggregation)
            : this(ScheduledQueryRuleCriterionType.StaticThresholdCriterion, name, metricName, timeAggregation)
        {
        }
    }
}
