// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventGridDomainPatch
    {
        /// <summary> This can be used to restrict traffic from specific IPs instead of all IPs. </summary>
        [WirePath("properties.inboundIpRules")]
        public IList<EventGridInboundIPRule> InboundIPRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DomainUpdateParameterProperties();
                }

                return Properties.InboundIPRules;
            }
        }

        /// <summary> Indicates whether local auth is disabled. </summary>
        [WirePath("properties.disableLocalAuth")]
        public bool? IsLocalAuthDisabled
        {
            get => Properties?.IsLocalAuthDisabled;
            set
            {
                if (Properties is null)
                {
                    Properties = new DomainUpdateParameterProperties();
                }

                Properties.IsLocalAuthDisabled = value;
            }
        }
    }
}
