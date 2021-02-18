// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series ID value that is an array of string values that uniquely identifies a Time Series instance.
    /// </summary>
    /// <remarks>
    /// At the moment, Time Series Id service only supports string types to represent a TSI Id. In order to reduce the confusion on the user,
    /// this class has been created to extend the more generic class <see cref="TimeSeriesId{T1, T2, T3}"/>.
    /// </remarks>
    public class TimeSeries3Id : TimeSeriesId<string, string, string>
    {
        /// <summary>
        /// Creates a new Time Series Id with 3 string properties.
        /// </summary>
        /// <param name="timeSeriesIdProp1">The first Id property that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdProp2">The second Id property that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdProp3">The third Id property that identifies a Time Series instance.</param>
        public TimeSeries3Id(string timeSeriesIdProp1, string timeSeriesIdProp2, string timeSeriesIdProp3)
            : base(timeSeriesIdProp1, timeSeriesIdProp2, timeSeriesIdProp3)
        {
        }
    }
}
