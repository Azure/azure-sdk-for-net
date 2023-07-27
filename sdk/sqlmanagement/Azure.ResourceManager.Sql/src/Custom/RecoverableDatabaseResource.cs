// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class RecoverableDatabaseResource
    {
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RecoverableDatabaseResource> Get(CancellationToken cancellationToken = default)
            => Get(null, null, cancellationToken);

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
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RecoverableDatabaseResource> Get(string expand = null, string filter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _recoverableDatabaseClientDiagnostics.CreateScope("RecoverableDatabaseResource.Get");
            scope.Start();
            try
            {
                var response = _recoverableDatabaseRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, cancellationToken);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RecoverableDatabaseResource>> GetAsync(CancellationToken cancellationToken = default)
            => await GetAsync(null, null, cancellationToken).ConfigureAwait(false);

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
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RecoverableDatabaseResource>> GetAsync(string expand, string filter, CancellationToken cancellationToken = default)
        {
            using var scope = _recoverableDatabaseClientDiagnostics.CreateScope("RecoverableDatabaseResource.Get");
            scope.Start();
            try
            {
                var response = await _recoverableDatabaseRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, cancellationToken).ConfigureAwait(false);
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
