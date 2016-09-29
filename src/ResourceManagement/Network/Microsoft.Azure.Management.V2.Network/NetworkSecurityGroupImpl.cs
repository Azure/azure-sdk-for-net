// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using NetworkSecurityGroup.Update;
    using System.Collections.Generic;
    using Management.Network.Models;
    using NetworkSecurityGroup.Definition;
    using Resource.Core;
    using Management.Network;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for NetworkSecurityGroup and its create and update interfaces.
    /// </summary>
    public partial class NetworkSecurityGroupImpl :
        GroupableParentResource<INetworkSecurityGroup,
            NetworkSecurityGroupInner,
            Rest.Azure.Resource,
            NetworkSecurityGroupImpl,
            INetworkManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            IUpdate>,
        INetworkSecurityGroup,
        IDefinition,
        IUpdate
    {
        private INetworkSecurityGroupsOperations innerCollection;
        private IDictionary<string, INetworkSecurityRule> rules;
        private IDictionary<string, INetworkSecurityRule> defaultRules;
        internal  NetworkSecurityGroupImpl(
            string name, 
            NetworkSecurityGroupInner innerModel, 
            INetworkSecurityGroupsOperations innerCollection, 
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
        }

        #region Helpers
        override protected Task<NetworkSecurityGroupInner> CreateInner()
        {
            return innerCollection.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
        }

        override protected void BeforeCreating()
        {
            // Reset and update subnets
            Inner.SecurityRules = InnersFromWrappers<SecurityRuleInner, INetworkSecurityRule>(rules.Values);
        }

        override protected void AfterCreating()
        {
            // Nothing to do
        }

        override protected void InitializeChildrenFromInner ()
        {
            rules = new SortedDictionary<string, INetworkSecurityRule>();
            IList<SecurityRuleInner> inners = Inner.SecurityRules;
            if (inners != null)
            {
                foreach (SecurityRuleInner inner in inners)
                {
                    rules[inner.Name] = new NetworkSecurityRuleImpl(inner, this);
                }
            }

            defaultRules = new SortedDictionary<string, INetworkSecurityRule>();
            inners = Inner.DefaultSecurityRules;
            if (inners != null)
            {
                foreach (SecurityRuleInner inner in inners)
                {
                    defaultRules[inner.Name] = new NetworkSecurityRuleImpl(inner, this);
                }
            }
        }

        internal NetworkSecurityGroupImpl WithRule(NetworkSecurityRuleImpl rule)
        {
            rules[rule.Name] = rule;
            return this;
        }
        #endregion

        #region Public Withers
        public NetworkSecurityRuleImpl UpdateRule (string name)
        {
            INetworkSecurityRule rule;
            rules.TryGetValue(name, out rule);
            return (NetworkSecurityRuleImpl) rule;
        }

        public NetworkSecurityRuleImpl DefineRule (string name)
        {
            SecurityRuleInner inner = new SecurityRuleInner()
            {
                Name = name,
                Priority = 100 // Must be at least 100
            };

            return new NetworkSecurityRuleImpl(inner, this);
        }

        public IUpdate WithoutRule(string name)
        {
            rules.Remove(name);
            return this;
        }
        #endregion

        #region Actions
        public IList<ISubnet> ListAssociatedSubnets()
        {
            IList<SubnetInner> subnetRefs = this.Inner.Subnets;
            IDictionary<string, INetwork> networks = new Dictionary<string, INetwork>();
            IList<ISubnet> subnets = new List<ISubnet>();

            if (subnetRefs != null)
            {
                foreach (SubnetInner subnetRef in subnetRefs)
                {
                    string networkId = ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
                    INetwork network;
                    if (!networks.TryGetValue(networkId, out network))
                    {
                        try
                        {
                            network = Manager.Networks.GetById(networkId);
                            networks[networkId] = network;
                        }
                        catch
                        {
                            // Skip if not in existence anymore
                        }
                    }

                    if (network != null)
                    {
                        string subnetName = ResourceUtils.NameFromResourceId(subnetRef.Id);
                        ISubnet subnet;
                        if (network.Subnets().TryGetValue(subnetName, out subnet))
                        {
                            subnets.Add(subnet);
                        }
                    }
                }
            }

            return subnets;
        }

        public override INetworkSecurityGroup Refresh()
        {
            var response = innerCollection.Get(ResourceGroupName, Name);
            SetInner(response);
            return this;
        }
        #endregion

        #region Accessors
        public IDictionary<string, INetworkSecurityRule> SecurityRules ()
        {
            return rules;
        }

        public IDictionary<string, INetworkSecurityRule> DefaultSecurityRules ()
        {
            return defaultRules;
        }

        public IList<string> NetworkInterfaceIds
        {
            get
            {
                IList<string> ids = new List<string>();
                if (Inner.NetworkInterfaces != null)
                {
                    foreach (var inner in Inner.NetworkInterfaces)
                    {
                        ids.Add(inner.Id);
                    }
                }
                return ids;
            }
        }
        #endregion
    }
}
