// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series ID value that is an array of string values that uniquely identifies a Time Series instance.
    /// </summary>
    /// <remarks>
    /// At the moment, Time Series Id service only supports string types to represent a TSI Id. In order to reduce the confusion on the user,
    /// this class has been created to extend the more generic class <see cref="TimeSeriesId{T1, T2}"/>.
    /// </remarks>
    public class TimeSeries2Id : TimeSeriesId<string, string>
    {
        /// <summary>
        /// Creates a new Time Series Id with 2 string properties.
        /// </summary>
        /// <param name="timeSeriesIdProp1">The first Id property that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdProp2">The second Id property that identifies a Time Series instance.</param>
        public TimeSeries2Id(string timeSeriesIdProp1, string timeSeriesIdProp2)
            : base(timeSeriesIdProp1, timeSeriesIdProp2)
        {
        }
    }
}
