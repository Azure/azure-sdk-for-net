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
        /// <summary> Lists deleted accounts under the subscription. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DeletedAccountResource> GetDeletedAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS0618 // Obsolete member
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccountsAsync(cancellationToken);
#pragma warning restore CS0618
        }

        // Backward-compatible overload: Lists deleted accounts under the subscription.
        /// <summary> Lists deleted accounts under the subscription. </summary>
        /// <param name="subscriptionResource"> The subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DeletedAccountResource> GetDeletedAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS0618 // Obsolete member
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccounts(cancellationToken);
#pragma warning restore CS0618
        }
    }
}
