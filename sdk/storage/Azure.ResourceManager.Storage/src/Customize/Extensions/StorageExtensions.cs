// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds extension method shims on SubscriptionResource preserving
// prior GA method names and signatures.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Storage
{
    public static partial class StorageExtensions
    {
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
