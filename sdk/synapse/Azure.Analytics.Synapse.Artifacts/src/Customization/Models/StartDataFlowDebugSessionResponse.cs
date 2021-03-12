// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Response body structure for starting data flow debug session. </summary>
    public partial class StartDataFlowDebugSessionResponse
    {
        /// <summary> Initializes a new instance of StartDataFlowDebugSessionResponse. </summary>
        public StartDataFlowDebugSessionResponse()
        {
        }

        /// <summary> The ID of data flow debug job version. </summary>
        public string JobVersion { get; set; }
    }
}
