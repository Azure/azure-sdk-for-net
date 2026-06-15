// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customizations are intentionally retained for backward compatibility.
// They re-expose the 1.5.0 model-factory signatures that the current generator no longer emits,
// delegating to the current generated factory methods.
namespace Azure.ResourceManager.ContainerService.Models
{
    public static partial class ArmContainerServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContainerService.AgentPoolUpgradeProfileData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.AgentPoolUpgradeProfileData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kubernetesVersion, ContainerServiceOSType osType, IEnumerable<AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades, string latestNodeImageVersion)
        {
            return AgentPoolUpgradeProfileData(id, name, resourceType, systemData, kubernetesVersion, osType, upgrades, null, latestNodeImageVersion);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceAgentPoolData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.ContainerServiceAgentPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceAgentPoolData ContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ETag? eTag, int? count, string vmSize, int? osDiskSizeInGB, ContainerServiceOSDiskType? osDiskType, KubeletDiskType? kubeletDiskType, WorkloadRuntime? workloadRuntime, string messageOfTheDay, Azure.Core.ResourceIdentifier vnetSubnetId, Azure.Core.ResourceIdentifier podSubnetId, PodIPAllocationMode? podIPAllocationMode, int? maxPods, ContainerServiceOSType? osType, ContainerServiceOSSku? osSku, int? maxCount, int? minCount, bool? isAutoScalingEnabled, ScaleDownMode? scaleDownMode, AgentPoolType? agentPoolType, AgentPoolMode? mode, string orchestratorVersion, string currentOrchestratorVersion, string nodeImageVersion, AgentPoolUpgradeSettings upgradeSettings, string provisioningState, IEnumerable<string> availabilityZones, bool? isNodePublicIpEnabled, Azure.Core.ResourceIdentifier nodePublicIPPrefixId, ScaleSetPriority? scaleSetPriority, ScaleSetEvictionPolicy? scaleSetEvictionPolicy, float? spotMaxPrice, IDictionary<string, string> tags, IDictionary<string, string> nodeLabels, IEnumerable<string> nodeTaints, Azure.Core.ResourceIdentifier proximityPlacementGroupId, KubeletConfig kubeletConfig, LinuxOSConfig linuxOSConfig, bool? isEncryptionAtHostEnabled, bool? isUltraSsdEnabled, bool? isFipsEnabled, GpuInstanceProfile? gpuInstanceProfile, Azure.Core.ResourceIdentifier capacityReservationGroupId, Azure.Core.ResourceIdentifier hostGroupId, AgentPoolNetworkProfile networkProfile, AgentPoolSecurityProfile securityProfile, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus, LocalDnsProfile localDnsProfile, ContainerServiceStateCode? powerStateCode, Azure.Core.ResourceIdentifier creationDataSourceResourceId, bool? isOutboundNatDisabled, int? gatewayPublicIPPrefixSize, bool? isArtifactStreamingEnabled, Azure.ResponseError statusProvisioningError, string upgradeMaxSurge, IEnumerable<ManualScaleProfile> scaleManual, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual, AgentPoolGpuDriver? gpuDriver, bool? enableAutoScaling, bool? enableNodePublicIP, bool? enableEncryptionAtHost, bool? enableFips, bool? enableUltraSsd)
        {
            var result = ContainerServiceAgentPoolData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                securityProfile: securityProfile,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                localDnsProfile: localDnsProfile,
                powerStateCode: powerStateCode,
                creationDataSourceResourceId: creationDataSourceResourceId,
                isOutboundNatDisabled: isOutboundNatDisabled,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                statusProvisioningError: statusProvisioningError,
                upgradeMaxSurge: upgradeMaxSurge,
                scaleManual: scaleManual,
                virtualMachinesScaleManual: virtualMachinesScaleManual,
                gpuDriver: gpuDriver,
                enableAutoScaling: enableAutoScaling,
                enableNodePublicIP: enableNodePublicIP,
                enableEncryptionAtHost: enableEncryptionAtHost,
                enableFips: enableFips,
                enableUltraSsd: enableUltraSsd,
                upgradeStrategy: default,
                isOSDiskFullCachingEnabled: default,
                upgradeSettingsBlueGreen: default,
                nodeInitializationTaints: default,
                gpuProfile: default,
                virtualMachinesScale: default,
                preparedImageSpecificationId: default);
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceManagedClusterData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.ContainerServiceManagedClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceManagedClusterData ContainerServiceManagedClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, Azure.Core.AzureLocation location, string provisioningState, int? maxAgentPools, string kubernetesVersion, string currentKubernetesVersion, string dnsPrefix, string fqdnSubdomain, string fqdn, string privateFqdn, string azurePortalFqdn, IEnumerable<ManagedClusterAgentPoolProfile> agentPoolProfiles, ContainerServiceLinuxProfile linuxProfile, ManagedClusterWindowsProfile windowsProfile, ManagedClusterServicePrincipalProfile servicePrincipalProfile, IDictionary<string, ManagedClusterAddonProfile> addonProfiles, ManagedClusterPodIdentityProfile podIdentityProfile, ManagedClusterOidcIssuerProfile oidcIssuerProfile, string nodeResourceGroup, bool? isRbacEnabled, KubernetesSupportPlan? supportPlan, ContainerServiceNetworkProfile networkProfile, ManagedClusterAadProfile aadProfile, ManagedClusterAutoUpgradeProfile autoUpgradeProfile, ManagedClusterAutoScalerProfile autoScalerProfile, ManagedClusterApiServerAccessProfile apiServerAccessProfile, Azure.Core.ResourceIdentifier diskEncryptionSetId, IDictionary<string, ContainerServiceUserAssignedIdentity> identityProfile, IEnumerable<ContainerServicePrivateLinkResourceData> privateLinkResources, bool? isLocalAccountsDisabled, ManagedClusterHttpProxyConfig httpProxyConfig, ManagedClusterSecurityProfile securityProfile, ManagedClusterStorageProfile storageProfile, ManagedClusterIngressProfile ingressProfile, ContainerServicePublicNetworkAccess? publicNetworkAccess, ManagedClusterWorkloadAutoScalerProfile workloadAutoScalerProfile, ManagedClusterAzureMonitorProfile azureMonitorProfile, ServiceMeshProfile serviceMeshProfile, Azure.Core.ResourceIdentifier resourceId, ManagedClusterNodeProvisioningProfile nodeProvisioningProfile, ManagedClusterBootstrapProfile bootstrapProfile, ManagedClusterHostedSystemProfile hostedSystemProfile, ContainerServiceStateCode? powerStateCode, ManagedClusterNodeResourceGroupRestrictionLevel? nodeResourceGroupRestrictionLevel, UpgradeOverrideSettings upgradeOverrideSettings, bool? isCostAnalysisEnabled, bool? isAIToolchainOperatorEnabled, Azure.ResponseError statusProvisioningError, Azure.ETag? eTag, ManagedClusterSku sku, ExtendedLocation extendedLocation, ManagedClusterIdentity clusterIdentity, string kind)
        {
            var result = ContainerServiceManagedClusterData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                provisioningState: provisioningState,
                maxAgentPools: maxAgentPools,
                kubernetesVersion: kubernetesVersion,
                currentKubernetesVersion: currentKubernetesVersion,
                dnsPrefix: dnsPrefix,
                fqdnSubdomain: fqdnSubdomain,
                fqdn: fqdn,
                privateFqdn: privateFqdn,
                azurePortalFqdn: azurePortalFqdn,
                agentPoolProfiles: agentPoolProfiles,
                linuxProfile: linuxProfile,
                windowsProfile: windowsProfile,
                servicePrincipalProfile: servicePrincipalProfile,
                addonProfiles: addonProfiles,
                podIdentityProfile: podIdentityProfile,
                oidcIssuerProfile: oidcIssuerProfile,
                nodeResourceGroup: nodeResourceGroup,
                isRbacEnabled: isRbacEnabled,
                supportPlan: supportPlan,
                networkProfile: networkProfile,
                aadProfile: aadProfile,
                autoUpgradeProfile: autoUpgradeProfile,
                autoScalerProfile: autoScalerProfile,
                apiServerAccessProfile: apiServerAccessProfile,
                diskEncryptionSetId: diskEncryptionSetId,
                identityProfile: identityProfile,
                privateLinkResources: privateLinkResources,
                isLocalAccountsDisabled: isLocalAccountsDisabled,
                httpProxyConfig: httpProxyConfig,
                securityProfile: securityProfile,
                storageProfile: storageProfile,
                ingressProfile: ingressProfile,
                publicNetworkAccess: publicNetworkAccess,
                workloadAutoScalerProfile: workloadAutoScalerProfile,
                azureMonitorProfile: azureMonitorProfile,
                serviceMeshProfile: serviceMeshProfile,
                resourceId: resourceId,
                nodeProvisioningProfile: nodeProvisioningProfile,
                bootstrapProfile: bootstrapProfile,
                hostedSystemProfile: hostedSystemProfile,
                powerStateCode: powerStateCode,
                nodeResourceGroupRestrictionLevel: nodeResourceGroupRestrictionLevel,
                upgradeOverrideSettings: upgradeOverrideSettings,
                isCostAnalysisEnabled: isCostAnalysisEnabled,
                isAIToolchainOperatorEnabled: isAIToolchainOperatorEnabled,
                statusProvisioningError: statusProvisioningError,
                eTag: eTag,
                sku: sku,
                extendedLocation: extendedLocation,
                clusterIdentity: clusterIdentity,
                kind: kind,
                isFipsEnabled: default,
                isNamespaceResourcesEnabled: default,
                healthMonitorProfile: default,
                creationDataSourceResourceId: default,
                upstreamSchedulerConfigMode: default,
                scalingSize: default,
                nodeDisruptionPolicy: default);
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfile"/>. </summary>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfile"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterAgentPoolProfile ManagedClusterAgentPoolProfile(Azure.ETag? eTag, int? count, string vmSize, int? osDiskSizeInGB, ContainerServiceOSDiskType? osDiskType, KubeletDiskType? kubeletDiskType, WorkloadRuntime? workloadRuntime, string messageOfTheDay, Azure.Core.ResourceIdentifier vnetSubnetId, Azure.Core.ResourceIdentifier podSubnetId, PodIPAllocationMode? podIPAllocationMode, int? maxPods, ContainerServiceOSType? osType, ContainerServiceOSSku? osSku, int? maxCount, int? minCount, bool? isAutoScalingEnabled, ScaleDownMode? scaleDownMode, AgentPoolType? agentPoolType, AgentPoolMode? mode, string orchestratorVersion, string currentOrchestratorVersion, string nodeImageVersion, AgentPoolUpgradeSettings upgradeSettings, string provisioningState, ContainerServiceStateCode? powerStateCode, IEnumerable<string> availabilityZones, bool? isNodePublicIpEnabled, Azure.Core.ResourceIdentifier nodePublicIPPrefixId, ScaleSetPriority? scaleSetPriority, ScaleSetEvictionPolicy? scaleSetEvictionPolicy, float? spotMaxPrice, IDictionary<string, string> tags, IDictionary<string, string> nodeLabels, IEnumerable<string> nodeTaints, Azure.Core.ResourceIdentifier proximityPlacementGroupId, KubeletConfig kubeletConfig, LinuxOSConfig linuxOSConfig, bool? isEncryptionAtHostEnabled, bool? isUltraSsdEnabled, bool? isFipsEnabled, GpuInstanceProfile? gpuInstanceProfile, Azure.Core.ResourceIdentifier creationDataSourceResourceId, Azure.Core.ResourceIdentifier capacityReservationGroupId, Azure.Core.ResourceIdentifier hostGroupId, AgentPoolNetworkProfile networkProfile, bool? isOutboundNatDisabled, AgentPoolSecurityProfile securityProfile, AgentPoolGpuDriver? gpuDriver, int? gatewayPublicIPPrefixSize, bool? isArtifactStreamingEnabled, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus, Azure.ResponseError statusProvisioningError, LocalDnsProfile localDnsProfile, string name)
        {
            var result = ManagedClusterAgentPoolProfile(
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                powerStateCode: powerStateCode,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                creationDataSourceResourceId: creationDataSourceResourceId,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                isOutboundNatDisabled: isOutboundNatDisabled,
                securityProfile: securityProfile,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                statusProvisioningError: statusProvisioningError,
                localDnsProfile: localDnsProfile,
                name: name,
                upgradeStrategy: default,
                isOSDiskFullCachingEnabled: default,
                upgradeSettingsBlueGreen: default,
                nodeInitializationTaints: default,
                gpuProfile: default,
                virtualMachinesScale: default,
                preparedImageSpecificationId: default);
            result.GpuDriver = gpuDriver;
            if (virtualMachinesScaleManual != null)
            {
                foreach (var item in virtualMachinesScaleManual)
                {
                    result.VirtualMachinesScaleManual.Add(item);
                }
            }
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfileProperties"/>. </summary>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfileProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterAgentPoolProfileProperties ManagedClusterAgentPoolProfileProperties(Azure.ETag? eTag, int? count, string vmSize, int? osDiskSizeInGB, ContainerServiceOSDiskType? osDiskType, KubeletDiskType? kubeletDiskType, WorkloadRuntime? workloadRuntime, string messageOfTheDay, Azure.Core.ResourceIdentifier vnetSubnetId, Azure.Core.ResourceIdentifier podSubnetId, PodIPAllocationMode? podIPAllocationMode, int? maxPods, ContainerServiceOSType? osType, ContainerServiceOSSku? osSku, int? maxCount, int? minCount, bool? isAutoScalingEnabled, ScaleDownMode? scaleDownMode, AgentPoolType? agentPoolType, AgentPoolMode? mode, string orchestratorVersion, string currentOrchestratorVersion, string nodeImageVersion, AgentPoolUpgradeSettings upgradeSettings, string provisioningState, ContainerServiceStateCode? powerStateCode, IEnumerable<string> availabilityZones, bool? isNodePublicIpEnabled, Azure.Core.ResourceIdentifier nodePublicIPPrefixId, ScaleSetPriority? scaleSetPriority, ScaleSetEvictionPolicy? scaleSetEvictionPolicy, float? spotMaxPrice, IDictionary<string, string> tags, IDictionary<string, string> nodeLabels, IEnumerable<string> nodeTaints, Azure.Core.ResourceIdentifier proximityPlacementGroupId, KubeletConfig kubeletConfig, LinuxOSConfig linuxOSConfig, bool? isEncryptionAtHostEnabled, bool? isUltraSsdEnabled, bool? isFipsEnabled, GpuInstanceProfile? gpuInstanceProfile, Azure.Core.ResourceIdentifier creationDataSourceResourceId, Azure.Core.ResourceIdentifier capacityReservationGroupId, Azure.Core.ResourceIdentifier hostGroupId, AgentPoolNetworkProfile networkProfile, bool? isOutboundNatDisabled, AgentPoolSecurityProfile securityProfile, AgentPoolGpuDriver? gpuDriver, int? gatewayPublicIPPrefixSize, bool? isArtifactStreamingEnabled, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus, Azure.ResponseError statusProvisioningError, LocalDnsProfile localDnsProfile)
        {
            var result = ManagedClusterAgentPoolProfileProperties(
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                powerStateCode: powerStateCode,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                creationDataSourceResourceId: creationDataSourceResourceId,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                isOutboundNatDisabled: isOutboundNatDisabled,
                securityProfile: securityProfile,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                statusProvisioningError: statusProvisioningError,
                localDnsProfile: localDnsProfile,
                upgradeStrategy: default,
                isOSDiskFullCachingEnabled: default,
                upgradeSettingsBlueGreen: default,
                nodeInitializationTaints: default,
                gpuProfile: default,
                virtualMachinesScale: default,
                preparedImageSpecificationId: default);
            result.GpuDriver = gpuDriver;
            if (virtualMachinesScaleManual != null)
            {
                foreach (var item in virtualMachinesScaleManual)
                {
                    result.VirtualMachinesScaleManual.Add(item);
                }
            }
            return result;
        }
    }
}
