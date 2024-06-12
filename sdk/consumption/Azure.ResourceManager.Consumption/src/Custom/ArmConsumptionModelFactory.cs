// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        {
            return ConsumptionReservationRecommendation(id, name, resourceType, systemData, kind, location, sku, etag, tags);
        }

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
        {
            return ConsumptionModernReservationRecommendation(
                id,
                name,
                resourceType,
                systemData,
                location,
                sku,
                etag,
                tags,
                locationPropertiesLocation,
                lookBackPeriod,
                instanceFlexibilityRatio,
                instanceFlexibilityGroup,
                normalizedSize,
                recommendedQuantityNormalized,
                meterId,
                term,
                costWithNoReservedInstances,
                recommendedQuantity,
                totalCostWithReservedInstances,
                netSavings,
                firstUsageOn,
                scope,
                skuProperties,
                skuName);
        }
    }
}
