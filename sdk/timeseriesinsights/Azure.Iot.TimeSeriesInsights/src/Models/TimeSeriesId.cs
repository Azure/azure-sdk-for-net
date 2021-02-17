// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series ID value that is an array of primitive values that uniquely identifies a Time Series instance.
    /// </summary>
    /// <remarks>
    /// A single Time Series ID can be composite if multiple properties are specified as Time Series ID at environment creation time.
    /// The position and type of values must match Time Series ID properties specified on the environment and returned by Get Model Setting API.
    /// </remarks>
    /// <typeparam name="T1">The type of the first Id property.</typeparam>
    /// <typeparam name="T2">The type of the second Id property.</typeparam>
    /// <typeparam name="T3">The type of the third Id property.</typeparam>
    public class TimeSeriesId<T1, T2, T3>
    {
        private readonly T1 _timeSeriesIdProp1;
        private readonly T2 _timeSeriesIdProp2;
        private readonly T3 _timeSeriesIdProp3;

        /// <summary>
        /// Creates a new Time Series Id.
        /// </summary>
        /// <param name="timeSeriesIdProp1">The first Id property that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdProp2">The second Id property that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdProp3">The third Id property that identifies a Time Series instance.</param>
        public TimeSeriesId(T1 timeSeriesIdProp1, T2 timeSeriesIdProp2, T3 timeSeriesIdProp3)
        {
            _timeSeriesIdProp1 = timeSeriesIdProp1;
            _timeSeriesIdProp2 = timeSeriesIdProp2;
            _timeSeriesIdProp3 = timeSeriesIdProp3;
        }

        /// <summary>
        /// Builds an array to represent a single Time Series Id in order to use it when making calls against the Time Series Insights client library.
        /// </summary>
        /// <returns>An array representing a single Time Series Id.</returns>
        public virtual IList<object> IdAsList()
        {
            return new List<object>() { _timeSeriesIdProp1, _timeSeriesIdProp2, _timeSeriesIdProp3 };
        }
    }
}
