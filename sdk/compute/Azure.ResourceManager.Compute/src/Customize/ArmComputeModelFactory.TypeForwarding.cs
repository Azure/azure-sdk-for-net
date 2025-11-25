// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Compute.Skus.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmComputeModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSku" />. </summary>
        /// <param name="resourceType"> The type of resource the SKU applies to. </param>
        /// <param name="name"> The name of SKU. </param>
        /// <param name="tier"> Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**. </param>
        /// <param name="size"> The Size of the SKU. </param>
        /// <param name="family"> The Family of this particular SKU. </param>
        /// <param name="kind"> The Kind of resources that are supported in this SKU. </param>
        /// <param name="capacity"> Specifies the number of virtual machines in the scale set. </param>
        /// <param name="locations"> The set of locations that the SKU is available. </param>
        /// <param name="locationInfo"> A list of locations and availability zones in those locations where the SKU is available. </param>
        /// <param name="apiVersions"> The api versions that support this SKU. </param>
        /// <param name="costs"> Metadata for retrieving price info. </param>
        /// <param name="capabilities"> A name value pair to describe the capability. </param>
        /// <param name="restrictions"> The restrictions because of which SKU cannot be used. This is empty if there are no restrictions. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSku" /> instance for mocking. </returns>
        public static ComputeResourceSku ComputeResourceSku(string resourceType = null, string name = null, string tier = null, string size = null, string family = null, string kind = null, ComputeResourceSkuCapacity capacity = null, IEnumerable<AzureLocation> locations = null, IEnumerable<ComputeResourceSkuLocationInfo> locationInfo = null, IEnumerable<string> apiVersions = null, IEnumerable<ResourceSkuCosts> costs = null, IEnumerable<ComputeResourceSkuCapabilities> capabilities = null, IEnumerable<ComputeResourceSkuRestrictions> restrictions = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSku(resourceType, name, tier, size, family, kind, capacity, locations, locationInfo, apiVersions, costs, capabilities, restrictions);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity" />. </summary>
        /// <param name="minimum"> The minimum capacity. </param>
        /// <param name="maximum"> The maximum capacity that can be set. </param>
        /// <param name="default"> The default capacity. </param>
        /// <param name="scaleType"> The scale type applicable to the sku. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity" /> instance for mocking. </returns>
        public static ComputeResourceSkuCapacity ComputeResourceSkuCapacity(long? minimum = null, long? maximum = null, long? @default = null, ComputeResourceSkuCapacityScaleType? scaleType = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSkuCapacity(minimum, maximum, @default, scaleType);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo" />. </summary>
        /// <param name="location"> Location of the SKU. </param>
        /// <param name="zones"> List of availability zones where the SKU is supported. </param>
        /// <param name="zoneDetails"> Details of capabilities available to a SKU in specific zones. </param>
        /// <param name="extendedLocations"> The names of extended locations. </param>
        /// <param name="extendedLocationType"> The type of the extended location. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo" /> instance for mocking. </returns>
        public static ComputeResourceSkuLocationInfo ComputeResourceSkuLocationInfo(AzureLocation? location = null, IEnumerable<string> zones = null, IEnumerable<ComputeResourceSkuZoneDetails> zoneDetails = null, IEnumerable<string> extendedLocations = null, ExtendedLocationType? extendedLocationType = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSkuLocationInfo(location, zones, zoneDetails, extendedLocations, extendedLocationType);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ResourceSkuCosts" />. </summary>
        /// <param name="meterId"> Used for querying price from commerce. </param>
        /// <param name="quantity"> The multiplier is needed to extend the base metered cost. </param>
        /// <param name="extendedUnit"> An invariant to show the extended unit. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ResourceSkuCosts" /> instance for mocking. </returns>
        public static ResourceSkuCosts ResourceSkuCosts(string meterId = null, long? quantity = null, string extendedUnit = null)
        {
            return ArmComputeSkusModelFactory.ResourceSkuCosts(meterId, quantity, extendedUnit);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities" />. </summary>
        /// <param name="name"> An invariant to describe the feature. </param>
        /// <param name="value"> An invariant if the feature is measured by quantity. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities" /> instance for mocking. </returns>
        public static ComputeResourceSkuCapabilities ComputeResourceSkuCapabilities(string name = null, string value = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSkuCapabilities(name, value);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions" />. </summary>
        /// <param name="restrictionsType"> The type of restrictions. </param>
        /// <param name="values"> The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted. </param>
        /// <param name="restrictionInfo"> The information about the restriction where the SKU cannot be used. </param>
        /// <param name="reasonCode"> The reason for restriction. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions" /> instance for mocking. </returns>
        public static ComputeResourceSkuRestrictions ComputeResourceSkuRestrictions(ComputeResourceSkuRestrictionsType? restrictionsType = null, IEnumerable<string> values = null, ComputeResourceSkuRestrictionInfo restrictionInfo = null, ComputeResourceSkuRestrictionsReasonCode? reasonCode = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSkuRestrictions(restrictionsType, values, restrictionInfo, reasonCode);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo" />. </summary>
        /// <param name="locations"> Locations where the SKU is restricted. </param>
        /// <param name="zones"> List of availability zones where the SKU is restricted. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo" /> instance for mocking. </returns>
        public static ComputeResourceSkuRestrictionInfo ComputeResourceSkuRestrictionInfo(IEnumerable<AzureLocation> locations = null, IEnumerable<string> zones = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSkuRestrictionInfo(locations, zones);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails" />. </summary>
        /// <param name="name"> The set of zones that the SKU is available in with the specified capabilities. </param>
        /// <param name="capabilities"> A list of capabilities that are available for the SKU in the specified list of zones. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails" /> instance for mocking. </returns>
        public static ComputeResourceSkuZoneDetails ComputeResourceSkuZoneDetails(IEnumerable<string> name = null, IEnumerable<ComputeResourceSkuCapabilities> capabilities = null)
        {
            return ArmComputeSkusModelFactory.ComputeResourceSkuZoneDetails(name, capabilities);
        }
    }
}
