// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class MonitorSingleMetricBaseline
    {
        /// <summary> The baseline for each time series that was queried. </summary>
        public IReadOnlyList<MonitorTimeSeriesBaseline> Baselines
        {
            get
            {
                return Properties is null ? default : new List<MonitorTimeSeriesBaseline>(Properties.Baselines);
            }
        }
    }
}
