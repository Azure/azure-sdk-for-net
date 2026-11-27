// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.BillingBenefits.Models;

namespace Azure.ResourceManager.BillingBenefits.Mocking
{
    // Preserve the previous virtual methods so existing extension-method mocks continue to work.
    public partial class MockableBillingBenefitsTenantResource
    {
        /// <inheritdoc cref="GetMaccsAsync(SellerResourceListContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetMaccsAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MaccResource> GetAllAsync(SellerResourceListContent content, CancellationToken cancellationToken = default)
        {
            return GetMaccsAsync(content, cancellationToken);
        }

        /// <inheritdoc cref="GetMaccs(SellerResourceListContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetMaccs instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MaccResource> GetAll(SellerResourceListContent content, CancellationToken cancellationToken = default)
        {
            return GetMaccs(content, cancellationToken);
        }

        /// <inheritdoc cref="ValidateBillingBenefitsSavingsPlanPurchaseAsync(BenefitValidateContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use ValidateBillingBenefitsSavingsPlanPurchaseAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BenefitValidateResult>> ValidateAsync(BenefitValidateContent content, CancellationToken cancellationToken = default)
        {
            return ValidateBillingBenefitsSavingsPlanPurchaseAsync(content, cancellationToken);
        }

        /// <inheritdoc cref="ValidateBillingBenefitsSavingsPlanPurchase(BenefitValidateContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use ValidateBillingBenefitsSavingsPlanPurchase instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BenefitValidateResult> Validate(BenefitValidateContent content, CancellationToken cancellationToken = default)
        {
            return ValidateBillingBenefitsSavingsPlanPurchase(content, cancellationToken);
        }
    }
}
