// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition;
    using Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.Resource.Definition;
    using SqlElasticPool.Definition;
    using SqlElasticPool.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlElasticPool and its parent interfaces.
    /// </summary>
    internal partial class SqlElasticPoolImpl :
        IndependentChildResourceImpl<ISqlElasticPool, ISqlServer, ElasticPoolInner, SqlElasticPoolImpl, IHasId, IUpdate>,
        ISqlElasticPool,
        IDefinition,
        IUpdate,
        IWithParentResource<ISqlElasticPool, ISqlServer>
    {
        private IElasticPoolsOperations innerCollection;
        private IDatabasesOperations databasesInner;
        private DatabasesImpl databasesImpl;
        private IDictionary<string, SqlDatabaseImpl> databaseCreatableMap;

        public IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> ListActivities()
        {
            var activities = this.innerCollection.ListActivity(this.ResourceGroupName, this.SqlServerName(),
                    this.Name);

            var activitiesToReturn = new List<IElasticPoolActivity>();
            foreach (var elasticPoolActivityInner in activities)
            {
                activitiesToReturn.Add(new ElasticPoolActivityImpl(elasticPoolActivityInner));
            }

            return activitiesToReturn;
        }

        private async Task CreateOrUpdateDatabaseAsync()
        {
            if (this.databaseCreatableMap.Any())
            {
                await this.databasesImpl.Databases.CreateAsync(this.databaseCreatableMap.Values.ToArray());
                this.databaseCreatableMap.Clear();
            }
        }

        internal SqlElasticPoolImpl(string name, ElasticPoolInner innerObject, IElasticPoolsOperations innerCollection, IDatabasesOperations databasesInner, DatabasesImpl databasesImpl)
            : base(name, innerObject)
        {
            this.innerCollection = innerCollection;
            this.databasesInner = databasesInner;
            this.databasesImpl = databasesImpl;
            this.databaseCreatableMap = new Dictionary<string, SqlDatabaseImpl>();
        }

        public int DatabaseDtuMax()
        {
            return this.Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        public SqlElasticPoolImpl WithEdition(string edition)
        {
            this.Inner.Edition = edition;
            return this;
        }

        public int Dtu()
        {
            return this.Inner.Dtu.GetValueOrDefault();
        }

        public string SqlServerName()
        {
            return this.parentName;
        }

        protected override async Task<ISqlElasticPool> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var elasticPoolInner = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.SqlServerName(), Name, this.Inner);
            SetInner(elasticPoolInner);

            await CreateOrUpdateDatabaseAsync();
            return this;
        }

        public IList<ISqlDatabase> ListDatabases()
        {
            var databases = this.innerCollection.ListDatabases(
                        this.ResourceGroupName,
                        this.SqlServerName(),
                        this.Name);
            return databases.Select((databaseInner) => (ISqlDatabase)new SqlDatabaseImpl(databaseInner.Name, databaseInner, this.databasesInner)).ToList();
        }

        public string Edition()
        {
            return this.Inner.Edition;
        }

        public override ISqlElasticPool Refresh()
        {
            this.innerCollection.Get(this.ResourceGroupName, this.SqlServerName(), this.Name);
            return this;
        }

        public DateTime CreationDate()
        {
            return this.Inner.CreationDate.GetValueOrDefault();
        }

        public void Delete()
        {
            this.innerCollection.Delete(this.ResourceGroupName, this.SqlServerName(), this.Name);
        }

        public SqlElasticPoolImpl WithNewDatabase(string databaseName)
        {
            this.databaseCreatableMap.Add(databaseName,
                (SqlDatabaseImpl)this.databasesImpl.Define(databaseName).WithExistingElasticPool(this.Name).WithoutSourceDatabaseId());
            return this;
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities()
        {
            var databaseActivities = this.innerCollection.ListDatabaseActivity(
                    this.Name,
                    this.ResourceGroupName,
                    this.SqlServerName());
            return databaseActivities.Select((elasticPoolDatabaseActivityInner) => (IElasticPoolDatabaseActivity)new ElasticPoolDatabaseActivityImpl(elasticPoolDatabaseActivityInner)).ToList();
        }

        public int DatabaseDtuMin()
        {
            return this.Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        public ISqlDatabase GetDatabase(string databaseName)
        {
            DatabaseInner database = this.innerCollection.GetDatabase(
                this.ResourceGroupName,
                this.SqlServerName(),
                this.Name,
                databaseName);
            return new SqlDatabaseImpl(database.Name, database, this.databasesInner);
        }

        public SqlElasticPoolImpl WithExistingDatabase(string databaseName)
        {
            this.databaseCreatableMap.Add(databaseName, (SqlDatabaseImpl)this.databasesImpl.Get(databaseName).Update().WithExistingElasticPool(this.Name));
            return this;
        }

        public SqlElasticPoolImpl WithExistingDatabase(ISqlDatabase database)
        {
            this.databaseCreatableMap.Add(database.Name, (SqlDatabaseImpl)database.Update().WithExistingElasticPool(this.Name));
            return this;
        }

        public SqlElasticPoolImpl WithDatabaseDtuMin(int databaseDtuMin)
        {
            this.Inner.DatabaseDtuMin = databaseDtuMin;
            return this;
        }

        public SqlElasticPoolImpl WithDatabaseDtuMax(int databaseDtuMax)
        {
            this.Inner.DatabaseDtuMax = databaseDtuMax;
            return this;
        }

        public int StorageMB()
        {
            return this.Inner.StorageMB.GetValueOrDefault();
        }

        public SqlElasticPoolImpl WithDtu(int dtu)
        {
            this.Inner.Dtu = dtu;
            return this;
        }

        public SqlElasticPoolImpl WithStorageCapacity(int storageMB)
        {
            this.Inner.StorageMB = storageMB;
            return this;
        }

        public string State()
        {
            return this.Inner.State;
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            return base.WithTags(tags);
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTag(string key, string value)
        {
            return base.WithTag(key, value);
        }
    }
}