// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.IoT.TimeSeriesInsights
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
        private readonly string[] _keys;

        /// <summary>
        /// Creates a new Time Series Id with 1 key.
        /// </summary>
        /// <param name="key1">The first key that identifies a Time Series instance.</param>
        /// <remarks>
        /// Use this constructor if the Time Series Id chosen at environment creation time
        /// is composed of 1 key.
        /// </remarks>
        public TimeSeriesId(string key1)
        {
            _keys = new string[] { key1 };
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
        public TimeSeriesId(string key1, string key2)
        {
            _keys = new string[] { key1, key2 };
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
        public TimeSeriesId(string key1, string key2, string key3)
        {
            _keys = new string[] { key1, key2, key3 };
        }

        /// <summary>
        /// An array to represent a single Time Series Id in order to use it when making calls against the Time
        /// Series Insights client library.
        /// </summary>
        /// <returns>An array representing a single Time Series Id.</returns>
        public string[] ToArray() => _keys;

        /// <summary>
        /// Represent the Time Series Id as a JSON string.
        /// </summary>
        /// <returns>The keys that make up the Time Series Id as a JSON string.</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(_keys);
        }
    }
}
