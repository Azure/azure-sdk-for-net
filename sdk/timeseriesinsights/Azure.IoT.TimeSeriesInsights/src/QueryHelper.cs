// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights
{
    internal class QueryHelper
    {
        internal static TimeSeriesPoint[] CreateQueryResponse(QueryResultPage value)
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
                result.Add(new TimeSeriesPoint(timestamp, propertyNameToPageValues, index));
            }

            return result.ToArray();
        }
    }
}
