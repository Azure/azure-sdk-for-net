// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Scaling plan properties that can be patched. </summary>
    public partial class ScalingPlanPatch
    {
        /// <summary> HostPool type for desktop. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version", false)]
        public HostPoolType? HostPoolType { get; set; }
    }
}
