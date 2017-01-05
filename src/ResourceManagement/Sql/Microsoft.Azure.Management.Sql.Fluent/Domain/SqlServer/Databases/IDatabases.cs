// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServer.Databases
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to access ElasticPools from the SQL Server.
    /// </summary>
    public interface IDatabases 
    {
        /// <summary>
        /// Gets a particular sql database.
        /// </summary>
        /// <param name="databaseName">Name of the sql database to get.</param>
        /// <return>Returns the database with in the SQL Server.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Get(string databaseName);

        /// <summary>
        /// Creates a new database in SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Returns a stage to specify arguments of the database.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IBlank Define(string databaseName);

        /// <summary>
        /// Delete specified database in the server.
        /// </summary>
        /// <param name="databaseName">Name of the database to delete.</param>
        /// <return>Observable for the delete operation.</return>
        Task DeleteAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns all the databases for the server.
        /// </summary>
        /// <return>List of databases for the server.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> List();

        /// <summary>
        /// Delete specified database in the server.
        /// </summary>
        /// <param name="databaseName">Name of the database to delete.</param>
        void Delete(string databaseName);
    }
}