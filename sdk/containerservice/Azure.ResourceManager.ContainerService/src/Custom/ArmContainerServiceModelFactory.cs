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
        public static AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string kubernetesVersion = null, ContainerServiceOSType osType = default, IEnumerable<AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades = null, IEnumerable<AgentPoolRecentlyUsedVersion> recentlyUsedVersions = null, string latestNodeImageVersion = null)
        {
            return new AgentPoolUpgradeProfileData(
                id,
                name,
                resourceType,
                systemData,
                new AgentPoolUpgradeProfileProperties(kubernetesVersion, osType, (upgrades ?? new List<AgentPoolUpgradeProfilePropertiesUpgradesItem>()).ToList(), (recentlyUsedVersions ?? new List<AgentPoolRecentlyUsedVersion>()).ToList(), latestNodeImageVersion, null),
                additionalBinaryDataProperties: null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested AppMonitoring model in place of the isAppMonitoringAutoInstrumentationEnabled flag.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAzureMonitorProfile"/>. </summary>
        /// <param name="metrics"> Metrics profile for the prometheus service addon. </param>
        /// <param name="isAppMonitoringAutoInstrumentationEnabled"> Indicates if Application Monitoring Auto Instrumentation is enabled or not. </param>
        /// <returns> A new <see cref="Models.ManagedClusterAzureMonitorProfile"/> instance for mocking. </returns>
        public static ManagedClusterAzureMonitorProfile ManagedClusterAzureMonitorProfile(ManagedClusterMonitorProfileMetrics metrics = null, bool? isAppMonitoringAutoInstrumentationEnabled = default)
        {
            ManagedClusterAzureMonitorProfileAppMonitoring appMonitoring = null;
            if (isAppMonitoringAutoInstrumentationEnabled.HasValue)
            {
                appMonitoring = new ManagedClusterAzureMonitorProfileAppMonitoring
                {
                    IsAppMonitoringAutoInstrumentationEnabled = isAppMonitoringAutoInstrumentationEnabled
                };
            }
            return new ManagedClusterAzureMonitorProfile(metrics, null, appMonitoring, null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested VerticalPodAutoscaler model in place of the isVpaEnabled flag.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterWorkloadAutoScalerProfile"/>. </summary>
        /// <param name="isKedaEnabled"> Whether to enable KEDA. </param>
        /// <param name="isVpaEnabled"> Whether to enable VPA add-on in cluster. Default value is false. </param>
        /// <returns> A new <see cref="Models.ManagedClusterWorkloadAutoScalerProfile"/> instance for mocking. </returns>
        public static ManagedClusterWorkloadAutoScalerProfile ManagedClusterWorkloadAutoScalerProfile(bool? isKedaEnabled = default, bool? isVpaEnabled = default)
        {
            ManagedClusterVerticalPodAutoscaler verticalPodAutoscaler = isVpaEnabled.HasValue
                ? new ManagedClusterVerticalPodAutoscaler(isVpaEnabled.Value)
                : null;
            ManagedClusterWorkloadAutoScalerProfileKeda keda = isKedaEnabled.HasValue
                ? new ManagedClusterWorkloadAutoScalerProfileKeda(isKedaEnabled.Value)
                : null;
            return new ManagedClusterWorkloadAutoScalerProfile(keda, verticalPodAutoscaler, null);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing securityGating parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterSecurityProfileDefender"/>. </summary>
        /// <param name="logAnalyticsWorkspaceResourceId"> Resource ID of the Log Analytics workspace to be associated with Microsoft Defender. </param>
        /// <param name="isSecurityMonitoringEnabled"> Whether to enable Defender threat detection. </param>
        /// <returns> A new <see cref="Models.ManagedClusterSecurityProfileDefender"/> instance for mocking. </returns>
        public static ManagedClusterSecurityProfileDefender ManagedClusterSecurityProfileDefender(ResourceIdentifier logAnalyticsWorkspaceResourceId = null, bool? isSecurityMonitoringEnabled = default)
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
        public static ManagedClusterNatGatewayProfile ManagedClusterNatGatewayProfile(int? managedOutboundIPCount = default, IEnumerable<WritableSubResource> effectiveOutboundIPs = null, int? idleTimeoutInMinutes = default)
        {
            ManagedClusterManagedOutboundIPProfile managedOutboundIPProfile = managedOutboundIPCount.HasValue
                ? new ManagedClusterManagedOutboundIPProfile { Count = managedOutboundIPCount }
                : null;
            return new ManagedClusterNatGatewayProfile(null, managedOutboundIPProfile, effectiveOutboundIPs?.ToList(), null, null, idleTimeoutInMinutes, null);
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
        public static ManagedClusterLoadBalancerProfile ManagedClusterLoadBalancerProfile(ManagedClusterLoadBalancerProfileManagedOutboundIPs managedOutboundIPs = null, IEnumerable<WritableSubResource> outboundPublicIPPrefixes = null, IEnumerable<WritableSubResource> outboundPublicIPs = null, IEnumerable<WritableSubResource> effectiveOutboundIPs = null, int? allocatedOutboundPorts = default, int? idleTimeoutInMinutes = default, bool? isMultipleStandardLoadBalancersEnabled = default, ManagedClusterLoadBalancerBackendPoolType? backendPoolType = default)
        {
            ManagedClusterLoadBalancerProfileOutboundIPPrefixes outboundIPPrefixes = outboundPublicIPPrefixes is null
                ? null
                : new ManagedClusterLoadBalancerProfileOutboundIPPrefixes(outboundPublicIPPrefixes.ToList(), null);
            ManagedClusterLoadBalancerProfileOutboundIPs outboundIPs = outboundPublicIPs is null
                ? null
                : new ManagedClusterLoadBalancerProfileOutboundIPs(outboundPublicIPs.ToList(), null);
            return new ManagedClusterLoadBalancerProfile(managedOutboundIPs, outboundIPPrefixes, outboundIPs, effectiveOutboundIPs?.ToList(), allocatedOutboundPorts, idleTimeoutInMinutes, isMultipleStandardLoadBalancersEnabled, backendPoolType, null);
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
        public static ManagedClusterIngressProfileWebAppRouting ManagedClusterIngressProfileWebAppRouting(bool? isEnabled = default, GatewayApiIstioMode? gatewayApiImplementationsIstioMode = default, IEnumerable<ResourceIdentifier> dnsZoneResourceIds = null, NginxIngressControllerType? nginxDefaultIngressControllerType = default, ContainerServiceUserAssignedIdentity identity = null)
        {
            return ManagedClusterIngressProfileWebAppRouting(isEnabled, dnsZoneResourceIds, nginxDefaultIngressControllerType, identity);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing applicationLoadBalancer parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterIngressProfile"/>. </summary>
        /// <param name="webAppRouting"> Web App Routing settings for the ingress profile. </param>
        /// <param name="gatewayApiInstallation"> The Gateway API installation mode. </param>
        /// <returns> A new <see cref="Models.ManagedClusterIngressProfile"/> instance for mocking. </returns>
        public static ManagedClusterIngressProfile ManagedClusterIngressProfile(ManagedClusterIngressProfileWebAppRouting webAppRouting = null, ManagedGatewayType? gatewayApiInstallation = default)
        {
            ManagedClusterIngressProfileGatewayConfiguration gatewayApi = gatewayApiInstallation.HasValue
                ? new ManagedClusterIngressProfileGatewayConfiguration(gatewayApiInstallation, null)
                : null;
            return new ManagedClusterIngressProfile(webAppRouting, gatewayApi, null);
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
        public static AgentPoolUpgradeSettings AgentPoolUpgradeSettings(string maxSurge = null, string maxUnavailable = null, int? drainTimeoutInMinutes = default, int? nodeSoakDurationInMinutes = default, UndrainableNodeBehavior? undrainableNodeBehavior = default)
        {
            return new AgentPoolUpgradeSettings(maxSurge, maxUnavailable, drainTimeoutInMinutes, nodeSoakDurationInMinutes, undrainableNodeBehavior, null);
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
        public static ContainerServiceAgentPoolData ContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default, int? count = default, string vmSize = null, int? osDiskSizeInGB = default, ContainerServiceOSDiskType? osDiskType = default, KubeletDiskType? kubeletDiskType = default, WorkloadRuntime? workloadRuntime = default, string messageOfTheDay = null, Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, PodIPAllocationMode? podIPAllocationMode = default, int? maxPods = default, ContainerServiceOSType? osType = default, ContainerServiceOSSku? osSku = default, int? maxCount = default, int? minCount = default, bool? isAutoScalingEnabled = default, ScaleDownMode? scaleDownMode = default, AgentPoolType? agentPoolType = default, AgentPoolMode? mode = default, string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, AgentPoolUpgradeSettings upgradeSettings = null, string provisioningState = null, IEnumerable<string> availabilityZones = null, bool? isNodePublicIpEnabled = default, Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, ScaleSetPriority? scaleSetPriority = default, ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default, float? spotMaxPrice = default, IDictionary<string, string> tags = null, IDictionary<string, string> nodeLabels = null, IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, KubeletConfig kubeletConfig = null, LinuxOSConfig linuxOSConfig = null, bool? isEncryptionAtHostEnabled = default, bool? isUltraSsdEnabled = default, bool? isFipsEnabled = default, GpuInstanceProfile? gpuInstanceProfile = default, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, AgentPoolNetworkProfile networkProfile = null, AgentPoolSecurityProfile securityProfile = null, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus = null, LocalDnsProfile localDnsProfile = null, ContainerServiceStateCode? powerStateCode = default, Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, bool? isOutboundNatDisabled = default, int? gatewayPublicIPPrefixSize = default, bool? isArtifactStreamingEnabled = default, Azure.ResponseError statusProvisioningError = null, string upgradeMaxSurge = null, IEnumerable<ManualScaleProfile> scaleManual = null, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual = null, AgentPoolGpuDriver? gpuDriver = default, bool? enableAutoScaling = default, bool? enableNodePublicIP = default, bool? enableEncryptionAtHost = default, bool? enableFips = default, bool? enableUltraSsd = default)
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
                virtualMachinesScale: default);
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceManagedClusterData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.ContainerServiceManagedClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceManagedClusterData ContainerServiceManagedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default, string provisioningState = null, int? maxAgentPools = default, string kubernetesVersion = null, string currentKubernetesVersion = null, string dnsPrefix = null, string fqdnSubdomain = null, string fqdn = null, string privateFqdn = null, string azurePortalFqdn = null, IEnumerable<ManagedClusterAgentPoolProfile> agentPoolProfiles = null, ContainerServiceLinuxProfile linuxProfile = null, ManagedClusterWindowsProfile windowsProfile = null, ManagedClusterServicePrincipalProfile servicePrincipalProfile = null, IDictionary<string, ManagedClusterAddonProfile> addonProfiles = null, ManagedClusterPodIdentityProfile podIdentityProfile = null, ManagedClusterOidcIssuerProfile oidcIssuerProfile = null, string nodeResourceGroup = null, bool? isRbacEnabled = default, KubernetesSupportPlan? supportPlan = default, ContainerServiceNetworkProfile networkProfile = null, ManagedClusterAadProfile aadProfile = null, ManagedClusterAutoUpgradeProfile autoUpgradeProfile = null, ManagedClusterAutoScalerProfile autoScalerProfile = null, ManagedClusterApiServerAccessProfile apiServerAccessProfile = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, IDictionary<string, ContainerServiceUserAssignedIdentity> identityProfile = null, IEnumerable<ContainerServicePrivateLinkResourceData> privateLinkResources = null, bool? isLocalAccountsDisabled = default, ManagedClusterHttpProxyConfig httpProxyConfig = null, ManagedClusterSecurityProfile securityProfile = null, ManagedClusterStorageProfile storageProfile = null, ManagedClusterIngressProfile ingressProfile = null, ContainerServicePublicNetworkAccess? publicNetworkAccess = default, ManagedClusterWorkloadAutoScalerProfile workloadAutoScalerProfile = null, ManagedClusterAzureMonitorProfile azureMonitorProfile = null, ServiceMeshProfile serviceMeshProfile = null, Azure.Core.ResourceIdentifier resourceId = null, ManagedClusterNodeProvisioningProfile nodeProvisioningProfile = null, ManagedClusterBootstrapProfile bootstrapProfile = null, ManagedClusterHostedSystemProfile hostedSystemProfile = null, ContainerServiceStateCode? powerStateCode = default, ManagedClusterNodeResourceGroupRestrictionLevel? nodeResourceGroupRestrictionLevel = default, UpgradeOverrideSettings upgradeOverrideSettings = null, bool? isCostAnalysisEnabled = default, bool? isAIToolchainOperatorEnabled = default, Azure.ResponseError statusProvisioningError = null, Azure.ETag? eTag = default, ManagedClusterSku sku = null, ExtendedLocation extendedLocation = null, ManagedClusterIdentity clusterIdentity = null, string kind = null)
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
                upstreamSchedulerConfigMode: default);
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfile"/>. </summary>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfile"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterAgentPoolProfile ManagedClusterAgentPoolProfile(Azure.ETag? eTag = default, int? count = default, string vmSize = null, int? osDiskSizeInGB = default, ContainerServiceOSDiskType? osDiskType = default, KubeletDiskType? kubeletDiskType = default, WorkloadRuntime? workloadRuntime = default, string messageOfTheDay = null, Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, PodIPAllocationMode? podIPAllocationMode = default, int? maxPods = default, ContainerServiceOSType? osType = default, ContainerServiceOSSku? osSku = default, int? maxCount = default, int? minCount = default, bool? isAutoScalingEnabled = default, ScaleDownMode? scaleDownMode = default, AgentPoolType? agentPoolType = default, AgentPoolMode? mode = default, string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, AgentPoolUpgradeSettings upgradeSettings = null, string provisioningState = null, ContainerServiceStateCode? powerStateCode = default, IEnumerable<string> availabilityZones = null, bool? isNodePublicIpEnabled = default, Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, ScaleSetPriority? scaleSetPriority = default, ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default, float? spotMaxPrice = default, IDictionary<string, string> tags = null, IDictionary<string, string> nodeLabels = null, IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, KubeletConfig kubeletConfig = null, LinuxOSConfig linuxOSConfig = null, bool? isEncryptionAtHostEnabled = default, bool? isUltraSsdEnabled = default, bool? isFipsEnabled = default, GpuInstanceProfile? gpuInstanceProfile = default, Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, AgentPoolNetworkProfile networkProfile = null, bool? isOutboundNatDisabled = default, AgentPoolSecurityProfile securityProfile = null, AgentPoolGpuDriver? gpuDriver = default, int? gatewayPublicIPPrefixSize = default, bool? isArtifactStreamingEnabled = default, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual = null, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus = null, Azure.ResponseError statusProvisioningError = null, LocalDnsProfile localDnsProfile = null, string name = null)
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
                virtualMachinesScale: default);
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
        public static ManagedClusterAgentPoolProfileProperties ManagedClusterAgentPoolProfileProperties(Azure.ETag? eTag = default, int? count = default, string vmSize = null, int? osDiskSizeInGB = default, ContainerServiceOSDiskType? osDiskType = default, KubeletDiskType? kubeletDiskType = default, WorkloadRuntime? workloadRuntime = default, string messageOfTheDay = null, Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, PodIPAllocationMode? podIPAllocationMode = default, int? maxPods = default, ContainerServiceOSType? osType = default, ContainerServiceOSSku? osSku = default, int? maxCount = default, int? minCount = default, bool? isAutoScalingEnabled = default, ScaleDownMode? scaleDownMode = default, AgentPoolType? agentPoolType = default, AgentPoolMode? mode = default, string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, AgentPoolUpgradeSettings upgradeSettings = null, string provisioningState = null, ContainerServiceStateCode? powerStateCode = default, IEnumerable<string> availabilityZones = null, bool? isNodePublicIpEnabled = default, Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, ScaleSetPriority? scaleSetPriority = default, ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default, float? spotMaxPrice = default, IDictionary<string, string> tags = null, IDictionary<string, string> nodeLabels = null, IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, KubeletConfig kubeletConfig = null, LinuxOSConfig linuxOSConfig = null, bool? isEncryptionAtHostEnabled = default, bool? isUltraSsdEnabled = default, bool? isFipsEnabled = default, GpuInstanceProfile? gpuInstanceProfile = default, Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, AgentPoolNetworkProfile networkProfile = null, bool? isOutboundNatDisabled = default, AgentPoolSecurityProfile securityProfile = null, AgentPoolGpuDriver? gpuDriver = default, int? gatewayPublicIPPrefixSize = default, bool? isArtifactStreamingEnabled = default, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual = null, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus = null, Azure.ResponseError statusProvisioningError = null, LocalDnsProfile localDnsProfile = null)
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
                virtualMachinesScale: default);
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
