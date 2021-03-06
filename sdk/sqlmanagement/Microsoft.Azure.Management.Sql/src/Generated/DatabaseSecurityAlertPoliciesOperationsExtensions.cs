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
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for DatabaseSecurityAlertPoliciesOperations.
    /// </summary>
    public static partial class DatabaseSecurityAlertPoliciesOperationsExtensions
    {
            /// <summary>
            /// Gets a database's security alert policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the  server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the  database for which the security alert policy is defined.
            /// </param>
            public static DatabaseSecurityAlertPolicy Get(this IDatabaseSecurityAlertPoliciesOperations operations, string resourceGroupName, string serverName, string databaseName)
            {
                return operations.GetAsync(resourceGroupName, serverName, databaseName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a database's security alert policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the  server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the  database for which the security alert policy is defined.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DatabaseSecurityAlertPolicy> GetAsync(this IDatabaseSecurityAlertPoliciesOperations operations, string resourceGroupName, string serverName, string databaseName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates a database's security alert policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the  server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the  database for which the security alert policy is defined.
            /// </param>
            /// <param name='parameters'>
            /// The database security alert policy.
            /// </param>
            public static DatabaseSecurityAlertPolicy CreateOrUpdate(this IDatabaseSecurityAlertPoliciesOperations operations, string resourceGroupName, string serverName, string databaseName, DatabaseSecurityAlertPolicy parameters)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, serverName, databaseName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a database's security alert policy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the  server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the  database for which the security alert policy is defined.
            /// </param>
            /// <param name='parameters'>
            /// The database security alert policy.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DatabaseSecurityAlertPolicy> CreateOrUpdateAsync(this IDatabaseSecurityAlertPoliciesOperations operations, string resourceGroupName, string serverName, string databaseName, DatabaseSecurityAlertPolicy parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of database's security alert policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the  server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the  database for which the security alert policy is defined.
            /// </param>
            public static IPage<DatabaseSecurityAlertPolicy> ListByDatabase(this IDatabaseSecurityAlertPoliciesOperations operations, string resourceGroupName, string serverName, string databaseName)
            {
                return operations.ListByDatabaseAsync(resourceGroupName, serverName, databaseName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of database's security alert policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='serverName'>
            /// The name of the  server.
            /// </param>
            /// <param name='databaseName'>
            /// The name of the  database for which the security alert policy is defined.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DatabaseSecurityAlertPolicy>> ListByDatabaseAsync(this IDatabaseSecurityAlertPoliciesOperations operations, string resourceGroupName, string serverName, string databaseName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByDatabaseWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of database's security alert policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<DatabaseSecurityAlertPolicy> ListByDatabaseNext(this IDatabaseSecurityAlertPoliciesOperations operations, string nextPageLink)
            {
                return operations.ListByDatabaseNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of database's security alert policies.
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
            public static async Task<IPage<DatabaseSecurityAlertPolicy>> ListByDatabaseNextAsync(this IDatabaseSecurityAlertPoliciesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByDatabaseNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
