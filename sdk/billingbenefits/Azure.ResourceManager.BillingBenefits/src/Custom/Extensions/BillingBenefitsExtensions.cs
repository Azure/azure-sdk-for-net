// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits.Models;

namespace Azure.ResourceManager.BillingBenefits
{
    // Preserve the beta.5 extension signatures reported missing by ApiCompat after the operation renames.
    public static partial class BillingBenefitsExtensions
    {
        /// <inheritdoc cref="GetApplicableMaccsAsync(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ApplicableMacc> GetAllAsync(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetAllAsync(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableMaccs(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ApplicableMacc> GetAll(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetAll(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableCreditsAsync(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CreditResource> GetApplicableAsync(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetApplicableAsync(scope, cancellationToken);
        }

        /// <inheritdoc cref="GetApplicableCredits(ArmClient, ResourceIdentifier, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CreditResource> GetApplicable(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableBillingBenefitsArmClient(client).GetApplicable(scope, cancellationToken);
        }
    }
}
