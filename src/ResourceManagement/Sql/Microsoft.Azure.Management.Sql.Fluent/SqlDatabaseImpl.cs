// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using SqlDatabase.Definition;
    using SqlDatabase.Update;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Resource.Fluent.Core.Resource.Definition;

    /// <summary>
    /// Implementation for SqlDatabase and its parent interfaces.
    /// </summary>
    internal partial class SqlDatabaseImpl :
        IndependentChildResourceImpl<ISqlDatabase, ISqlServer, DatabaseInner, SqlDatabaseImpl, IHasId, IUpdate>,
        ISqlDatabase,
        IDefinition,
        IUpdate,
        IWithParentResource<ISqlDatabase, ISqlServer>
    {
        internal IDatabasesOperations innerCollection;
        private string elasticPoolCreatableKey;

        public string ElasticPoolName()
        {
            return this.Inner.ElasticPoolName;
        }

        public SqlDatabaseImpl WithEdition(string edition)
        {
            this.Inner.Edition = edition;
            return this;
        }

        public SqlDatabaseImpl WithServiceObjective(string serviceLevelObjective)
        {
            this.Inner.RequestedServiceObjectiveName = serviceLevelObjective;
            this.Inner.RequestedServiceObjectiveId = null;

            return this;
        }

        public string Edition()
        {
            return this.Inner.Edition;
        }

        public ISqlWarehouse CastToWarehouse()
        {
            if (this.IsDataWarehouse())
            {
                return (ISqlWarehouse)this;
            }

            return null;
        }

        public void Delete()
        {
            this.innerCollection.Delete(this.ResourceGroupName, this.SqlServerName(), this.Name);
        }

        public SqlDatabaseImpl WithMaxSizeBytes(long maxSizeBytes)
        {
            this.Inner.MaxSizeBytes = maxSizeBytes.ToString();
            return this;
        }

        public Guid CurrentServiceObjectiveId()
        {
            return this.Inner.CurrentServiceObjectiveId.GetValueOrDefault();
        }

        public SqlDatabaseImpl WithExistingElasticPool(string elasticPoolName)
        {
            this.Inner.ElasticPoolName = elasticPoolName;
            return this;
        }

        public SqlDatabaseImpl WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool.Name);
        }

        public SqlDatabaseImpl WithoutSourceDatabaseId()
        {
            return this;
        }

        public IUpgradeHint GetUpgradeHint()
        {
            if (this.Inner.UpgradeHint == null)
            {
                this.SetInner(this.innerCollection.Get(this.ResourceGroupName, this.SqlServerName(), this.Name, "upgradeHint"));
            }
            if (this.Inner.UpgradeHint != null)
            {
                return new UpgradeHintImpl(this.Inner.UpgradeHint);
            }

            return null;
        }

        public long MaxSizeBytes()
        {
            return long.Parse(this.Inner.MaxSizeBytes);
        }

        public string DefaultSecondaryLocation()
        {
            return this.Inner.DefaultSecondaryLocation;
        }

        public string Collation()
        {
            return this.Inner.Collation;
        }

        public string DatabaseId()
        {
            return this.Inner.DatabaseId;
        }

        public DateTime EarliestRestoreDate()
        {
            return this.Inner.EarliestRestoreDate.GetValueOrDefault();
        }

        public string RequestedServiceObjectiveName()
        {
            return this.Inner.RequestedServiceObjectiveName;
        }

        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks()
        {
            var replicationLinks = this.innerCollection.ListReplicationLinks(
                this.ResourceGroupName, this.SqlServerName(), this.Name);

            IDictionary<string, IReplicationLink> result = new Dictionary<string, IReplicationLink>();
            foreach (var replicationLink in replicationLinks)
            {
                result.Add(replicationLink.Name, new ReplicationLinkImpl(replicationLink, this.innerCollection));
            }

            return new ReadOnlyDictionary<string, IReplicationLink>(result);
        }

        public SqlDatabaseImpl WithCollation(string collation)
        {
            this.Inner.Collation = collation;
            return this;
        }

        public SqlDatabaseImpl WithMode(string createMode)
        {
            this.Inner.CreateMode = createMode;
            return this;
        }

        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages()
        {
            Func<DatabaseMetric, DatabaseMetricImpl> convertor = (databaseMetricInner) => new DatabaseMetricImpl(databaseMetricInner);

            return PagedListConverter.Convert(
                this.innerCollection.ListUsages(
                this.ResourceGroupName,
                this.SqlServerName(),
                this.Name), convertor);
        }

        public string SqlServerName()
        {
            return base.parentName;
        }

        protected async override Task<ISqlDatabase> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SqlDatabaseImpl self = this;
            if (this.elasticPoolCreatableKey != null)
            {
                var sqlElasticPool = (ISqlElasticPool)this.CreatedResource(this.elasticPoolCreatableKey);
                WithExistingElasticPool(sqlElasticPool);
            }
            if (!string.IsNullOrWhiteSpace(this.Inner.ElasticPoolName))
            {
                this.Inner.Edition = string.Empty;
                this.Inner.RequestedServiceObjectiveName = string.Empty;
                this.Inner.RequestedServiceObjectiveId = null;
            }

            var databaseInner = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.SqlServerName(), this.Name, this.Inner);

            SetInner(databaseInner);
            this.elasticPoolCreatableKey = null;

            return this;
        }

        public ITransparentDataEncryption GetTransparentDataEncryption()
        {
            return new TransparentDataEncryptionImpl(
                this.innerCollection.GetTransparentDataEncryptionConfiguration(
                this.ResourceGroupName,
                this.SqlServerName(),
                this.Name), this.innerCollection);
        }

        public override ISqlDatabase Refresh()
        {
            if (this.Inner.UpgradeHint != null)
            {
                this.SetInner(this.innerCollection.Get(this.ResourceGroupName, this.SqlServerName(), this.Name));
            }
            else
            {
                this.SetInner(this.innerCollection.Get(this.ResourceGroupName, this.SqlServerName(), this.Name, "upgradeHint"));
            }

            return this;
        }

        public SqlDatabaseImpl WithNewElasticPool(ICreatable<ISqlElasticPool> sqlElasticPool)
        {
            if (this.elasticPoolCreatableKey == null)
            {
                this.elasticPoolCreatableKey = sqlElasticPool.Key;
                this.AddCreatableDependency(sqlElasticPool as IResourceCreator<IHasId>);
            }
            return this;
        }

        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints()
        {
            Func<RestorePointInner, RestorePointImpl> convertor = (restorePointInner) => new RestorePointImpl(restorePointInner);

            return PagedListConverter.Convert(
                this.innerCollection.ListRestorePoints(this.ResourceGroupName, this.SqlServerName(), this.Name),
                convertor);
        }

        public DateTime CreationDate()
        {
            return this.Inner.CreationDate.GetValueOrDefault();
        }

        public string ServiceLevelObjective()
        {
            return this.Inner.ServiceLevelObjective;
        }

        internal SqlDatabaseImpl(string name, DatabaseInner innerObject, IDatabasesOperations innerCollection)
               : base(name, innerObject)
        {
            this.innerCollection = innerCollection;
        }

        public SqlDatabaseImpl WithoutElasticPool()
        {
            this.Inner.ElasticPoolName = "";
            return this;
        }

        public bool IsDataWarehouse()
        {
            return StringComparer.OrdinalIgnoreCase.Equals(this.Edition(), DatabaseEditions.DataWarehouse);
        }

        public Guid RequestedServiceObjectiveId()
        {
            return this.Inner.RequestedServiceObjectiveId.GetValueOrDefault();
        }

        public IWithCreateMode WithSourceDatabase(string sourceDatabaseId)
        {
            this.Inner.SourceDatabaseId = sourceDatabaseId;
            return this;
        }

        public IWithCreateMode WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            return WithSourceDatabase(sourceDatabase.Id);
        }

        public string Status()
        {
            return this.Inner.Status;
        }

        public IReadOnlyDictionary<string, IServiceTierAdvisor> ListServiceTierAdvisors()
        {
            var serviceTierAdvisorMap = new Dictionary<string, IServiceTierAdvisor>();

            foreach (var serviceTierAdvisorInner
                in this.innerCollection.ListServiceTierAdvisors(this.ResourceGroupName, this.SqlServerName(), this.Name))
            {
                serviceTierAdvisorMap.Add(serviceTierAdvisorInner.Name, new ServiceTierAdvisorImpl(serviceTierAdvisorInner,
                    this.innerCollection));
            }

            return new ReadOnlyDictionary<string, IServiceTierAdvisor>(serviceTierAdvisorMap);
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