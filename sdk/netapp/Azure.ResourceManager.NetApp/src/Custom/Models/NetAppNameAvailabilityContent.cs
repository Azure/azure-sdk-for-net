// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppNameAvailabilityContent
    {
        /// <summary> The resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppNameAvailabilityResourceType ResourceType => Type;
    }
}
