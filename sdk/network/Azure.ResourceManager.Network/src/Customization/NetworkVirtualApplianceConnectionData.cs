// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceConnectionData
    {
        // The released NFV compatibility model was independent of the native routing wire property.
        /// <summary> The Routing Configuration indicating the associated and propagated route tables on this connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsoleted and will be removed in a future version. Please use ConnectionRoutingConfiguration instead.")]
        public RoutingConfigurationNfv RoutingConfiguration { get; set; }
    }
}
