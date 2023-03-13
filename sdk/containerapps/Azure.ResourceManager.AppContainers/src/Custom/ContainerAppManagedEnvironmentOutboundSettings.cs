// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> this class here is to keep the class public and add the AppContainersSkuName attribute </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerAppManagedEnvironmentOutboundSettings
    {
        /// <summary> Outbound IP Addresses for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.AppContainers.Models.ContainerAppManagedEnvironmentOutBoundType? OutBoundType { get { throw null; } set { } }

        /// <summary> Outbound IP Addresses for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.Net.IPAddress VirtualNetworkApplianceIP { get { throw null; } set { } }
    }
}
