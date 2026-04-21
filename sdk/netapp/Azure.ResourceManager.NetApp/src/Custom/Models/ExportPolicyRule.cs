// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Compatibility shim for the former export rule model name. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExportPolicyRule : NetAppVolumeExportPolicyRule
    {
    }
}
