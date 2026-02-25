// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
