// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.GuestConfiguration.Models
{
    /// <summary> Guest configuration is an Azure resource putting guest configuration assignments on the machine. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GuestConfigurationResourceData
    {
        /// <summary> Initializes a new instance of <see cref="GuestConfigurationResourceData"/>. </summary>
        public GuestConfigurationResourceData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="GuestConfigurationResourceData"/>. </summary>
        internal GuestConfigurationResourceData(ResourceIdentifier id, string name, AzureLocation? location, ResourceType? resourceType, SystemData systemData)
        {
            Id = id;
            Name = name;
            Location = location;
            ResourceType = resourceType;
            SystemData = systemData;
        }

        /// <summary> ARM resource id of the guest configuration assignment. </summary>
        [WirePath("id")]
        public ResourceIdentifier Id { get; }
        /// <summary> Name of the guest configuration assignment. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> Region where the VM is located. </summary>
        [WirePath("location")]
        public AzureLocation? Location { get; set; }
        /// <summary> The type of the resource. </summary>
        [WirePath("type")]
        public ResourceType? ResourceType { get; }
        /// <summary> Azure Resource Manager metadata containing createdBy and modifiedBy information. </summary>
        [WirePath("systemData")]
        public SystemData SystemData { get; }
    }
}
