// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Routing Configuration indicating the associated and propagated route tables for this connection. </summary>
    public partial class RoutingConfiguration
    {
        // Preserve the supported flattened facade without copying the native route list.
        /// <summary> Gets the static routes in the virtual network routing configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
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
