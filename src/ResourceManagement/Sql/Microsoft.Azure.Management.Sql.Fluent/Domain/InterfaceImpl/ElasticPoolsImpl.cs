// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPools.SqlElasticPoolsCreatable;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.ElasticPools;
    using System.Collections.Generic;

    internal partial class ElasticPoolsImpl 
    {
        /// <summary>
        /// Creates a new elastic pool in SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <return>Returns a stage to specify arguments of the elastic pool.</return>
        SqlElasticPool.Definition.IBlank SqlServer.ElasticPools.IElasticPools.Define(string elasticPoolName)
        {
            return this.Define(elasticPoolName) as SqlElasticPool.Definition.IBlank;
        }

        /// <summary>
        /// Delete specified elastic pool in the server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to delete.</param>
        void SqlServer.ElasticPools.IElasticPools.Delete(string elasticPoolName)
        {
 
            this.Delete(elasticPoolName);
        }

        /// <summary>
        /// Delete specified elastic pool in the server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to delete.</param>
        /// <return>Observable for the delete operation.</return>
        async Task SqlServer.ElasticPools.IElasticPools.DeleteAsync(string elasticPoolName, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(elasticPoolName, cancellationToken);
        }

        /// <summary>
        /// Returns all the elastic pools for the server.
        /// </summary>
        /// <return>List of elastic pools for the server.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> SqlServer.ElasticPools.IElasticPools.List()
        {
            return this.List() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>;
        }

        /// <summary>
        /// Gets a particular elastic pool.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to get.</param>
        /// <return>Returns the elastic pool with in the SQL Server.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool SqlServer.ElasticPools.IElasticPools.Get(string elasticPoolName)
        {
            return this.Get(elasticPoolName) as Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool;
        }
    }
}