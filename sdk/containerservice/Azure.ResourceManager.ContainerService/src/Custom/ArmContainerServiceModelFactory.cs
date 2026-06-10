// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Model factory for models. </summary>
    [CodeGenSuppress("ManagedClusterIngressProfileWebAppRouting", typeof(bool?), typeof(GatewayApiIstioMode?), typeof(IEnumerable<ResourceIdentifier>), typeof(NginxIngressControllerType?), typeof(ContainerServiceUserAssignedIdentity))]
    public static partial class ArmContainerServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterIngressProfileWebAppRouting"/>. </summary>
        /// <param name="isEnabled"> Whether to enable the Application Routing add-on. </param>
        /// <param name="gatewayApiImplementationsIstioMode"> Whether to enable Istio as a Gateway API implementation for managed ingress with App Routing. </param>
        /// <param name="dnsZoneResourceIds"> Resource IDs of the DNS zones to be associated with the Application Routing add-on. Used only when Application Routing add-on is enabled. Public and private DNS zones can be in different resource groups, but all public DNS zones must be in the same resource group and all private DNS zones must be in the same resource group. </param>
        /// <param name="nginxDefaultIngressControllerType"> Ingress type for the default NginxIngressController custom resource. </param>
        /// <param name="identity"> Managed identity of the Application Routing add-on. This is the identity that should be granted permissions, for example, to manage the associated Azure DNS resource and get certificates from Azure Key Vault. See [this overview of the add-on](https://learn.microsoft.com/en-us/azure/aks/web-app-routing?tabs=with-osm) for more instructions. </param>
        /// <returns> A new <see cref="Models.ManagedClusterIngressProfileWebAppRouting"/> instance for mocking. </returns>
        public static ManagedClusterIngressProfileWebAppRouting ManagedClusterIngressProfileWebAppRouting(bool? isEnabled = default, GatewayApiIstioMode? gatewayApiImplementationsIstioMode = default, IEnumerable<ResourceIdentifier> dnsZoneResourceIds = default, NginxIngressControllerType? nginxDefaultIngressControllerType = default, ContainerServiceUserAssignedIdentity identity = default)
        {
            dnsZoneResourceIds ??= new ChangeTrackingList<ResourceIdentifier>();

            return new ManagedClusterIngressProfileWebAppRouting(
                isEnabled,
                gatewayApiImplementationsIstioMode is null ? default : new ManagedClusterWebAppRoutingGatewayAPIImplementations { IstioMode = gatewayApiImplementationsIstioMode },
                (dnsZoneResourceIds ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(),
                nginxDefaultIngressControllerType is null ? default : new ManagedClusterIngressProfileNginx(nginxDefaultIngressControllerType, default),
                identity,
                default);
        }

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
                new AgentPoolUpgradeProfileProperties(kubernetesVersion, osType, (upgrades ?? new List<AgentPoolUpgradeProfilePropertiesUpgradesItem>()).ToList(), new ChangeTrackingList<AgentPoolRecentlyUsedVersion>(), latestNodeImageVersion, null),
                additionalBinaryDataProperties: null);
        }
    }
}
