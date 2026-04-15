// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBreakFileLocksContent
    {
        /// <summary> The client IP address. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress ClientIP
        {
            get => string.IsNullOrEmpty(ClientIp) ? null : IPAddress.Parse(ClientIp);
            set => ClientIp = value?.ToString();
        }
    }
}
