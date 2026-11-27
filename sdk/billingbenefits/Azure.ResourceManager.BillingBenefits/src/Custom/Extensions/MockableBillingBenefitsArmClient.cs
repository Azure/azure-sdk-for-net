// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits.Models;

namespace Azure.ResourceManager.BillingBenefits.Mocking
{
    // Preserve the beta.5 virtual methods so existing extension-method mocks continue to work.
    public partial class MockableBillingBenefitsArmClient
    {
        /// <inheritdoc cref="GetApplicableMaccsAsync(ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableMaccsAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ApplicableMacc> GetAllAsync(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            return GetApplicableMaccsAsync(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableMaccs(ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableMaccs instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ApplicableMacc> GetAll(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            return GetApplicableMaccs(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableCreditsAsync(ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableCreditsAsync instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CreditResource> GetApplicableAsync(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            return GetApplicableCreditsAsync(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableCredits(ResourceIdentifier, CancellationToken)"/>
        [Obsolete("This method is obsolete and will be removed in a future version. Please use GetApplicableCredits instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CreditResource> GetApplicable(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            return GetApplicableCredits(scope, cancellationToken);
        }
    }
}
