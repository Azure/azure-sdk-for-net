// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.BillingBenefits
{
    // Preserve previous extension signatures while exposing resource-specific operation names.
    public static partial class BillingBenefitsExtensions
    {
        /// <inheritdoc cref="GetApplicableMaccsAsync(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableMaccsAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ApplicableMacc> GetAllAsync(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetAllAsync(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableMaccs(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableMaccs instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ApplicableMacc> GetAll(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetAll(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableCreditsAsync(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableCreditsAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CreditResource> GetApplicableAsync(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetApplicableAsync(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableCredits(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableCredits instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CreditResource> GetApplicable(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetApplicable(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetMaccsAsync(TenantResource, SellerResourceListContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetMaccsAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MaccResource> GetAllAsync(this TenantResource tenantResource, SellerResourceListContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingBenefitsTenantResource(tenantResource).GetAllAsync(content, cancellationToken);
        }

        /// <inheritdoc cref="GetMaccs(TenantResource, SellerResourceListContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetMaccs instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MaccResource> GetAll(this TenantResource tenantResource, SellerResourceListContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingBenefitsTenantResource(tenantResource).GetAll(content, cancellationToken);
        }

        /// <inheritdoc cref="ValidateBillingBenefitsSavingsPlanPurchaseAsync(TenantResource, BenefitValidateContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use ValidateBillingBenefitsSavingsPlanPurchaseAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<BenefitValidateResult>> ValidateAsync(this TenantResource tenantResource, BenefitValidateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingBenefitsTenantResource(tenantResource).ValidateAsync(content, cancellationToken);
        }

        /// <inheritdoc cref="ValidateBillingBenefitsSavingsPlanPurchase(TenantResource, BenefitValidateContent, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use ValidateBillingBenefitsSavingsPlanPurchase instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BenefitValidateResult> Validate(this TenantResource tenantResource, BenefitValidateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingBenefitsTenantResource(tenantResource).Validate(content, cancellationToken);
        }
    }
}
