// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights
{
    internal class QueryHelper
    {
        public static TimeSeriesPoint[] CreateQueryResponse(QueryResultPage value)
        {
            var result = new List<TimeSeriesPoint>();

            var propertyNameToPageValues = new Dictionary<string, PropertyValues>();
            foreach (PropertyValues property in value.Properties)
            {
                propertyNameToPageValues[property.Name] = property;
            }

            for (int index = 0; index < value.Timestamps.Count; index++)
            {
                DateTimeOffset timestamp = value.Timestamps[index];
                var point = new TimeSeriesPoint(propertyNameToPageValues, index, timestamp);
                result.Add(point);
            }

            return result.ToArray();
        }
    }
}
