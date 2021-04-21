// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Represents a Time Series point at a specific timestamp.
    /// </summary>
    public struct TimeSeriesPoint
    {
        private readonly IDictionary<string, PropertyValues> _propertyNameToPageValues;
        private readonly int _index;

        /// <summary>
        /// Timestamp of the point.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Creates a new instance of TimeSeriesPoint.
        /// </summary>
        /// <param name="timestamp">The timestamp of the point.</param>
        /// <param name="propertyNameToPageValues">A dictionary that maps from property names to the property values in a single response page.</param>
        /// <param name="index">The index of the value specific to this point.</param>
        public TimeSeriesPoint(DateTimeOffset timestamp, IDictionary<string, PropertyValues> propertyNameToPageValues, int index)
        {
            Timestamp = timestamp;
            _propertyNameToPageValues = propertyNameToPageValues;
            _index = index;
        }

        /// <summary>
        /// Get the <see cref="TimeSeriesValue"/> of the point for a specific property.
        /// </summary>
        /// <param name="propertyName">the name of the property to get the value for.</param>
        /// <returns>A <see cref="TimeSeriesValue"/>.</returns>
        public TimeSeriesValue GetValue(string propertyName)
        {
            if (_propertyNameToPageValues.TryGetValue(propertyName, out PropertyValues propertyValues))
            {
                return propertyValues.Values[_index];
            }

            throw new Exception($"Unable to find property {propertyName} for the time series point.");
        }

        /// <summary>
        /// Get the unique property names associated with the Time Series point.
        /// </summary>
        /// <returns>List of unique property names.</returns>
        public string[] GetUniquePropertyNames()
        {
            return _propertyNameToPageValues.Keys.ToArray();
        }
    }
}
