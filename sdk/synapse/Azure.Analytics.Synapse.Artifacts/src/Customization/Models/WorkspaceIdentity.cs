// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Identity properties of the workspace resource. </summary>
    public partial class WorkspaceIdentity
    {
        /// <summary> Initializes a new instance of WorkspaceIdentity. </summary>
        public WorkspaceIdentity()
        {
            Type = "SystemAssigned";
        }

        /// <summary> The principal id of the identity. </summary>
        public string PrincipalId { get; set; }
        /// <summary> The client tenant id of the identity. </summary>
        public string TenantId { get; set; }
    }
}
