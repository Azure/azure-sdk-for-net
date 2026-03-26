// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds CreateOrUpdate overloads that forward to the collection's CreateOrUpdate (PUT)
// to preserve prior GA behavior. The resource's Update sends PATCH which differs from recordings.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountManagementPolicyResource
    {
        // Backward-compatible overload: delegates to collection CreateOrUpdate (PUT) with default name.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<StorageAccountManagementPolicyResource> CreateOrUpdate(WaitUntil waitUntil, StorageAccountManagementPolicyData data, CancellationToken cancellationToken = default)
        {
            var collection = new StorageAccountManagementPolicyCollection(Client, Id.Parent);
            return collection.CreateOrUpdate(waitUntil, ManagementPolicyName.Default, data, cancellationToken);
        }

        // Backward-compatible overload: delegates to collection CreateOrUpdateAsync (PUT) with default name.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<StorageAccountManagementPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, StorageAccountManagementPolicyData data, CancellationToken cancellationToken = default)
        {
            var collection = new StorageAccountManagementPolicyCollection(Client, Id.Parent);
            return collection.CreateOrUpdateAsync(waitUntil, ManagementPolicyName.Default, data, cancellationToken);
        }
    }
}
