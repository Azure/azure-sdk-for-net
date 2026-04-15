// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NicInfo
    {
        /// <summary> IP Address. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPAddress => IpAddress;
    }
}
