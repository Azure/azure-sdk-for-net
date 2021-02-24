// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series Id value that is composed of one primitive value that uniquely identifies a Time Series instance.
    /// </summary>
    /// <remarks>
    /// A single Time Series Id can be composite if multiple properties are specified as Time Series Id at environment creation time.
    /// The position and type of values must match Time Series Id properties specified on the environment and returned by Get Model Setting API.
    /// </remarks>
    /// <typeparam name="T1">The type of the Id property.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "The mismatch between the file name and the class name is because we have other TimeSeriesId classes that accept" +
        "other generics. So in order to make it less confusing for the user, the class name has been simplified.")]
    public class TimeSeriesId<T1> : ITimeSeriesId
    {
        private readonly T1 _timeSeriesIdProp1;

        /// <summary>
        /// Creates a new Time Series Id with 1 property type.
        /// </summary>
        /// <param name="timeSeriesIdProp1">The first Id property that identifies a Time Series instance.</param>
        public TimeSeriesId(T1 timeSeriesIdProp1)
        {
            _timeSeriesIdProp1 = timeSeriesIdProp1;
        }

        /// <inheritdoc/>
        public object[] ToArray()
        {
            return new object[] { _timeSeriesIdProp1 };
        }
    }
}
