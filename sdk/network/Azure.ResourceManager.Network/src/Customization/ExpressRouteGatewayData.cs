// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteGatewayData type. </summary>
    public partial class ExpressRouteGatewayData
    {
        // The released alias reads the canonical generated list; it must not own separate storage.
        /// <inheritdoc cref="ExpressRouteConnectionList"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        public IReadOnlyList<ExpressRouteConnectionData> ExpressRouteConnections => ExpressRouteConnectionList as IReadOnlyList<ExpressRouteConnectionData>;

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="VirtualHubId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use VirtualHubId instead.")]
        [WirePath("properties.virtualHub")]
        public ResourceIdentifier VirtualHub
        {
            get => VirtualHubId;
            set => VirtualHubId = value;
        }
    }
}
