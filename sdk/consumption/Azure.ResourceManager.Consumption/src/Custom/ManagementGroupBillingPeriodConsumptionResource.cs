// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption
{
    // This type was removed during TypeSpec migration.
    // Stub retained for backward compatibility.
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ManagementGroupBillingPeriodConsumptionResource : ArmResource
    {
        public static readonly ResourceType ResourceType = "Microsoft.Management/managementGroups/providers/Microsoft.Billing/billingPeriods";

        protected ManagementGroupBillingPeriodConsumptionResource()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionAggregatedCostResult> GetAggregatedCost(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionAggregatedCostResult>> GetAggregatedCostAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }
    }
}
