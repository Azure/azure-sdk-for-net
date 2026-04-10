// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmContainerServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContainerService.OSOptionProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="osOptionPropertyList"> The list of OS options. </param>
        /// <returns> A new <see cref="ContainerService.OSOptionProfileData"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileData OSOptionProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<ContainerServiceOSOptionProperty> osOptionPropertyList)
        {
            osOptionPropertyList ??= new List<ContainerServiceOSOptionProperty>();

            return new OSOptionProfileData(
                id,
                name,
                resourceType,
                systemData,
                osOptionPropertyList?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerServiceOSOptionProperty"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        /// <param name="enableFipsImage"> Whether the image is FIPS-enabled. </param>
        /// <returns> A new <see cref="Models.ContainerServiceOSOptionProperty"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceOSOptionProperty ContainerServiceOSOptionProperty(string osType = null, bool enableFipsImage = default)
        {
            return new ContainerServiceOSOptionProperty(osType, enableFipsImage, serializedAdditionalRawData: null);
        }

        // This factory method is retained because the generator no longer emits one for AgentPoolUpgradeProfileData.
        // It is required for backward compatibility with existing callers that depend on this public API surface.
        /// <summary> Initializes a new instance of <see cref="ContainerService.AgentPoolUpgradeProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kubernetesVersion"> The Kubernetes version (major.minor.patch). </param>
        /// <param name="osType"> The operating system type. The default is Linux. </param>
        /// <param name="upgrades"> List of orchestrator types and versions available for upgrade. </param>
        /// <param name="latestNodeImageVersion"> The latest AKS supported node image version. </param>
        /// <returns> A new <see cref="ContainerService.AgentPoolUpgradeProfileData"/> instance for mocking. </returns>
        public static AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kubernetesVersion, ContainerServiceOSType osType, IEnumerable<AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades, string latestNodeImageVersion)
        {
            return new AgentPoolUpgradeProfileData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new AgentPoolUpgradeProfileProperties(kubernetesVersion, osType, (upgrades ?? new List<AgentPoolUpgradeProfilePropertiesUpgradesItem>()).ToList(), new ChangeTrackingList<KubernetesVersionComponents>(), new ChangeTrackingList<AgentPoolRecentlyUsedVersion>(), latestNodeImageVersion, null));
        }
    }
}
