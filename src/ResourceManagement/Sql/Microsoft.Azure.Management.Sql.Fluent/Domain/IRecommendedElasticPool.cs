// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Recommended ElasticPool.
    /// </summary>
    public interface IRecommendedElasticPool  :
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool>,
        IWrapper<Models.RecommendedElasticPoolInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <summary>
        /// Gets the list of Azure SQL Databases in this pool. Expanded property.
        /// </summary>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Databases { get; }

        /// <summary>
        /// Gets the maximum DTU for the database.
        /// </summary>
        double DatabaseDtuMax { get; }

        /// <summary>
        /// Gets the DTU for the SQL Azure Recommended Elastic Pool.
        /// </summary>
        double Dtu { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets maximum observed DTU.
        /// </summary>
        double MaxObservedDtu { get; }

        /// <summary>
        /// Fetches list of databases by making call to Azure.
        /// </summary>
        /// <return>List of the databases in recommended elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases();

        /// <summary>
        /// Gets maximum observed storage in megabytes.
        /// </summary>
        double MaxObservedStorageMB { get; }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime ObservationPeriodEnd { get; }

        /// <summary>
        /// Gets the edition of the Azure SQL Recommended Elastic Pool. The
        /// ElasticPoolEditions enumeration contains all the valid editions.
        /// Possible values include: 'Basic', 'Standard', 'Premium'.
        /// </summary>
        string DatabaseEdition { get; }

        /// <summary>
        /// Gets the minimum DTU for the database.
        /// </summary>
        double DatabaseDtuMin { get; }

        /// <summary>
        /// Get a specific database in the recommended database.
        /// </summary>
        /// <param name="databaseName">Name of the database to be fetched.</param>
        /// <return>Information on the database recommended in recommended elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase GetDatabase(string databaseName);

        /// <summary>
        /// Fetches list of metrics information by making call to Azure.
        /// </summary>
        /// <return>List of the databases in recommended elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric> ListMetrics();

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime ObservationPeriodStart { get; }

        /// <summary>
        /// Gets storage size in megabytes.
        /// </summary>
        double StorageMB { get; }
    }
}