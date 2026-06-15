// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class PartnerNamespaceData
    {
        /// <summary> This can be used to restrict traffic from specific IPs instead of all IPs. </summary>
        [WirePath("properties.inboundIpRules")]
        public IList<EventGridInboundIPRule> InboundIPRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PartnerNamespaceProperties();
                }

                return Properties.InboundIPRules;
            }
        }
    }
}
