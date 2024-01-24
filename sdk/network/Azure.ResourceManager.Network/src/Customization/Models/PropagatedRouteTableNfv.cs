// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Nfv version of the list of RouteTables to advertise the routes to. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PropagatedRouteTableNfv
    {
        /// <summary> Initializes a new instance of PropagatedRouteTableNfv. </summary>
        public PropagatedRouteTableNfv()
        {
            Labels = new ChangeTrackingList<string>();
            Ids = new ChangeTrackingList<RoutingConfigurationNfvSubResource>();
        }

        /// <summary> Initializes a new instance of PropagatedRouteTableNfv. </summary>
        /// <param name="labels"> The list of labels. </param>
        /// <param name="ids"> The list of resource ids of all the RouteTables. </param>
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
