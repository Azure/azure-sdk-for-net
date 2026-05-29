// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingCustomerPolicyResource
    {
        // TODO: codegen bug — resources whose service contract exposes only a PUT (CreateOrUpdate) get no Update/UpdateAsync,
        // but the SDK's tag boilerplate calls Update. Re-expose Update/UpdateAsync as thin wrappers here until the generator
        // emits them. Tracking: see PR for a new generator-fix request to be filed against Azure/azure-sdk-for-net.

        /// <summary>
        /// Update is an alias for CreateOrUpdate, provided to satisfy the auto-generated tag boilerplate
        /// on resources that only expose a PUT (CreateOrUpdate) operation in the service contract.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingCustomerPolicyResource>> UpdateAsync(WaitUntil waitUntil, BillingCustomerPolicyData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update is an alias for CreateOrUpdate, provided to satisfy the auto-generated tag boilerplate
        /// on resources that only expose a PUT (CreateOrUpdate) operation in the service contract.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingCustomerPolicyResource> Update(WaitUntil waitUntil, BillingCustomerPolicyData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, data, cancellationToken);
        }
    }
}
