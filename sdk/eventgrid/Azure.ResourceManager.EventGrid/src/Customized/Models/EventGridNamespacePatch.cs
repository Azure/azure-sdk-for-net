// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    [CodeGenSuppress("TopicsCustomDomains")]
    public partial class EventGridNamespacePatch
    {
        /// <summary> This can be used to restrict traffic from specific IPs instead of all IPs. </summary>
        [WirePath("properties.inboundIpRules")]
        public IList<EventGridInboundIPRule> InboundIPRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NamespaceUpdateParameterProperties();
                }

                return Properties.InboundIPRules;
            }
        }

        [WirePath("properties.topicsConfiguration.customDomains")]
        public IList<CustomDomainConfiguration> TopicsCustomDomains
        {
            get
            {
                if (TopicsConfiguration is null)
                {
                    TopicsConfiguration = new UpdateTopicsConfigurationInfo();
                }

                return TopicsConfiguration.TopicsCustomDomains;
            }
        }

        internal UpdateTopicsConfigurationInfo TopicsConfiguration
        {
            get => Properties is null ? default : Properties.TopicsConfiguration;
            set
            {
                if (Properties is null)
                {
                    Properties = new NamespaceUpdateParameterProperties();
                }
                Properties.TopicsConfiguration = value;
            }
        }
    }
}
