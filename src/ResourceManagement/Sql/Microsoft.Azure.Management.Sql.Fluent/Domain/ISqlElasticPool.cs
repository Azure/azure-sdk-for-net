// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using SqlElasticPool.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL ElasticPool.
    /// </summary>
    public interface ISqlElasticPool  :
        IIndependentChildResource,
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>,
        IUpdatable<SqlElasticPool.Update.IUpdate>,
        IWrapper<Models.ElasticPoolInner>
    {
        /// <return>The information about elastic pool activities.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> ListActivities();

        /// <return>The maximum DTU any one SQL Azure database can consume.</return>
        int DatabaseDtuMax { get; }

        /// <return>The total shared DTU for the SQL Azure Database Elastic Pool.</return>
        int Dtu { get; }

        /// <return>Name of the SQL Server to which this elastic pool belongs.</return>
        string SqlServerName { get; }

        /// <return>The information about databases in elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases();

        /// <return>The edition of Azure SQL Elastic Pool.</return>
        string Edition { get; }

        /// <return>The creation date of the Azure SQL Elastic Pool.</return>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Deletes the elastic pool from the server.
        /// </summary>
        void Delete();

        /// <return>The information about elastic pool database activities.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities();

        /// <return>The minimum DTU all SQL Azure Databases are guaranteed.</return>
        int DatabaseDtuMin { get; }

        /// <summary>
        /// Gets the specific database in the elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the database to look into.</param>
        /// <return>The information about specific database in elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase GetDatabase(string databaseName);

        /// <return>The storage limit for the SQL Azure Database Elastic Pool in MB.</return>
        int StorageMB { get; }

        /// <return>The state of the Azure SQL Elastic Pool.</return>
        string State { get; }
    }
}