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
    public partial class PropertyValues : EventProperty
    {
        private TimeSeriesValue[] _values;

        [CodeGenMember("Values")]
        internal JsonElement ValuesInternal { get; }

        /// <summary>
        /// Values of a single property corresponding to the timestamps. May contain nulls. Type of values matches the type of property.
        /// </summary>
        public TimeSeriesValue[] Values => _values ??= CreateValues();

        private TimeSeriesValue[] CreateValues()
        {
            var values = new List<TimeSeriesValue>();

            foreach (JsonElement item in ValuesInternal.EnumerateArray())
            {
                if (Type == PropertyTypes.Bool)
                {
                    values.Add(new TimeSeriesValue((bool?)item.GetObject()));
                }
                else if (Type == PropertyTypes.DateTime)
                {
                    values.Add(new TimeSeriesValue((DateTimeOffset?)item.GetObject()));
                }
                else if (Type == PropertyTypes.Double)
                {
                    values.Add(new TimeSeriesValue((double?)item.GetObject()));
                }
                else if (Type == PropertyTypes.Long)
                {
                    values.Add(new TimeSeriesValue((double?)item.GetObject()));
                }
                else if (Type == PropertyTypes.String)
                {
                    values.Add(new TimeSeriesValue(item.GetString()));
                }
                else if (Type == PropertyTypes.TimeSpan)
                {
                    values.Add(new TimeSeriesValue((TimeSpan?)item.GetObject()));
                }
            }

            return values.ToArray();
        }
    }
}
