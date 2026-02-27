// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias. Old name was ExtensionUpgradeContent, renamed to ArcExtensionUpgradeContent.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExtensionUpgradeContent : ArcExtensionUpgradeContent
    {
    }
}
