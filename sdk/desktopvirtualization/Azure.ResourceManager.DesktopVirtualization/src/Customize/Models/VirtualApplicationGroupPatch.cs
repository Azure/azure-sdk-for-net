// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The Tags property was previously exposed directly on the Patch model.
// The new generated code removed it (tags are handled differently). This restores the Tags
// property so existing callers that set Tags on VirtualApplicationGroupPatch are not broken.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> ApplicationGroup properties that can be patched. </summary>
    public partial class VirtualApplicationGroupPatch
    {
        /// <summary> tags to be updated. </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; set; }
    }
}
