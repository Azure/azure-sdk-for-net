// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
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
