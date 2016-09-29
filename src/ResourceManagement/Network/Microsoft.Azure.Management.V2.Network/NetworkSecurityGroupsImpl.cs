// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for NetworkSecurityGroups.
    /// </summary>
    public partial class NetworkSecurityGroupsImpl  :
        GroupableResources<
            Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup,
            Microsoft.Azure.Management.V2.Network.NetworkSecurityGroupImpl,
            Microsoft.Azure.Management.Network.Models.NetworkSecurityGroupInner,
            INetworkSecurityGroupsOperations,
            NetworkManager>,
        INetworkSecurityGroups
    {
        internal  NetworkSecurityGroupsImpl (
            INetworkSecurityGroupsOperations innerCollection, 
            NetworkManager networkManager) : base(innerCollection, networkManager)
        {

            //$ final NetworkSecurityGroupsInner innerCollection,
            //$ final NetworkManager networkManager) {
            //$ super(innerCollection, networkManager);
            //$ }

        }

        public PagedList<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup> List ()
        {

            //$ return wrapList(this.innerCollection.listAll());

            return null;
        }

        public PagedList<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup> ListByGroup (string groupName)
        {

            //$ return wrapList(this.innerCollection.list(groupName));

            return null;
        }

        public NetworkSecurityGroupImpl Define (string name)
        {

            //$ return wrapModel(name);

            return null;
        }

        Task DeleteAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }

        public override async Task<INetworkSecurityGroup> GetByGroupAsync(string groupName, string name)
        {
            return this as INetworkSecurityGroup;
        }


        override protected NetworkSecurityGroupImpl WrapModel (string name)
        {

            //$ NetworkSecurityGroupInner inner = new NetworkSecurityGroupInner();
            //$ 
            //$ // Initialize rules
            //$ if (inner.securityRules() == null) {
            //$ inner.withSecurityRules(new ArrayList<SecurityRuleInner>());
            //$ }
            //$ 
            //$ if (inner.defaultSecurityRules() == null) {
            //$ inner.withDefaultSecurityRules(new ArrayList<SecurityRuleInner>());
            //$ }
            //$ 
            //$ return new NetworkSecurityGroupImpl(
            //$ name,
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager);

            return null;
        }

        //$TODO: return NetworkSecurityGroupImpl
        override protected INetworkSecurityGroup WrapModel (NetworkSecurityGroupInner inner)
        {

            //$ return new NetworkSecurityGroupImpl(
            //$ inner.name(),
            //$ inner,
            //$ this.innerCollection,
            //$ this.myManager);

            return null;
        }

        void ISupportsDeleting.Delete(string id)
        {
            throw new NotImplementedException();
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void ISupportsDeletingByGroup.Delete(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}