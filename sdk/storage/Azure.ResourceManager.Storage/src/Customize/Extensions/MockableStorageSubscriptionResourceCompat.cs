// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds subscription-level method overloads matching prior GA surface
// (CheckStorageAccountNameAvailability, GetDeletedAccounts with old signatures).

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage.Mocking
{
    public partial class MockableStorageSubscriptionResource
    {
        // Backward-compatible overload: Gets the current usage count and the limit for the resources of the location under the subscription.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<StorageUsage> GetUsagesByLocationAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetByLocationAsync(location.Name, cancellationToken);

        // Backward-compatible overload: Gets the current usage count and the limit for the resources of the location under the subscription.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<StorageUsage> GetUsagesByLocation(AzureLocation location, CancellationToken cancellationToken)
            => GetByLocation(location.Name, cancellationToken);

        // Backward-compatible overload: Checks that the storage account name is valid and is not already in use.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<StorageAccountNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(StorageAccountNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        // Backward-compatible overload: Checks that the storage account name is valid and is not already in use.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StorageAccountNameAvailabilityResult> CheckStorageAccountNameAvailability(StorageAccountNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        // Backward-compatible overload: Lists deleted accounts under the subscription.
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.", error: true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DeletedAccountResource> GetDeletedAccountsAsync(CancellationToken cancellationToken)
            => throw new NotSupportedException("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.");

        // Backward-compatible overload: Lists deleted accounts under the subscription.
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.", error: true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DeletedAccountResource> GetDeletedAccounts(CancellationToken cancellationToken)
            => throw new NotSupportedException("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.");
    }
}
