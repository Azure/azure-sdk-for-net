// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Request body structure for data flow preview data. </summary>
    public partial class DataFlowDebugPreviewDataRequest
    {
        public DataFlowDebugPreviewDataRequest()
        {
        }

        /// <summary> The ID of data flow debug session. </summary>
        public string SessionId { get; set; }
        /// <summary> The data flow which contains the debug session. </summary>
        public string DataFlowName { get; set; }
        /// <summary> The output stream name. </summary>
        public string StreamName { get; set; }
        /// <summary> The row limit for preview request. </summary>
        public int? RowLimits { get; set; }
    }
}
