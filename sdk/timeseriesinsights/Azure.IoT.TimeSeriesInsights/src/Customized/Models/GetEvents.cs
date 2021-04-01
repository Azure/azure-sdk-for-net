// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Get Events query. Allows to retrieve raw events for a given Time Series Id and search span.
    /// </summary>
    [CodeGenModel("GetEvents")]
    [CodeGenSuppress("GetEvents", typeof(IEnumerable<object>), typeof(DateTimeRange))]
    public partial class GetEvents
    {
        // Autorest does not support changing type for properties. In order to turn TimeSeriesId
        // from a list of objects to a strongly typed object, TimeSeriesId has been renamed to
        // TimeSeriesIdInternal and a new property, TimeSeriesId, has been created with the proper type.

        [CodeGenMember("TimeSeriesId")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "CodeQuality",
            "IDE0051:Remove unused private members",
            Justification = "Autorest does not support changing type for properties. In order to turn TimeSeriesId from" +
            "a list of objects to a strongly typed object, TimeSeriesId has been renamed to TimeSeriesIdInternal and a" +
            "new property, TimeSeriesId, has been created with the proper type.")]
        private IList<object> TimeSeriesIdInternal { get; }

        /// <summary>
        /// Time Series Id that uniquely identifies the instance. It matches Time Series Id properties in an environment.
        /// </summary>
        public TimeSeriesId TimeSeriesId { get; }

        /// <summary>
        /// Initializes a new instance of GetEvents.
        /// </summary>
        /// <param name="timeSeriesId">
        /// Time Series Id that uniquely identifies the instance. It matches Time Series Id properties in
        /// an environment. Immutable, never null.
        /// </param>
        /// <param name="searchSpan">
        /// The range of time on which the query is executed. Cannot be null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="timeSeriesId"/> or <paramref name="searchSpan"/> is null.
        /// </exception>
        public GetEvents(TimeSeriesId timeSeriesId, DateTimeRange searchSpan)
        {
            TimeSeriesId = timeSeriesId ?? throw new ArgumentNullException(nameof(timeSeriesId));
            SearchSpan = searchSpan ?? throw new ArgumentNullException(nameof(searchSpan));
            ProjectedProperties = new ChangeTrackingList<EventProperty>();
        }
    }
}
