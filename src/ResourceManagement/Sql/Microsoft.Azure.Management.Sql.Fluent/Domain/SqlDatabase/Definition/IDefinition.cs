// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithCreate,
        IWithCollation,
        IWithEdition,
        IWithElasticPoolName,
        IWithSourceDatabaseId,
        IWithCreateMode,
        IWithCreateWithLessOptions,
        IWithExistingDatabase
    {
    }

    /// <summary>
    /// A SQL Database definition with sufficient inputs to create a new
    /// SQL Server in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreateWithLessOptions  :
        ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The SQL Database definition to set the edition for database.
    /// </summary>
    public interface IWithEdition 
    {
        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreate WithEdition(string edition);
    }

    /// <summary>
    /// The first stage of the SQL Server definition.
    /// </summary>
    public interface IBlank  :
        IWithElasticPoolName
    {
    }

    /// <summary>
    /// The SQL Database definition to set the Max Size in Bytes for database.
    /// </summary>
    public interface IWithMaxSizeBytes 
    {
        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreate WithMaxSizeBytes(long maxSizeBytes);
    }

    /// <summary>
    /// The SQL Database definition to set the service level objective.
    /// </summary>
    public interface IWithServiceObjective 
    {
        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreate WithServiceObjective(string serviceLevelObjective);
    }

    /// <summary>
    /// The SQL Database definition to set the elastic pool for database.
    /// </summary>
    public interface IWithElasticPoolName 
    {
        /// <summary>
        /// Specifies database to be created without elastic pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabase WithoutElasticPool();

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabase WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabase WithExistingElasticPool(string elasticPoolName);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithExistingDatabase WithExistingElasticPool(ISqlElasticPool sqlElasticPool);
    }

    /// <summary>
    /// The SQL Database definition to set the create mode for database.
    /// </summary>
    public interface IWithCreateMode 
    {
        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreateWithLessOptions WithMode(string createMode);
    }

    /// <summary>
    /// The stage to decide whether using existing database or not.
    /// </summary>
    public interface IWithExistingDatabase  :
        IWithSourceDatabaseId
    {
        /// <summary>
        /// Sets the creation flow to ask relevant question when source database is not specified.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreate WithoutSourceDatabaseId();
    }

    /// <summary>
    /// The SQL Database definition to set the source database id for database.
    /// </summary>
    public interface IWithSourceDatabaseId 
    {
        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreateMode WithSourceDatabase(string sourceDatabaseId);

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreateMode WithSourceDatabase(ISqlDatabase sourceDatabase);
    }

    /// <summary>
    /// A SQL Database definition with sufficient inputs to create a new
    /// SQL Server in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        IWithMaxSizeBytes,
        IWithServiceObjective,
        IWithCollation,
        IWithEdition,
        IWithCreateWithLessOptions
    {
    }

    /// <summary>
    /// The SQL Database definition to set the collation for database.
    /// </summary>
    public interface IWithCollation 
    {
        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IWithCreate WithCollation(string collation);
    }
}