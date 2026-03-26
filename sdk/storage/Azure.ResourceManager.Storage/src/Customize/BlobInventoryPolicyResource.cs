// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds CreateOrUpdate overloads forwarding to Update to preserve prior GA method names.
// Operation was renamed in TypeSpec spec.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobInventoryPolicyResource
    {
        // Backward-compatible overload: CreateOrUpdate renamed to Update.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<BlobInventoryPolicyResource> CreateOrUpdate(WaitUntil waitUntil, BlobInventoryPolicyData data, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, cancellationToken);

        // Backward-compatible overload: CreateOrUpdateAsync renamed to UpdateAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<BlobInventoryPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, BlobInventoryPolicyData data, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, data, cancellationToken);
    }
}
