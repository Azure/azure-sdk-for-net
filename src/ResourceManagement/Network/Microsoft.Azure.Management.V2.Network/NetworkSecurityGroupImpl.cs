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
    public partial class NetworkSecurityGroupImpl :
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

        public async override Task<INetworkSecurityGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
            this.SetInner(response);
            this.InitializeRulesFromInner();
            return this;
        }
    }
}