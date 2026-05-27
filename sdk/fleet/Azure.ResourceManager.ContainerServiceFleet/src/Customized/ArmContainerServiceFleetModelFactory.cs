// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmContainerServiceFleetModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="eTag"> If eTag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields. </param>
        /// <param name="provisioningState"> The provisioning state of the AutoUpgradeProfile resource. </param>
        /// <param name="updateStrategyId"> The resource id of the UpdateStrategy resource to reference. If not specified, the auto upgrade will run on all clusters which are members of the fleet. </param>
        /// <param name="channel"> Configures how auto-upgrade will be run. </param>
        /// <param name="selectionType"> The node image upgrade to be applied to the target clusters in auto upgrade. </param>
        /// <param name="disabled">
        /// If set to False: the auto upgrade has effect - target managed clusters will be upgraded on schedule.
        /// If set to True: the auto upgrade has no effect - no upgrade will be run on the target managed clusters.
        /// This is a boolean and not an enum because enabled/disabled are all available states of the auto upgrade profile.
        /// By default, this is set to False.
        /// </param>
        /// <param name="autoUpgradeProfileStatus"> The status of the auto upgrade profile. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutoUpgradeProfileData AutoUpgradeProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? eTag, AutoUpgradeProfileProvisioningState? provisioningState, ResourceIdentifier updateStrategyId, ContainerServiceFleetUpgradeChannel? channel, AutoUpgradeNodeImageSelectionType? selectionType, bool? disabled, AutoUpgradeProfileStatus autoUpgradeProfileStatus)
        {
            return new AutoUpgradeProfileData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new AutoUpgradeProfileProperties(provisioningState, updateStrategyId, channel, nodeImageSelection: default, disabled, autoUpgradeProfileStatus, targetKubernetesVersion: default, longTermSupport: default, additionalBinaryDataProperties: default), eTag);
        }
    }
}
