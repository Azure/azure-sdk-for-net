// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitPeeringData type. </summary>
    public partial class ExpressRouteCircuitPeeringData
    {
        /// <summary> Gets or sets the ID of the ExpressRoute connection. </summary>
        /// <remarks> The service treats this ID as read-only, so it is not included in requests. </remarks>
        [WirePath("properties.expressRouteConnection.id")]
        public ResourceIdentifier ExpressRouteConnectionId
        {
            get => Properties?.ExpressRouteConnection?.Id;
            set
            {
                Properties ??= new Models.ExpressRouteCircuitPeeringPropertiesFormat();
                Properties.ExpressRouteConnection = new Models.ExpressRouteConnectionId(value, default);
            }
        }

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="ExpressRouteConnectionId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteConnectionId instead.")]
        [WirePath("properties.expressRouteConnection")]
        public ResourceIdentifier ExpressRouteConnection
        {
            get => ExpressRouteConnectionId;
            set => ExpressRouteConnectionId = value;
        }
    }
}
