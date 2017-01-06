// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The template for a SQLElasticPool update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IWithDatabaseDtuMax,
        IWithDatabaseDtuMin,
        IWithDtu,
        IWithStorageCapacity,
        IWithDatabase,
        IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>
    {
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the number of shared DTU for elastic pool.
    /// </summary>
    public interface IWithDtu 
    {
        /// <summary>
        /// Sets the total shared DTU for the SQL Azure Database Elastic Pool.
        /// </summary>
        /// <param name="dtu">Total shared DTU for the SQL Azure Database Elastic Pool.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDtu(int dtu);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the storage limit for the SQL Azure Database Elastic Pool in MB.
    /// </summary>
    public interface IWithStorageCapacity 
    {
        /// <summary>
        /// Sets the storage limit for the SQL Azure Database Elastic Pool in MB.
        /// </summary>
        /// <param name="storageMB">Storage limit for the SQL Azure Database Elastic Pool in MB.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithStorageCapacity(int storageMB);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to add the Database in the elastic pool.
    /// </summary>
    public interface IWithDatabase 
    {
        /// <summary>
        /// Adds an existing database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the existing database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithExistingDatabase(string databaseName);

        /// <summary>
        /// Adds the database in the SQL elastic pool.
        /// </summary>
        /// <param name="database">Database instance to be added in SQL elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithExistingDatabase(ISqlDatabase database);

        /// <summary>
        /// Creates a new database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the new database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithNewDatabase(string databaseName);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the minimum DTU for database.
    /// </summary>
    public interface IWithDatabaseDtuMin 
    {
        /// <summary>
        /// Sets the minimum DTU all SQL Azure Databases are guaranteed.
        /// </summary>
        /// <param name="databaseDtuMin">Minimum DTU for all SQL Azure databases.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMin(int databaseDtuMin);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the maximum DTU for one database.
    /// </summary>
    public interface IWithDatabaseDtuMax 
    {
        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update.IUpdate WithDatabaseDtuMax(int databaseDtuMax);
    }
}