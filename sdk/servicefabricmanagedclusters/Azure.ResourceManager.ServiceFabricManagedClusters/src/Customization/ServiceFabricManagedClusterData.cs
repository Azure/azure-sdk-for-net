// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedClusterData
    {
        /// <summary>
        /// A class representing the ServiceFabricManagedCluster data model.
        /// The managed cluster resource
        ///
        /// </summary>
        ///
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServiceFabricManagedClusterData(AzureLocation location)
        {
          Location = location;
        }

        /// <summary> Initializes a new instance of <see cref="ServiceFabricManagedClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The sku of the managed cluster. </param>
        /// <param name="dnsName"> The cluster dns name. </param>
        /// <param name="fqdn"> The fully qualified domain name associated with the public load balancer of the cluster. </param>
        /// <param name="ipv4Address"> The IPv4 address associated with the public load balancer of the cluster. </param>
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
        /// <param name="clusterCodeVersion"> The Service Fabric runtime version of the cluster. This property is required when **clusterUpgradeMode** is set to 'Manual'. To get list of available Service Fabric versions for new clusters use [ClusterVersion API](./ClusterVersion.md). To get the list of available version for existing clusters use **availableClusterVersions**. </param>
        /// <param name="clusterUpgradeMode">
        /// The upgrade mode of the cluster when new Service Fabric runtime version is available.
        ///
        /// </param>
        /// <param name="clusterUpgradeCadence"> Indicates when new cluster runtime version upgrades will be applied after they are released. By default is Wave0. Only applies when **clusterUpgradeMode** is set to 'Automatic'. </param>
        /// <param name="addOnFeatures"> List of add-on features to enable on the cluster. </param>
        /// <param name="isAutoOSUpgradeEnabled"> Setting this to true enables automatic OS upgrade for the node types that are created using any platform OS image with version 'latest'. The default value for this setting is false. </param>
        /// <param name="hasZoneResiliency"> Indicates if the cluster has zone resiliency. </param>
        /// <param name="applicationTypeVersionsCleanupPolicy"> The policy used to clean up unused versions. </param>
        /// <param name="isIPv6Enabled"> Setting this to true creates IPv6 address space for the default VNet used by the cluster. This setting cannot be changed once the cluster is created. The default value for this setting is false. </param>
        /// <param name="subnetId"> If specified, the node types for the cluster are created in this subnet instead of the default VNet. The **networkSecurityRules** specified for the cluster are also applied to this subnet. This setting cannot be changed once the cluster is created. </param>
        /// <param name="ipTags"> The list of IP tags associated with the default public IP address of the cluster. </param>
        /// <param name="ipv6Address"> IPv6 address for the cluster if IPv6 is enabled. </param>
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
        /// <param name="etag"> Azure resource etag. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        ///
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ServiceFabricManagedClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ServiceFabricManagedClustersSku sku, string dnsName, string fqdn, IPAddress ipv4Address, Guid? clusterId, ServiceFabricManagedClusterState? clusterState, IReadOnlyList<BinaryData> clusterCertificateThumbprints, int? clientConnectionPort, int? httpGatewayConnectionPort, string adminUserName, string adminPassword, IList<ManagedClusterLoadBalancingRule> loadBalancingRules, bool? isRdpAccessAllowed, IList<ServiceFabricManagedNetworkSecurityRule> networkSecurityRules, IList<ManagedClusterClientCertificate> clients, ManagedClusterAzureActiveDirectory azureActiveDirectory, IList<ClusterFabricSettingsSection> fabricSettings, ServiceFabricManagedResourceProvisioningState? provisioningState, string clusterCodeVersion, ManagedClusterUpgradeMode? clusterUpgradeMode, ManagedClusterUpgradeCadence? clusterUpgradeCadence, IList<ManagedClusterAddOnFeature> addOnFeatures, bool? isAutoOSUpgradeEnabled, bool? hasZoneResiliency, ApplicationTypeVersionsCleanupPolicy applicationTypeVersionsCleanupPolicy, bool? isIPv6Enabled, string subnetId, IList<ManagedClusterIPTag> ipTags, IPAddress ipv6Address, bool? isServicePublicIPEnabled, IList<ManagedClusterSubnet> auxiliarySubnets, IList<ManagedClusterServiceEndpoint> serviceEndpoints, ZonalUpdateMode? zonalUpdateMode, bool? useCustomVnet, ResourceIdentifier publicIPPrefixId, ResourceIdentifier publicIPv6PrefixId, ResourceIdentifier ddosProtectionPlanId, ManagedClusterUpgradePolicy upgradeDescription, int? httpGatewayTokenAuthConnectionPort, bool? isHttpGatewayExclusiveAuthModeEnabled, ETag? etag, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Sku = sku;
            DnsName = dnsName;
            Fqdn = fqdn;
            IPv4Address = ipv4Address;
            ClusterId = clusterId;
            ClusterState = clusterState;
            ClusterCertificateThumbprints = clusterCertificateThumbprints;
            ClientConnectionPort = clientConnectionPort;
            HttpGatewayConnectionPort = httpGatewayConnectionPort;
            AdminUserName = adminUserName;
            AdminPassword = adminPassword;
            LoadBalancingRules = loadBalancingRules;
            IsRdpAccessAllowed = isRdpAccessAllowed;
            NetworkSecurityRules = networkSecurityRules;
            Clients = clients;
            AzureActiveDirectory = azureActiveDirectory;
            FabricSettings = fabricSettings;
            ProvisioningState = provisioningState;
            ClusterCodeVersion = clusterCodeVersion;
            ClusterUpgradeMode = clusterUpgradeMode;
            ClusterUpgradeCadence = clusterUpgradeCadence;
            AddOnFeatures = addOnFeatures;
            IsAutoOSUpgradeEnabled = isAutoOSUpgradeEnabled;
            HasZoneResiliency = hasZoneResiliency;
            ApplicationTypeVersionsCleanupPolicy = applicationTypeVersionsCleanupPolicy;
            IsIPv6Enabled = isIPv6Enabled;
            SubnetId = subnetId;
            IPTags = ipTags;
            IPv6Address = ipv6Address;
            IsServicePublicIPEnabled = isServicePublicIPEnabled;
            AuxiliarySubnets = auxiliarySubnets;
            ServiceEndpoints = serviceEndpoints;
            ZonalUpdateMode = zonalUpdateMode;
            UseCustomVnet = useCustomVnet;
            PublicIPPrefixId = publicIPPrefixId;
            PublicIPv6PrefixId = publicIPv6PrefixId;
            DdosProtectionPlanId = ddosProtectionPlanId;
            UpgradeDescription = upgradeDescription.ToClusterUpgradePolicy();
            HttpGatewayTokenAuthConnectionPort = httpGatewayTokenAuthConnectionPort;
            IsHttpGatewayExclusiveAuthModeEnabled = isHttpGatewayExclusiveAuthModeEnabled;
            ETag = etag;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above. If token-based authentication is used, HttpGatewayTokenAuthConnectionPort must be defined. </summary>
        ///
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHttpGatewayExclusiveAuthModeEnabled
        {
            get => EnableHttpGatewayExclusiveAuthMode is null ? null : EnableHttpGatewayExclusiveAuthMode.Value;
            set
            {
                EnableHttpGatewayExclusiveAuthMode = value;
            }
        }

        /*/// <summary> The policy to use when upgrading the cluster. </summary>
        ///
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedClusterHealthPolicy UpgradeDescription
        {
            get;
            set;
        }*/
    }
}
