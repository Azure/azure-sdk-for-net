// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series ID value that is composed of three primitive values that uniquely identifies a Time Series instance.
    /// </summary>
    /// <remarks>
    /// A single Time Series ID can be composite if multiple properties are specified as Time Series ID at environment creation time.
    /// The position and type of values must match Time Series ID properties specified on the environment and returned by Get Model Setting API.
    /// </remarks>
    /// <typeparam name="T1">The type of the first Id property.</typeparam>
    /// <typeparam name="T2">The type of the second Id property.</typeparam>
    /// <typeparam name="T3">The type of the third Id property.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "<Pending>")]
    public class TimeSeriesId<T1, T2, T3> : ITimeSeriesId
    {
        private readonly T1 _timeSeriesIdProp1;
        private readonly T2 _timeSeriesIdProp2;
        private readonly T3 _timeSeriesIdProp3;

        /// <summary>
        /// Creates a new Time Series Id with 3 property types.
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

        /// <inheritdoc/>
        public object[] ToArray()
        {
            return new object[] { _timeSeriesIdProp1, _timeSeriesIdProp2, _timeSeriesIdProp3 };
        }
    }
}
