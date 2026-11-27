// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MaccResource> GetAllAsync(SellerResourceListContent content, CancellationToken cancellationToken = default)
        {
            return GetMaccsAsync(content, cancellationToken);
        }

        /// <inheritdoc cref="GetMaccs(SellerResourceListContent, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MaccResource> GetAll(SellerResourceListContent content, CancellationToken cancellationToken = default)
        {
            return GetMaccs(content, cancellationToken);
        }

        /// <inheritdoc cref="ValidateBillingBenefitsSavingsPlanPurchaseAsync(BenefitValidateContent, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BenefitValidateResult>> ValidateAsync(BenefitValidateContent content, CancellationToken cancellationToken = default)
        {
            return ValidateBillingBenefitsSavingsPlanPurchaseAsync(content, cancellationToken);
        }

        /// <inheritdoc cref="ValidateBillingBenefitsSavingsPlanPurchase(BenefitValidateContent, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BenefitValidateResult> Validate(BenefitValidateContent content, CancellationToken cancellationToken = default)
        {
            return ValidateBillingBenefitsSavingsPlanPurchase(content, cancellationToken);
        }
    }
}
