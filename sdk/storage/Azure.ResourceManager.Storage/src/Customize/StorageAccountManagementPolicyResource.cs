// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds CreateOrUpdate overloads forwarding to Update to preserve prior GA
// method names. Operation was renamed in TypeSpec spec.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountManagementPolicyResource
    {
        /// <summary> CreateOrUpdate renamed to Update. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StorageAccountManagementPolicyResource> CreateOrUpdate(WaitUntil waitUntil, StorageAccountManagementPolicyData data, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, cancellationToken);

        /// <summary> CreateOrUpdateAsync renamed to UpdateAsync. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<StorageAccountManagementPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, StorageAccountManagementPolicyData data, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, data, cancellationToken);
    }
}
