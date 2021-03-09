﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Response body structure of data flow result for data preview, statistics or expression preview. </summary>
    public partial class DataFlowDebugResultResponse
    {
        /// <summary> Initializes a new instance of DataFlowDebugResultResponse. </summary>
        public DataFlowDebugResultResponse()
        {
        }

        /// <summary> The run status of data preview, statistics or expression preview. </summary>
        public string Status { get; set; }
        /// <summary> The result data of data preview, statistics or expression preview. </summary>
        public string Data { get; set; }
    }
}
