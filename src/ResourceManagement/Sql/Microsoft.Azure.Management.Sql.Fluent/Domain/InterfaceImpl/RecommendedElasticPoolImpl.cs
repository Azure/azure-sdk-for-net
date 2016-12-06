// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;

    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    internal partial class RecommendedElasticPoolImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool;
        }

        /// <return>
        /// The edition of the Azure SQL Recommended Elastic Pool. The
        /// ElasticPoolEditions enumeration contains all the valid editions.
        /// Possible values include: 'Basic', 'Standard', 'Premium'.
        /// </return>
        string Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.DatabaseEdition
        {
            get
            {
                return this.DatabaseEdition() as string;
            }
        }

        /// <summary>
        /// Fetches list of databases by making call to Azure.
        /// </summary>
        /// <return>List of the databases in recommended elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.ListDatabases()
        {
            return this.ListDatabases() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>;
        }

        /// <summary>
        /// Fetches list of metrics information by making call to Azure.
        /// </summary>
        /// <return>List of the databases in recommended elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric> Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.ListMetrics()
        {
            return this.ListMetrics() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric>;
        }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.ObservationPeriodStart
        {
            get
            {
                return this.ObservationPeriodStart();
            }
        }

        /// <return>The minimum DTU for the database.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.DatabaseDtuMin
        {
            get
            {
                return this.DatabaseDtuMin();
            }
        }

        /// <return>The DTU for the SQL Azure Recommended Elastic Pool.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.Dtu
        {
            get
            {
                return this.Dtu();
            }
        }

        /// <return>The maximum DTU for the database.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.DatabaseDtuMax
        {
            get
            {
                return this.DatabaseDtuMax();
            }
        }

        /// <summary>
        /// Get a specific database in the recommended database.
        /// </summary>
        /// <param name="databaseName">Name of the database to be fetched.</param>
        /// <return>Information on the database recommended in recommended elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.GetDatabase(string databaseName)
        {
            return this.GetDatabase(databaseName) as Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase;
        }

        /// <return>Maximum observed storage in megabytes.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.MaxObservedStorageMB
        {
            get
            {
                return this.MaxObservedStorageMB();
            }
        }

        /// <return>Maximum observed DTU.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.MaxObservedDtu
        {
            get
            {
                return this.MaxObservedDtu();
            }
        }

        /// <return>Name of the SQL Server to which this database belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>The list of Azure SQL Databases in this pool. Expanded property.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.Databases
        {
            get
            {
                return this.Databases() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>;
            }
        }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.ObservationPeriodEnd
        {
            get
            {
                return this.ObservationPeriodEnd();
            }
        }

        /// <return>Storage size in megabytes.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.StorageMB
        {
            get
            {
                return this.StorageMB();
            }
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
            }
        }

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }
    }
}