// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using NetworkSecurityGroup.Definition;
    using NetworkSecurityGroup.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NetworkSecurityGroupImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup;
        }

        /// <summary>
        /// Gets default security rules associated with this network security group, indexed by their name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup.DefaultSecurityRules
        {
            get
            {
                return this.DefaultSecurityRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule>;
            }
        }

        /// <summary>
        /// Gets security rules associated with this network security group, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup.SecurityRules
        {
            get
            {
                return this.SecurityRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule>;
            }
        }

        /// <summary>
        /// Gets list of the ids of the network interfaces associated with this network security group.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Starts the definition of a new security rule.
        /// </summary>
        /// <param name="name">The name for the new security rule.</param>
        /// <return>The first stage of the security rule definition.</return>
        NetworkSecurityRule.Definition.IBlank<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityGroup.Definition.IWithRule.DefineRule(string name)
        {
            return this.DefineRule(name) as NetworkSecurityRule.Definition.IBlank<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of a new security rule to be added to this network security group.
        /// </summary>
        /// <param name="name">The name of the new security rule.</param>
        /// <return>The first stage of the new security rule definition.</return>
        NetworkSecurityRule.UpdateDefinition.IBlank<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityGroup.Update.IWithRule.DefineRule(string name)
        {
            return this.DefineRule(name) as NetworkSecurityRule.UpdateDefinition.IBlank<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Removes an existing security rule.
        /// </summary>
        /// <param name="name">The name of the security rule to remove.</param>
        /// <return>The next stage of the network security group description.</return>
        NetworkSecurityGroup.Update.IUpdate NetworkSecurityGroup.Update.IWithRule.WithoutRule(string name)
        {
            return this.WithoutRule(name) as NetworkSecurityGroup.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing security rule of this network security group.
        /// </summary>
        /// <param name="name">The name of an existing security rule.</param>
        /// <return>The first stage of the security rule update description.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityGroup.Update.IWithRule.UpdateRule(string name)
        {
            return this.UpdateRule(name) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <return>List of subnets associated with this resource.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ISubnet> Microsoft.Azure.Management.Network.Fluent.IHasAssociatedSubnets.ListAssociatedSubnets()
        {
            return this.ListAssociatedSubnets() as System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ISubnet>;
        }
    }
}