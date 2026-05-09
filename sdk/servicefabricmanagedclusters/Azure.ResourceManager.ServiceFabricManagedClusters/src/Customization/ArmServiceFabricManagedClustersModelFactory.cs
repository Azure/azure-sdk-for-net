// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public static partial class ArmServiceFabricManagedClustersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ServiceFabricManagedClusters.ServiceFabricManagedApplicationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Describes the managed identities for an Azure resource. </param>
        /// <param name="provisioningState"> The current deployment or provisioning state, which only appears in the response. </param>
        /// <param name="version">
        /// The version of the application type as defined in the application manifest.
        /// This name must be the full Arm Resource ID for the referenced application type version.
        /// </param>
        /// <param name="parameters"> List of application parameters with overridden values from their default values specified in the application manifest. </param>
        /// <param name="upgradePolicy"> Describes the policy for a monitored application upgrade. </param>
        /// <param name="managedIdentities"> List of user assigned identities for the application, each mapped to a friendly name. </param>
        /// <returns> A new <see cref="ServiceFabricManagedClusters.ServiceFabricManagedApplicationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedApplicationData ServiceFabricManagedApplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location = default, ManagedServiceIdentity identity = null, string provisioningState = null, string version = null, IDictionary<string, string> parameters = null, ApplicationUpgradePolicy upgradePolicy = null, IEnumerable<ApplicationUserAssignedIdentityInfo> managedIdentities = null)
            => ServiceFabricManagedApplicationData(id, name, resourceType, systemData, location, managedIdentities, provisioningState, version, parameters, upgradePolicy, tags, identity);

        // Backward-compat: pre-overhaul signature had baseSizeTiB and extendedCapacitySizeTiB as long? (nullable).
        // The mgmt generator's flatten/lift-to-nullable overhaul now exposes these as non-nullable long.
        /// <summary> Initializes a new instance of <see cref="Models.NodeTypeVmssExtension"/>. </summary>
        /// <param name="name"> The name of the extension. </param>
        /// <param name="publisher"> The name of the extension handler publisher. </param>
        /// <param name="vmssExtensionPropertiesType"> Specifies the type of the extension; an example is "CustomScriptExtension". </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="autoUpgradeMinorVersion"> Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true. </param>
        /// <param name="settings"> Json formatted public settings for the extension. </param>
        /// <param name="protectedSettings"> The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all. </param>
        /// <param name="forceUpdateTag"> If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed. </param>
        /// <param name="provisionAfterExtensions"> Collection of extension names after which this extension needs to be provisioned. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="isAutomaticUpgradeEnabled"> Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available. </param>
        /// <param name="setupOrder"> Indicates the setup order for the extension. </param>
        /// <returns> A new <see cref="Models.NodeTypeVmssExtension"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NodeTypeVmssExtension NodeTypeVmssExtension(string name, string publisher, string vmssExtensionPropertiesType, string typeHandlerVersion, bool? autoUpgradeMinorVersion, BinaryData settings, BinaryData protectedSettings, string forceUpdateTag, IEnumerable<string> provisionAfterExtensions, string provisioningState, bool? isAutomaticUpgradeEnabled, IEnumerable<VmssExtensionSetupOrder> setupOrder)
        {
            provisionAfterExtensions ??= new List<string>();
            setupOrder ??= new List<VmssExtensionSetupOrder>();

            return new NodeTypeVmssExtension(
                        name,
                        new VmssExtensionProperties(publisher,
                                vmssExtensionPropertiesType,
                                typeHandlerVersion,
                                autoUpgradeMinorVersion,
                                settings,
                                protectedSettings,
                                forceUpdateTag,
                                provisionAfterExtensions?.ToList(),
                                provisioningState,
                                isAutomaticUpgradeEnabled,
                                setupOrder?.ToList(),
                                null),
                        null);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="dnsName"> The cluster dns name. </param>
        /// <param name="fqdn"> The fully qualified domain name associated with the public load balancer of the cluster. </param>
        /// <param name="iPv4Address"> The IPv4 address associated with the public load balancer of the cluster. </param>
        /// <param name="clusterId"> A service generated unique identifier for the cluster resource. </param>
        /// <param name="clusterState"> The current state of the cluster. </param>
        /// <param name="clusterCertificateThumbprints"> List of thumbprints of the cluster certificates. </param>
        /// <param name="clientConnectionPort"> The port used for client connections to the cluster. </param>
        /// <param name="httpGatewayConnectionPort"> The port used for HTTP connections to the cluster. </param>
        /// <param name="adminUserName"> VM admin user name. </param>
        /// <param name="adminPassword"> VM admin user password. </param>
        /// <param name="loadBalancingRules"> Load balancing rules that are applied to the public load balancer of the cluster. </param>
        /// <param name="isRdpAccessAllowed"> Setting this to true enables RDP access to the VM. The default NSG rule opens RDP port to Internet which can be overridden with custom Network Security Rules. The default value for this setting is false. </param>
        /// <param name="networkSecurityRules"> Custom Network Security Rules that are applied to the Virtual Network of the cluster. </param>
        /// <param name="clients"> Client certificates that are allowed to manage the cluster. </param>
        /// <param name="azureActiveDirectory"> The AAD authentication settings of the cluster. </param>
        /// <param name="fabricSettings"> The list of custom fabric settings to configure the cluster. </param>
        /// <param name="provisioningState"> The provisioning state of the managed cluster resource. </param>
        /// <param name="clusterCodeVersion"> The Service Fabric runtime version of the cluster. This property is required when <b>clusterUpgradeMode</b> is set to 'Manual'. To get list of available Service Fabric versions for new clusters use [ClusterVersion API](./ClusterVersion.md). To get the list of available version for existing clusters use <b>availableClusterVersions</b>. </param>
        /// <param name="clusterUpgradeMode"> The upgrade mode of the cluster when new Service Fabric runtime version is available. </param>
        /// <param name="clusterUpgradeCadence"> Indicates when new cluster runtime version upgrades will be applied after they are released. By default is Wave0. Only applies when <b>clusterUpgradeMode</b> is set to 'Automatic'. </param>
        /// <param name="addOnFeatures"> List of add-on features to enable on the cluster. </param>
        /// <param name="isAutoOSUpgradeEnabled"> Enables automatic OS upgrade for node types created using OS images with version 'latest'. The default value for this setting is false. </param>
        /// <param name="hasZoneResiliency"> Indicates if the cluster has zone resiliency. </param>
        /// <param name="isIPv6Enabled"> Setting this to true creates IPv6 address space for the default VNet used by the cluster. This setting cannot be changed once the cluster is created. The default value for this setting is false. </param>
        /// <param name="subnetId"> If specified, the node types for the cluster are created in this subnet instead of the default VNet. The <b>networkSecurityRules</b> specified for the cluster are also applied to this subnet. This setting cannot be changed once the cluster is created. </param>
        /// <param name="ipTags"> The list of IP tags associated with the default public IP address of the cluster. </param>
        /// <param name="iPv6Address"> IPv6 address for the cluster if IPv6 is enabled. </param>
        /// <param name="isServicePublicIPEnabled"> Setting this to true will link the IPv4 address as the ServicePublicIP of the IPv6 address. It can only be set to True if IPv6 is enabled on the cluster. </param>
        /// <param name="auxiliarySubnets"> Auxiliary subnets for the cluster. </param>
        /// <param name="serviceEndpoints"> Service endpoints for subnets in the cluster. </param>
        /// <param name="zonalUpdateMode"> Indicates the update mode for Cross Az clusters. </param>
        /// <param name="useCustomVnet"> For new clusters, this parameter indicates that it uses Bring your own VNet, but the subnet is specified at node type level; and for such clusters, the subnetId property is required for node types. </param>
        /// <param name="publicIPPrefixId"> Specify the resource id of a public IPv4 prefix that the load balancer will allocate a public IPv4 address from. This setting cannot be changed once the cluster is created. </param>
        /// <param name="publicIPv6PrefixId"> Specify the resource id of a public IPv6 prefix that the load balancer will allocate a public IPv6 address from. This setting cannot be changed once the cluster is created. </param>
        /// <param name="ddosProtectionPlanId"> Specify the resource id of a DDoS network protection plan that will be associated with the virtual network of the cluster. </param>
        /// <param name="upgradeDescription"> The policy to use when upgrading the cluster. </param>
        /// <param name="httpGatewayTokenAuthConnectionPort"> The port used for token-auth based HTTPS connections to the cluster. Cannot be set to the same port as HttpGatewayEndpoint. </param>
        /// <param name="isHttpGatewayExclusiveAuthModeEnabled"> If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above. If token-based authentication is used, HttpGatewayTokenAuthConnectionPort must be defined. </param>
        /// <param name="autoGeneratedDomainNameLabelScope"> This property is the entry point to using a public CA cert for your cluster cert. It specifies the level of reuse allowed for the custom FQDN created, matching the subject of the public CA cert. </param>
        /// <param name="allocatedOutboundPorts"> The number of outbound ports allocated for SNAT for each node in the backend pool of the default load balancer. The default value is 0 which provides dynamic port allocation based on pool size. </param>
        /// <param name="vmImage"> The VM image the node types are configured with. This property controls the Service Fabric component packages to be used for the cluster. Allowed values are: 'Windows'. The default value is 'Windows'. </param>
        /// <param name="enableOutboundOnlyNodeTypes"> Enable the creation of node types with only outbound traffic enabled. If set, a separate load balancer backend pool will be created for node types with inbound traffic enabled. Can only be set at the time of cluster creation. </param>
        /// <param name="skipManagedNsgAssignment"> Determines whether to skip the assignment of the managed network security group (SF-NSG) to the cluster subnet when using a bring-your-own virtual network (BYOVNET) configuration. The default value is false. </param>
        /// <param name="maxUnusedVersionsToKeep"> Number of unused versions per application type to keep. </param>
        /// <param name="etag"> If eTag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields.",. </param>
        /// <param name="skuName"> Sku Name. </param>
        /// <returns> A new <see cref="ServiceFabricManagedClusters.ServiceFabricManagedClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedClusterData ServiceFabricManagedClusterData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            IDictionary<string, string> tags,
            AzureLocation location,
            string dnsName,
            string fqdn,
            IPAddress iPv4Address,
            Guid? clusterId,
            ServiceFabricManagedClusterState? clusterState,
            IEnumerable<BinaryData> clusterCertificateThumbprints,
            int? clientConnectionPort,
            int? httpGatewayConnectionPort,
            string adminUserName,
            string adminPassword,
            IEnumerable<ManagedClusterLoadBalancingRule> loadBalancingRules,
            bool? isRdpAccessAllowed,
            IEnumerable<ServiceFabricManagedNetworkSecurityRule> networkSecurityRules,
            IEnumerable<ManagedClusterClientCertificate> clients,
            ManagedClusterAzureActiveDirectory azureActiveDirectory,
            IEnumerable<ClusterFabricSettingsSection> fabricSettings,
            ServiceFabricManagedResourceProvisioningState? provisioningState,
            string clusterCodeVersion,
            ManagedClusterUpgradeMode? clusterUpgradeMode,
            ManagedClusterUpgradeCadence? clusterUpgradeCadence,
            IEnumerable<ManagedClusterAddOnFeature> addOnFeatures,
            bool? isAutoOSUpgradeEnabled,
            bool? hasZoneResiliency,
            bool? isIPv6Enabled,
            string subnetId,
            IEnumerable<ManagedClusterIPTag> ipTags,
            IPAddress iPv6Address,
            bool? isServicePublicIPEnabled,
            IEnumerable<ManagedClusterSubnet> auxiliarySubnets,
            IEnumerable<ManagedClusterServiceEndpoint> serviceEndpoints,
            ZonalUpdateMode? zonalUpdateMode,
            bool? useCustomVnet,
            ResourceIdentifier publicIPPrefixId,
            ResourceIdentifier publicIPv6PrefixId,
            ResourceIdentifier ddosProtectionPlanId,
            ManagedClusterUpgradePolicy upgradeDescription,
            int? httpGatewayTokenAuthConnectionPort,
            bool? isHttpGatewayExclusiveAuthModeEnabled,
            AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope,
            int? allocatedOutboundPorts,
            string vmImage,
            bool? enableOutboundOnlyNodeTypes,
            bool? skipManagedNsgAssignment,
            int? maxUnusedVersionsToKeep,
            ETag? etag,
            ServiceFabricManagedClustersSkuName? skuName)
            => ServiceFabricManagedClusterData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                dnsName,
                fqdn,
                iPv4Address,
                clusterId,
                clusterState,
                clusterCertificateThumbprints,
                clientConnectionPort,
                httpGatewayConnectionPort,
                adminUserName,
                adminPassword,
                loadBalancingRules,
                isRdpAccessAllowed,
                networkSecurityRules,
                clients,
                azureActiveDirectory,
                fabricSettings,
                provisioningState,
                clusterCodeVersion,
                clusterUpgradeMode,
                clusterUpgradeCadence,
                addOnFeatures,
                isAutoOSUpgradeEnabled,
                hasZoneResiliency,
                isIPv6Enabled,
                subnetId,
                ipTags,
                iPv6Address,
                isServicePublicIPEnabled,
                auxiliarySubnets,
                serviceEndpoints,
                zonalUpdateMode,
                useCustomVnet,
                publicIPPrefixId,
                publicIPv6PrefixId,
                ddosProtectionPlanId,
                upgradeDescription,
                httpGatewayTokenAuthConnectionPort,
                isHttpGatewayExclusiveAuthModeEnabled,
                autoGeneratedDomainNameLabelScope,
                allocatedOutboundPorts,
                vmImage,
                enableOutboundOnlyNodeTypes,
                skipManagedNsgAssignment,
                maxUnusedVersionsToKeep,
                etag,
                skuName.GetValueOrDefault());

        // Workaround: The generator has a bug that when an overload is created in customized code with the same parameter list, but the nullability of some parameters is different,
        // the generator somehow treat the overload as a duplicated method, and the generated overload with different nullability will no longer be generated.
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="dnsName"> The cluster dns name. </param>
        /// <param name="fqdn"> The fully qualified domain name associated with the public load balancer of the cluster. </param>
        /// <param name="iPv4Address"> The IPv4 address associated with the public load balancer of the cluster. </param>
        /// <param name="clusterId"> A service generated unique identifier for the cluster resource. </param>
        /// <param name="clusterState"> The current state of the cluster. </param>
        /// <param name="clusterCertificateThumbprints"> List of thumbprints of the cluster certificates. </param>
        /// <param name="clientConnectionPort"> The port used for client connections to the cluster. </param>
        /// <param name="httpGatewayConnectionPort"> The port used for HTTP connections to the cluster. </param>
        /// <param name="adminUserName"> VM admin user name. </param>
        /// <param name="adminPassword"> VM admin user password. </param>
        /// <param name="loadBalancingRules"> Load balancing rules that are applied to the public load balancer of the cluster. </param>
        /// <param name="isRdpAccessAllowed"> Setting this to true enables RDP access to the VM. The default NSG rule opens RDP port to Internet which can be overridden with custom Network Security Rules. The default value for this setting is false. </param>
        /// <param name="networkSecurityRules"> Custom Network Security Rules that are applied to the Virtual Network of the cluster. </param>
        /// <param name="clients"> Client certificates that are allowed to manage the cluster. </param>
        /// <param name="azureActiveDirectory"> The AAD authentication settings of the cluster. </param>
        /// <param name="fabricSettings"> The list of custom fabric settings to configure the cluster. </param>
        /// <param name="provisioningState"> The provisioning state of the managed cluster resource. </param>
        /// <param name="clusterCodeVersion"> The Service Fabric runtime version of the cluster. This property is required when <b>clusterUpgradeMode</b> is set to 'Manual'. To get list of available Service Fabric versions for new clusters use [ClusterVersion API](./ClusterVersion.md). To get the list of available version for existing clusters use <b>availableClusterVersions</b>. </param>
        /// <param name="clusterUpgradeMode"> The upgrade mode of the cluster when new Service Fabric runtime version is available. </param>
        /// <param name="clusterUpgradeCadence"> Indicates when new cluster runtime version upgrades will be applied after they are released. By default is Wave0. Only applies when <b>clusterUpgradeMode</b> is set to 'Automatic'. </param>
        /// <param name="addOnFeatures"> List of add-on features to enable on the cluster. </param>
        /// <param name="isAutoOSUpgradeEnabled"> Enables automatic OS upgrade for node types created using OS images with version 'latest'. The default value for this setting is false. </param>
        /// <param name="hasZoneResiliency"> Indicates if the cluster has zone resiliency. </param>
        /// <param name="isIPv6Enabled"> Setting this to true creates IPv6 address space for the default VNet used by the cluster. This setting cannot be changed once the cluster is created. The default value for this setting is false. </param>
        /// <param name="subnetId"> If specified, the node types for the cluster are created in this subnet instead of the default VNet. The <b>networkSecurityRules</b> specified for the cluster are also applied to this subnet. This setting cannot be changed once the cluster is created. </param>
        /// <param name="ipTags"> The list of IP tags associated with the default public IP address of the cluster. </param>
        /// <param name="iPv6Address"> IPv6 address for the cluster if IPv6 is enabled. </param>
        /// <param name="isServicePublicIPEnabled"> Setting this to true will link the IPv4 address as the ServicePublicIP of the IPv6 address. It can only be set to True if IPv6 is enabled on the cluster. </param>
        /// <param name="auxiliarySubnets"> Auxiliary subnets for the cluster. </param>
        /// <param name="serviceEndpoints"> Service endpoints for subnets in the cluster. </param>
        /// <param name="zonalUpdateMode"> Indicates the update mode for Cross Az clusters. </param>
        /// <param name="useCustomVnet"> For new clusters, this parameter indicates that it uses Bring your own VNet, but the subnet is specified at node type level; and for such clusters, the subnetId property is required for node types. </param>
        /// <param name="publicIPPrefixId"> Specify the resource id of a public IPv4 prefix that the load balancer will allocate a public IPv4 address from. This setting cannot be changed once the cluster is created. </param>
        /// <param name="publicIPv6PrefixId"> Specify the resource id of a public IPv6 prefix that the load balancer will allocate a public IPv6 address from. This setting cannot be changed once the cluster is created. </param>
        /// <param name="ddosProtectionPlanId"> Specify the resource id of a DDoS network protection plan that will be associated with the virtual network of the cluster. </param>
        /// <param name="upgradeDescription"> The policy to use when upgrading the cluster. </param>
        /// <param name="httpGatewayTokenAuthConnectionPort"> The port used for token-auth based HTTPS connections to the cluster. Cannot be set to the same port as HttpGatewayEndpoint. </param>
        /// <param name="isHttpGatewayExclusiveAuthModeEnabled"> If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above. If token-based authentication is used, HttpGatewayTokenAuthConnectionPort must be defined. </param>
        /// <param name="autoGeneratedDomainNameLabelScope"> This property is the entry point to using a public CA cert for your cluster cert. It specifies the level of reuse allowed for the custom FQDN created, matching the subject of the public CA cert. </param>
        /// <param name="allocatedOutboundPorts"> The number of outbound ports allocated for SNAT for each node in the backend pool of the default load balancer. The default value is 0 which provides dynamic port allocation based on pool size. </param>
        /// <param name="vmImage"> The VM image the node types are configured with. This property controls the Service Fabric component packages to be used for the cluster. Allowed values are: 'Windows'. The default value is 'Windows'. </param>
        /// <param name="enableOutboundOnlyNodeTypes"> Enable the creation of node types with only outbound traffic enabled. If set, a separate load balancer backend pool will be created for node types with inbound traffic enabled. Can only be set at the time of cluster creation. </param>
        /// <param name="skipManagedNsgAssignment"> Determines whether to skip the assignment of the managed network security group (SF-NSG) to the cluster subnet when using a bring-your-own virtual network (BYOVNET) configuration. The default value is false. </param>
        /// <param name="maxUnusedVersionsToKeep"> Number of unused versions per application type to keep. </param>
        /// <param name="etag"> If eTag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields.",. </param>
        /// <param name="skuName"> Sku Name. </param>
        /// <returns> A new <see cref="ServiceFabricManagedClusters.ServiceFabricManagedClusterData"/> instance for mocking. </returns>
        public static ServiceFabricManagedClusterData ServiceFabricManagedClusterData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            IDictionary<string, string> tags = default,
            AzureLocation location = default,
            string dnsName = default,
            string fqdn = default,
            IPAddress iPv4Address = default,
            Guid? clusterId = default,
            ServiceFabricManagedClusterState? clusterState = default,
            IEnumerable<BinaryData> clusterCertificateThumbprints = default,
            int? clientConnectionPort = default,
            int? httpGatewayConnectionPort = default,
            string adminUserName = default,
            string adminPassword = default,
            IEnumerable<ManagedClusterLoadBalancingRule> loadBalancingRules = default,
            bool? isRdpAccessAllowed = default,
            IEnumerable<ServiceFabricManagedNetworkSecurityRule> networkSecurityRules = default,
            IEnumerable<ManagedClusterClientCertificate> clients = default,
            ManagedClusterAzureActiveDirectory azureActiveDirectory = default,
            IEnumerable<ClusterFabricSettingsSection> fabricSettings = default,
            ServiceFabricManagedResourceProvisioningState? provisioningState = default,
            string clusterCodeVersion = default,
            ManagedClusterUpgradeMode? clusterUpgradeMode = default,
            ManagedClusterUpgradeCadence? clusterUpgradeCadence = default,
            IEnumerable<ManagedClusterAddOnFeature> addOnFeatures = default,
            bool? isAutoOSUpgradeEnabled = default,
            bool? hasZoneResiliency = default,
            bool? isIPv6Enabled = default,
            string subnetId = default,
            IEnumerable<ManagedClusterIPTag> ipTags = default,
            IPAddress iPv6Address = default,
            bool? isServicePublicIPEnabled = default,
            IEnumerable<ManagedClusterSubnet> auxiliarySubnets = default,
            IEnumerable<ManagedClusterServiceEndpoint> serviceEndpoints = default,
            ZonalUpdateMode? zonalUpdateMode = default,
            bool? useCustomVnet = default,
            ResourceIdentifier publicIPPrefixId = default,
            ResourceIdentifier publicIPv6PrefixId = default,
            ResourceIdentifier ddosProtectionPlanId = default,
            ManagedClusterUpgradePolicy upgradeDescription = default,
            int? httpGatewayTokenAuthConnectionPort = default,
            bool? isHttpGatewayExclusiveAuthModeEnabled = default,
            AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default,
            int? allocatedOutboundPorts = default,
            string vmImage = default,
            bool? enableOutboundOnlyNodeTypes = default,
            bool? skipManagedNsgAssignment = default,
            int? maxUnusedVersionsToKeep = default,
            ETag? etag = default,
            ServiceFabricManagedClustersSkuName skuName = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new ServiceFabricManagedClusterData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                dnsName is null && fqdn is null && iPv4Address is null && clusterId is null && clusterState is null && clusterCertificateThumbprints is null && clientConnectionPort is null && httpGatewayConnectionPort is null && adminUserName is null && adminPassword is null && loadBalancingRules is null && isRdpAccessAllowed is null && networkSecurityRules is null && clients is null && azureActiveDirectory is null && fabricSettings is null && provisioningState is null && clusterCodeVersion is null && clusterUpgradeMode is null && clusterUpgradeCadence is null && addOnFeatures is null && isAutoOSUpgradeEnabled is null && hasZoneResiliency is null && isIPv6Enabled is null && subnetId is null && ipTags is null && iPv6Address is null && isServicePublicIPEnabled is null && auxiliarySubnets is null && serviceEndpoints is null && zonalUpdateMode is null && useCustomVnet is null && publicIPPrefixId is null && publicIPv6PrefixId is null && ddosProtectionPlanId is null && upgradeDescription is null && httpGatewayTokenAuthConnectionPort is null && isHttpGatewayExclusiveAuthModeEnabled is null && autoGeneratedDomainNameLabelScope is null && allocatedOutboundPorts is null && vmImage is null && enableOutboundOnlyNodeTypes is null && skipManagedNsgAssignment is null && maxUnusedVersionsToKeep is null ? default : new ManagedClusterProperties(
                    dnsName,
                    fqdn,
                    iPv4Address,
                    clusterId,
                    clusterState,
                    (clusterCertificateThumbprints ?? new ChangeTrackingList<BinaryData>()).ToList(),
                    clientConnectionPort,
                    httpGatewayConnectionPort,
                    adminUserName,
                    adminPassword,
                    (loadBalancingRules ?? new ChangeTrackingList<ManagedClusterLoadBalancingRule>()).ToList(),
                    isRdpAccessAllowed,
                    (networkSecurityRules ?? new ChangeTrackingList<ServiceFabricManagedNetworkSecurityRule>()).ToList(),
                    (clients ?? new ChangeTrackingList<ManagedClusterClientCertificate>()).ToList(),
                    azureActiveDirectory,
                    (fabricSettings ?? new ChangeTrackingList<ClusterFabricSettingsSection>()).ToList(),
                    provisioningState,
                    clusterCodeVersion,
                    clusterUpgradeMode,
                    clusterUpgradeCadence,
                    (addOnFeatures ?? new ChangeTrackingList<ManagedClusterAddOnFeature>()).ToList(),
                    isAutoOSUpgradeEnabled,
                    hasZoneResiliency,
                    new ApplicationTypeVersionsCleanupPolicy(maxUnusedVersionsToKeep.GetValueOrDefault(), null),
                    isIPv6Enabled,
                    subnetId,
                    (ipTags ?? new ChangeTrackingList<ManagedClusterIPTag>()).ToList(),
                    iPv6Address,
                    isServicePublicIPEnabled,
                    (auxiliarySubnets ?? new ChangeTrackingList<ManagedClusterSubnet>()).ToList(),
                    (serviceEndpoints ?? new ChangeTrackingList<ManagedClusterServiceEndpoint>()).ToList(),
                    zonalUpdateMode,
                    useCustomVnet,
                    publicIPPrefixId,
                    publicIPv6PrefixId,
                    ddosProtectionPlanId,
                    upgradeDescription,
                    httpGatewayTokenAuthConnectionPort,
                    isHttpGatewayExclusiveAuthModeEnabled,
                    autoGeneratedDomainNameLabelScope,
                    allocatedOutboundPorts,
                    vmImage,
                    enableOutboundOnlyNodeTypes,
                    skipManagedNsgAssignment,
                    null),
                etag,
                new ServiceFabricManagedClustersSku(skuName, null));
        }
    }
}
