// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// A single Time Series Id value that is composed of up to 3 primitive values that uniquely identifies a Time Series instance. The
    /// keys that make up the Time Series Id are chosen when creating a Time Series Insights Gen2 environment through the Azure portal.
    /// </summary>
    /// <remarks>
    /// A single Time Series Id can be composite of multiple properties are specified as Time Series Id at environment creation time.
    /// The position and type of values must match Time Series Id properties specified on the environment and returned by Get Model Setting API.
    /// </remarks>
    public class TimeSeriesId
    {
        private readonly object[] _keys;
        private readonly string _tsiId;

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
            _keys = new object[] { key1 };
            _tsiId = $"Time Series Id key 1: {key1}";
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
            _keys = new object[] { key1, key2 };
            _tsiId =
                $"Time Series Id key 1: {key1}\n" +
                $"Time Series Id key 2: {key2}";
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
            _keys = new object[] { key1, key2, key3 };
            _tsiId =
                $"Time Series Id key 1: {key1}\n" +
                $"Time Series Id key 2: {key2}\n" +
                $"Time Series Id key 3: {key3}";
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
            : this(key1: stringKey1)
        {
        }

        /// <summary>
        /// Creates a new Time Series Id with 2 string keys.
        /// </summary>
        /// <param name="stringKey1">The first key that identifies a Time Series instance.</param>
        /// <param name="stringKey2">The second key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 2 string keys.
        /// </remarks>
        public TimeSeriesId(string stringKey1, string stringKey2)
            : this(key1: stringKey1, key2: stringKey2)
        {
        }

        /// <summary>
        /// Creates a new Time Series Id with 3 string keys.
        /// </summary>
        /// <param name="stringKey1">The first key that identifies a Time Series instance.</param>
        /// <param name="stringKey2">The second key that identifies a Time Series instance.</param>
        /// <param name="stringKey3">The third key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 3 string keys.
        /// </remarks>
        public TimeSeriesId(string stringKey1, string stringKey2, string stringKey3)
            : this(key1: stringKey1, key2: stringKey2, key3: stringKey3)
        {
        }

        /// <summary>
        /// An array to represent a single Time Series Id in order to use it when making calls against the Time
        /// Series Insights client library.
        /// </summary>
        /// <returns>An array representing a single Time Series Id.</returns>
        public object[] ToArray() => _keys;

        /// <summary>
        /// Builds a friendly string representation of the Time Series Id.
        /// </summary>
        /// <returns>The keys that make up the Time Series Id.</returns>
        public string GetId() => _tsiId;
    }
}
