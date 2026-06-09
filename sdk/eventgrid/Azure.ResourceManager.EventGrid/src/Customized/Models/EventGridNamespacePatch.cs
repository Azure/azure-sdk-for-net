// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventGridNamespacePatch
    {
        /// <summary> This can be used to restrict traffic from specific IPs instead of all IPs. </summary>
        [WirePath("properties.inboundIpRules")]
        public IList<EventGridInboundIPRule> InboundIPRules => InboundIpRules;
    }
}
