// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class RecoverableDatabaseCollection
    {
        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<bool> Exists(string databaseName, CancellationToken cancellationToken = default)
            => Exists(databaseName, null, null, cancellationToken);

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<bool> Exists(string databaseName, string expand, string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _recoverableDatabaseClientDiagnostics.CreateScope("RecoverableDatabaseCollection.Exists");
            scope.Start();
            try
            {
                var response = _recoverableDatabaseRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, expand, filter, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string databaseName, CancellationToken cancellationToken = default)
            => await ExistsAsync(databaseName, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string databaseName, string expand, string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _recoverableDatabaseClientDiagnostics.CreateScope("RecoverableDatabaseCollection.Exists");
            scope.Start();
            try
            {
                var response = await _recoverableDatabaseRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, expand, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a recoverable database, which is a resource representing a database's geo backup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<RecoverableDatabaseResource> Get(string databaseName, CancellationToken cancellationToken = default)
            => Get(databaseName, null, null, cancellationToken);

        /// <summary>
        /// Gets a recoverable database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<RecoverableDatabaseResource> Get(string databaseName, string expand, string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _recoverableDatabaseClientDiagnostics.CreateScope("RecoverableDatabaseCollection.Get");
            scope.Start();
            try
            {
                var response = _recoverableDatabaseRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, expand, filter, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecoverableDatabaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a recoverable database, which is a resource representing a database's geo backup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<RecoverableDatabaseResource>> GetAsync(string databaseName, CancellationToken cancellationToken = default)
            => await GetAsync(databaseName, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a recoverable database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<RecoverableDatabaseResource>> GetAsync(string databaseName, string expand, string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _recoverableDatabaseClientDiagnostics.CreateScope("RecoverableDatabaseCollection.Get");
            scope.Start();
            try
            {
                var response = await _recoverableDatabaseRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, expand, filter, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecoverableDatabaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
