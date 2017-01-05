// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServer.ElasticPools
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to access ElasticPools from the SQL Server.
    /// </summary>
    public interface IElasticPools 
    {
        /// <summary>
        /// Gets a particular elastic pool.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to get.</param>
        /// <return>Returns the elastic pool with in the SQL Server.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Get(string elasticPoolName);

        /// <summary>
        /// Creates a new elastic pool in SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <return>Returns a stage to specify arguments of the elastic pool.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition.IBlank Define(string elasticPoolName);

        /// <summary>
        /// Delete specified elastic pool in the server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to delete.</param>
        /// <return>Observable for the delete operation.</return>
        Task DeleteAsync(string elasticPoolName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns all the elastic pools for the server.
        /// </summary>
        /// <return>List of elastic pools for the server.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> List();

        /// <summary>
        /// Delete specified elastic pool in the server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to delete.</param>
        void Delete(string elasticPoolName);
    }
}