// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using SqlServer.Definition;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlServers and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJzSW1wbA==
    internal partial class SqlServersImpl :
        GroupableResources<ISqlServer, SqlServerImpl, ServerInner, IServersOperations, ISqlManager>,
        ISqlServers
    {
        ///GENMHASH:01C0FA69267690E3BF39F794FC8D1F05:9CCC9CA468F37F7150A173588C172C02
        internal SqlServersImpl(SqlManager manager)
            : base(manager.Inner.Servers, manager)
        {
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public async override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:92EAC0C15F6E0EE83B7B356CD097B0A0
        public async override Task<ISqlServer> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetByResourceGroupAsync(groupName, name, cancellationToken));
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public PagedList<ISqlServer> List()
        {
            return WrapList(new PagedList<ServerInner>(Inner.List()));
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:4400109B5DDC2A92920D8D598AB5D8B9
        protected override SqlServerImpl WrapModel(string name)
        {
            ServerInner inner = new ServerInner();
            inner.Version = ServerVersion.TwoFullStopZero;
            return new SqlServerImpl(
                name,
                inner,
                Manager);
        }

        ///GENMHASH:14929760F9002214878530515584D731:A4CD16875FD79CECC756C53898FB4374
        protected override ISqlServer WrapModel(ServerInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new SqlServerImpl(
                inner.Name,
                inner,
                Manager);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:F27988875BD81EE531DA23D26C675612
        public PagedList<ISqlServer> ListByGroup(string resourceGroupName)
        {
            return WrapList(new PagedList<ServerInner>(Inner.ListByResourceGroup(resourceGroupName)));
        }
    }
}
