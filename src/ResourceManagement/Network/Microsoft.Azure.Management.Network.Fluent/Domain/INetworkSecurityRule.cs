// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A network security rule in a network security group.
    /// </summary>
    public interface INetworkSecurityRule  :
        IWrapper<Models.SecurityRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>
    {
        /// <summary>
        /// Gets the destination address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",
        /// and "" means "any".
        /// </summary>
        string DestinationAddressPrefix { get; }

        /// <summary>
        /// Gets the network protocol the rule applies to.
        /// </summary>
        string Protocol { get; }

        /// <summary>
        /// Gets the type of access the rule enforces.
        /// </summary>
        string Access { get; }

        /// <summary>
        /// Gets the source port range that the rule applies to, in the format "##-##", where "" means "any".
        /// </summary>
        string SourcePortRange { get; }

        /// <summary>
        /// Gets the source address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",
        /// and "" means "any".
        /// </summary>
        string SourceAddressPrefix { get; }

        /// <summary>
        /// Gets the destination port range that the rule applies to, in the format "##-##", where "" means any.
        /// </summary>
        string DestinationPortRange { get; }

        /// <summary>
        /// Gets the user-defined description of the security rule.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the priority number of this rule based on which this rule will be applied relative to the priority numbers of any other rules specified
        /// for this network security group.
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Gets the direction of the network traffic that the network security rule applies to.
        /// </summary>
        string Direction { get; }
    }
}