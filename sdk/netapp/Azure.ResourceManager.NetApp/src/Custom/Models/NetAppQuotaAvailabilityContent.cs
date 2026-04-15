// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppQuotaAvailabilityContent
    {
        /// <summary> The resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppQuotaAvailabilityResourceType AvailabilityResourceType => Type;
    }
}
