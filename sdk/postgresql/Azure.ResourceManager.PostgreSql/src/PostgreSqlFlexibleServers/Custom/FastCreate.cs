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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerCollection
    {
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
                var rg = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));

                var cachedServerNameRequest = new Models.PostgreSqlFlexibleServerCachedServerNameContent(data.Version ?? Models.PostgreSqlFlexibleServerVersion.Ver12, data.Storage, data.Sku);
                var cachedServerNameResponse = await rg.GetPostgreSqlFlexibleServerCachedServerNameAsync(data.Location, cachedServerNameRequest, cancellationToken).ConfigureAwait(false);
                var serverName = cachedServerNameResponse.Value.Name;

                return await CreateOrUpdateAsync(waitUntil, serverName, data, cancellationToken).ConfigureAwait(false);
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
                var rg = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));

                var cachedServerNameRequest = new Models.PostgreSqlFlexibleServerCachedServerNameContent(data.Version ?? Models.PostgreSqlFlexibleServerVersion.Ver12, data.Storage, data.Sku);
                var cachedServerNameResponse = rg.GetPostgreSqlFlexibleServerCachedServerName(data.Location, cachedServerNameRequest, cancellationToken);
                var serverName = cachedServerNameResponse.Value.Name;

                return CreateOrUpdate(waitUntil, serverName, data, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
