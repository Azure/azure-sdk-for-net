// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
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
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DatabaseRestoreResourceInfo> GetRestorableMongoDBResources(AzureLocation? restoreLocation = null, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
        {
            Page<DatabaseRestoreResourceInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _restorableMongoDBResourcesClientDiagnostics.CreateScope("RestorableCosmosDBAccountResource.GetRestorableMongoDBResources");
                scope.Start();
                try
                {
                    var response = _restorableMongoDBResourcesRestClient.List(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restoreLocation, restoreTimestampInUtc, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableMongoDBResourceData(x, null)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DatabaseRestoreResourceInfo> GetRestorableMongoDBResourcesAsync(AzureLocation? restoreLocation = null, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DatabaseRestoreResourceInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _restorableMongoDBResourcesClientDiagnostics.CreateScope("RestorableCosmosDBAccountResource.GetRestorableMongoDBResources");
                scope.Start();
                try
                {
                    var response = await _restorableMongoDBResourcesRestClient.ListAsync(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restoreLocation, restoreTimestampInUtc, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableMongoDBResourceData(x, null)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DatabaseRestoreResourceInfo> GetRestorableSqlResourcesAsync(AzureLocation? restoreLocation = null, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DatabaseRestoreResourceInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _restorableSqlResourcesClientDiagnostics.CreateScope("RestorableCosmosDBAccountResource.GetRestorableSqlResources");
                scope.Start();
                try
                {
                    var response = await _restorableSqlResourcesRestClient.ListAsync(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restoreLocation, restoreTimestampInUtc, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableSqlResourceData(x,null)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DatabaseRestoreResourceInfo> GetRestorableSqlResources(AzureLocation? restoreLocation = null, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
        {
            Page<DatabaseRestoreResourceInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _restorableSqlResourcesClientDiagnostics.CreateScope("RestorableCosmosDBAccountResource.GetRestorableSqlResources");
                scope.Start();
                try
                {
                    var response = _restorableSqlResourcesRestClient.List(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restoreLocation, restoreTimestampInUtc, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableSqlResourceData(x, null)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Show the event feed of all mutations done on all the Azure Cosmos DB MongoDB collections under a specific database.  This helps in scenario where container was accidentally deleted.  This API requires &apos;Microsoft.DocumentDB/locations/restorableDatabaseAccounts/.../read&apos; permission
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{instanceId}/restorableMongodbCollections
        /// Operation Id: RestorableMongodbCollections_List
        /// </summary>
        /// <param name="restorableMongoDBDatabaseRid"> The resource ID of the MongoDB database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RestorableMongoDBCollection" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RestorableMongoDBCollection> GetRestorableMongoDBCollectionsAsync(string restorableMongoDBDatabaseRid, CancellationToken cancellationToken)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _restorableMongoDBCollectionsRestClient.CreateListRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restorableMongoDBDatabaseRid, null, null);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => RestorableMongoDBCollection.DeserializeRestorableMongoDBCollection(e), _restorableMongoDBCollectionsClientDiagnostics, Pipeline, "RestorableCosmosDBAccountResource.GetRestorableMongoDBCollections", "value", null, cancellationToken);
        }

        /// <summary>
        /// Show the event feed of all mutations done on all the Azure Cosmos DB MongoDB collections under a specific database.  This helps in scenario where container was accidentally deleted.  This API requires &apos;Microsoft.DocumentDB/locations/restorableDatabaseAccounts/.../read&apos; permission
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{instanceId}/restorableMongodbCollections
        /// Operation Id: RestorableMongodbCollections_List
        /// </summary>
        /// <param name="restorableMongoDBDatabaseRid"> The resource ID of the MongoDB database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RestorableMongoDBCollection" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RestorableMongoDBCollection> GetRestorableMongoDBCollections(string restorableMongoDBDatabaseRid, CancellationToken cancellationToken)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _restorableMongoDBCollectionsRestClient.CreateListRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Name), Guid.Parse(Id.Name), restorableMongoDBDatabaseRid, null, null);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => RestorableMongoDBCollection.DeserializeRestorableMongoDBCollection(e), _restorableMongoDBCollectionsClientDiagnostics, Pipeline, "RestorableCosmosDBAccountResource.GetRestorableMongoDBCollections", "value", null, cancellationToken);
        }

        private static DatabaseRestoreResourceInfo ConvertFromRestorableMongoDBResourceData(RestorableMongoDBResourceData value, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            return new DatabaseRestoreResourceInfo(value.DatabaseName, value.CollectionNames.ToList(), serializedAdditionalRawData);
        }

        private static DatabaseRestoreResourceInfo ConvertFromRestorableSqlResourceData(RestorableSqlResourceData value , IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            return new DatabaseRestoreResourceInfo(value.DatabaseName, value.CollectionNames.ToList(), serializedAdditionalRawData);
        }
    }
}
