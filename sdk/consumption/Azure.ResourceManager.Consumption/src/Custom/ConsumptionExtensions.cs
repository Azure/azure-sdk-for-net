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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Consumption
{
    // Backward-compatibility extension methods for resource types removed during TypeSpec migration.
    // These stubs preserve the public API surface so existing code that references
    // the old resource types (e.g. GetBillingAccountConsumptionResource) continues to compile.
    // All methods throw NotSupportedException — callers should migrate to the new extension methods.
    public static partial class ConsumptionExtensions
    {
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingAccountConsumptionResource GetBillingAccountConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingProfileConsumptionResource GetBillingProfileConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ReservationConsumptionResource GetReservationConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PriceSheetResult> GetPriceSheet(this SubscriptionResource subscriptionResource, string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use GetPriceSheetResource instead.");
        }

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<PriceSheetResult>> GetPriceSheetAsync(this SubscriptionResource subscriptionResource, string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use GetPriceSheetResource instead.");
        }
    }
}
