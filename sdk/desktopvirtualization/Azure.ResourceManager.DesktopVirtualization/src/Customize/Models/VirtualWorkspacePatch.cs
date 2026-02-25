// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Workspace properties that can be patched. </summary>
    public partial class VirtualWorkspacePatch
    {
        /// <summary> tags to be updated. </summary>
        [WirePath("tags")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary> List of applicationGroup links. </summary>
        [WirePath("properties.applicationGroupReferences")]
        public IList<string> ApplicationGroupReferences
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new WorkspacePatchProperties();
                }
                return Properties.ApplicationGroupReferences;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new WorkspacePatchProperties();
                }
                Properties.ApplicationGroupReferences.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        Properties.ApplicationGroupReferences.Add(item);
                    }
                }
            }
        }
    }
}
