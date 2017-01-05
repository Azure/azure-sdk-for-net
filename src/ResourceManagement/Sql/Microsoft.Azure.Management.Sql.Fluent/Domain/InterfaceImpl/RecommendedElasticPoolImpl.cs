// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using System.Collections.Generic;
    using System;

    internal partial class RecommendedElasticPoolImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
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

        /// <summary>
        /// Gets the edition of the Azure SQL Recommended Elastic Pool. The
        /// ElasticPoolEditions enumeration contains all the valid editions.
        /// Possible values include: 'Basic', 'Standard', 'Premium'.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.DatabaseEdition
        {
            get
            {
                return this.DatabaseEdition();
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

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.ObservationPeriodStart
        {
            get
            {
                return this.ObservationPeriodStart();
            }
        }

        /// <summary>
        /// Gets the minimum DTU for the database.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.DatabaseDtuMin
        {
            get
            {
                return this.DatabaseDtuMin();
            }
        }

        /// <summary>
        /// Gets the DTU for the SQL Azure Recommended Elastic Pool.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.Dtu
        {
            get
            {
                return this.Dtu();
            }
        }

        /// <summary>
        /// Gets the maximum DTU for the database.
        /// </summary>
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

        /// <summary>
        /// Gets maximum observed storage in megabytes.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.MaxObservedStorageMB
        {
            get
            {
                return this.MaxObservedStorageMB();
            }
        }

        /// <summary>
        /// Gets maximum observed DTU.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.MaxObservedDtu
        {
            get
            {
                return this.MaxObservedDtu();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the list of Azure SQL Databases in this pool. Expanded property.
        /// </summary>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.Databases
        {
            get
            {
                return this.Databases() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>;
            }
        }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.ObservationPeriodEnd
        {
            get
            {
                return this.ObservationPeriodEnd();
            }
        }

        /// <summary>
        /// Gets storage size in megabytes.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool.StorageMB
        {
            get
            {
                return this.StorageMB();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }
    }
}