// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The ApplicationGroupReferences property was previously a flattened
// top-level property on VirtualWorkspaceData. The new generated code nests it under a Properties
// sub-object. This shim property preserves the old flat accessor by delegating to
// Properties.ApplicationGroupReferences, so existing callers are not broken.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing the VirtualWorkspace data model.
    /// Represents a Workspace definition.
    /// </summary>
    public partial class VirtualWorkspaceData
    {
        /// <summary> List of applicationGroup resource Ids. </summary>
        [WirePath("properties.applicationGroupReferences")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ApplicationGroupReferences
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new WorkspaceProperties();
                }
                return Properties.ApplicationGroupReferences;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new WorkspaceProperties();
                }
                Properties.ApplicationGroupReferences = value;
            }
        }
    }
}
