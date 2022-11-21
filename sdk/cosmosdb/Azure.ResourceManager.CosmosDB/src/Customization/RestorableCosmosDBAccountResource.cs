// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary>
    /// A Class representing a RestorableCosmosDBAccount along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="RestorableCosmosDBAccountResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetRestorableCosmosDBAccountResource method.
    /// Otherwise you can get one from its parent resource <see cref="CosmosDBLocationResource" /> using the GetRestorableCosmosDBAccount method.
    /// </summary>
    public partial class RestorableCosmosDBAccountResource : ArmResource
    {
        /// <summary>
        /// Show the event feed of all mutations done on all the Azure Cosmos DB SQL containers under a specific database.  This helps in scenario where container was accidentally deleted.  This API requires &apos;Microsoft.DocumentDB/locations/restorableDatabaseAccounts/.../read&apos; permission
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{instanceId}/restorableSqlContainers
        /// Operation Id: RestorableSqlContainers_List
        /// </summary>
        /// <param name="restorableSqlDatabaseRid"> The resource ID of the SQL database. </param>
        /// <param name="startTime"> The snapshot create timestamp after which snapshots need to be listed. </param>
        /// <param name="endTime"> The snapshot create timestamp before which snapshots need to be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RestorableSqlContainer" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RestorableSqlContainer> GetRestorableSqlContainersAsync(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RestorableSqlContainer>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _restorableSqlContainersClientDiagnostics.CreateScope("RestorableCosmosDBAccountResource.GetRestorableSqlContainers");
                scope.Start();
                try
                {
                    var response = await _restorableSqlContainersRestClient.ListAsync(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restorableSqlDatabaseRid, startTime, endTime, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Show the event feed of all mutations done on all the Azure Cosmos DB SQL containers under a specific database.  This helps in scenario where container was accidentally deleted.  This API requires &apos;Microsoft.DocumentDB/locations/restorableDatabaseAccounts/.../read&apos; permission
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{instanceId}/restorableSqlContainers
        /// Operation Id: RestorableSqlContainers_List
        /// </summary>
        /// <param name="restorableSqlDatabaseRid"> The resource ID of the SQL database. </param>
        /// <param name="startTime"> The snapshot create timestamp after which snapshots need to be listed. </param>
        /// <param name="endTime"> The snapshot create timestamp before which snapshots need to be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RestorableSqlContainer" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RestorableSqlContainer> GetRestorableSqlContainers(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, CancellationToken cancellationToken = default)
        {
            Page<RestorableSqlContainer> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _restorableSqlContainersClientDiagnostics.CreateScope("RestorableCosmosDBAccountResource.GetRestorableSqlContainers");
                scope.Start();
                try
                {
                    var response = _restorableSqlContainersRestClient.List(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restorableSqlDatabaseRid, startTime, endTime, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
