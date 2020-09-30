// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The PeriodFeedback. </summary>
    public partial class PeriodFeedback : MetricFeedback
    {
        /// <summary>
        /// The value of the feedback.
        /// </summary>
        public PeriodFeedbackValue Value { get; set; }
    }
}
