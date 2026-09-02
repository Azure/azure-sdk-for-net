// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor.Models
{
    // AutoRest generated this metric baseline payload as ResourceData and exposed Baselines as IReadOnlyList.
    // Restore that API shape while delegating to the generated TypeSpec properties.
    public partial class MonitorSingleMetricBaseline : ResourceData
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
