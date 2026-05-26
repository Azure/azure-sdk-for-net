// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // The generated model now uses Type/IPPrefixValues/IPGroupNames. The previous SDK exposed
    // SourceDestinationType/IpPrefixValues/IpGroupNames, so these aliases prevent public property removals.
    // Removing them would require callers to rename properties even though this migration should be API-neutral.
    public partial class IPMatchCondition
    {
        /// <summary> IP Address type that needs to be matched. </summary>
        public SourceDestinationType? SourceDestinationType
        {
            get => Type;
            set => Type = value;
        }

        /// <summary> The list of IP Prefixes that need to be matched. </summary>
        public IList<string> IpPrefixValues => IPPrefixValues;

        /// <summary> The List of IP Group Names that need to be matched. </summary>
        public IList<string> IpGroupNames => IPGroupNames;
    }
}
