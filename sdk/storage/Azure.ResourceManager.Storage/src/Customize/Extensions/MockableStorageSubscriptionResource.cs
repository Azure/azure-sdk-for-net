// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds subscription-level method overloads matching prior GA surface
// (CheckStorageAccountNameAvailability, GetDeletedAccounts with old signatures).

using System;
using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.Storage.Mocking
{
    public partial class MockableStorageSubscriptionResource
    {
        // Backward-compatible overload: Lists deleted accounts under the subscription.
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DeletedAccountResource> GetDeletedAccountsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.");

        // Backward-compatible overload: Lists deleted accounts under the subscription.
        [Obsolete("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DeletedAccountResource> GetDeletedAccounts(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This overload is no longer supported. Use GetDeletedAccounts() to obtain the DeletedAccountCollection, then access individual deleted accounts by location and name.");
    }
}
