// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// For seasonal data, when performing anomaly detection, one step is to estimate the period (seasonality) of the time series,
    /// and apply it to the anomaly detection phase. Sometimes, it's hard to identify a precise period, and the period may also
    /// change. An incorrectly defined period may have side effects on the anomaly detection results. This class allows providing
    /// feedback for a period to fix this kind of anomaly detection error.
    /// </summary>
    /// <remarks>
    /// In order to create period feedback, you must pass this instance to the method
    /// <see cref="MetricsAdvisorClient.AddFeedbackAsync"/>.
    /// </remarks>
    [CodeGenModel("PeriodFeedback")]
    [CodeGenSuppress(nameof(MetricPeriodFeedback), typeof(string), typeof(FeedbackFilter))]
    public partial class MetricPeriodFeedback : MetricFeedback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricPeriodFeedback"/> class.
        /// </summary>
        /// <param name="metricId">The identifier of the metric to which the <see cref="MetricPeriodFeedback"/> applies.</param>
        /// <param name="dimensionKey">
        /// A key that identifies a set of time series to which the <see cref="MetricPeriodFeedback"/> applies.
        /// If all possible dimensions are set, this key uniquely identifies a single time series
        /// for the specified <paramref name="metricId"/>. If only a subset of dimensions are set, this
        /// key uniquely identifies a group of time series.
        /// </param>
        /// <param name="periodType">Tells the service how to determine the period of the seasonal data.</param>
        /// <param name="periodValue">The expected value of the period, measured in amount of data points. 0 means non-seasonal data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionKey"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty.</exception>
        public MetricPeriodFeedback(string metricId, DimensionKey dimensionKey, MetricPeriodType periodType, int periodValue)
            : base(metricId, dimensionKey)
        {
            ValueInternal = new PeriodFeedbackValue(periodType, periodValue);
            FeedbackKind = MetricFeedbackKind.Period;
        }

        /// <summary> Initializes a new instance of MetricPeriodFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="feedbackFilter"> . </param>
        /// <param name="valueInternal"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metricId"/>, <paramref name="feedbackFilter"/>, or <paramref name="valueInternal"/> is null. </exception>
        internal MetricPeriodFeedback(string metricId, FeedbackFilter feedbackFilter, PeriodFeedbackValue valueInternal)
            : base(metricId, feedbackFilter.DimensionKey)
        {
            if (valueInternal == null)
            {
                throw new ArgumentNullException(nameof(valueInternal));
            }

            ValueInternal = valueInternal;
            FeedbackKind = MetricFeedbackKind.Period;
        }

        /// <summary>
        /// Tells the service how to determine the period of the seasonal data.
        /// </summary>
        public MetricPeriodType PeriodType => ValueInternal.PeriodType;

        /// <summary>
        /// The expected value of the period, measured in amount of data points. 0 means non-seasonal data.
        /// </summary>
        public int PeriodValue => ValueInternal.PeriodValue;

        [CodeGenMember("Value")]
        internal PeriodFeedbackValue ValueInternal { get; }
    }
}
