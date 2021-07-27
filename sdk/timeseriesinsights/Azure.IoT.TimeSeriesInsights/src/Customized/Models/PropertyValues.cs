// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Values of a single property corresponding to the timestamps.
    /// </summary>
    [CodeGenModel("PropertyValues")]
    public partial class PropertyValues : TimeSeriesInsightsEventProperty
    {
        // This class has been customized and overriden to change the property Values into a JsonElement. Changing it into a JsonElement
        // allows lazy load of the values. Only when Values is accesssed, we will deseialize the JsonElement into a TimeSeriesValue array.
        private TimeSeriesValue[] _values;

        [CodeGenMember("Values")]
        internal JsonElement ValuesInternal { get; }

        /// <summary>
        /// Values of a single property corresponding to the timestamps. May contain nulls. Type of values matches the type of property.
        /// </summary>
        public IReadOnlyList<TimeSeriesValue> Values => _values ??= CreateValues();

        private TimeSeriesValue[] CreateValues()
        {
            var values = new List<TimeSeriesValue>();

            foreach (JsonElement item in ValuesInternal.EnumerateArray())
            {
                if (PropertyValueType == TimeSeriesPropertyType.Bool)
                {
                    values.Add(new TimeSeriesValue((bool?)item.GetObject()));
                }
                else if (PropertyValueType == TimeSeriesPropertyType.DateTime)
                {
                    values.Add(new TimeSeriesValue((DateTimeOffset?)item.GetObject()));
                }
                else if (PropertyValueType == TimeSeriesPropertyType.Double)
                {
                    values.Add(new TimeSeriesValue((double?)item.GetObject()));
                }
                else if (PropertyValueType == TimeSeriesPropertyType.Long)
                {
                    values.Add(new TimeSeriesValue((int?)item.GetObject()));
                }
                else if (PropertyValueType == TimeSeriesPropertyType.String)
                {
                    values.Add(new TimeSeriesValue(item.GetString()));
                }
                else if (PropertyValueType == TimeSeriesPropertyType.TimeSpan)
                {
                    values.Add(new TimeSeriesValue((TimeSpan?)item.GetObject()));
                }
            }

            return values.ToArray();
        }
    }
}
