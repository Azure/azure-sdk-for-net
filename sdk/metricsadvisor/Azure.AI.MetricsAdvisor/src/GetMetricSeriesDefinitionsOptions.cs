// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetMetricSeriesDefinitions"/>
    /// or <see cref="MetricsAdvisorClient.GetMetricSeriesDefinitionsAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetMetricSeriesDefinitionsOptions
    {
        private IDictionary<string, IList<string>> _dimensionCombinationsToFilter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMetricSeriesDefinitionsOptions"/> class.
        /// </summary>
        /// <param name="activeSince">Filters the result. Time series that haven't been active since this point in time, in UTC, won't be listed.</param>
        public GetMetricSeriesDefinitionsOptions(DateTimeOffset activeSince)
        {
            ActiveSince = activeSince;
            DimensionCombinationsToFilter = new ChangeTrackingDictionary<string, IList<string>>();
        }

        /// <summary>
        /// Filters the result. Time series that haven't been active since this point in time, in UTC, won't be listed.
        /// </summary>
        public DateTimeOffset ActiveSince { get; }

        /// <summary>
        /// Filters the result, mapping a dimension's name to a list of possible values it can assume. Only time series
        /// with the specified dimension values will be returned.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, IList<string>> DimensionCombinationsToFilter
        {
            get => _dimensionCombinationsToFilter;
            set
            {
                Argument.AssertNotNull(value, nameof(DimensionCombinationsToFilter));
                _dimensionCombinationsToFilter = value;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the amount of items to
        /// be skipped.
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned in each page of results. Note:
        /// unless the number of pages enumerated from the service is limited, the service will
        /// return an unlimited number of total items.
        /// </summary>
        public int? TopCount { get; set; }
    }
}
