// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Backward-compat ModelFactory overload: The old AutoRest SDK (v1.1.3) had a
    // MaintenanceConfigurationAssignmentData factory method with 7 optional params
    // (id, name, resourceType, systemData, location, maintenanceConfigurationId, resourceId)
    // returning Models.MaintenanceConfigurationAssignmentData. The new TypeSpec-generated
    // primary method has 8 params in different order (adds filter) and returns the root
    // namespace type. ApiCompat requires the old 7-param overload to exist with the old
    // return type and parameter order.
    public static partial class ArmMaintenanceModelFactory
    {
        /// <summary> Backward-compat overload matching v1.1.3 API surface for MaintenanceConfigurationAssignmentData. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="location"> Location of the resource. </param>
        /// <param name="maintenanceConfigurationId"> The maintenance configuration Id. </param>
        /// <param name="resourceId"> The unique resourceId. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MaintenanceConfigurationAssignmentData MaintenanceConfigurationAssignmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, ResourceIdentifier maintenanceConfigurationId = null, ResourceIdentifier resourceId = null)
        {
            return MaintenanceConfigurationAssignmentData(id, name, resourceType, systemData, maintenanceConfigurationId, resourceId, filter: default, location);
        }
    }
}
