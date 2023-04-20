// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
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
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableMongoDBResourceData(x)), null, response.GetRawResponse());
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
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableMongoDBResourceData(x)), null, response.GetRawResponse());
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
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableSqlResourceData(x)), null, response.GetRawResponse());
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
                    return Page.FromValues(response.Value.Value.Select(x => ConvertFromRestorableSqlResourceData(x)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        private static DatabaseRestoreResourceInfo ConvertFromRestorableMongoDBResourceData(RestorableMongoDBResourceData value)
        {
            return new DatabaseRestoreResourceInfo(value.DatabaseName, value.CollectionNames.ToList());
        }

        private static DatabaseRestoreResourceInfo ConvertFromRestorableSqlResourceData(RestorableSqlResourceData value)
        {
            return new DatabaseRestoreResourceInfo(value.DatabaseName, value.CollectionNames.ToList());
        }
    }
}
