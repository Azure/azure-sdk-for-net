// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class TimeSeriesIdHelper
    {
        internal static TimeSeriesId CreateTimeSeriesId(TimeSeriesModelSettings modelSettings)
        {
            int numOfIdKeys = modelSettings.TimeSeriesIdProperties.Count;

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            var id = new List<string>();
            for (int i = 0; i < numOfIdKeys; i++)
            {
                id.Add(Guid.NewGuid().ToString());
            }

            TimeSeriesId tsId = numOfIdKeys switch
            {
                1 => new TimeSeriesId(id[0]),
                2 => new TimeSeriesId(id[0], id[1]),
                3 => new TimeSeriesId(id[0], id[1], id[2]),
                _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
            };

            return tsId;
        }
    }
}
