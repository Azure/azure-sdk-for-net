// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

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

        // Internal in 1.15.0; unnecessarily exposed publicly during the 1.16.0 TypeSpec migration.
        // Retained for released 1.16/1.17 API compatibility; forwards the ID, not the backing object.
        /// <inheritdoc cref="ExpressRouteConnectionId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteConnectionId instead.")]
        [WirePath("properties.expressRouteConnection")]
        public ResourceIdentifier ExpressRouteConnection
        {
            get => ExpressRouteConnectionId;
            set => ExpressRouteConnectionId = value;
        }

        // Internal in 1.15.0; unnecessarily exposed publicly during the 1.16.0 TypeSpec migration.
        // Retained for released 1.16/1.17 API compatibility; returns a new wrapper and copies only its ID.
        /// <summary> Compatibility member. </summary>
        public WritableSubResource RouteFilter
        {
            get => RouteFilterId is null ? default : new WritableSubResource { Id = RouteFilterId };
            set => RouteFilterId = value?.Id;
        }
    }
}
