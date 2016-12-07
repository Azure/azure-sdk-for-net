// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation for RecommendedElasticPool and its parent interfaces.
    /// </summary>
    internal partial class RecommendedElasticPoolImpl :
        Wrapper<Models.RecommendedElasticPoolInner>,
        IRecommendedElasticPool
    {
        private IDatabasesOperations databasesInner;
        private IRecommendedElasticPoolsOperations recommendedElasticPoolsInner;
        private ResourceId resourceId;

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Databases()
        {
            return this.Inner.Databases.Select(databaseInner => (ISqlDatabase)new SqlDatabaseImpl(databaseInner.Name, databaseInner, this.databasesInner)).ToList();
        }

        public double DatabaseDtuMax()
        {
            return this.Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        internal RecommendedElasticPoolImpl(RecommendedElasticPoolInner innerObject,
            IDatabasesOperations databasesInner,
            IRecommendedElasticPoolsOperations recommendedElasticPoolsInner)
            : base(innerObject)
        {
            this.databasesInner = databasesInner;
            this.recommendedElasticPoolsInner = recommendedElasticPoolsInner;
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
        }

        public double Dtu()
        {
            return this.Inner.Dtu.GetValueOrDefault();
        }

        public string SqlServerName()
        {
            return this.resourceId.Parent.Name;
        }

        public double MaxObservedDtu()
        {
            return this.Inner.MaxObservedDtu.GetValueOrDefault();
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases()
        {
            var databases = this.recommendedElasticPoolsInner.ListDatabases(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.Name());

            return databases.Select(databaseInner => (ISqlDatabase)new SqlDatabaseImpl(databaseInner.Name, databaseInner, this.databasesInner)).ToList();
        }

        public IRecommendedElasticPool Refresh()
        {
            this.SetInner(this.recommendedElasticPoolsInner.Get(this.ResourceGroupName(), this.SqlServerName(), this.Name()));
            return this;
        }

        public double MaxObservedStorageMB()
        {
            return this.Inner.MaxObservedStorageMB.GetValueOrDefault();
        }

        public DateTime ObservationPeriodEnd()
        {
            return this.Inner.ObservationPeriodEnd.GetValueOrDefault();
        }

        public string DatabaseEdition()
        {
            return this.Inner.DatabaseEdition;
        }

        public double DatabaseDtuMin()
        {
            return this.Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        public ISqlDatabase GetDatabase(string databaseName)
        {
            DatabaseInner databaseInner = this.recommendedElasticPoolsInner.GetDatabases(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.Name(),
                databaseName);

            return new SqlDatabaseImpl(databaseInner.Name, databaseInner, this.databasesInner);
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric> ListMetrics()
        {
            var metricInner = this.recommendedElasticPoolsInner.ListMetrics(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.Name());
            return metricInner.Select(recommendedElasticPoolMetricInner => (IRecommendedElasticPoolMetric)new RecommendedElasticPoolMetricImpl(recommendedElasticPoolMetricInner)).ToList();
        }

        public DateTime ObservationPeriodStart()
        {
            return this.Inner.ObservationPeriodStart.GetValueOrDefault();
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public double StorageMB()
        {
            return this.Inner.StorageMB.GetValueOrDefault();
        }

        public string Id()
        {
            return this.Inner.Id;
        }
    }
}