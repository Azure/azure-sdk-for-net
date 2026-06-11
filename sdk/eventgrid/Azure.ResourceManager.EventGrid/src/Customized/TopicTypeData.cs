// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("TopicTypeData")]

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Properties of a topic type info. </summary>
    public partial class TopicTypeData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="TopicTypeData"/>. </summary>
        public TopicTypeData()
        {
            SupportedLocations = new ChangeTrackingList<string>();
            SupportedScopesForSource = new ChangeTrackingList<TopicTypeSourceScope>();
            AdditionalEnforcedPermissions = new ChangeTrackingList<TopicTypeAdditionalEnforcedPermission>();
        }

        /// <summary> Initializes a new instance of <see cref="TopicTypeData"/> for deserialization. </summary>
        internal TopicTypeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, TopicTypeProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, name, resourceType, systemData)
        {
            Provider = properties?.Provider;
            DisplayName = properties?.DisplayName;
            Description = properties?.Description;
            ResourceRegionType = properties?.ResourceRegionType;
            ProvisioningState = properties?.ProvisioningState;
            SupportedLocations = properties?.SupportedLocations ?? new ChangeTrackingList<string>();
            SourceResourceFormat = properties?.SourceResourceFormat;
            SupportedScopesForSource = properties?.SupportedScopesForSource ?? new ChangeTrackingList<TopicTypeSourceScope>();
            AreRegionalAndGlobalSourcesSupported = properties?.AreRegionalAndGlobalSourcesSupported;
            AdditionalEnforcedPermissions = properties?.AdditionalEnforcedPermissions ?? new ChangeTrackingList<TopicTypeAdditionalEnforcedPermission>();
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Namespace of the provider of the topic type. </summary>
        [WirePath("properties.provider")]
        public string Provider { get; set; }

        /// <summary> Display Name for the topic type. </summary>
        [WirePath("properties.displayName")]
        public string DisplayName { get; set; }

        /// <summary> Description of the topic type. </summary>
        [WirePath("properties.description")]
        public string Description { get; set; }

        /// <summary> Region type of the resource. </summary>
        [WirePath("properties.resourceRegionType")]
        public EventGridResourceRegionType? ResourceRegionType { get; set; }

        /// <summary> Provisioning state of the topic type. </summary>
        [WirePath("properties.provisioningState")]
        public TopicTypeProvisioningState? ProvisioningState { get; set; }

        /// <summary> List of locations supported by this topic type. </summary>
        [WirePath("properties.supportedLocations")]
        public IList<string> SupportedLocations { get; }

        /// <summary> Source resource format. </summary>
        [WirePath("properties.sourceResourceFormat")]
        public string SourceResourceFormat { get; set; }

        /// <summary> Supported source scopes. </summary>
        [WirePath("properties.supportedScopesForSource")]
        public IList<TopicTypeSourceScope> SupportedScopesForSource { get; }

        /// <summary> Flag to indicate that a topic type can support both regional or global system topics. </summary>
        [WirePath("properties.areRegionalAndGlobalSourcesSupported")]
        public bool? AreRegionalAndGlobalSourcesSupported { get; set; }

        /// <summary> Permissions which are enforced for creating and updating system topics of this this topic type. </summary>
        [WirePath("properties.additionalEnforcedPermissions")]
        public IList<TopicTypeAdditionalEnforcedPermission> AdditionalEnforcedPermissions { get; }
    }
}
