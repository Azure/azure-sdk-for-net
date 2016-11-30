// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using SqlDatabase.Definition;
    using SqlDatabases.SqlDatabaseCreatable;
    using SqlServer.Databases;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of SqlServer.Databases, which enables the creating the database from the SQLServer directly.
    /// </summary>
    internal partial class DatabasesImpl :
        IDatabases
    {
        private string resourceGroupName;
        private string sqlServerName;
        private ISqlDatabaseCreatable databases;
        private Region region;

        internal ISqlDatabases Databases
        {
            get
            {
                return this.databases;
            }
        }

        public ISqlDatabase Get(string databaseName)
        {
            return this.databases.GetBySqlServer(this.resourceGroupName, this.sqlServerName, databaseName);
        }

        public IBlank Define(string databaseName)
        {
            return this.databases.DefinedWithSqlServer(this.resourceGroupName, this.sqlServerName, databaseName, this.region);
        }

        public async Task DeleteAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.databases.DeleteByParentAsync(this.resourceGroupName, this.sqlServerName, databaseName, cancellationToken);
        }

        internal DatabasesImpl(IDatabasesOperations innerCollection, SqlManager manager, string resourceGroupName, string sqlServerName, Region region)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.region = region;
            this.databases = new SqlDatabasesImpl(innerCollection, manager);
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> List()
        {
            return this.databases.ListBySqlServer(this.resourceGroupName, this.sqlServerName);
        }

        public void Delete(string databaseName)
        {
            this.databases.DeleteByParent(this.resourceGroupName, this.sqlServerName, databaseName);
        }
    }
}