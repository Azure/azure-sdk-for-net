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
    // (PriceSheetResults.get). The operation itself is still available and is exposed via
    // PriceSheetResource (ArmClient.GetPriceSheet(scope)).
    // Stub retained only to keep the v1.1.0 type signature for source/binary compatibility.
    /// <summary> Obsolete. Use <see cref="PriceSheetResource"/> via <c>ArmClient.GetPriceSheet(scope)</c> instead. </summary>
    [Obsolete("This type is obsolete. Use ArmClient.GetPriceSheet(scope) extension method instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SubscriptionBillingPeriodConsumptionResource : ArmResource
    {
        /// <summary> Resource type for the corresponding ARM resource id segment shipped by v1.1.0. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingPeriods";

        /// <summary> Initializes a new instance of the <see cref="SubscriptionBillingPeriodConsumptionResource"/> class for mocking. </summary>
        protected SubscriptionBillingPeriodConsumptionResource()
        {
        }

        /// <summary> Obsolete. Use <see cref="PriceSheetResource"/> via <c>ArmClient.GetPriceSheet(scope)</c> instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PriceSheetResult> GetPriceSheet(string expand = null, string skipToken = null, int? top = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use PriceSheetResource via ArmClient.GetPriceSheet(scope) instead.");
        }

        /// <summary> Obsolete. Use <see cref="PriceSheetResource"/> via <c>ArmClient.GetPriceSheet(scope)</c> instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PriceSheetResult>> GetPriceSheetAsync(string expand = null, string skipToken = null, int? top = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use PriceSheetResource via ArmClient.GetPriceSheet(scope) instead.");
        }
    }
}
