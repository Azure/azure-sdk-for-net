// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppVolumeGroupData. </summary>
    public partial class NetAppVolumeGroupData
    {
        /// <summary> Resource location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureLocation? Location
        {
            get => LocationString is string loc ? new AzureLocation(loc) : null;
            set => LocationString = value?.ToString();
        }
    }
}
