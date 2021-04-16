// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights
{
    internal class QueryHelper
    {
        public static TimeSeriesPoint[] CreateQueryResponse(QueryResultPage value, HashSet<EventProperty> _eventProperties)
        {
            var result = new List<TimeSeriesPoint>();

            for (int i = 0; i < value.Timestamps.Count; i++)
            {
                DateTimeOffset timestamp = value.Timestamps[i];
                var point = new TimeSeriesPoint(timestamp);

                foreach (PropertyValues property in value.Properties)
                {
                    var eventProperty = new EventProperty(property.Name, property.Type);
                    TimeSeriesValue tsValue;
                    if (property.Type == PropertyTypes.Bool)
                    {
                        tsValue = new TimeSeriesValue((bool)property.Values[i]);
                    }
                    else if (property.Type == PropertyTypes.Double || property.Type == PropertyTypes.Long)
                    {
                        tsValue = new TimeSeriesValue((double)property.Values[i]);
                    }
                    else if (property.Type == PropertyTypes.String)
                    {
                        tsValue = new TimeSeriesValue((string)property.Values[i]);
                    }
                    else if (property.Type == PropertyTypes.DateTime)
                    {
                        tsValue = new TimeSeriesValue((DateTimeOffset)property.Values[i]);
                    }
                    else
                    {
                        tsValue = null; // TODO: ADD MORE TYPES TO BE SUPPORTED IN THE VARIANT TYPE
                    }

                    point.Values[eventProperty] = tsValue;
                    _eventProperties.Add(eventProperty);
                }

                result.Add(point);
            }

            return result.ToArray();
        }
    }
}
