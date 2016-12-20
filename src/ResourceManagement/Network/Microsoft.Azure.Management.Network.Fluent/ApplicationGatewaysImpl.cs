// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// Implementation for ApplicationGateways.
    /// </summary>
    internal partial class ApplicationGatewaysImpl :
        GroupableResources<IApplicationGateway, ApplicationGatewayImpl, ApplicationGatewayInner, IApplicationGatewaysOperations, INetworkManager>,
        IApplicationGateways
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:7CF698D4F4194C8BBD98455A92E17A2C
        public ApplicationGatewayImpl Define(string name)
        {
            return WrapModel(name).WithSize(ApplicationGatewaySkuName.StandardSmall).WithInstanceCount(1);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<IApplicationGateway> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await InnerCollection.GetAsync(groupName, name, cancellationToken);
            return WrapModel(data);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        public PagedList<IApplicationGateway> List()
        {
            var pagedList = new PagedList<ApplicationGatewayInner>(InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        internal ApplicationGatewaysImpl(INetworkManagementClient networkClient, INetworkManager networkManager) : base(networkClient.ApplicationGateways, networkManager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        public PagedList<IApplicationGateway> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<ApplicationGatewayInner>(InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:4FD24066BFA6ACCBA6BCD17F67645E2A
        protected override ApplicationGatewayImpl WrapModel(string name)
        {
            var inner = new ApplicationGatewayInner();
            return new ApplicationGatewayImpl(
                name,
                inner,
                InnerCollection,
                Manager);
        }

        ///GENMHASH:0982709B48CC855164CE982B2642C391:0AF033C117570F9A4027C0D7C3ECFFC7
        protected override IApplicationGateway WrapModel(ApplicationGatewayInner inner)
        {
            return (inner == null) ? null : new ApplicationGatewayImpl(
                inner.Name,
                inner,
                InnerCollection,
                Manager);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }
    }
}
