// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for NetworkSecurityGroups.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1NlY3VyaXR5R3JvdXBzSW1wbA==
    internal partial class NetworkSecurityGroupsImpl  :
        TopLevelModifiableResources<
            INetworkSecurityGroup,
            NetworkSecurityGroupImpl,
            NetworkSecurityGroupInner,
            INetworkSecurityGroupsOperations,
            INetworkManager>,
        INetworkSecurityGroups
    {
        
        ///GENMHASH:DB33B9596F264F57A36F2BBE37A750E6:7796053155B488254D560E1523EBBD30
        internal  NetworkSecurityGroupsImpl (INetworkManager networkManager) : base(networkManager.Inner.NetworkSecurityGroups, networkManager)
        {
        }

        
        protected async override Task<IPage<NetworkSecurityGroupInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<NetworkSecurityGroupInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        
        protected async override Task<IPage<NetworkSecurityGroupInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<NetworkSecurityGroupInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal NetworkSecurityGroupImpl Define (string name)
        {
            return WrapModel(name);
        }

        
        ///GENMHASH:9D38835F71DF2C39BF88CBB588420D30:BA469A1870FD53668BBB4D29E7CFB651
        public async override Task DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Clear NIC references if any
            var nsg = await GetByResourceGroupAsync(groupName, name, cancellationToken);
            if (nsg != null)
            {
                var nicIds = nsg.NetworkInterfaceIds;
                if (nicIds != null)
                {
                    foreach (string nicRef in nicIds)
                    {
                        var nic = await Manager.NetworkInterfaces.GetByIdAsync(nicRef, cancellationToken);
                        if (nic == null)
                        {
                            continue;
                        }
                        else if (!nsg.Id.ToLowerInvariant().Equals(nic.NetworkSecurityGroupId.ToLowerInvariant()))
                        {
                            continue;
                        }
                        else
                        {
                            await nic.Update().WithoutNetworkSecurityGroup().ApplyAsync(cancellationToken);
                        }
                    }
                }
            }

            await DeleteInnerByGroupAsync(groupName, name, cancellationToken);
        }
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        
        protected async override Task<NetworkSecurityGroupInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:89BA2E4B4D969CAA0D4C6AE36B763722
        override protected NetworkSecurityGroupImpl WrapModel (string name)
        {
            NetworkSecurityGroupInner inner = new NetworkSecurityGroupInner();
            return new NetworkSecurityGroupImpl(name, inner, Manager);
        }

        //$TODO: return NetworkSecurityGroupImpl

        
        ///GENMHASH:B59141AC50BFD765AA31B7D8EBE354C5:DFAB72C58AA3BB4194C39E854D2EF23B
        override protected INetworkSecurityGroup WrapModel (NetworkSecurityGroupInner inner)
        {
            return new NetworkSecurityGroupImpl(inner.Name, inner, Manager);
        }
    }
}
