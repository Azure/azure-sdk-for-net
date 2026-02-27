// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias. Old name was UpdatePrerequisite, renamed to HciClusterUpdatePrerequisite.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class UpdatePrerequisite : HciClusterUpdatePrerequisite
    {
    }
}
