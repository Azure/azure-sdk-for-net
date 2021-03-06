// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ManagedDatabaseTablesOperations.
    /// </summary>
    public static partial class ManagedDatabaseTablesOperationsExtensions
    {
            /// <summary>
            /// List managed database tables
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='managedInstanceName'>
            /// The name of the managed instance.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the database.
            /// </param>
            /// <param name='schemaName'>
            /// The name of the schema.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IPage<DatabaseTable> ListBySchema(this IManagedDatabaseTablesOperations operations, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, ODataQuery<DatabaseTable> odataQuery = default(ODataQuery<DatabaseTable>))
            {
                return operations.ListBySchemaAsync(resourceGroupName, managedInstanceName, databaseName, schemaName, odataQuery).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List managed database tables
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='managedInstanceName'>
            /// The name of the managed instance.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the database.
            /// </param>
            /// <param name='schemaName'>
            /// The name of the schema.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DatabaseTable>> ListBySchemaAsync(this IManagedDatabaseTablesOperations operations, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, ODataQuery<DatabaseTable> odataQuery = default(ODataQuery<DatabaseTable>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySchemaWithHttpMessagesAsync(resourceGroupName, managedInstanceName, databaseName, schemaName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get managed database table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='managedInstanceName'>
            /// The name of the managed instance.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the database.
            /// </param>
            /// <param name='schemaName'>
            /// The name of the schema.
            /// </param>
            /// <param name='tableName'>
            /// The name of the table.
            /// </param>
            public static DatabaseTable Get(this IManagedDatabaseTablesOperations operations, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName)
            {
                return operations.GetAsync(resourceGroupName, managedInstanceName, databaseName, schemaName, tableName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get managed database table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='managedInstanceName'>
            /// The name of the managed instance.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the database.
            /// </param>
            /// <param name='schemaName'>
            /// The name of the schema.
            /// </param>
            /// <param name='tableName'>
            /// The name of the table.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DatabaseTable> GetAsync(this IManagedDatabaseTablesOperations operations, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, managedInstanceName, databaseName, schemaName, tableName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List managed database tables
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<DatabaseTable> ListBySchemaNext(this IManagedDatabaseTablesOperations operations, string nextPageLink)
            {
                return operations.ListBySchemaNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List managed database tables
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DatabaseTable>> ListBySchemaNextAsync(this IManagedDatabaseTablesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySchemaNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
