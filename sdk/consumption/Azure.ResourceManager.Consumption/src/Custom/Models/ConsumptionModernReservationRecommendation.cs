// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Consumption.Models
{
    // Restores the v1.x SDK surface for back-compat.
    // The TypeSpec spec uses @discriminator("scope") on ModernReservationRecommendationProperties,
    // which makes it ineligible for @@Legacy.flattenProperty (TCGC's flatten-polymorphism rule).
    // We re-expose the inner Properties members directly on the recommendation as the old
    // AutoRest-generated surface did, by delegating to the (already public) Properties bag.
    // Note: Properties.Location is surfaced as LocationPropertiesLocation to avoid colliding
    // with the inherited ConsumptionReservationRecommendation.Location (AzureLocation?).
    public partial class ConsumptionModernReservationRecommendation
    {
        /// <summary> Resource Location. </summary>
        public string LocationPropertiesLocation => Properties?.Location;

        /// <summary> The number of days of usage to look back for recommendation. </summary>
        public int? LookBackPeriod => Properties?.LookBackPeriod;

        /// <summary> The instance Flexibility Ratio. </summary>
        public float? InstanceFlexibilityRatio => Properties?.InstanceFlexibilityRatio;

        /// <summary> The instance Flexibility Group. </summary>
        public string InstanceFlexibilityGroup => Properties?.InstanceFlexibilityGroup;

        /// <summary> The normalized Size. </summary>
        public string NormalizedSize => Properties?.NormalizedSize;

        /// <summary> The recommended Quantity Normalized. </summary>
        public float? RecommendedQuantityNormalized => Properties?.RecommendedQuantityNormalized;

        /// <summary> The meter id (GUID). </summary>
        public Guid? MeterId => Properties?.MeterId;

        /// <summary> RI recommendations in one or three year terms. </summary>
        public string Term => Properties?.Term;

        /// <summary> The total amount of cost without reserved instances. </summary>
        public ConsumptionAmount CostWithNoReservedInstances => Properties?.CostWithNoReservedInstances;

        /// <summary> Recommended quality for reserved instances. </summary>
        public decimal? RecommendedQuantity => Properties?.RecommendedQuantity;

        /// <summary> The total amount of cost with reserved instances. </summary>
        public ConsumptionAmount TotalCostWithReservedInstances => Properties?.TotalCostWithReservedInstances;

        /// <summary> Total estimated savings with reserved instances. </summary>
        public ConsumptionAmount NetSavings => Properties?.NetSavings;

        /// <summary> The usage date for looking back. </summary>
        public DateTimeOffset? FirstUsageOn => Properties?.FirstUsageOn;

        /// <summary> Shared or single recommendation. </summary>
        public string Scope => Properties?.Scope;

        /// <summary> List of sku properties. </summary>
        public IReadOnlyList<ConsumptionSkuProperty> SkuProperties => Properties?.SkuProperties;

        /// <summary> This is the ARM Sku name. </summary>
        public string SkuName => Properties?.SkuName;
    }
}
