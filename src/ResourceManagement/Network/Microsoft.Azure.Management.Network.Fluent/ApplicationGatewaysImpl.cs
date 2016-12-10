// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;

    /// <summary>
    /// Implementation for ApplicationGateways.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5c0ltcGw=
    internal partial class ApplicationGatewaysImpl :
        GroupableResources<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway, Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl, Models.ApplicationGatewayInner, IApplicationGatewaysOperations, INetworkManager>,
        IApplicationGateways
    {
        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.InnerCollection.DeleteAsync(groupName, name);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:7CF698D4F4194C8BBD98455A92E17A2C
        public ApplicationGatewayImpl Define(string name)
        {
            //$ return wrapModel(name).WithSize(ApplicationGatewaySkuName.STANDARD_SMALL).WithInstanceCount(1);

            return null;
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<IApplicationGateway> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapModel(this.InnerCollection.Get(groupName, name));

            return null;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        public PagedList<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway> List()
        {
            //$ return wrapList(this.InnerCollection.ListAll());

            return null;
        }

        ///GENMHASH:DB7CDF51E063E00F632236B9A1581DD7:A55F357967E86E32E70097D1F0B4D25E
        internal ApplicationGatewaysImpl(INetworkManagementClient networkClient, INetworkManager networkManager) : base(networkClient.ApplicationGateways, networkManager)
        {
            //$ {
            //$ super(networkClient.ApplicationGateways(), networkManager);
            //$ }

        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        public PagedList<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway> ListByGroup(string groupName)
        {
            //$ return wrapList(this.InnerCollection.List(groupName));

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:4FD24066BFA6ACCBA6BCD17F67645E2A
        protected override ApplicationGatewayImpl WrapModel(string name)
        {
            //$ ApplicationGatewayInner inner = new ApplicationGatewayInner();
            //$ return new ApplicationGatewayImpl(
            //$ name,
            //$ inner,
            //$ this.InnerCollection,
            //$ super.MyManager);

            return null;
        }

        ///GENMHASH:0982709B48CC855164CE982B2642C391:0AF033C117570F9A4027C0D7C3ECFFC7
        protected override IApplicationGateway WrapModel(ApplicationGatewayInner inner)
        {
            //$ return (inner == null) ? null : new ApplicationGatewayImpl(
            //$ inner.Name(),
            //$ inner,
            //$ this.InnerCollection,
            //$ this.MyManager);

            return null;
        }
    }
}