// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Parameters for updating a workspace resource. </summary>
    public partial class WorkspaceUpdateParameters
    {
        /// <summary> Initializes a new instance of WorkspaceUpdateParameters. </summary>
        public WorkspaceUpdateParameters()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Managed service identity of the workspace. </summary>
        public WorkspaceIdentity Identity { get; set; }
    }
}
