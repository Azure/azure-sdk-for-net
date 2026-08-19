// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // TopicsCustomDomains is a two-level flatten (properties.topicsConfiguration.customDomains) that the
    // single-level @@flattenProperty decorator in the spec cannot express, so it is reshaped here to match
    // main's GA surface. (InboundIPRules is intentionally NOT customized here: the spec's @@flattenProperty +
    // @@clientName already generate it identically.)
    [CodeGenSuppress("TopicsCustomDomains")]
    public partial class EventGridNamespacePatch
    {
        /// <summary> Gets the custom domains for namespace topics. </summary>
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
