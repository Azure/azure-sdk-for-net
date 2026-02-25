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
    }
}
