// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage.Mocking
{
    public partial class MockableStorageSubscriptionResource
    {
        /// <summary> Lists deleted accounts under the subscription. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DeletedAccountResource> GetDeletedAccountsAsync(CancellationToken cancellationToken)
            => GetDeletedAccounts().GetAllAsync(cancellationToken);

        /// <summary> Lists deleted accounts under the subscription. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DeletedAccountResource> GetDeletedAccounts(CancellationToken cancellationToken)
            => GetDeletedAccounts().GetAll(cancellationToken);

        /// <summary> Gets the current usage count and the limit for the resources of the location under the subscription. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageUsage> GetUsagesByLocationAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetByLocationAsync(location.Name, cancellationToken);

        /// <summary> Gets the current usage count and the limit for the resources of the location under the subscription. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageUsage> GetUsagesByLocation(AzureLocation location, CancellationToken cancellationToken)
            => GetByLocation(location.Name, cancellationToken);

        /// <summary> Checks that the storage account name is valid and is not already in use. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<StorageAccountNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(StorageAccountNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks that the storage account name is valid and is not already in use. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StorageAccountNameAvailabilityResult> CheckStorageAccountNameAvailability(StorageAccountNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);
    }
}
