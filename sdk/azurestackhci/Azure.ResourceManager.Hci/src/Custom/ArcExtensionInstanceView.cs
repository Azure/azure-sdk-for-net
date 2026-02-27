// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias for ArcExtensionInstanceView (old autorest name).
    /// The TypeSpec migration renamed ExtensionInstanceView to HciExtensionInstanceView.
    /// This alias allows the deprecated model factory overload to compile.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ArcExtensionInstanceView : HciExtensionInstanceView
    {
    }
}
