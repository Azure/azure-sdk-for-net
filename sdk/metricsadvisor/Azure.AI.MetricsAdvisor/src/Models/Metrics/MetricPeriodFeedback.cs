// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Feedback indicating that this is an interval of seasonality.
    /// </summary>
    [CodeGenModel("PeriodFeedback")]
    public partial class MetricPeriodFeedback : MetricFeedback
    {
        /// <summary> Initializes a new <see cref="MetricPeriodFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The <see cref="FeedbackDimensionFilter"/> to apply to the feedback. </param>
        /// <param name="value"> The <see cref="PeriodFeedbackValue"/> for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metricId"/>, <paramref name="dimensionFilter"/>, or <paramref name="value"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="metricId"/> is empty. </exception>
        public MetricPeriodFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, PeriodFeedbackValue value) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(dimensionFilter, nameof(dimensionFilter));
            Argument.AssertNotNull(value, nameof(value));

            ValueInternal = value;
            Type = FeedbackType.Period;
        }

        /// <summary>
        /// The <see cref="Models.PeriodType"/>.
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
