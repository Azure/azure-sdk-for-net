// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscoverySap.Models
{
    // The TypeSpec generator places the top-level extendedLocation property after the flattened properties.
    // When all default, it will be ambiguous.
    // Preserve the previously shipped parameter order for callers that use positional or named arguments.
    [CodeGenSuppress("SapDiscoverySiteData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(string), typeof(SapDiscoveryProvisioningState?), typeof(SapMigrateError), typeof(SapDiscoveryExtendedLocation))]
    public static partial class ArmMigrationDiscoverySapModelFactory
    {
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="legacyExtendedLocation"> The extended location definition. </param>
        /// <param name="masterSiteId"> The master site ID from Azure Migrate. </param>
        /// <param name="migrateProjectId"> The migrate project ID from Azure Migrate. </param>
        /// <param name="provisioningState"> Defines the provisioning states. </param>
        /// <param name="errors"> Indicates any errors on the SAP Migration discovery site resource. </param>
        /// <returns> A new <see cref="MigrationDiscoverySap.SapDiscoverySiteData"/> instance for mocking. </returns>
        public static SapDiscoverySiteData SapDiscoverySiteData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            IDictionary<string, string> tags = default,
            AzureLocation location = default,
            SapDiscoveryExtendedLocation legacyExtendedLocation = default,
            string masterSiteId = default,
            string migrateProjectId = default,
            SapDiscoveryProvisioningState? provisioningState = default,
            SapMigrateError errors = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new SapDiscoverySiteData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                masterSiteId is null && migrateProjectId is null && provisioningState is null && errors is null ? default : new SAPDiscoverySiteProperties(masterSiteId, migrateProjectId, provisioningState, errors, default),
                legacyExtendedLocation,
                default);
        }
    }
}
