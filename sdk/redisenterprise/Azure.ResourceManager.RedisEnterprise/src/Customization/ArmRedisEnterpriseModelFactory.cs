// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    // Keep released signatures and append firewallRules to preserve positional calls.
    // Omitted factory arguments leave rules undefined; empty sequences clear them.
    // Retain these overrides until generation preserves both parameter order and wire presence.
    [CodeGenSuppress("RedisEnterpriseClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(RedisEnterpriseHighAvailability?), typeof(RedisEnterpriseTlsVersion?), typeof(IEnumerable<RedisEnterpriseFirewallRule>), typeof(string), typeof(RedisEnterpriseProvisioningStatus?), typeof(RedisEnterpriseRedundancyMode?), typeof(RedisEnterpriseClusterResourceState?), typeof(string), typeof(IEnumerable<RedisEnterprisePrivateEndpointConnectionData>), typeof(string), typeof(RedisEnterpriseCustomerManagedKeyEncryption), typeof(IEnumerable<RedisEnterpriseMaintenanceWindow>), typeof(RedisEnterprisePublicNetworkAccess?), typeof(RedisEnterpriseKind?), typeof(RedisEnterpriseSku), typeof(IEnumerable<string>), typeof(ManagedServiceIdentity))]
    [CodeGenSuppress("RedisEnterpriseClusterPatch", typeof(RedisEnterpriseSku), typeof(RedisEnterpriseHighAvailability?), typeof(RedisEnterpriseTlsVersion?), typeof(IEnumerable<RedisEnterpriseFirewallRule>), typeof(string), typeof(RedisEnterpriseProvisioningStatus?), typeof(RedisEnterpriseRedundancyMode?), typeof(RedisEnterpriseClusterResourceState?), typeof(string), typeof(IEnumerable<RedisEnterprisePrivateEndpointConnectionData>), typeof(string), typeof(RedisEnterpriseCustomerManagedKeyEncryption), typeof(IEnumerable<RedisEnterpriseMaintenanceWindow>), typeof(RedisEnterprisePublicNetworkAccess?), typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>))]
    public static partial class ArmRedisEnterpriseModelFactory
    {
        /// <summary> Initializes cluster data with explicitly supplied firewall rules for mocking. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="highAvailability"> The high availability setting. </param>
        /// <param name="minimumTlsVersion"> The minimum supported TLS version. </param>
        /// <param name="hostName"> The cluster endpoint DNS name. </param>
        /// <param name="provisioningState"> The provisioning status. </param>
        /// <param name="redundancyMode"> The redundancy strategy. </param>
        /// <param name="resourceState"> The resource status. </param>
        /// <param name="redisVersion"> The Redis version. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="migratedEndpoint"> The source endpoint pointing to this cluster after migration. </param>
        /// <param name="customerManagedKeyEncryption"> Customer-managed key encryption settings. </param>
        /// <param name="maintenanceWindows"> Custom maintenance windows. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="kind"> The cluster kind. </param>
        /// <param name="sku"> The cluster SKU. </param>
        /// <param name="zones"> Availability zones. </param>
        /// <param name="identity"> Managed service identities. </param>
        /// <param name="firewallRules"> The complete rule set. An empty sequence sends an empty array to clear existing rules. With public access enabled, no rules allows all public source IPs. </param>
        /// <returns> Cluster data for mocking. </returns>
        public static RedisEnterpriseClusterData RedisEnterpriseClusterData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, RedisEnterpriseHighAvailability? highAvailability = default, RedisEnterpriseTlsVersion? minimumTlsVersion = default, string hostName = default, RedisEnterpriseProvisioningStatus? provisioningState = default, RedisEnterpriseRedundancyMode? redundancyMode = default, RedisEnterpriseClusterResourceState? resourceState = default, string redisVersion = default, IEnumerable<RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections = default, string migratedEndpoint = default, RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption = default, IEnumerable<RedisEnterpriseMaintenanceWindow> maintenanceWindows = default, RedisEnterprisePublicNetworkAccess? publicNetworkAccess = default, RedisEnterpriseKind? kind = default, RedisEnterpriseSku sku = default, IEnumerable<string> zones = default, ManagedServiceIdentity identity = default, IEnumerable<RedisEnterpriseFirewallRule> firewallRules = default)
        {
            var data = RedisEnterpriseClusterData(id, name, resourceType, systemData, tags, location, highAvailability, minimumTlsVersion, hostName, provisioningState, redundancyMode, resourceState, redisVersion, privateEndpointConnections, migratedEndpoint, customerManagedKeyEncryption, maintenanceWindows, publicNetworkAccess, kind, sku, zones, identity);
            if (firewallRules != null)
            {
                data.FirewallRules.Clear();
                foreach (RedisEnterpriseFirewallRule rule in firewallRules)
                {
                    data.FirewallRules.Add(rule);
                }
            }
            return data;
        }

        /// <summary> Initializes a cluster patch with explicitly supplied firewall rules for mocking. </summary>
        /// <param name="sku"> The cluster SKU. </param>
        /// <param name="highAvailability"> The high availability setting. </param>
        /// <param name="minimumTlsVersion"> The minimum supported TLS version. </param>
        /// <param name="hostName"> The cluster endpoint DNS name. </param>
        /// <param name="provisioningState"> The provisioning status. </param>
        /// <param name="redundancyMode"> The redundancy strategy. </param>
        /// <param name="resourceState"> The resource status. </param>
        /// <param name="redisVersion"> The Redis version. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="migratedEndpoint"> The source endpoint pointing to this cluster after migration. </param>
        /// <param name="customerManagedKeyEncryption"> Customer-managed key encryption settings. </param>
        /// <param name="maintenanceWindows"> Custom maintenance windows. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="identity"> Managed service identities. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="firewallRules"> The complete rule set. Omit this argument to leave rules unchanged on PATCH unless public access is being disabled. An empty sequence sends an empty array to clear existing rules. </param>
        /// <returns> A cluster patch for mocking. </returns>
        public static RedisEnterpriseClusterPatch RedisEnterpriseClusterPatch(RedisEnterpriseSku sku = default, RedisEnterpriseHighAvailability? highAvailability = default, RedisEnterpriseTlsVersion? minimumTlsVersion = default, string hostName = default, RedisEnterpriseProvisioningStatus? provisioningState = default, RedisEnterpriseRedundancyMode? redundancyMode = default, RedisEnterpriseClusterResourceState? resourceState = default, string redisVersion = default, IEnumerable<RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections = default, string migratedEndpoint = default, RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption = default, IEnumerable<RedisEnterpriseMaintenanceWindow> maintenanceWindows = default, RedisEnterprisePublicNetworkAccess? publicNetworkAccess = default, ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default, IEnumerable<RedisEnterpriseFirewallRule> firewallRules = default)
        {
            var patch = RedisEnterpriseClusterPatch(sku, highAvailability, minimumTlsVersion, hostName, provisioningState, redundancyMode, resourceState, redisVersion, privateEndpointConnections, migratedEndpoint, customerManagedKeyEncryption, maintenanceWindows, publicNetworkAccess, identity, tags);
            if (firewallRules != null)
            {
                patch.FirewallRules.Clear();
                foreach (RedisEnterpriseFirewallRule rule in firewallRules)
                {
                    patch.FirewallRules.Add(rule);
                }
            }
            return patch;
        }
    }
}
