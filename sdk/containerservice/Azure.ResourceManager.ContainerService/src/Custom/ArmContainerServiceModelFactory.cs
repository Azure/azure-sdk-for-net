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
    }
}
