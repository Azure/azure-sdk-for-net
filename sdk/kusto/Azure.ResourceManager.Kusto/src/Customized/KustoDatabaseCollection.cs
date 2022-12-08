// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Kusto
{
    /// <summary>
    /// A class representing a collection of <see cref="KustoDatabaseResource" /> and their operations.
    /// Each <see cref="KustoDatabaseResource" /> in the collection will belong to the same instance of <see cref="KustoClusterResource" />.
    /// To get a <see cref="KustoDatabaseCollection" /> instance call the GetKustoDatabases method from an instance of <see cref="KustoClusterResource" />.
    /// </summary>
    public partial class KustoDatabaseCollection : ArmCollection, IEnumerable<KustoDatabaseResource>, IAsyncEnumerable<KustoDatabaseResource>
    {
        /// <summary>
        /// Creates or updates a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}
        /// Operation Id: Databases_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="databaseName"> The name of the database in the Kusto cluster. </param>
        /// <param name="data"> The database parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<KustoDatabaseResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string databaseName, KustoDatabaseData data, CancellationToken cancellationToken) =>
            await CreateOrUpdateAsync(waitUntil, databaseName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates or updates a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Kusto/clusters/{clusterName}/databases/{databaseName}
        /// Operation Id: Databases_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="databaseName"> The name of the database in the Kusto cluster. </param>
        /// <param name="data"> The database parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<KustoDatabaseResource> CreateOrUpdate(WaitUntil waitUntil, string databaseName, KustoDatabaseData data, CancellationToken cancellationToken) =>
            CreateOrUpdate(waitUntil, databaseName, data, null, cancellationToken);
    }
}
