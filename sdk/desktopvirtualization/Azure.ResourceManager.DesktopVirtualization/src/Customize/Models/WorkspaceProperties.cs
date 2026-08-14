// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Internal helper class used by the VirtualWorkspaceData customization. It holds the
// ApplicationGroupReferences list that VirtualWorkspaceData's backward-compatible shim
// property delegates to.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Schema for Workspace properties. </summary>
    internal partial class WorkspaceProperties
    {
        /// <summary> List of applicationGroup resource Ids. </summary>
        [WirePath("applicationGroupReferences")]
        public IList<string> ApplicationGroupReferences { get; set; } = new ChangeTrackingList<string>();
    }
}
