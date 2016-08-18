/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading;
    using Management.Network;
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for {@link NetworkSecurityGroup} and its create and update interfaces.
    /// </summary>
    public class NetworkSecurityGroupImpl :
        GroupableResource<INetworkSecurityGroup, 
            NetworkSecurityGroupInner,
            Rest.Azure.Resource,
            NetworkSecurityGroupImpl, 
            INetworkManager,
            NetworkSecurityGroup.Definition.IWithGroup,
            NetworkSecurityGroup.Definition.IWithCreate,
            NetworkSecurityGroup.Definition.IWithCreate,
            IUpdate>,
        INetworkSecurityGroup,
        IDefinition,
        IUpdate
    {
        private INetworkSecurityGroupsOperations innerCollection;
        private IList<INetworkSecurityRule> rules;
        private IList<INetworkSecurityRule> defaultRules;

        internal NetworkSecurityGroupImpl(string name, NetworkSecurityGroupInner innerModel, INetworkSecurityGroupsOperations innerCollection, NetworkManager networkManager) :
            base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
            this.InitializeRulesFromInner();
        }

        private void InitializeRulesFromInner()
        {
            this.rules = new List<INetworkSecurityRule>();
            if (this.Inner.SecurityRules != null)
            {
                foreach (SecurityRuleInner ruleInner in this.Inner.SecurityRules)
                {
                    this.rules.Add(new NetworkSecurityRuleImpl(ruleInner, this));
                }
            }

            this.defaultRules = new List<INetworkSecurityRule>();
            if (this.Inner.DefaultSecurityRules != null)
            {
                foreach (SecurityRuleInner ruleInner in this.Inner.DefaultSecurityRules)
                {
                    this.defaultRules.Add(new NetworkSecurityRuleImpl(ruleInner, this));
                }
            }
        }

        public NetworkSecurityRuleImpl UpdateRule(string name)
        {
            foreach (INetworkSecurityRule r in this.rules)
            {
                if (r.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return (NetworkSecurityRuleImpl)r;
                }
            }

            throw new Exception("Network security rule '" + name + "' not found");
        }

        public NetworkSecurityRuleImpl DefineRule(string name)
        {
            SecurityRuleInner inner = new SecurityRuleInner();
            inner.Name = name;
            inner.Priority = 100; // Must be at least 100
            return new NetworkSecurityRuleImpl(inner, this);
        }

        public async override Task<INetworkSecurityGroup> Refresh()
        {
            var response = await this.innerCollection.GetAsync(this.ResourceGroupName, this.Name);
            SetInner(response);
            return this;
        }

        public IUpdate WithoutRule(string name)
        {
            // Remove from cache
            IList<INetworkSecurityRule> r = this.rules;
            for (int i = 0; i < r.Count; i++)
            {
                if (r[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    r.Remove(r[i]);
                    break;
                }
            }

            // Remove from inner
            IList<SecurityRuleInner> innerRules = this.Inner.SecurityRules;
            for (int i = 0; i < innerRules.Count; i++)
            {
                if (innerRules[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    innerRules.Remove(innerRules[i]);
                    break;
                }
            }

            return this;
        }

        public IList<INetworkSecurityRule> SecurityRules()
        {
            return new ReadOnlyCollection<INetworkSecurityRule>(this.rules);
        }

        public IList<INetworkSecurityRule> DefaultSecurityRules()
        {
            return new ReadOnlyCollection<INetworkSecurityRule>(this.defaultRules);
        }

        public IList<string> NetworkInterfaceIds
        {
            get
            {
                List<string> ids = new List<string>();
                if (this.Inner.NetworkInterfaces != null)
                {
                    foreach (NetworkInterfaceInner inner in this.Inner.NetworkInterfaces)
                    {
                        ids.Add(inner.Id);
                    }
                }
                return ids;
            }
        }

        public override Task<INetworkSecurityGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            // final NetworkSecurityGroupImpl self = this;
            // return this.innerCollection.createOrUpdateAsync(this.resourceGroupName(), this.name(), this.Inner,
            // new ServiceCallback<NetworkSecurityGroupInner>() {
            // @Override
            // public void failure(Throwable t) {
            // callback.failure(t);
            // }
            // 
            // @Override
            // public void success(ServiceResponse<NetworkSecurityGroupInner> response) {
            // self.setInner(response.getBody());
            // initializeRulesFromInner();
            // callback.success(new ServiceResponse<Resource>(self, response.getResponse()));
            // }
            // });

            return null;
        }


        /// <returns>list of default security rules associated with this network security group</returns>
        System.Collections.Generic.IList<INetworkSecurityRule> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.DefaultSecurityRules
        {
            get
            {
                return this.DefaultSecurityRules() as System.Collections.Generic.IList<INetworkSecurityRule>;
            }
        }

        /// <returns>list of security rules associated with this network security group</returns>
        System.Collections.Generic.IList<INetworkSecurityRule> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.SecurityRules
        {
            get
            {
                return this.SecurityRules() as System.Collections.Generic.IList<INetworkSecurityRule>;
            }
        }

        /// <returns>list of the ids of the network interfaces associated with this network security group</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds as System.Collections.Generic.IList<string>;
            }
        }
        /// <summary>
        /// Starts the definition of a new security rule.
        /// </summary>
        /// <param name="name">name the name for the new security rule</param>
        /// <returns>the first stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Definition.IBlank<IWithCreate> Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition.IWithRule.DefineRule(string name)
        {
            return this.DefineRule(name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Definition.IBlank<IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of a new security rule to be added to this network security group.
        /// </summary>
        /// <param name="name">name the name of the new security rule</param>
        /// <returns>the first stage of the new security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.UpdateDefinition.IBlank<IUpdate> Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IWithRule.DefineRule(string name)
        {
            return this.DefineRule(name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.UpdateDefinition.IBlank<IUpdate>;
        }

        /// <summary>
        /// Removes an existing security rule.
        /// </summary>
        /// <param name="name">name the name of the security rule to remove</param>
        /// <returns>the next stage of the network security group description</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IWithRule.WithoutRule(string name)
        {
            return this.WithoutRule(name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing security rule of this network security group.
        /// </summary>
        /// <param name="name">name the name of an existing security rule</param>
        /// <returns>the first stage of the security rule update description</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IWithRule.UpdateRule(string name)
        {
            return this.UpdateRule(name) as Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate;
        }

    }
}