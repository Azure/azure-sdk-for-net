// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption
{
    // The wrapper resource class was removed during TypeSpec migration because the new
    // generator no longer emits a resource type for the underlying action operation
    // (getForBillingPeriodByManagementGroup). The operation itself is still available
    // and is now exposed as the extension method
    // ArmClient.GetForBillingPeriodByManagementGroup(ResourceIdentifier scope).
    // Stub retained only to keep the v1.1.0 type signature for source/binary compatibility.
    /// <summary> Obsolete. Use <see cref="ConsumptionExtensions.GetForBillingPeriodByManagementGroup(Azure.ResourceManager.ArmClient, ResourceIdentifier, CancellationToken)"/> instead. </summary>
    [Obsolete("This type is obsolete. Use ArmClient.GetForBillingPeriodByManagementGroup(scope) extension method instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ManagementGroupBillingPeriodConsumptionResource : ArmResource
    {
        /// <summary> Resource type for the corresponding ARM resource id segment shipped by v1.1.0. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Management/managementGroups/providers/Microsoft.Billing/billingPeriods";

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupBillingPeriodConsumptionResource"/> class for mocking. </summary>
        protected ManagementGroupBillingPeriodConsumptionResource()
        {
        }

        /// <summary> Obsolete. Use <see cref="ConsumptionExtensions.GetForBillingPeriodByManagementGroup(Azure.ResourceManager.ArmClient, ResourceIdentifier, CancellationToken)"/> instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionAggregatedCostResult> GetAggregatedCost(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use ArmClient.GetForBillingPeriodByManagementGroup(scope) extension method instead.");
        }

        /// <summary> Obsolete. Use <see cref="ConsumptionExtensions.GetForBillingPeriodByManagementGroupAsync(Azure.ResourceManager.ArmClient, ResourceIdentifier, CancellationToken)"/> instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionAggregatedCostResult>> GetAggregatedCostAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use ArmClient.GetForBillingPeriodByManagementGroupAsync(scope) extension method instead.");
        }
    }
}
