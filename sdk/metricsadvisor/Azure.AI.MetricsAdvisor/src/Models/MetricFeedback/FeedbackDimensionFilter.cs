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
            DimensionFilter = new DimensionKey();
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
        /// Filters the result by series. Only feedbacks for the series in the time series group specified will
        /// be returned.
        /// </summary>
        public DimensionKey DimensionFilter { get; private set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal IDictionary<string, string> Dimension
        {
            get => DimensionFilter.Dimension;
            set => DimensionFilter = new DimensionKey(value);
        }
    }
}
