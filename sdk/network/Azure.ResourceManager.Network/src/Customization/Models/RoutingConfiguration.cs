// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Routing Configuration indicating the associated and propagated route tables for this connection. </summary>
    public partial class RoutingConfiguration : RoutingConfigurationNfv, IJsonModel<RoutingConfiguration>, IPersistableModel<RoutingConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="RoutingConfiguration"/>. </summary>
        public RoutingConfiguration()
        {
        }

        // Reuse native deserialization storage instead of returning an empty legacy wrapper.
        private RoutingConfiguration(RoutingConfigurationNfv original) : base(original)
        {
        }

        /// <summary> The propagated route tables. </summary>
        [WirePath("propagatedRouteTables")]
        public new PropagatedRouteTable PropagatedRouteTables { get; set; }

        // Preserve the supported flattened facade without copying the native route list.
        /// <summary> Gets the static routes in the virtual network routing configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<StaticRoute> StaticRoutes
        {
            get
            {
                VnetRoutes ??= new VnetRoute();
                return VnetRoutes.StaticRoutes;
            }
        }
    }
}
