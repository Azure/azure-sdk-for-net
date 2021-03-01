// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Response body structure of data flow query for data preview, statistics or expression preview. </summary>
    public partial class DataFlowDebugQueryResponse
    {
        /// <summary> Initializes a new instance of DataFlowDebugQueryResponse. </summary>
        public DataFlowDebugQueryResponse()
        {
        }

        /// <summary> The run ID of data flow debug session. </summary>
        public string RunId { get; set; }
    }
}
