// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The Tags property setter was previously exposed on the Patch model.
// The new generated code removed it. This customization restores the Tags setter so existing
// callers that set Tags on HostPoolPatch are not broken.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> HostPool properties that can be patched. </summary>
    public partial class HostPoolPatch
    {
        /// <summary> tags to be updated. </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; set; }
    }
}
