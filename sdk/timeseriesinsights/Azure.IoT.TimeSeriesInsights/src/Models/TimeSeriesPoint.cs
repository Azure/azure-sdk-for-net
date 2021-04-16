// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Represents a Time Series point at a specific timestamp.
    /// </summary>
    public struct TimeSeriesPoint
    {
        /// <summary>
        /// Timestamp of the point.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// List of property values associated with the point.
        /// </summary>
        public IDictionary<EventProperty, TimeSeriesValue> Values { get; }

        /// <summary>
        /// Create a new instance of TimeSeriesPoint.
        /// </summary>
        /// <param name="timestamp"></param>
        public TimeSeriesPoint(DateTimeOffset timestamp)
        {
            Timestamp = timestamp;
            Values = new Dictionary<EventProperty, TimeSeriesValue>();
        }

        /// <summary>
        /// Get the property names associated with this point.
        /// </summary>
        /// <returns></returns>
        public string[] GetPropertyNames()
        {
            ICollection<EventProperty> keys = Values.Keys;
            return keys.Select((key) => key.Name).ToArray();
        }

        /// <summary>
        /// Get the value of the point for a specific property.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public TimeSeriesValue GetValue(string property)
        {
            ICollection<EventProperty> keys = Values.Keys.ToList();
            EventProperty eventProperty = keys.First((key) => key.Name == property);
            return Values[eventProperty];
        }
    }
}
