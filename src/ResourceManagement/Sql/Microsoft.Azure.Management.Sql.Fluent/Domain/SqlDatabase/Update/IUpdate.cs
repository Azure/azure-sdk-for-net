// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL Database definition to set the elastic pool for database.
    /// </summary>
    public interface IWithElasticPoolName 
    {
        /// <summary>
        /// Removes database from it's elastic pool.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IWithEdition WithoutElasticPool();

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate WithExistingElasticPool(string elasticPoolName);

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate WithExistingElasticPool(ISqlElasticPool sqlElasticPool);
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
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate WithEdition(string edition);
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
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate WithServiceObjective(string serviceLevelObjective);
    }

    /// <summary>
    /// The template for a SQLDatabase modifyState operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IWithEdition,
        IWithElasticPoolName,
        IWithMaxSizeBytes,
        IWithServiceObjective,
        IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>
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
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update.IUpdate WithMaxSizeBytes(long maxSizeBytes);
    }
}