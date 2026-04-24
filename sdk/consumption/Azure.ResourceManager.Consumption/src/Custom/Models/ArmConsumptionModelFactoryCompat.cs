// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Consumption.Models
{
    // Backward-compat overloads retained to match shipped v1.1.0 ArmConsumptionModelFactory surface.
    // The discriminator-base types (ConsumptionChargeSummary / ConsumptionReservationRecommendation / ConsumptionUsageDetail)
    // are abstract, so these overloads throw NotSupportedException - callers should use the Legacy/Modern subclass factories instead.
    public static partial class ArmConsumptionModelFactory
    {
        [Obsolete("Use the factory overload for ConsumptionLegacyChargeSummary or ConsumptionModernChargeSummary instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionChargeSummary ConsumptionChargeSummary(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, ETag? etag)
            => throw new NotSupportedException("ConsumptionChargeSummary is abstract; use ConsumptionLegacyChargeSummary/ConsumptionModernChargeSummary factory overloads instead.");

        [Obsolete("Use the ConsumptionCreditSummaryData factory overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionCreditSummary ConsumptionCreditSummary(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CreditBalanceSummary balanceSummary, ConsumptionAmount pendingCreditAdjustments, ConsumptionAmount expiredCredit, ConsumptionAmount pendingEligibleCharges, string creditCurrency, string billingCurrency, ConsumptionReseller reseller, ETag? etag)
            => throw new NotSupportedException("Use ConsumptionCreditSummaryData factory overload instead.");

        [Obsolete("Use the factory overload for ConsumptionLegacyReservationRecommendation or ConsumptionModernReservationRecommendation instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionReservationRecommendation ConsumptionReservationRecommendation(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, AzureLocation? location, string sku, ETag? etag, IReadOnlyDictionary<string, string> tags)
            => throw new NotSupportedException("ConsumptionReservationRecommendation is abstract; use ConsumptionLegacyReservationRecommendation/ConsumptionModernReservationRecommendation factory overloads instead.");

        [Obsolete("Use the ConsumptionTagsResult factory overload that takes etag as string.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionTagsResult ConsumptionTagsResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<ConsumptionTag> tags, string nextLink, string previousLink, ETag? etag)
            => ConsumptionTagsResult(id, name, resourceType, systemData, tags, nextLink, previousLink, etag?.ToString());

        [Obsolete("Use the factory overload for ConsumptionLegacyUsageDetail or ConsumptionModernUsageDetail instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionUsageDetail ConsumptionUsageDetail(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, ETag? etag, IReadOnlyDictionary<string, string> tags)
            => throw new NotSupportedException("ConsumptionUsageDetail is abstract; use ConsumptionLegacyUsageDetail/ConsumptionModernUsageDetail factory overloads instead.");

        [Obsolete("Use the PriceSheetResultData factory overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PriceSheetResult PriceSheetResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<PriceSheetProperties> pricesheets, string nextLink, ConsumptionMeterDetails download, ETag? etag, IReadOnlyDictionary<string, string> tags)
            => throw new NotSupportedException("Use PriceSheetResultData factory overload instead.");
    }
}
