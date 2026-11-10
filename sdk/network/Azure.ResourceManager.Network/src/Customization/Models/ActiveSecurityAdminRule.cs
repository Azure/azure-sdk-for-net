// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ActiveSecurityAdminRule
    {
        // 1.15.0 generated IReadOnlyList<T> properties; the native flattened properties expose IList<T>.
        // Preserve the released interface with read-only views of the deserializer's backing lists.

        /// <summary> The source address prefixes. CIDR or source IP ranges. </summary>
        [CodeGenMember("Sources")]
        [WirePath("properties.sources")]
        public IReadOnlyList<AddressPrefixItem> Sources
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<AddressPrefixItem>(properties.Sources);
            }
        }

        /// <summary> The destination address prefixes. CIDR or destination IP ranges. </summary>
        [CodeGenMember("Destinations")]
        [WirePath("properties.destinations")]
        public IReadOnlyList<AddressPrefixItem> Destinations
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<AddressPrefixItem>(properties.Destinations);
            }
        }

        /// <summary> The source port ranges. </summary>
        [CodeGenMember("SourcePortRanges")]
        [WirePath("properties.sourcePortRanges")]
        public IReadOnlyList<string> SourcePortRanges
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<string>(properties.SourcePortRanges);
            }
        }

        /// <summary> The destination port ranges. </summary>
        [CodeGenMember("DestinationPortRanges")]
        [WirePath("properties.destinationPortRanges")]
        public IReadOnlyList<string> DestinationPortRanges
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<string>(properties.DestinationPortRanges);
            }
        }
    }
}
