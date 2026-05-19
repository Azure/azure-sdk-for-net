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
        /// <summary>
        /// Update is an alias for CreateOrUpdate, provided to satisfy the auto-generated tag boilerplate
        /// on resources that only expose a PUT (CreateOrUpdate) operation in the service contract.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingProfilePolicyResource>> UpdateAsync(WaitUntil waitUntil, BillingProfilePolicyData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update is an alias for CreateOrUpdate, provided to satisfy the auto-generated tag boilerplate
        /// on resources that only expose a PUT (CreateOrUpdate) operation in the service contract.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingProfilePolicyResource> Update(WaitUntil waitUntil, BillingProfilePolicyData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, data, cancellationToken);
        }
    }
}
