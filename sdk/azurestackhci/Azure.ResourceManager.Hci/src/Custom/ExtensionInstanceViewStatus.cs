// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias for ExtensionInstanceViewStatus (old autorest name).
    /// The TypeSpec migration renamed it to ArcExtensionInstanceViewStatus.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExtensionInstanceViewStatus : ArcExtensionInstanceViewStatus
    {
    }
}
