// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserves [Obsolete] from previous API version
    [CodeGenSuppress("InstanceView")]
    public partial class PerNodeExtensionState
    {
        /// <summary> The extension instance view. </summary>
        [WirePath("instanceView")]
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        public HciExtensionInstanceView InstanceView { get; }
    }
}
