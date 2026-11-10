// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRouteGatewayData
    {
        // The released alias reads the canonical generated list; it must not own separate storage.
        /// <inheritdoc cref="ExpressRouteConnectionList"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        public IReadOnlyList<ExpressRouteConnectionData> ExpressRouteConnections => new ReadOnlyCollection<ExpressRouteConnectionData>(ExpressRouteConnectionList);
    }
}
