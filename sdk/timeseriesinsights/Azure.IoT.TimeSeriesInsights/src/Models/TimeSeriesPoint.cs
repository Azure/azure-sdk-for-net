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
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        private readonly IDictionary<string, PropertyValues> _propertyNameToPageValues;
        private readonly int _rowNumber;

        /// <summary>
        /// </summary>
        /// <param name="propertyNameToPageValues"></param>
        /// <param name="rowNumber"></param>
        /// <param name="timestamp"></param>
        public TimeSeriesPoint(IDictionary<string, PropertyValues> propertyNameToPageValues, int rowNumber, DateTimeOffset timestamp)
        {
            Timestamp = timestamp;

            _propertyNameToPageValues = propertyNameToPageValues;
            _rowNumber = rowNumber;
        }

        /// <summary>
        /// Get the value of the point for a specific property.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public TimeSeriesValue GetValue(string property)
        {
            if (!_propertyNameToPageValues.TryGetValue(property, out PropertyValues propertyValues))
            {
                return null;
            }
            else
            {
                return propertyValues.Values[_rowNumber];
            }
        }
    }
}
