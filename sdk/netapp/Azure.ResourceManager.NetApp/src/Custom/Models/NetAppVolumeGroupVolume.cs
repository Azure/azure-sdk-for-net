// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> The resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceType? ResourceType => string.IsNullOrEmpty(Type) ? (ResourceType?)null : new ResourceType(Type);
    }
}
