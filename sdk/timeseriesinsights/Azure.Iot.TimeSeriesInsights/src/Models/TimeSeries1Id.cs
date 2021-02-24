// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series Id value that is an array of 1 string value that uniquely identifies a Time Series instance.
    /// </summary>
    /// <remarks>
    /// At the moment, Time Series Id service only supports string types to represent a TSI Id. In order to reduce the confusion on the user,
    /// this class has been created to extend the more generic class <see cref="TimeSeriesId{T1}"/>.
    /// </remarks>
    public class TimeSeries1Id : TimeSeriesId<string>
    {
        /// <summary>
        /// Creates a new Time Series Id with 1 string property.
        /// </summary>
        /// <param name="timeSeriesIdProp1">The first Id property that identifies a Time Series instance.</param>
        public TimeSeries1Id(string timeSeriesIdProp1)
            : base(timeSeriesIdProp1)
        {
        }
    }
}
