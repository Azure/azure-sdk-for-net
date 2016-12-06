// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using System.Collections.Generic;

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
        /// <return>The list of Azure SQL Databases in this pool. Expanded property.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Databases { get; }

        /// <return>The maximum DTU for the database.</return>
        double DatabaseDtuMax { get; }

        /// <return>The DTU for the SQL Azure Recommended Elastic Pool.</return>
        double Dtu { get; }

        /// <return>Name of the SQL Server to which this database belongs.</return>
        string SqlServerName { get; }

        /// <return>Maximum observed DTU.</return>
        double MaxObservedDtu { get; }

        /// <summary>
        /// Fetches list of databases by making call to Azure.
        /// </summary>
        /// <return>List of the databases in recommended elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases();

        /// <return>Maximum observed storage in megabytes.</return>
        double MaxObservedStorageMB { get; }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime ObservationPeriodEnd { get; }

        /// <return>
        /// The edition of the Azure SQL Recommended Elastic Pool. The
        /// ElasticPoolEditions enumeration contains all the valid editions.
        /// Possible values include: 'Basic', 'Standard', 'Premium'.
        /// </return>
        string DatabaseEdition { get; }

        /// <return>The minimum DTU for the database.</return>
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

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime ObservationPeriodStart { get; }

        /// <return>Storage size in megabytes.</return>
        double StorageMB { get; }
    }
}