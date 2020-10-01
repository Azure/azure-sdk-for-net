// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The PeriodFeedback. </summary>
    [CodeGenModel("PeriodFeedback")]
    public partial class MetricPeriodFeedback : MetricFeedback
    {
        /// <summary>
        /// The period type.
        /// </summary>
        public PeriodType PeriodType { get => ValueInternal.PeriodType; }

        /// <summary>
        /// The period value.
        /// </summary>
        public int PeriodValue { get => ValueInternal.PeriodValue; }

        [CodeGenMember("Value")]
        internal PeriodFeedbackValue ValueInternal { get; }
    }
}
