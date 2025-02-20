// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Routing Configuration indicating the associated and propagated route tables for this connection. </summary>
    public partial class RoutingConfiguration
    {
        /// <summary> List of all Static Routes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public IList<StaticRoute> StaticRoutes
        {
            get
            {
                if (VnetRoutes is null)
                    VnetRoutes = new VnetRoute();
                return VnetRoutes.StaticRoutes;
            }
        }
    }
}
