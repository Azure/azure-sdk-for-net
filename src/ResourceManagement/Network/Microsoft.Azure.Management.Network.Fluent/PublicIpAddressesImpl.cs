// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Management.Network.Fluent.Models;
    using System.Threading;
    using Resource.Fluent.Core;
    using System.Threading.Tasks;
    using Management.Network;

    /// <summary>
    /// Implementation for PublicIpAddresses.
    /// </summary>
    public partial class PublicIpAddressesImpl :
        GroupableResources<
            IPublicIpAddress,
            PublicIpAddressImpl,
            PublicIPAddressInner,
            IPublicIPAddressesOperations,
            NetworkManager>,
        IPublicIpAddresses
    {
        internal PublicIpAddressesImpl(NetworkManagementClient client, NetworkManager networkManager)
            : base(client.PublicIPAddresses, networkManager)
        {
        }

        override protected PublicIpAddressImpl WrapModel(string name)
        {
            PublicIPAddressInner inner = new PublicIPAddressInner();

            if (null == inner.DnsSettings)
            {
                inner.DnsSettings = new PublicIPAddressDnsSettings();
            }

            return new PublicIpAddressImpl(name, inner, InnerCollection, Manager);
        }

        //$TODO: shoudl return PublicIpAddressImpl
        override protected IPublicIpAddress WrapModel(PublicIPAddressInner inner)
        {
            return new PublicIpAddressImpl(inner.Id, inner, InnerCollection, Manager);
        }

        internal PagedList<IPublicIpAddress> List()
        {
            var pagedList = new PagedList<PublicIPAddressInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        internal PagedList<IPublicIpAddress> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<PublicIPAddressInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }


        internal PublicIpAddressImpl Define(string name)
        {
            return WrapModel(name);
        }

        Task DeleteAsync(string groupName, string name)
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        public override async Task<IPublicIpAddress> GetByGroupAsync(string groupName, string name)
        {
            var data = await InnerCollection.GetAsync(groupName, name);
            return WrapModel(data);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }
    }
}
