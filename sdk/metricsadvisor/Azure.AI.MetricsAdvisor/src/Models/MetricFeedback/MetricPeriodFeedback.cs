﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Feedback indicating that this is an interval of seasonality.
    /// </summary>
    [CodeGenModel("PeriodFeedback")]
    [CodeGenSuppress(nameof(MetricPeriodFeedback), typeof(string), typeof(FeedbackDimensionFilter))]
    public partial class MetricPeriodFeedback : MetricFeedback
    {
        /// <summary> Initializes a new <see cref="MetricPeriodFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The <see cref="FeedbackDimensionFilter"/> to apply to the feedback. </param>
        /// <param name="periodType"> The <see cref="MetricPeriodType"/>. </param>
        /// <param name="periodValue"> The period value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metricId"/> or <paramref name="dimensionFilter"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="metricId"/> is empty. </exception>
        public MetricPeriodFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, MetricPeriodType periodType, int periodValue) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(dimensionFilter, nameof(dimensionFilter));

            ValueInternal = new PeriodFeedbackValue(periodType, periodValue);
            Kind = MetricFeedbackKind.Period;
        }

        /// <summary> Initializes a new instance of MetricPeriodFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="valueInternal"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metricId"/>, <paramref name="dimensionFilter"/>, or <paramref name="valueInternal"/> is null. </exception>
        internal MetricPeriodFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, PeriodFeedbackValue valueInternal) : base(metricId, dimensionFilter)
        {
            if (metricId == null)
            {
                throw new ArgumentNullException(nameof(metricId));
            }
            if (dimensionFilter == null)
            {
                throw new ArgumentNullException(nameof(dimensionFilter));
            }
            if (valueInternal == null)
            {
                throw new ArgumentNullException(nameof(valueInternal));
            }

            ValueInternal = valueInternal;
            Kind = MetricFeedbackKind.Period;
        }

        /// <summary>
        /// The <see cref="MetricPeriodType"/>.
        /// </summary>
        public MetricPeriodType PeriodType { get => ValueInternal.PeriodType; }

        /// <summary>
        /// The period value.
        /// </summary>
        public int PeriodValue { get => ValueInternal.PeriodValue; }

        [CodeGenMember("Value")]
        internal PeriodFeedbackValue ValueInternal { get; }
    }
}
