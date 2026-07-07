// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.GuestConfiguration.Models
{
    public static partial class ArmGuestConfigurationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="GuestConfiguration.GuestConfigurationAssignmentData"/>. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="properties"> Properties of the Guest configuration assignment. </param>
        /// <returns> A new <see cref="GuestConfiguration.GuestConfigurationAssignmentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GuestConfigurationAssignmentData GuestConfigurationAssignmentData(ResourceIdentifier id, string name, AzureLocation? location, ResourceType? resourceType, SystemData systemData, GuestConfigurationAssignmentProperties properties)
        {
            return new GuestConfigurationAssignmentData(id, name, location, resourceType, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.GuestConfigurationResourceData"/>. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <returns> A new <see cref="Models.GuestConfigurationResourceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GuestConfigurationResourceData GuestConfigurationResourceData(ResourceIdentifier id = default, string name = default, AzureLocation? location = default, ResourceType? resourceType = default, SystemData systemData = default)
        {
            return new GuestConfigurationResourceData(id, name, location, resourceType, additionalBinaryDataProperties: null);
        }
    }
}
