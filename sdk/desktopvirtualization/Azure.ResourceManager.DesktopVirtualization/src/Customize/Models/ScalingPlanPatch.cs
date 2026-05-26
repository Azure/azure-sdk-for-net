// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Scaling plan properties that can be patched. </summary>
    public partial class ScalingPlanPatch
    {
        // Backward compatibility: The Tags property setter was previously exposed on the Patch model.
        // The new generated code removed it. This customization restores the Tags setter so existing
        // callers that set Tags on ScalingPlanPatch are not broken.

        /// <summary> tags to be updated. </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary> HostPool type for desktop. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version", false)]
        public HostPoolType? HostPoolType { get; set; }
    }
}
