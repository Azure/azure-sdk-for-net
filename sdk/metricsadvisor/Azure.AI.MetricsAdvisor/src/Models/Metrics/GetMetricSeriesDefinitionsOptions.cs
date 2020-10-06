// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetMetricSeriesDefinitionsOptions
    {
        private IDictionary<string, IList<string>> _dimensionCombinationsToFilter;

        /// <summary>
        /// </summary>
        public GetMetricSeriesDefinitionsOptions(DateTimeOffset activeSince)
        {
            ActiveSince = activeSince;
            DimensionCombinationsToFilter = new ChangeTrackingDictionary<string, IList<string>>();
        }

        /// <summary>
        /// </summary>
        public DateTimeOffset ActiveSince { get; }

        /// <summary>
        /// </summary>
        public IDictionary<string, IList<string>> DimensionCombinationsToFilter
        {
            get => _dimensionCombinationsToFilter;
            set
            {
                Argument.AssertNotNull(value, nameof(DimensionCombinationsToFilter));
                _dimensionCombinationsToFilter = value;
            }
        }

        /// <summary>
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// </summary>
        public int? TopCount { get; set; }
    }
}
