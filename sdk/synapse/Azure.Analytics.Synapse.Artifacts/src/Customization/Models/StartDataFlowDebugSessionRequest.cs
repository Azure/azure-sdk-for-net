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
    }
}
