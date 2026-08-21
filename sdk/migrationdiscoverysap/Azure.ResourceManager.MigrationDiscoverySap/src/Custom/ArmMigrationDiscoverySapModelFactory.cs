// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MigrationDiscoverySap.Models
{
    public static partial class ArmMigrationDiscoverySapModelFactory
    {
        // The TypeSpec generator places the top-level extendedLocation property after the flattened properties.
        // Preserve the previously shipped parameter order for callers that use positional or named arguments.
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
            return SapDiscoverySiteData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                masterSiteId,
                migrateProjectId,
                provisioningState,
                errors,
                legacyExtendedLocation);
        }
    }
}
