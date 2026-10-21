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
        /// <summary> The source address prefixes. CIDR or source IP ranges. </summary>
        [CodeGenMember("Sources")]
        [WirePath("properties.sources")]
        public IReadOnlyList<AddressPrefixItem> Sources
        {
            get
            {
                return Properties is null ? default : new ReadOnlyCollection<AddressPrefixItem>(Properties.Sources);
            }
        }

        /// <summary> The destination address prefixes. CIDR or destination IP ranges. </summary>
        [CodeGenMember("Destinations")]
        [WirePath("properties.destinations")]
        public IReadOnlyList<AddressPrefixItem> Destinations
        {
            get
            {
                return Properties is null ? default : new ReadOnlyCollection<AddressPrefixItem>(Properties.Destinations);
            }
        }

        /// <summary> The source port ranges. </summary>
        [CodeGenMember("SourcePortRanges")]
        [WirePath("properties.sourcePortRanges")]
        public IReadOnlyList<string> SourcePortRanges
        {
            get
            {
                return Properties is null ? default : new ReadOnlyCollection<string>(Properties.SourcePortRanges);
            }
        }

        /// <summary> The destination port ranges. </summary>
        [CodeGenMember("DestinationPortRanges")]
        [WirePath("properties.destinationPortRanges")]
        public IReadOnlyList<string> DestinationPortRanges
        {
            get
            {
                return Properties is null ? default : new ReadOnlyCollection<string>(Properties.DestinationPortRanges);
            }
        }
    }
}
