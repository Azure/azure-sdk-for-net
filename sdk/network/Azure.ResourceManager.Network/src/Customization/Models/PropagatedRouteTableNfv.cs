// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Nfv version of the list of RouteTables to advertise the routes to. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future version. Please use PropagatedRouteTable instead.")]
    public partial class PropagatedRouteTableNfv
    {
        /// <summary> Initializes a new instance of PropagatedRouteTableNfv. </summary>
        public PropagatedRouteTableNfv()
        {
            Labels = new ChangeTrackingList<string>();
            Ids = new ChangeTrackingList<RoutingConfigurationNfvSubResource>();
        }

        internal PropagatedRouteTableNfv(IList<string> labels, IList<RoutingConfigurationNfvSubResource> ids)
        {
            Labels = labels;
            Ids = ids;
        }

        /// <summary> The list of labels. </summary>
        public IList<string> Labels { get; }
        /// <summary> The list of resource ids of all the RouteTables. </summary>
        public IList<RoutingConfigurationNfvSubResource> Ids { get; }
    }
}
