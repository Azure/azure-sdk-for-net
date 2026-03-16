// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudStorageProfile
    {
        /// <summary> The disk object for creating the OS disk on the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudOSDisk OSDisk
        {
            get => OsDisk;
            set => OsDisk = value;
        }
    }
}
