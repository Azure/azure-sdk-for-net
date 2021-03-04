// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Request body structure for data flow statistics. </summary>
    public partial class DataFlowDebugStatisticsRequest
    {
        /// <summary> Initializes a new instance of DataFlowDebugStatisticsRequest. </summary>
        public DataFlowDebugStatisticsRequest()
        {
            Columns = new ChangeTrackingList<string>();
        }

        /// <summary> The run ID of data flow debug session. </summary>
        public string RunId { get; set; }
    }
}
