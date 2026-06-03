// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers. Three distinct root causes:
    //   - Merge/Split/Cancel: the new MPG generator renamed payloads to *Request (with
    //     different property types in some cases, e.g. TermDuration TimeSpan?->string,
    //     CustomerId ResourceIdentifier->string). Shims translate GA Content into the
    //     generated Request before forwarding to the new overload.
    //   - Update(BillingSubscriptionData): the new generator emits Update(BillingSubscriptionPatch)
    //     to reflect the PATCH HTTP verb. GA exposed Update(Data); shim transfers Properties +
    //     Tags from Data to Patch then forwards.
    //   - Get(CancellationToken): the new generator added an optional `expand` parameter; explicit
    //     parameterless overload required for binary/source compat with GA call sites.
    public partial class BillingSubscriptionResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingSubscriptionMergeContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingSubscriptionResource>> MergeAsync(WaitUntil waitUntil, BillingSubscriptionMergeContent content, CancellationToken cancellationToken = default)
        {
            var request = new BillingSubscriptionMergeRequest
            {
                Quantity = content?.Quantity,
                TargetBillingSubscriptionName = content?.TargetBillingSubscriptionName,
            };
            return await MergeAsync(waitUntil, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingSubscriptionMergeContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingSubscriptionResource> Merge(WaitUntil waitUntil, BillingSubscriptionMergeContent content, CancellationToken cancellationToken = default)
        {
            var request = new BillingSubscriptionMergeRequest
            {
                Quantity = content?.Quantity,
                TargetBillingSubscriptionName = content?.TargetBillingSubscriptionName,
            };
            return Merge(waitUntil, request, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingSubscriptionSplitContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingSubscriptionResource>> SplitAsync(WaitUntil waitUntil, BillingSubscriptionSplitContent content, CancellationToken cancellationToken = default)
        {
            var request = new BillingSubscriptionSplitRequest
            {
                BillingFrequency = content?.BillingFrequency,
                Quantity = content?.Quantity,
                TargetProductTypeId = content?.TargetProductTypeId,
                TargetSkuId = content?.TargetSkuId,
                TermDuration = content?.TermDuration is null ? null : XmlConvert.ToString(content.TermDuration.Value),
            };
            return await SplitAsync(waitUntil, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingSubscriptionSplitContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingSubscriptionResource> Split(WaitUntil waitUntil, BillingSubscriptionSplitContent content, CancellationToken cancellationToken = default)
        {
            var request = new BillingSubscriptionSplitRequest
            {
                BillingFrequency = content?.BillingFrequency,
                Quantity = content?.Quantity,
                TargetProductTypeId = content?.TargetProductTypeId,
                TargetSkuId = content?.TargetSkuId,
                TermDuration = content?.TermDuration is null ? null : XmlConvert.ToString(content.TermDuration.Value),
            };
            return Split(waitUntil, request, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="CancelSubscriptionContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> CancelAsync(WaitUntil waitUntil, CancelSubscriptionContent content, CancellationToken cancellationToken = default)
        {
            if (content == null)
                throw new System.ArgumentNullException(nameof(content));
            var request = new CancelSubscriptionRequest(content.CancellationReason)
            {
                CustomerId = content.CustomerId?.ToString(),
            };
            return await CancelAsync(waitUntil, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Cancel(WaitUntil waitUntil, CancelSubscriptionContent content, CancellationToken cancellationToken = default)
        {
            if (content == null)
                throw new System.ArgumentNullException(nameof(content));
            var request = new CancelSubscriptionRequest(content.CancellationReason)
            {
                CustomerId = content.CustomerId?.ToString(),
            };
            return Cancel(waitUntil, request, cancellationToken);
        }

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
