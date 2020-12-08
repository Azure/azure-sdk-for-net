// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("SeriesResult")]
    [CodeGenSuppress(nameof(MetricEnrichedSeriesData), typeof(SeriesIdentity), typeof(IEnumerable<DateTimeOffset>), typeof(IEnumerable<double>), typeof(IEnumerable<bool>), typeof(IEnumerable<int>), typeof(IEnumerable<double>), typeof(IEnumerable<double>), typeof(IEnumerable<double>))]
    [CodeGenSuppress("Series")]
    public partial class MetricEnrichedSeriesData
    {
        internal MetricEnrichedSeriesData(SeriesIdentity series, IReadOnlyList<DateTimeOffset> timestamps, IReadOnlyList<double> values, IReadOnlyList<bool> isAnomaly, IReadOnlyList<int> periods, IReadOnlyList<double> expectedValues, IReadOnlyList<double> lowerBoundaries, IReadOnlyList<double> upperBoundaries)
        {
            SeriesKey = new DimensionKey(series.Dimension);
            Timestamps = timestamps;
            Values = values;
            IsAnomaly = isAnomaly;
            Periods = periods;
            ExpectedValues = expectedValues;
            LowerBoundaries = lowerBoundaries;
            UpperBoundaries = upperBoundaries;
        }

        /// <summary>
        /// </summary>
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("TimestampList")]
        public IReadOnlyList<DateTimeOffset> Timestamps { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("ValueList")]
        public IReadOnlyList<double> Values { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("ExpectedValueList")]
        public IReadOnlyList<double> ExpectedValues { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("IsAnomalyList")]
        public IReadOnlyList<bool> IsAnomaly { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("PeriodList")]
        public IReadOnlyList<int> Periods { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("LowerBoundaryList")]
        public IReadOnlyList<double> LowerBoundaries { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("UpperBoundaryList")]
        public IReadOnlyList<double> UpperBoundaries { get; }
    }
}
