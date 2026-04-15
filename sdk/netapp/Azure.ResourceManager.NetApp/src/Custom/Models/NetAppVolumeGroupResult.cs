// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backward-compat shims for NetAppVolumeGroupResult. </summary>
    public partial class NetAppVolumeGroupResult
    {
        /// <summary> Resource location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureLocation? Location => LocationString is string loc ? new AzureLocation(loc) : null;
    }
}
