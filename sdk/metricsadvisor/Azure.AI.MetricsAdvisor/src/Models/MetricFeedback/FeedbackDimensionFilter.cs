// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Filters the result of feedback-related operations.
    /// </summary>
    public partial class FeedbackDimensionFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackDimensionFilter"/> class.
        /// </summary>
        public FeedbackDimensionFilter()
        {
        }

        /// <summary> Initializes a new instance of FeedbackDimensionFilter. </summary>
        /// <param name="dimension"> metric dimension filter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimension"/> is null. </exception>
        internal FeedbackDimensionFilter(IDictionary<string, string> dimension)
        {
            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            Dimension = dimension;
        }

        /// <summary>
        /// Filters the result by time series. Only feedback for the series in the time series specified will be
        /// returned. If all possible dimensions are set, this key uniquely identifies a single time series for the
        /// corresponding metric. If only a subset of dimensions are set, this key identifies a group of time series.
        /// </summary>
        public DimensionKey DimensionKey { get; set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal IDictionary<string, string> Dimension
        {
            get => DimensionKey?.Dimension ?? new Dictionary<string, string>();
            set => DimensionKey = new DimensionKey(value);
        }
    }
}
