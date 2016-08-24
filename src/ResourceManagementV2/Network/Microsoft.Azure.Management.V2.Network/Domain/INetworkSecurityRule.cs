/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// A network security rule in a network security group.
    /// </summary>
    public interface INetworkSecurityRule  :
        IWrapper<Microsoft.Azure.Management.Network.Models.SecurityRuleInner>,
        IChildResource
    {
        /// <returns>the network traffic direction the rule applies to</returns>
        string Direction { get; }

        /// <returns>the network protocol the rule applies to</returns>
        string Protocol { get; }

        /// <returns>the user-defined description of the security rule</returns>
        string Description { get; }

        /// <returns>the type of access the rule enforces</returns>
        string Access { get; }

        /// <returns>the source address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",</returns>
        /// <returns>and "*" means "any"</returns>
        string SourceAddressPrefix { get; }

        /// <returns>the source port range that the rule applies to, in the format "##-##", where "*" means "any"</returns>
        string SourcePortRange { get; }

        /// <returns>the destination address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",</returns>
        /// <returns>and "*" means "any"</returns>
        string DestinationAddressPrefix { get; }

        /// <returns>the destination port range that the rule applies to, in the format "##-##", where "*" means any</returns>
        string DestinationPortRange { get; }

        /// <returns>the priority number of this rule based on which this rule will be applied relative to the priority numbers of any other rules specified</returns>
        /// <returns>for this network security group</returns>
        int? Priority { get; }

    }
}