// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabases.SqlDatabaseCreatable
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// Entry point to SQL FirewallRule management API, which already have the SQLServer specified.
    /// </summary>
    public interface ISqlDatabaseCreatable  :
        ISqlDatabases
    {
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition.IBlank DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string databaseName, Region region);
    }
}