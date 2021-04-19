// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary> Values of a single property corresponding to the timestamps. May contain nulls. Type of values matches the type of property. </summary>
    [CodeGenModel("PropertyValues")]
    public partial class PropertyValues : EventProperty
    {
        private IList<TimeSeriesValue> _values;

        /// <summary> Values of a single property corresponding to the timestamps. May contain nulls. Type of values matches the type of property. </summary>
        [CodeGenMember("Values")]
        internal JsonElement ValuesInternal { get; }

        /// <summary>
        /// </summary>
        public IList<TimeSeriesValue> Values => _values ??= CreateValues();

        private IList<TimeSeriesValue> CreateValues()
        {
            var values = new List<TimeSeriesValue>();

            foreach (JsonElement item in ValuesInternal.EnumerateArray())
            {
                if (Type == PropertyTypes.Bool)
                {
                    values.Add(new TimeSeriesValue(item.GetBoolean()));
                }
                else if (Type == PropertyTypes.DateTime)
                {
                    values.Add(new TimeSeriesValue(item.GetDateTimeOffset()));
                }
                else if (Type == PropertyTypes.Double)
                {
                    values.Add(new TimeSeriesValue(item.GetDouble()));
                }
                else if (Type == PropertyTypes.Long)
                {
                    values.Add(new TimeSeriesValue(item.GetInt64()));
                }
                else if (Type == PropertyTypes.String)
                {
                    values.Add(new TimeSeriesValue(item.GetString()));
                }
                // todo check more
            }

            return values;
        }
    }
}
