// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Threading.Tasks;
    public partial class NetworkSecurityGroupImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup>.Refresh () { 
            return this.Refresh() as Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup;
        }

        /// <returns>virtual networks associated with this security group,</returns>
        /// <returns>indexed by the names of the specific subnets referencing this security group</returns>
        System.Collections.Generic.List<Microsoft.Azure.Management.V2.Network.ISubnet> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.ListAssociatedSubnets () { 
            return this.ListAssociatedSubnets() as System.Collections.Generic.List<Microsoft.Azure.Management.V2.Network.ISubnet>;
        }

        /// <returns>default security rules associated with this network security group, indexed by their name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.DefaultSecurityRules () { 
            return this.DefaultSecurityRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule>;
        }

        /// <returns>security rules associated with this network security group, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.SecurityRules () { 
            return this.SecurityRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.V2.Network.INetworkSecurityRule>;
        }

        /// <returns>list of the ids of the network interfaces associated with this network security group</returns>
        System.Collections.Generic.List<string> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds as System.Collections.Generic.List<string>;
            }
        }
        /// <summary>
        /// Starts the definition of a new security rule.
        /// </summary>
        /// <param name="name">name the name for the new security rule</param>
        /// <returns>the first stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Definition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition.IWithRule.DefineRule (string name) { 
            return this.DefineRule( name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Definition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of a new security rule to be added to this network security group.
        /// </summary>
        /// <param name="name">name the name of the new security rule</param>
        /// <returns>the first stage of the new security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IWithRule.DefineRule (string name) { 
            return this.DefineRule( name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Removes an existing security rule.
        /// </summary>
        /// <param name="name">name the name of the security rule to remove</param>
        /// <returns>the next stage of the network security group description</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IWithRule.WithoutRule (string name) { 
            return this.WithoutRule( name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing security rule of this network security group.
        /// </summary>
        /// <param name="name">name the name of an existing security rule</param>
        /// <returns>the first stage of the security rule update description</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IWithRule.UpdateRule (string name) { 
            return this.UpdateRule( name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate;
        }

    }
}