// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Backward-compat ModelFactory overloads: The old AutoRest SDK (v1.1.3) had
    // ModelFactory methods with optional parameters (= null / = default). The TypeSpec
    // MPG generator produces compat overloads with positional params (no defaults), which
    // ApiCompat treats as different due to [Optional] attribute differences.
    //
    // MaintenanceConfigurationData: The old API had (id, name, resourceType, systemData, tags,
    // location, @namespace, extensionProperties, maintenanceScope, visibility, startOn, expireOn,
    // duration, timeZone, recurEvery) — all optional, tags at position 5, no installPatches param.
    // The new primary method reorders params (tags last) and adds installPatches. The generated
    // compat overload has the old param order but uses positional (non-optional) params.
    // We suppress it and replace with optional-params version to match the old API exactly.
    //
    // MaintenanceConfigurationAssignmentData: The old API had (id, name, resourceType, systemData,
    // location, maintenanceConfigurationId, resourceId) — 7 optional params, location at position 5.
    // The new primary method has 8 params in different order (maintenanceConfigurationId, resourceId,
    // filter, location). We add a compat overload with the old 7-param order.
    // Note: The return type namespace changed from .Models to root — this is an unavoidable break
    // because [CodeGenType] cannot move ResourceData types between namespaces.
    [CodeGenSuppress("MaintenanceConfigurationData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(IDictionary<string, string>), typeof(MaintenanceScope?), typeof(MaintenanceConfigurationVisibility?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(TimeSpan?), typeof(string), typeof(string))]
    public static partial class ArmMaintenanceModelFactory
    {
        /// <summary> Backward-compat overload matching v1.1.3 API surface. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="namespace"> Gets or sets namespace of the resource. </param>
        /// <param name="extensionProperties"> Gets or sets extensionProperties of the maintenanceConfiguration. </param>
        /// <param name="maintenanceScope"> Gets or sets maintenanceScope of the configuration. </param>
        /// <param name="visibility"> Gets or sets the visibility of the configuration. </param>
        /// <param name="startOn"> Effective start date of the maintenance window in YYYY-MM-DD hh:mm format. </param>
        /// <param name="expireOn"> Effective expiration date of the maintenance window in YYYY-MM-DD hh:mm format. </param>
        /// <param name="duration"> Duration of the maintenance window in HH:mm format. </param>
        /// <param name="timeZone"> Name of the timezone. </param>
        /// <param name="recurEvery"> Rate at which a Maintenance window is expected to recur. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MaintenanceConfigurationData MaintenanceConfigurationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string @namespace = null, IDictionary<string, string> extensionProperties = null, MaintenanceScope? maintenanceScope = null, MaintenanceConfigurationVisibility? visibility = null, DateTimeOffset? startOn = null, DateTimeOffset? expireOn = null, TimeSpan? duration = null, string timeZone = null, string recurEvery = null)
        {
            return MaintenanceConfigurationData(id, name, resourceType, systemData, location, @namespace, extensionProperties, maintenanceScope, visibility, installPatches: default, startOn, expireOn, duration, timeZone, recurEvery, tags);
        }

        /// <summary> Backward-compat overload matching v1.1.3 API surface for MaintenanceConfigurationAssignmentData. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="location"> Location of the resource. </param>
        /// <param name="maintenanceConfigurationId"> The maintenance configuration Id. </param>
        /// <param name="resourceId"> The unique resourceId. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MaintenanceConfigurationAssignmentData MaintenanceConfigurationAssignmentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = null, ResourceIdentifier maintenanceConfigurationId = null, ResourceIdentifier resourceId = null)
        {
            return MaintenanceConfigurationAssignmentData(id, name, resourceType, systemData, maintenanceConfigurationId, resourceId, filter: default, location);
        }
    }
}
