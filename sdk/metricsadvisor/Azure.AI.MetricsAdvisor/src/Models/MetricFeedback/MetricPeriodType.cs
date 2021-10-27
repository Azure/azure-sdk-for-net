// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Used by <see cref="MetricPeriodFeedback"/> to tell the service how to determine the period of a
    /// seasonal set of data points.
    /// </summary>
    [CodeGenModel("PeriodType")]
    public readonly partial struct MetricPeriodType
    {
        /// <summary>
        /// Tells the service to disregard any previous period feedback given to the set of data
        /// points affected.
        /// </summary>
        public static MetricPeriodType AutoDetect { get; } = new MetricPeriodType(AutoDetectValue);

        /// <summary>
        /// The data points have their period assigned according to the <see cref="MetricPeriodFeedback.PeriodValue"/>
        /// provided.
        /// </summary>
        public static MetricPeriodType AssignValue { get; } = new MetricPeriodType(AssignValueValue);
    }
}
