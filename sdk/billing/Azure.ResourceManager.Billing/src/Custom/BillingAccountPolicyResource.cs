// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Billing
{
    // Generator tag-helper boilerplate (#58747) calls this.Update/UpdateAsync(WaitUntil,
    // <Data>, CT) on PUT-only resources, but MPG emits CreateOrUpdate for PUT (method
    // name derived from HTTP verb per ARM convention). Alias Update -> CreateOrUpdate so
    // the generated AddTag/SetTags/RemoveTag fallback compiles. Also restores the GA
    // Update API surface that the prior AutoRest SDK exposed.
    public partial class BillingAccountPolicyResource
    {
        /// <summary> Update is an alias for CreateOrUpdate to satisfy generator tag-helper boilerplate (#58747) and preserve the GA API surface. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingAccountPolicyResource>> UpdateAsync(WaitUntil waitUntil, BillingAccountPolicyData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update is an alias for CreateOrUpdate to satisfy generator tag-helper boilerplate (#58747) and preserve the GA API surface. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingAccountPolicyResource> Update(WaitUntil waitUntil, BillingAccountPolicyData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, data, cancellationToken);
        }
    }
}
