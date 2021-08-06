﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Contains details about the data ingested by a time series, but with additional content from an
    /// <see cref="AnomalyDetectionConfiguration"/>. To make plotting easier, this data is scattered
    /// across different lists, such as <see cref="Timestamps"/> and <see cref="MetricValues"/>. A data
    /// point is represented by the same index across these lists.
    /// </summary>
    [CodeGenModel("SeriesResult")]
    [CodeGenSuppress(nameof(MetricEnrichedSeriesData), typeof(SeriesIdentity), typeof(IEnumerable<DateTimeOffset>), typeof(IEnumerable<double>), typeof(IEnumerable<bool?>), typeof(IEnumerable<int?>), typeof(IEnumerable<double?>), typeof(IEnumerable<double?>), typeof(IEnumerable<double?>))]
    [CodeGenSuppress("Series")]
    public partial class MetricEnrichedSeriesData
    {
        internal MetricEnrichedSeriesData(SeriesIdentity series, IReadOnlyList<DateTimeOffset> timestamps, IReadOnlyList<double> values, IReadOnlyList<bool?> isAnomaly, IReadOnlyList<int?> periods, IReadOnlyList<double?> expectedValues, IReadOnlyList<double?> lowerBoundaries, IReadOnlyList<double?> upperBoundaries)
        {
            SeriesKey = new DimensionKey(series.Dimension);
            Timestamps = timestamps;
            MetricValues = values;
            IsAnomaly = isAnomaly;
            Periods = periods;
            ExpectedMetricValues = expectedValues;
            LowerBoundaryValues = lowerBoundaries;
            UpperBoundaryValues = upperBoundaries;
        }

        /// <summary>
        /// The key that, within a metric, uniquely identifies this time series. In this key,
        /// a value is assigned to every possible dimension.
        /// </summary>
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// The timestamps, in UTC, of the data points present in this time series.
        /// </summary>
        [CodeGenMember("TimestampList")]
        public IReadOnlyList<DateTimeOffset> Timestamps { get; }

        /// <summary>
        /// The values of the data points present in this time series.
        /// </summary>
        [CodeGenMember("ValueList")]
        public IReadOnlyList<double> MetricValues { get; }

        /// <summary>
        /// The expected values of the data points in this time series, according
        /// to the associated <see cref="AnomalyDetectionConfiguration"/>'s smart
        /// detector.
        /// </summary>
        [CodeGenMember("ExpectedValueList")]
        public IReadOnlyList<double?> ExpectedMetricValues { get; }

        /// <summary>
        /// Whether or not a data point is considered an anomaly, according to the
        /// associated <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        [CodeGenMember("IsAnomalyList")]
        public IReadOnlyList<bool?> IsAnomaly { get; }

        /// <summary>
        /// The period of every data point in this time series, measured in amount of
        /// points. Used to describe seasonal data.
        /// </summary>
        [CodeGenMember("PeriodList")]
        public IReadOnlyList<int?> Periods { get; }

        /// <summary>
        /// The lower boundaries the data points in this time series must cross to
        /// be considered anomalies, according the associated <see cref="AnomalyDetectionConfiguration"/>'s
        /// smart detector.
        /// </summary>
        [CodeGenMember("LowerBoundaryList")]
        public IReadOnlyList<double?> LowerBoundaryValues { get; }

        /// <summary>
        /// The upper boundaries the data points in this time series must cross to
        /// be considered anomalies, according the associated <see cref="AnomalyDetectionConfiguration"/>'s
        /// smart detector.
        /// </summary>
        [CodeGenMember("UpperBoundaryList")]
        public IReadOnlyList<double?> UpperBoundaryValues { get; }
    }
}
