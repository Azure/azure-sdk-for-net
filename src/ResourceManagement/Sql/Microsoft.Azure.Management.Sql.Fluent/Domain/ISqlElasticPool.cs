// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using SqlElasticPool.Update;
    using Models;
    using System.Collections.Generic;
    using System;

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

        /// <summary>
        /// Gets the maximum DTU any one SQL Azure database can consume.
        /// </summary>
        int DatabaseDtuMax { get; }

        /// <summary>
        /// Gets The total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        int Dtu { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this elastic pool belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <return>The information about databases in elastic pool.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases();

        /// <summary>
        /// Gets the edition of Azure SQL Elastic Pool.
        /// </summary>
        string Edition { get; }

        /// <summary>
        /// Gets the creation date of the Azure SQL Elastic Pool.
        /// </summary>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Deletes the elastic pool from the server.
        /// </summary>
        void Delete();

        /// <return>The information about elastic pool database activities.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities();

        /// <summary>
        /// Gets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        int DatabaseDtuMin { get; }

        /// <summary>
        /// Gets the specific database in the elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the database to look into.</param>
        /// <return>The information about specific database in elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase GetDatabase(string databaseName);

        /// <summary>
        /// Gets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        int StorageMB { get; }

        /// <summary>
        /// Gets the state of the Azure SQL Elastic Pool.
        /// </summary>
        string State { get; }
    }
}