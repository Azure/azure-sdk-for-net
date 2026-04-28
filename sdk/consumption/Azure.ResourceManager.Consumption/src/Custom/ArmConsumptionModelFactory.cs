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
    public static partial class ArmConsumptionModelFactory
    {
        // we have this customization because the order of properties changed in the consolidation when a model has multiple `allOf` in their swagger definition.
        /// <summary> Initializes a new instance of <see cref="Models.ConsumptionReservationRecommendation"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> Specifies the kind of reservation recommendation. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="sku"> Resource sku. </param>
        /// <returns> A new <see cref="Models.ConsumptionReservationRecommendation"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionReservationRecommendation ConsumptionReservationRecommendation(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, ETag? etag = null, IReadOnlyDictionary<string, string> tags = null, AzureLocation? location = null, string sku = null)
            => ConsumptionReservationRecommendation(id, name, resourceType, systemData, location, sku, etag, tags, kind);

        // we have this customization because the order of properties changed in the consolidation when a model has multiple `allOf` in their swagger definition.
        /// <summary> Initializes a new instance of <see cref="Models.ConsumptionModernReservationRecommendation"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="sku"> Resource sku. </param>
        /// <param name="locationPropertiesLocation"> Resource Location. </param>
        /// <param name="lookBackPeriod"> The number of days of usage to look back for recommendation. </param>
        /// <param name="instanceFlexibilityRatio"> The instance Flexibility Ratio. </param>
        /// <param name="instanceFlexibilityGroup"> The instance Flexibility Group. </param>
        /// <param name="normalizedSize"> The normalized Size. </param>
        /// <param name="recommendedQuantityNormalized"> The recommended Quantity Normalized. </param>
        /// <param name="meterId"> The meter id (GUID). </param>
        /// <param name="term"> RI recommendations in one or three year terms. </param>
        /// <param name="costWithNoReservedInstances"> The total amount of cost without reserved instances. </param>
        /// <param name="recommendedQuantity"> Recommended quality for reserved instances. </param>
        /// <param name="totalCostWithReservedInstances"> The total amount of cost with reserved instances. </param>
        /// <param name="netSavings"> Total estimated savings with reserved instances. </param>
        /// <param name="firstUsageOn"> The usage date for looking back. </param>
        /// <param name="scope"> Shared or single recommendation. </param>
        /// <param name="skuProperties"> List of sku properties. </param>
        /// <param name="skuName"> This is the ARM Sku name. </param>
        /// <returns> A new <see cref="Models.ConsumptionModernReservationRecommendation"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionModernReservationRecommendation ConsumptionModernReservationRecommendation(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag = null, IReadOnlyDictionary<string, string> tags = null, AzureLocation? location = null, string sku = null, string locationPropertiesLocation = null, int? lookBackPeriod = null, float? instanceFlexibilityRatio = null, string instanceFlexibilityGroup = null, string normalizedSize = null, float? recommendedQuantityNormalized = null, Guid? meterId = null, string term = null, ConsumptionAmount costWithNoReservedInstances = null, decimal? recommendedQuantity = null, ConsumptionAmount totalCostWithReservedInstances = null, ConsumptionAmount netSavings = null, DateTimeOffset? firstUsageOn = null, string scope = null, IEnumerable<ConsumptionSkuProperty> skuProperties = null, string skuName = null)
            => ConsumptionModernReservationRecommendation(id, name, resourceType, systemData, location, sku, etag, tags, locationPropertiesLocation, lookBackPeriod, instanceFlexibilityRatio, instanceFlexibilityGroup, normalizedSize, recommendedQuantityNormalized, meterId, term, costWithNoReservedInstances, recommendedQuantity, totalCostWithReservedInstances, netSavings, firstUsageOn, scope, skuProperties, skuName);

        // Backward-compat overloads retained to match shipped v1.1.0 ArmConsumptionModelFactory surface.
        // The discriminator-base types (ConsumptionChargeSummary / ConsumptionReservationRecommendation / ConsumptionUsageDetail)
        // are abstract, so these overloads throw NotSupportedException - callers should use the Legacy/Modern subclass factories instead.

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
            => throw new NotSupportedException("Use the ConsumptionTagsResult overload that takes etag as string instead.");

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
