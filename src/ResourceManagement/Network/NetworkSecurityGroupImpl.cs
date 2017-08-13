// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System;
    using System.Threading;

    /// <summary>
    /// Implementation for NetworkSecurityGroup
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1NlY3VyaXR5R3JvdXBJbXBs
    internal partial class NetworkSecurityGroupImpl :
        GroupableParentResource<INetworkSecurityGroup,
            NetworkSecurityGroupInner,
            NetworkSecurityGroupImpl,
            INetworkManager,
            NetworkSecurityGroup.Definition.IWithGroup,
            NetworkSecurityGroup.Definition.IWithCreate,
            NetworkSecurityGroup.Definition.IWithCreate,
            NetworkSecurityGroup.Update.IUpdate>,
        INetworkSecurityGroup,
        NetworkSecurityGroup.Definition.IDefinition,
        NetworkSecurityGroup.Update.IUpdate
    {
        private Dictionary<string, INetworkSecurityRule> rules;
        private Dictionary<string, INetworkSecurityRule> defaultRules;
        
        ///GENMHASH:99ABC9D2B92F8B3218318103F9D13D01:3881994DCADCE14215F82F0CC81BDD88
        internal  NetworkSecurityGroupImpl(
            string name,
            NetworkSecurityGroupInner innerModel,
            INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        #region Helpers

        
        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:AB749B78EE0B940488F4408AFD5A856D
        protected async override Task<NetworkSecurityGroupInner> CreateInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.NetworkSecurityGroups.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }

        
        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:A61BAEAFF2676CB74CB2C0A5F49B245E
        override protected void BeforeCreating()
        {
            // Reset and update subnets
            Inner.SecurityRules = InnersFromWrappers<SecurityRuleInner, INetworkSecurityRule>(rules.Values);
        }

        
        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:27E486AB74A10242FF421C0798DDC450
        override protected void AfterCreating()
        {
            // Nothing to do
        }

        
        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:6624452329542D5B0E4B4BE8D790304C
        override protected void InitializeChildrenFromInner ()
        {
            rules = new Dictionary<string, INetworkSecurityRule>();
            IList<SecurityRuleInner> inners = Inner.SecurityRules;
            if (inners != null)
            {
                foreach (SecurityRuleInner inner in inners)
                {
                    rules[inner.Name] = new NetworkSecurityRuleImpl(inner, this);
                }
            }

            defaultRules = new Dictionary<string, INetworkSecurityRule>();
            inners = Inner.DefaultSecurityRules;
            if (inners != null)
            {
                foreach (SecurityRuleInner inner in inners)
                {
                    defaultRules[inner.Name] = new NetworkSecurityRuleImpl(inner, this);
                }
            }
        }

        
        ///GENMHASH:659398B48C1740FA02043DE9B0D11CF8:E49A6315EAB2204516FEF948739183C2
        internal NetworkSecurityGroupImpl WithRule(NetworkSecurityRuleImpl rule)
        {
            rules[rule.Name()] = rule;
            return this;
        }
        #endregion

        #region Public Withers

        
        ///GENMHASH:0E516034DD6EAC0154C689EE19E8DACC:3B3673F8DAFFB5EAAA6DA437C687075E
        internal NetworkSecurityRuleImpl UpdateRule (string name)
        {
            INetworkSecurityRule rule;
            rules.TryGetValue(name, out rule);
            return (NetworkSecurityRuleImpl) rule;
        }

        
        ///GENMHASH:6823FCC8CD86F0A33002CFB751DEA302:1B86A0897B3C9C09B427B720B9ED7DDE
        internal NetworkSecurityRuleImpl DefineRule (string name)
        {
            SecurityRuleInner inner = new SecurityRuleInner()
            {
                Name = name,
                Priority = 100 // Must be at least 100
            };

            return new NetworkSecurityRuleImpl(inner, this);
        }

        
        ///GENMHASH:EC4B0EE9E5C17F0368D305042F19A0FD:BB6B3B198CEC808EF295F8AE72D11548
        internal NetworkSecurityGroupImpl WithoutRule(string name)
        {
            rules.Remove(name);
            return this;
        }
        #endregion

        #region Actions

        
        ///GENMHASH:E78D7ACAEEE05A0117BC7B6E41B0D53B:062BFEFE0393BE2C1D9F8B1A963FDE23
        internal IReadOnlyList<ISubnet> ListAssociatedSubnets()
        {
            return Manager.ListAssociatedSubnets(Inner.Subnets);
        }

        
        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:07B3E20B02A42C7CA6F82856FD2C45A3
        protected override async Task<NetworkSecurityGroupInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.NetworkSecurityGroups.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        #endregion

        #region Accessors

        
        ///GENMHASH:F8F85F9267133B95FDDB0B6F1F27E816:FC8B3AE517369B64F33F8DC475426F01
        internal IReadOnlyDictionary<string, INetworkSecurityRule> SecurityRules ()
        {
            return rules;
        }

        
        ///GENMHASH:79407FFCDB8168F82199BE25744F9808:90E13C4BC15B37167DE1F6486AFDC06C
        internal IReadOnlyDictionary<string, INetworkSecurityRule> DefaultSecurityRules ()
        {
            return defaultRules;
        }

        
        ///GENMHASH:606A3D349546DF27E3A091C321476658:8AB71673F69C559071289576B86748A0
        internal ISet<string> NetworkInterfaceIds()
        {
            ISet<string> ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (Inner.NetworkInterfaces != null)
            {
                foreach (var inner in Inner.NetworkInterfaces)
                    ids.Add(inner.Id);
            }
            return ids;
        }
        #endregion
    }
}
