// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Maintenance.Models
{
    /// <summary> A class representing the MaintenanceConfigurationAssignment data model. </summary>
    [CodeGenModel("MaintenanceConfigurationAssignmentData")]
    public partial class MaintenanceConfigurationAssignmentData : ResourceData
    {
        /// <summary> Initializes a new instance of MaintenanceConfigurationAssignmentData. </summary>
        public MaintenanceConfigurationAssignmentData()
        {
            ResourceTypes = new ChangeTrackingList<string>();
            ResourceGroups = new ChangeTrackingList<string>();
            Locations = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of MaintenanceConfigurationAssignmentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Location of the resource. </param>
        /// <param name="maintenanceConfigurationId"> The maintenance configuration Id. </param>
        /// <param name="resourceId"> The unique resourceId. </param>
        /// <param name="resourceTypes"> List of allowed resources. </param>
        /// <param name="resourceGroups"> List of allowed resource groups. </param>
        /// <param name="locations"> List of locations to scope the query to. </param>
        /// <param name="tagSettings"> Tag settings for the VM. </param>
        internal MaintenanceConfigurationAssignmentData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, AzureLocation? location, ResourceIdentifier maintenanceConfigurationId, ResourceIdentifier resourceId, IList<string> resourceTypes, IList<string> resourceGroups, IList<string> locations, TagSettingsProperties tagSettings) : base(id, name, resourceType, systemData)
        {
            Location = location;
            MaintenanceConfigurationId = maintenanceConfigurationId;
            ResourceId = resourceId;
            ResourceTypes = resourceTypes;
            ResourceGroups = resourceGroups;
            Locations = locations;
            TagSettings = tagSettings;
        }

        /// <summary> Location of the resource. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> The maintenance configuration Id. </summary>
        public ResourceIdentifier MaintenanceConfigurationId { get; set; }
        /// <summary> The unique resourceId. </summary>
        public ResourceIdentifier ResourceId { get; set; }
        /// <summary> List of allowed resources. </summary>
        public IList<string> ResourceTypes { get; }
        /// <summary> List of allowed resource groups. </summary>
        public IList<string> ResourceGroups { get; }
        /// <summary> List of locations to scope the query to. </summary>
        public IList<string> Locations { get; }
        /// <summary> Tag settings for the VM. </summary>
        public TagSettingsProperties TagSettings { get; set; }
    }
}
