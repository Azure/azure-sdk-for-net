// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers. Two distinct root causes:
    //   - Update(BillingSubscriptionData): the new generator emits Update(BillingSubscriptionPatch)
    //     to reflect the PATCH HTTP verb. GA exposed Update(Data); shim transfers Properties +
    //     Tags from Data to Patch then forwards.
    //   - Get(CancellationToken): the new generator added an optional `expand` parameter; explicit
    //     parameterless overload required for binary compat with GA call sites.
    public partial class BillingSubscriptionResource
    {
        /// <summary> Back-compat parameterless Get for GA 1.2.2 callers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BillingSubscriptionResource>> GetAsync(CancellationToken cancellationToken)
        {
            return GetAsync(expand: default, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat parameterless Get for GA 1.2.2 callers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingSubscriptionResource> Get(CancellationToken cancellationToken)
        {
            return Get(expand: default, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat Update overload for GA 1.2.2 callers that pass <see cref="BillingSubscriptionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingSubscriptionResource>> UpdateAsync(WaitUntil waitUntil, BillingSubscriptionData data, CancellationToken cancellationToken)
        {
            if (data == null)
                throw new System.ArgumentNullException(nameof(data));
            var patch = new BillingSubscriptionPatch { Properties = data.Properties };
            if (data.Tags != null)
            {
                foreach (var kv in data.Tags)
                {
                    patch.Tags[kv.Key] = kv.Value;
                }
            }
            return await UpdateAsync(waitUntil, patch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Back-compat Update overload for GA 1.2.2 callers that pass <see cref="BillingSubscriptionData"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingSubscriptionResource> Update(WaitUntil waitUntil, BillingSubscriptionData data, CancellationToken cancellationToken)
        {
            if (data == null)
                throw new System.ArgumentNullException(nameof(data));
            var patch = new BillingSubscriptionPatch { Properties = data.Properties };
            if (data.Tags != null)
            {
                foreach (var kv in data.Tags)
                {
                    patch.Tags[kv.Key] = kv.Value;
                }
            }
            return Update(waitUntil, patch, cancellationToken);
        }
    }
}
