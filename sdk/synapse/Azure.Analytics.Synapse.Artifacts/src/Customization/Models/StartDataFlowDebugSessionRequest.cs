// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Request body structure for starting data flow debug session. </summary>
    public partial class StartDataFlowDebugSessionRequest
    {
        /// <summary> Initializes a new instance of StartDataFlowDebugSessionRequest. </summary>
        public StartDataFlowDebugSessionRequest()
        {
            Datasets = new ChangeTrackingList<DatasetResource>();
            LinkedServices = new ChangeTrackingList<LinkedServiceResource>();
        }

        /// <summary> The ID of data flow debug session. </summary>
        public string SessionId { get; set; }
        /// <summary> Data flow instance. </summary>
        public DataFlowResource DataFlow { get; set; }
        /// <summary> Staging info for debug session. </summary>
        public object Staging { get; set; }
        /// <summary> Data flow debug settings. </summary>
        public object DebugSettings { get; set; }
        /// <summary> The type of new Databricks cluster. </summary>
        public bool? IncrementalDebug { get; set; }
    }
}
