// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingRuleRouteDestination
    {
        /// <summary> Gets or sets the route destination type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use DestinationType instead.")]
        public RoutingRuleDestinationType Type
        {
            get => DestinationType;
            set => DestinationType = value;
        }
    }
}
