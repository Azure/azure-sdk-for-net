// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingProfilePolicyResource
    {
        // Back-compat shim — NOT a codegen bug. The MPG generator emits CreateOrUpdate
        // for PUT operations per ARM resource conventions; the previous GA SDK exposed
        // the same operation as Update via an AutoRest-side customization. We restore
        // Update/UpdateAsync as thin EditorBrowsable(Never) wrappers so existing callers
        // keep compiling. No spec or generator change can resolve this — the Resource
        // method name is derived from HTTP verb (PUT→CreateOrUpdate, PATCH→Update),
        // not from operation name; @@clientName affects the rest-client method name
        // (CreateUpdateRequest) but not the public Resource method name.

        /// <summary>
        /// Update is an alias for CreateOrUpdate to preserve the GA 12.4.0 API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingProfilePolicyResource>> UpdateAsync(WaitUntil waitUntil, BillingProfilePolicyData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update is an alias for CreateOrUpdate to preserve the GA 12.4.0 API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingProfilePolicyResource> Update(WaitUntil waitUntil, BillingProfilePolicyData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, data, cancellationToken);
        }
    }
}
