// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL Elastic Pool definition to set the maximum DTU for one database.
    /// </summary>
    public interface IWithDatabaseDtuMax 
    {
        /// <summary>
        /// Sets the maximum DTU any one SQL Azure Database can consume.
        /// </summary>
        /// <param name="databaseDtuMax">Maximum DTU any one SQL Azure Database can consume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithDatabaseDtuMax(int databaseDtuMax);
    }

    /// <summary>
    /// The SQL Elastic Pool definition to set the edition for database.
    /// </summary>
    public interface IWithEdition 
    {
        /// <summary>
        /// Sets the edition for the SQL Elastic Pool.
        /// </summary>
        /// <param name="edition">Edition to be set for elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithEdition(string edition);
    }

    /// <summary>
    /// A SQL Server definition with sufficient inputs to create a new
    /// SQL Server in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate>,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDatabaseDtuMin,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDatabaseDtuMax,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDtu,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithStorageCapacity,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithDatabase
    {
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
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithExistingDatabase(string databaseName);

        /// <summary>
        /// Adds the database in the SQL elastic pool.
        /// </summary>
        /// <param name="database">Database instance to be added in SQL elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithExistingDatabase(ISqlDatabase database);

        /// <summary>
        /// Creates a new database in the SQL elastic pool.
        /// </summary>
        /// <param name="databaseName">Name of the new database to be added in the elastic pool.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithNewDatabase(string databaseName);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IBlank,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithEdition,
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate
    {
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithStorageCapacity(int storageMB);
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithDtu(int dtu);
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithCreate WithDatabaseDtuMin(int databaseDtuMin);
    }

    /// <summary>
    /// The first stage of the SQL Server definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IWithEdition
    {
    }
}