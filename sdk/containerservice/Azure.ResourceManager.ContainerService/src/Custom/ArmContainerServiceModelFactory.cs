// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

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
        /// <param name="recentlyUsedVersions"> List of versions that the agent pool has recently been on. </param>
        /// <param name="latestNodeImageVersion"> The latest AKS supported node image version. </param>
        /// <returns> A new <see cref="ContainerService.AgentPoolUpgradeProfileData"/> instance for mocking. </returns>
        public static AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kubernetesVersion, ContainerServiceOSType osType, IEnumerable<AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades, IEnumerable<AgentPoolRecentlyUsedVersion> recentlyUsedVersions, string latestNodeImageVersion)
        {
            return new AgentPoolUpgradeProfileData(
                id,
                name,
                resourceType,
                systemData,
                new AgentPoolUpgradeProfileProperties(kubernetesVersion, osType, (upgrades ?? new List<AgentPoolUpgradeProfilePropertiesUpgradesItem>()).ToList(), new ChangeTrackingList<KubernetesVersionComponents>(), (recentlyUsedVersions ?? new List<AgentPoolRecentlyUsedVersion>()).ToList(), latestNodeImageVersion, null),
                additionalBinaryDataProperties: null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested AppMonitoring model in place of the isAppMonitoringAutoInstrumentationEnabled flag.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAzureMonitorProfile"/>. </summary>
        /// <param name="metrics"> Metrics profile for the prometheus service addon. </param>
        /// <param name="isAppMonitoringAutoInstrumentationEnabled"> Indicates if Application Monitoring Auto Instrumentation is enabled or not. </param>
        /// <returns> A new <see cref="Models.ManagedClusterAzureMonitorProfile"/> instance for mocking. </returns>
        public static ManagedClusterAzureMonitorProfile ManagedClusterAzureMonitorProfile(ManagedClusterMonitorProfileMetrics metrics, bool? isAppMonitoringAutoInstrumentationEnabled)
        {
            ManagedClusterAzureMonitorProfileAppMonitoring appMonitoring = null;
            if (isAppMonitoringAutoInstrumentationEnabled.HasValue)
            {
                appMonitoring = new ManagedClusterAzureMonitorProfileAppMonitoring
                {
                    IsAppMonitoringAutoInstrumentationEnabled = isAppMonitoringAutoInstrumentationEnabled
                };
            }
            return ManagedClusterAzureMonitorProfile(metrics, null, appMonitoring);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested VerticalPodAutoscaler model in place of the isVpaEnabled flag.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterWorkloadAutoScalerProfile"/>. </summary>
        /// <param name="isKedaEnabled"> Whether to enable KEDA. </param>
        /// <param name="isVpaEnabled"> Whether to enable VPA add-on in cluster. Default value is false. </param>
        /// <returns> A new <see cref="Models.ManagedClusterWorkloadAutoScalerProfile"/> instance for mocking. </returns>
        public static ManagedClusterWorkloadAutoScalerProfile ManagedClusterWorkloadAutoScalerProfile(bool? isKedaEnabled, bool? isVpaEnabled)
        {
            ManagedClusterVerticalPodAutoscaler verticalPodAutoscaler = isVpaEnabled.HasValue
                ? new ManagedClusterVerticalPodAutoscaler(isVpaEnabled.Value)
                : null;
            return ManagedClusterWorkloadAutoScalerProfile(isKedaEnabled, verticalPodAutoscaler);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing securityGating parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterSecurityProfileDefender"/>. </summary>
        /// <param name="logAnalyticsWorkspaceResourceId"> Resource ID of the Log Analytics workspace to be associated with Microsoft Defender. </param>
        /// <param name="isSecurityMonitoringEnabled"> Whether to enable Defender threat detection. </param>
        /// <returns> A new <see cref="Models.ManagedClusterSecurityProfileDefender"/> instance for mocking. </returns>
        public static ManagedClusterSecurityProfileDefender ManagedClusterSecurityProfileDefender(ResourceIdentifier logAnalyticsWorkspaceResourceId, bool? isSecurityMonitoringEnabled)
        {
            return ManagedClusterSecurityProfileDefender(logAnalyticsWorkspaceResourceId, isSecurityMonitoringEnabled, null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested ManagedOutboundIPProfile model in place of the managedOutboundIPCount value and added
        // the outboundPublicIPPrefixes and outboundPublicIPs parameters.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterNatGatewayProfile"/>. </summary>
        /// <param name="managedOutboundIPCount"> The desired number of outbound IPs created/managed by Azure. </param>
        /// <param name="effectiveOutboundIPs"> The effective outbound IP resources of the cluster NAT gateway. </param>
        /// <param name="idleTimeoutInMinutes"> Desired outbound flow idle timeout in minutes. </param>
        /// <returns> A new <see cref="Models.ManagedClusterNatGatewayProfile"/> instance for mocking. </returns>
        public static ManagedClusterNatGatewayProfile ManagedClusterNatGatewayProfile(int? managedOutboundIPCount, IEnumerable<WritableSubResource> effectiveOutboundIPs, int? idleTimeoutInMinutes)
        {
            ManagedClusterManagedOutboundIPProfile managedOutboundIPProfile = managedOutboundIPCount.HasValue
                ? new ManagedClusterManagedOutboundIPProfile { Count = managedOutboundIPCount }
                : null;
            return ManagedClusterNatGatewayProfile(managedOutboundIPProfile, effectiveOutboundIPs, null, null, idleTimeoutInMinutes);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing clusterServiceLoadBalancerHealthProbeMode parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterLoadBalancerProfile"/>. </summary>
        /// <param name="managedOutboundIPs"> Desired managed outbound IPs for the cluster load balancer. </param>
        /// <param name="outboundPublicIPPrefixes"> Desired outbound IP Prefix resources for the cluster load balancer. </param>
        /// <param name="outboundPublicIPs"> Desired outbound IP resources for the cluster load balancer. </param>
        /// <param name="effectiveOutboundIPs"> The effective outbound IP resources of the cluster load balancer. </param>
        /// <param name="allocatedOutboundPorts"> The desired number of allocated SNAT ports per VM. </param>
        /// <param name="idleTimeoutInMinutes"> Desired outbound flow idle timeout in minutes. </param>
        /// <param name="isMultipleStandardLoadBalancersEnabled"> Enable multiple standard load balancers per AKS cluster or not. </param>
        /// <param name="backendPoolType"> The type of the managed inbound Load Balancer BackendPool. </param>
        /// <returns> A new <see cref="Models.ManagedClusterLoadBalancerProfile"/> instance for mocking. </returns>
        public static ManagedClusterLoadBalancerProfile ManagedClusterLoadBalancerProfile(ManagedClusterLoadBalancerProfileManagedOutboundIPs managedOutboundIPs, IEnumerable<WritableSubResource> outboundPublicIPPrefixes, IEnumerable<WritableSubResource> outboundPublicIPs, IEnumerable<WritableSubResource> effectiveOutboundIPs, int? allocatedOutboundPorts, int? idleTimeoutInMinutes, bool? isMultipleStandardLoadBalancersEnabled, ManagedClusterLoadBalancerBackendPoolType? backendPoolType)
        {
            return ManagedClusterLoadBalancerProfile(managedOutboundIPs, outboundPublicIPPrefixes, outboundPublicIPs, effectiveOutboundIPs, allocatedOutboundPorts, idleTimeoutInMinutes, isMultipleStandardLoadBalancersEnabled, backendPoolType, null);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing defaultDomain parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterIngressProfileWebAppRouting"/>. </summary>
        /// <param name="isEnabled"> Whether to enable Web App Routing. </param>
        /// <param name="gatewayApiImplementationsIstioMode"> Istio mode for the Gateway API implementation. </param>
        /// <param name="dnsZoneResourceIds"> Resource IDs of the DNS zones to be associated with the Web App Routing add-on. </param>
        /// <param name="nginxDefaultIngressControllerType"> Type of the default NginxIngressController custom resource. </param>
        /// <param name="identity"> Managed identity of the Web Application Routing add-on. </param>
        /// <returns> A new <see cref="Models.ManagedClusterIngressProfileWebAppRouting"/> instance for mocking. </returns>
        public static ManagedClusterIngressProfileWebAppRouting ManagedClusterIngressProfileWebAppRouting(bool? isEnabled, GatewayApiIstioMode? gatewayApiImplementationsIstioMode, IEnumerable<ResourceIdentifier> dnsZoneResourceIds, NginxIngressControllerType? nginxDefaultIngressControllerType, ContainerServiceUserAssignedIdentity identity)
        {
            return ManagedClusterIngressProfileWebAppRouting(isEnabled, gatewayApiImplementationsIstioMode, dnsZoneResourceIds, nginxDefaultIngressControllerType, identity, null);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing applicationLoadBalancer parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterIngressProfile"/>. </summary>
        /// <param name="webAppRouting"> Web App Routing settings for the ingress profile. </param>
        /// <param name="gatewayApiInstallation"> The Gateway API installation mode. </param>
        /// <returns> A new <see cref="Models.ManagedClusterIngressProfile"/> instance for mocking. </returns>
        public static ManagedClusterIngressProfile ManagedClusterIngressProfile(ManagedClusterIngressProfileWebAppRouting webAppRouting, ManagedGatewayType? gatewayApiInstallation)
        {
            return ManagedClusterIngressProfile(webAppRouting, gatewayApiInstallation, null);
        }

        // This factory method is retained for backward compatibility. The generated factory inserted the
        // maxBlockedNodes parameter.
        /// <summary> Initializes a new instance of <see cref="Models.AgentPoolUpgradeSettings"/>. </summary>
        /// <param name="maxSurge"> The maximum number or percentage of nodes that are surged during upgrade. </param>
        /// <param name="maxUnavailable"> The maximum number or percentage of nodes that can be simultaneously unavailable during upgrade. </param>
        /// <param name="drainTimeoutInMinutes"> The amount of time (in minutes) to wait on eviction of pods and graceful termination per node. </param>
        /// <param name="nodeSoakDurationInMinutes"> The amount of time (in minutes) to wait after draining a node and before reimaging it and moving on to next node. </param>
        /// <param name="undrainableNodeBehavior"> Defines the behavior for undrainable nodes during upgrade. </param>
        /// <returns> A new <see cref="Models.AgentPoolUpgradeSettings"/> instance for mocking. </returns>
        public static AgentPoolUpgradeSettings AgentPoolUpgradeSettings(string maxSurge, string maxUnavailable, int? drainTimeoutInMinutes, int? nodeSoakDurationInMinutes, UndrainableNodeBehavior? undrainableNodeBehavior)
        {
            return AgentPoolUpgradeSettings(maxSurge, maxUnavailable, null, drainTimeoutInMinutes, nodeSoakDurationInMinutes, undrainableNodeBehavior);
        }

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
