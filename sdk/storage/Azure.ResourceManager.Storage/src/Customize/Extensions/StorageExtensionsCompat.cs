// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds extension method shims on SubscriptionResource preserving
// prior GA method names and signatures.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public static partial class StorageExtensions
    {
        // Backward-compatible overload: Gets the current usage count and the limit for the resources of the location under the subscription.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<StorageUsage> GetUsagesByLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableStorageSubscriptionResource(subscriptionResource).GetUsagesByLocationAsync(location, cancellationToken);

        // Backward-compatible overload: Gets the current usage count and the limit for the resources of the location under the subscription.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<StorageUsage> GetUsagesByLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableStorageSubscriptionResource(subscriptionResource).GetUsagesByLocation(location, cancellationToken);

        // Backward-compatible overload: Checks that the storage account name is valid and is not already in use.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<StorageAccountNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(this SubscriptionResource subscriptionResource, StorageAccountNameAvailabilityContent content, CancellationToken cancellationToken)
            => await GetMockableStorageSubscriptionResource(subscriptionResource).CheckStorageAccountNameAvailabilityAsync(content, cancellationToken).ConfigureAwait(false);

        // Backward-compatible overload: Checks that the storage account name is valid and is not already in use.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<StorageAccountNameAvailabilityResult> CheckStorageAccountNameAvailability(this SubscriptionResource subscriptionResource, StorageAccountNameAvailabilityContent content, CancellationToken cancellationToken)
            => GetMockableStorageSubscriptionResource(subscriptionResource).CheckStorageAccountNameAvailability(content, cancellationToken);

        // Backward-compatible overload: Lists deleted accounts under the subscription.
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.", error: true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DeletedAccountResource> GetDeletedAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
#pragma warning disable CS0619 // Obsolete member
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccountsAsync(cancellationToken);
#pragma warning restore CS0619
        }

        // Backward-compatible overload: Lists deleted accounts under the subscription.
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.", error: true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DeletedAccountResource> GetDeletedAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
#pragma warning disable CS0619 // Obsolete member
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccounts(cancellationToken);
#pragma warning restore CS0619
        }
    }
}
