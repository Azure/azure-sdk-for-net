// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using SqlDatabase.Definition;
    using SqlDatabases.SqlDatabaseCreatable;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQLDatabases and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZXNJbXBs
    internal partial class SqlDatabasesImpl :
        IndependentChildResourcesImpl<ISqlDatabase, SqlDatabaseImpl, DatabaseInner, IDatabasesOperations, ISqlManager, ISqlServer>,
        ISqlDatabaseCreatable,
        ISupportsGettingByParent<ISqlDatabase, ISqlServer, ISqlManager>,
        ISupportsListingByParent<ISqlDatabase, ISqlServer, ISqlManager>
    {
        ///GENMHASH:810ADAE06099EC51B2E3C858F502369C:0FCD47CBCD9128C3D4A03458C5796741
        internal SqlDatabasesImpl(IDatabasesOperations innerCollection, ISqlManager manager)
            : base(innerCollection, manager)
        {
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:F46E4D0A3CDB6C5AE412BF5B7FB52B09
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return new List<ISqlDatabase>(this.ListByParent(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:CD989F8A79EC70D56C4F5154E2B8BE11:57462F0C7FF757AFBBFD3B3561C9F9ED
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListBySqlServer(ISqlServer sqlServer)
        {
            return new List<ISqlDatabase>(this.ListByParent(sqlServer));
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:7F70CB1AA5FE23578E360B95D229A1C6
        public override async Task<PagedList<ISqlDatabase>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var pagedList = new PagedList<DatabaseInner>(await Inner.ListByServerAsync(resourceGroupName, parentName, cancellationToken));

            return WrapList(pagedList);
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:877F7B73190881879934925547D57EAF
        public ISqlDatabase GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return GetByParent(resourceGroup, sqlServerName, name);
        }

        ///GENMHASH:6B5394D9B9C62E3B4A3B037DD27B7A20:466DF29CB4850E0593B3C691F625BC2C
        public ISqlDatabase GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return GetByParent(sqlServer, name);
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:1056648A6B4A4D9B6EA5F5AC88AE4C12
        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, parentName, name);
        }

        ///GENMHASH:E3353FA0F9E79B667402107BE3CC7CC3:0CA4332DE38D32AB72FBE39111235FB6
        public ICreatable<ISqlDatabase> DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string databaseName, Region region)
        {
            DatabaseInner inner = new DatabaseInner();
            inner.Location = region.ToString();

            return new SqlDatabaseImpl(
                databaseName,
                inner,
                Inner,
                Manager).WithExistingParentResource(resourceGroupName, sqlServerName);
        }

        ///GENMHASH:C32C5A59EBD92E91959156A49A8C1A95:36E87C79062474D6AB62B46DAD7396F9
        public override async Task<ISqlDatabase> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(resourceGroup, parentName, name, null, cancellationToken));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:EE2AFF190F028DCFBD558F3E893BACCE
        protected override SqlDatabaseImpl WrapModel(string name)
        {
            DatabaseInner inner = new DatabaseInner();
            return new SqlDatabaseImpl(
                name,
                inner,
                Inner,
                Manager);
        }

        ///GENMHASH:CA9C77E2E75D4B5516D4A63CB7215DC7:D226C70930A9D702B9E8BCF068F33C76
        protected override ISqlDatabase WrapModel(DatabaseInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new SqlWarehouseImpl(inner.Name, inner, Inner, Manager);
        }
    }
}
