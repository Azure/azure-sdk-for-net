// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series Id value that is composed of three primitive values that uniquely identifies a Time Series instance. The
    /// keys that make up the Time Series Id are chosen when creating a Time Series Insights Gen2 environment through the Azure portal.
    /// </summary>
    /// <remarks>
    /// A single Time Series Id can be composite of multiple properties are specified as Time Series Id at environment creation time.
    /// The position and type of values must match Time Series Id properties specified on the environment and returned by Get Model Setting API.
    /// </remarks>
    public class TimeSeriesId
    {
        private (bool, object) _key1;
        private (bool, object) _key2;
        private (bool, object) _key3;

        internal (bool, object) Key1 => _key1;

        internal (bool, object) Key2 => _key2;

        internal (bool, object) Key3 => _key3;

        /// <summary>
        /// Creates a new Time Series Id with 1 key.
        /// </summary>
        /// <param name="key1">The first key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 1 key.
        /// </remarks>
        public TimeSeriesId(object key1)
        {
            _key1 = (true, key1);
        }

        /// <summary>
        /// Creates a new Time Series Id with 2 keys.
        /// </summary>
        /// <param name="key1">The first key that identifies a Time Series instance.</param>
        /// <param name="key2">The second key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 2 keys.
        /// </remarks>
        public TimeSeriesId(object key1, object key2)
        {
            _key1 = (true, key1);
            _key2 = (true, key2);
        }

        /// <summary>
        /// Creates a new Time Series Id with 3 keys.
        /// </summary>
        /// <param name="key1">The first key that identifies a Time Series instance.</param>
        /// <param name="key2">The second key that identifies a Time Series instance.</param>
        /// <param name="key3">The third key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 3 keys.
        /// </remarks>
        public TimeSeriesId(object key1, object key2, object key3)
        {
            _key1 = (true, key1);
            _key2 = (true, key2);
            _key3 = (true, key3);
        }

        /// <summary>
        /// Creates a new Time Series Id with 1 string key.
        /// </summary>
        /// <param name="stringKey1">The first key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 1 string key.
        /// </remarks>
        public TimeSeriesId(string stringKey1)
        {
            _key1 = (true, stringKey1);
        }

        /// <summary>
        /// Creates a new Time Series Id with 2 string keys.
        /// </summary>
        /// <param name="stringKey1">The first key that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdStringProp2">The second key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 2 string keys.
        /// </remarks>
        public TimeSeriesId(string stringKey1, string timeSeriesIdStringProp2)
        {
            _key1 = (true, stringKey1);
            _key2 = (true, timeSeriesIdStringProp2);
        }

        /// <summary>
        /// Creates a new Time Series Id with 3 string keys.
        /// </summary>
        /// <param name="timeSeriesIdStringProp1">The first key that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdStringProp2">The second key that identifies a Time Series instance.</param>
        /// <param name="timeSeriesIdStringProp3">The third key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 3 string keys.
        /// </remarks>
        public TimeSeriesId(string timeSeriesIdStringProp1, string timeSeriesIdStringProp2, string timeSeriesIdStringProp3)
        {
            _key1 = (true, timeSeriesIdStringProp1);
            _key2 = (true, timeSeriesIdStringProp2);
            _key3 = (true, timeSeriesIdStringProp3);
        }

        /// <summary>
        /// Builds an array to represent a single Time Series Id in order to use it when making calls against the Time
        /// Series Insights client library.
        /// </summary>
        /// <returns>An array representing a single Time Series Id.</returns>
        public object[] ToArray()
        {
            if (_key3.Item1)
            {
                return new object[] { _key1.Item2, _key2.Item2, _key3.Item2 };
            }

            if (_key2.Item1)
            {
                return new object[] { _key1.Item2, _key2.Item2 };
            }

            return new object[] { _key1.Item2 };
        }

        /// <summary>
        /// Builds a string representation of the Time Series Id.
        /// </summary>
        /// <returns>The keys that make up the Time Series Id separated by a comma.</returns>
        public string GetId()
        {
            if (_key3.Item1)
            {
                return $"{_key1.Item2},{_key2.Item2},{_key3.Item2}";
            }

            if (_key2.Item1)
            {
                return $"{_key1.Item2},{_key2.Item2}";
            }

            return $"{_key1.Item2}";
        }
    }
}
