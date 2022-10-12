// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerCollection
    {
        private GetCachedServerNameRestOperations _getCachedServerNameRestClient;

        private GetCachedServerNameRestOperations GetCachedServerNameRestClient => _getCachedServerNameRestClient ??= new GetCachedServerNameRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        /// <summary>
        /// Creates a new server using fast provisioning method.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The required parameters for creating a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerResource>> FastCreateAsync(WaitUntil waitUntil, PostgreSqlFlexibleServerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _postgreSqlFlexibleServerServersClientDiagnostics.CreateScope("PostgreSqlFlexibleServerCollection.FastCreate");
            scope.Start();
            try
            {
                string serverName = null;

                using var cachedServerNameScope = _postgreSqlFlexibleServerServersClientDiagnostics.CreateScope("PostgreSqlFlexibleServerCollection.GetPostgreSqlFlexibleServerCachedServerName");
                cachedServerNameScope.Start();
                try
                {
                    var cachedServerNameRequest = new Models.PostgreSqlFlexibleServerCachedServerNameContent(data.Version ?? Models.PostgreSqlFlexibleServerVersion.Ver12, data.Storage, data.Sku);
                    var cachedServerNameResponse = await GetCachedServerNameRestClient.ExecuteAsync(Id.SubscriptionId, Id.ResourceGroupName, data.Location, cachedServerNameRequest, cancellationToken).ConfigureAwait(false);
                    serverName = cachedServerNameResponse.Value.Name;
                }
                catch (Exception e)
                {
                    cachedServerNameScope.Failed(e);
                    throw;
                }

                using var serverScope = _postgreSqlFlexibleServerServersClientDiagnostics.CreateScope("PostgreSqlFlexibleServerCollection.CreateOrUpdate");
                serverScope.Start();
                try
                {
                    var serverResponse = await _postgreSqlFlexibleServerServersRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, serverName, data, cancellationToken).ConfigureAwait(false);
                    var serverOperation = new FlexibleServersArmOperation<PostgreSqlFlexibleServerResource>(new PostgreSqlFlexibleServerOperationSource(Client), _postgreSqlFlexibleServerServersClientDiagnostics, Pipeline, _postgreSqlFlexibleServerServersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, serverName, data).Request, serverResponse, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        await serverOperation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    return serverOperation;
                }
                catch (Exception e)
                {
                    serverScope.Failed(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new server using fast provisioning method.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The required parameters for creating a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<PostgreSqlFlexibleServerResource> FastCreate(WaitUntil waitUntil, PostgreSqlFlexibleServerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _postgreSqlFlexibleServerServersClientDiagnostics.CreateScope("PostgreSqlFlexibleServerCollection.FastCreate");
            scope.Start();
            try
            {
                string serverName = null;

                using var cachedServerNameScope = _postgreSqlFlexibleServerServersClientDiagnostics.CreateScope("PostgreSqlFlexibleServerCollection.GetPostgreSqlFlexibleServerCachedServerName");
                cachedServerNameScope.Start();
                try
                {
                    var cachedServerNameRequest = new Models.PostgreSqlFlexibleServerCachedServerNameContent(data.Version ?? Models.PostgreSqlFlexibleServerVersion.Ver12, data.Storage, data.Sku);
                    var cachedServerNameResponse = GetCachedServerNameRestClient.Execute(Id.SubscriptionId, Id.ResourceGroupName, data.Location, cachedServerNameRequest, cancellationToken);
                    serverName = cachedServerNameResponse.Value.Name;
                }
                catch (Exception e)
                {
                    cachedServerNameScope.Failed(e);
                    throw;
                }

                using var serverScope = _postgreSqlFlexibleServerServersClientDiagnostics.CreateScope("PostgreSqlFlexibleServerCollection.CreateOrUpdate");
                serverScope.Start();
                try
                {
                    var serverResponse = _postgreSqlFlexibleServerServersRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, serverName, data, cancellationToken);
                    var serverOperation = new FlexibleServersArmOperation<PostgreSqlFlexibleServerResource>(new PostgreSqlFlexibleServerOperationSource(Client), _postgreSqlFlexibleServerServersClientDiagnostics, Pipeline, _postgreSqlFlexibleServerServersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, serverName, data).Request, serverResponse, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        serverOperation.WaitForCompletion(cancellationToken);
                    return serverOperation;
                }
                catch (Exception e)
                {
                    serverScope.Failed(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
