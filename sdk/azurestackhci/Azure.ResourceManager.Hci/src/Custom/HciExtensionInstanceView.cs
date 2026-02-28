// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserves [Obsolete] from previous API version
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionInstanceView` moving forward.")]
    public partial class HciExtensionInstanceView
    {
        /// <summary> Specifies the type of the extension. </summary>
        public string ExtensionInstanceViewType => Type;
    }
}
