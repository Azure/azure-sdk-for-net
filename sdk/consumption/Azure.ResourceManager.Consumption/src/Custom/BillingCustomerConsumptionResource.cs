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
    /// <summary>
    /// Obsolete backward-compatibility stub for the billing-customer scoped consumption resource that
    /// existed in the v1.1.0 surface. The TypeSpec migration replaced this wrapper resource with
    /// scope-based extension methods on <see cref="ArmClient"/>; this type now throws on every member
    /// and is hidden from IntelliSense. Use <c>ArmClient.GetConsumptionLotSummaries(scope, filter)</c> instead.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BillingCustomerConsumptionResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts/customers";

        /// <summary> Initializes a new instance of the <see cref="BillingCustomerConsumptionResource"/> class for mocking. </summary>
        protected BillingCustomerConsumptionResource()
        {
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionLotSummaries(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionLotSummary> GetLots(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionLotSummaries(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionLotSummariesAsync(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionLotSummary> GetLotsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionLotSummariesAsync(scope, filter) instead.");
        }
    }
}
