// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Backward-compat shim: In the old Swagger SDK (v1.1.3), MaintenanceConfigurationAssignmentData
    // lived in Azure.ResourceManager.Maintenance.Models namespace. The old autorest.md explicitly
    // marked all ConfigurationAssignment request paths as request-path-is-non-resource, so the old
    // autorest.csharp generator treated it as a regular model (no Resource/Collection classes).
    //
    // In the new TypeSpec SDK, ConfigurationAssignment is defined as ProxyResource<> with
    // @armResourceOperations interfaces, so the MPG generator correctly identifies it as a resource
    // model and places MaintenanceConfigurationAssignmentData in the root namespace
    // (Azure.ResourceManager.Maintenance) with Resource/Collection classes.
    //
    // This class preserves the old Models namespace type for backward compatibility.
    // Implicit conversion operators enable seamless interop between the two types via
    // JSON serialization roundtrip, preserving all data including base class properties.

    /// <summary> Configuration Assignment. </summary>
    public partial class MaintenanceConfigurationAssignmentData : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MaintenanceConfigurationAssignmentData"/>. </summary>
        public MaintenanceConfigurationAssignmentData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MaintenanceConfigurationAssignmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Location of the resource. </param>
        /// <param name="maintenanceConfigurationId"> The maintenance configuration Id. </param>
        /// <param name="resourceId"> The unique resourceId. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MaintenanceConfigurationAssignmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, ResourceIdentifier maintenanceConfigurationId, ResourceIdentifier resourceId, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            MaintenanceConfigurationId = maintenanceConfigurationId;
            ResourceId = resourceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Location of the resource. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> The maintenance configuration Id. </summary>
        public ResourceIdentifier MaintenanceConfigurationId { get; set; }
        /// <summary> The unique resourceId. </summary>
        public ResourceIdentifier ResourceId { get; set; }

        /// <summary>
        /// Converts from root namespace <see cref="Maintenance.MaintenanceConfigurationAssignmentData"/>
        /// to this Models namespace type via JSON serialization roundtrip.
        /// </summary>
        /// <param name="source"> The root namespace instance to convert. </param>
        public static implicit operator MaintenanceConfigurationAssignmentData(Maintenance.MaintenanceConfigurationAssignmentData source)
        {
            if (source == null) return null;
            var data = ModelReaderWriter.Write(source, ModelSerializationExtensions.WireOptions, AzureResourceManagerMaintenanceContext.Default);
            return ModelReaderWriter.Read<MaintenanceConfigurationAssignmentData>(data, ModelSerializationExtensions.WireOptions, AzureResourceManagerMaintenanceContext.Default);
        }

        /// <summary>
        /// Converts from this Models namespace type to root namespace
        /// <see cref="Maintenance.MaintenanceConfigurationAssignmentData"/> via JSON serialization roundtrip.
        /// </summary>
        /// <param name="source"> The Models namespace instance to convert. </param>
        public static implicit operator Maintenance.MaintenanceConfigurationAssignmentData(MaintenanceConfigurationAssignmentData source)
        {
            if (source == null) return null;
            var data = ModelReaderWriter.Write(source, ModelSerializationExtensions.WireOptions, AzureResourceManagerMaintenanceContext.Default);
            return ModelReaderWriter.Read<Maintenance.MaintenanceConfigurationAssignmentData>(data, ModelSerializationExtensions.WireOptions, AzureResourceManagerMaintenanceContext.Default);
        }
    }
}
