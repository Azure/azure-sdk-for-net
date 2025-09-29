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
            return ConsumptionReservationRecommendation(id, name, resourceType, systemData, etag, tags, location, sku, kind);
        }
    }
}
