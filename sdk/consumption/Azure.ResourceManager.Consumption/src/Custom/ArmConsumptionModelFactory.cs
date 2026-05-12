// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Consumption.Models
{
    // The generator emits a 24-parameter expanded ConsumptionModernReservationRecommendation factory
    // that attempts `new Models.ModernReservationRecommendationProperties(...)`, but that base type is
    // abstract (only ModernSingleScope/ModernSharedScope subclasses are constructible) — see
    // ModernReservationRecommendationProperties.cs:18. Suppress that broken expanded overload and
    // provide a back-compat replacement that delegates to the simpler `properties:` factory.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ConsumptionModernReservationRecommendation", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(AzureLocation?), typeof(string), typeof(ETag?), typeof(IReadOnlyDictionary<string, string>), typeof(string), typeof(int?), typeof(float?), typeof(string), typeof(string), typeof(float?), typeof(Guid?), typeof(string), typeof(ConsumptionAmount), typeof(decimal?), typeof(ConsumptionAmount), typeof(ConsumptionAmount), typeof(DateTimeOffset?), typeof(string), typeof(IEnumerable<ConsumptionSkuProperty>), typeof(string))]
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
        // Replacement for the suppressed generator-emitted 24-parameter expanded overload. Delegates to
        // the simpler `properties:` factory and passes `default` for properties — preserving the shipped
        // v1.1.0 behavior, which also discarded the individual property params.
        /// <summary> Initializes a new instance of <see cref="Models.ConsumptionModernReservationRecommendation"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="sku"> Resource sku. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
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
        public static ConsumptionModernReservationRecommendation ConsumptionModernReservationRecommendation(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, string sku, ETag? etag, IReadOnlyDictionary<string, string> tags, string locationPropertiesLocation, int? lookBackPeriod, float? instanceFlexibilityRatio, string instanceFlexibilityGroup, string normalizedSize, float? recommendedQuantityNormalized, Guid? meterId, string term, ConsumptionAmount costWithNoReservedInstances, decimal? recommendedQuantity, ConsumptionAmount totalCostWithReservedInstances, ConsumptionAmount netSavings, DateTimeOffset? firstUsageOn, string scope, IEnumerable<ConsumptionSkuProperty> skuProperties, string skuName)
            => ConsumptionModernReservationRecommendation(id: id, name: name, resourceType: resourceType, systemData: systemData, location: location, sku: sku, eTag: etag, tags: tags, properties: default);

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
            => ConsumptionModernReservationRecommendation(id: id, name: name, resourceType: resourceType, systemData: systemData, location: location, sku: sku, eTag: etag, tags: tags, properties: default);

        // Backward-compat overloads retained to match shipped v1.1.0 ArmConsumptionModelFactory surface.
        // The discriminator-base types (ConsumptionChargeSummary / ConsumptionReservationRecommendation / ConsumptionUsageDetail)
        // are abstract, so these overloads cannot construct an instance and throw NotSupportedException -
        // callers should use the Legacy/Modern subclass factories instead.

        /// <summary> Obsolete. The discriminator base type is abstract; use the <see cref="T:Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary"/> or <see cref="T:Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary"/> factory overload instead. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> Specifies the kind of charge summary. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <returns> Always throws <see cref="NotSupportedException"/>. </returns>
        [Obsolete("Use the factory overload for ConsumptionLegacyChargeSummary or ConsumptionModernChargeSummary instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionChargeSummary ConsumptionChargeSummary(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, ETag? etag)
            => throw new NotSupportedException("ConsumptionChargeSummary is abstract; use ConsumptionLegacyChargeSummary/ConsumptionModernChargeSummary factory overloads instead.");

        /// <summary> Obsolete. Use the <see cref="ConsumptionCreditSummaryData"/> factory overload instead. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="balanceSummary"> Summary of balances associated with this credit summary. </param>
        /// <param name="pendingCreditAdjustments"> Pending credit adjustments. </param>
        /// <param name="expiredCredit"> Expired credit. </param>
        /// <param name="pendingEligibleCharges"> Pending eligible charges. </param>
        /// <param name="creditCurrency"> The credit currency. </param>
        /// <param name="billingCurrency"> The billing currency. </param>
        /// <param name="reseller"> Credit's reseller. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <returns> Always throws <see cref="NotSupportedException"/>. </returns>
        [Obsolete("Use the ConsumptionCreditSummaryData factory overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionCreditSummary ConsumptionCreditSummary(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CreditBalanceSummary balanceSummary, ConsumptionAmount pendingCreditAdjustments, ConsumptionAmount expiredCredit, ConsumptionAmount pendingEligibleCharges, string creditCurrency, string billingCurrency, ConsumptionReseller reseller, ETag? etag)
            => throw new NotSupportedException("Use ConsumptionCreditSummaryData factory overload instead.");

        /// <summary> Obsolete. The discriminator base type is abstract; use the <see cref="T:Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation"/> or <see cref="T:Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation"/> factory overload instead. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> Specifies the kind of reservation recommendation. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="sku"> Resource sku. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> Always throws <see cref="NotSupportedException"/>. </returns>
        [Obsolete("Use the factory overload for ConsumptionLegacyReservationRecommendation or ConsumptionModernReservationRecommendation instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionReservationRecommendation ConsumptionReservationRecommendation(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, AzureLocation? location, string sku, ETag? etag, IReadOnlyDictionary<string, string> tags)
            => throw new NotSupportedException("ConsumptionReservationRecommendation is abstract; use ConsumptionLegacyReservationRecommendation/ConsumptionModernReservationRecommendation factory overloads instead.");

        /// <summary> Obsolete. Use the <see cref="ConsumptionTagsResult"/> factory overload that takes <paramref name="etag"/> as <see cref="string"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> A list of Tag. </param>
        /// <param name="nextLink"> The link (url) to the next page of results. </param>
        /// <param name="previousLink"> The link (url) to the previous page of results. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <returns> Always throws <see cref="NotSupportedException"/>. </returns>
        [Obsolete("Use the ConsumptionTagsResult factory overload that takes etag as string.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionTagsResult ConsumptionTagsResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<ConsumptionTag> tags, string nextLink, string previousLink, ETag? etag)
            => throw new NotSupportedException("Use the ConsumptionTagsResult overload that takes etag as string instead.");

        /// <summary> Obsolete. The discriminator base type is abstract; use the <see cref="T:Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail"/> or <see cref="T:Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail"/> factory overload instead. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> Specifies the kind of usage details. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> Always throws <see cref="NotSupportedException"/>. </returns>
        [Obsolete("Use the factory overload for ConsumptionLegacyUsageDetail or ConsumptionModernUsageDetail instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConsumptionUsageDetail ConsumptionUsageDetail(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kind, ETag? etag, IReadOnlyDictionary<string, string> tags)
            => throw new NotSupportedException("ConsumptionUsageDetail is abstract; use ConsumptionLegacyUsageDetail/ConsumptionModernUsageDetail factory overloads instead.");

        /// <summary> Obsolete. Use the <see cref="PriceSheetResultData"/> factory overload instead. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="pricesheets"> Price sheet. </param>
        /// <param name="nextLink"> The link (url) to the next page of results. </param>
        /// <param name="download"> Pricesheet download details. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> Always throws <see cref="NotSupportedException"/>. </returns>
        [Obsolete("Use the PriceSheetResultData factory overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PriceSheetResult PriceSheetResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<PriceSheetProperties> pricesheets, string nextLink, ConsumptionMeterDetails download, ETag? etag, IReadOnlyDictionary<string, string> tags)
            => throw new NotSupportedException("Use PriceSheetResultData factory overload instead.");
    }
}
