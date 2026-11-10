// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    // Keep the released optional signatures for omitted rules. The new overloads require
    // firewallRules to distinguish explicit null, with [Optional] on the preceding parameters
    // so named calls remain convenient without moving released positional parameters.
    // Retain these overrides until generation preserves both parameter order and wire presence.
    [CodeGenSuppress("RedisEnterpriseClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(RedisEnterpriseHighAvailability?), typeof(RedisEnterpriseTlsVersion?), typeof(IEnumerable<FirewallRule>), typeof(string), typeof(RedisEnterpriseProvisioningStatus?), typeof(RedisEnterpriseRedundancyMode?), typeof(RedisEnterpriseClusterResourceState?), typeof(string), typeof(IEnumerable<RedisEnterprisePrivateEndpointConnectionData>), typeof(string), typeof(RedisEnterpriseCustomerManagedKeyEncryption), typeof(IEnumerable<RedisEnterpriseMaintenanceWindow>), typeof(RedisEnterprisePublicNetworkAccess?), typeof(RedisEnterpriseKind?), typeof(RedisEnterpriseSku), typeof(IEnumerable<string>), typeof(ManagedServiceIdentity))]
    [CodeGenSuppress("RedisEnterpriseClusterPatch", typeof(RedisEnterpriseSku), typeof(RedisEnterpriseHighAvailability?), typeof(RedisEnterpriseTlsVersion?), typeof(IEnumerable<FirewallRule>), typeof(string), typeof(RedisEnterpriseProvisioningStatus?), typeof(RedisEnterpriseRedundancyMode?), typeof(RedisEnterpriseClusterResourceState?), typeof(string), typeof(IEnumerable<RedisEnterprisePrivateEndpointConnectionData>), typeof(string), typeof(RedisEnterpriseCustomerManagedKeyEncryption), typeof(IEnumerable<RedisEnterpriseMaintenanceWindow>), typeof(RedisEnterprisePublicNetworkAccess?), typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>))]
    [CodeGenSuppress("RedisEnterpriseClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(RedisEnterpriseHighAvailability?), typeof(RedisEnterpriseTlsVersion?), typeof(string), typeof(RedisEnterpriseProvisioningStatus?), typeof(RedisEnterpriseRedundancyMode?), typeof(RedisEnterpriseClusterResourceState?), typeof(string), typeof(IEnumerable<RedisEnterprisePrivateEndpointConnectionData>), typeof(string), typeof(RedisEnterpriseCustomerManagedKeyEncryption), typeof(IEnumerable<RedisEnterpriseMaintenanceWindow>), typeof(RedisEnterprisePublicNetworkAccess?), typeof(RedisEnterpriseKind?), typeof(RedisEnterpriseSku), typeof(IEnumerable<string>), typeof(ManagedServiceIdentity))]
    [CodeGenSuppress("RedisEnterpriseClusterPatch", typeof(RedisEnterpriseSku), typeof(RedisEnterpriseHighAvailability?), typeof(RedisEnterpriseTlsVersion?), typeof(string), typeof(RedisEnterpriseProvisioningStatus?), typeof(RedisEnterpriseRedundancyMode?), typeof(RedisEnterpriseClusterResourceState?), typeof(string), typeof(IEnumerable<RedisEnterprisePrivateEndpointConnectionData>), typeof(string), typeof(RedisEnterpriseCustomerManagedKeyEncryption), typeof(IEnumerable<RedisEnterpriseMaintenanceWindow>), typeof(RedisEnterprisePublicNetworkAccess?), typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>))]
    public static partial class ArmRedisEnterpriseModelFactory
    {
        /// <summary> Initializes cluster data for mocking. </summary>
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
        /// <returns> Cluster data for mocking. </returns>
        public static RedisEnterpriseClusterData RedisEnterpriseClusterData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, RedisEnterpriseHighAvailability? highAvailability = default, RedisEnterpriseTlsVersion? minimumTlsVersion = default, string hostName = default, RedisEnterpriseProvisioningStatus? provisioningState = default, RedisEnterpriseRedundancyMode? redundancyMode = default, RedisEnterpriseClusterResourceState? resourceState = default, string redisVersion = default, IEnumerable<RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections = default, string migratedEndpoint = default, RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption = default, IEnumerable<RedisEnterpriseMaintenanceWindow> maintenanceWindows = default, RedisEnterprisePublicNetworkAccess? publicNetworkAccess = default, RedisEnterpriseKind? kind = default, RedisEnterpriseSku sku = default, IEnumerable<string> zones = default, ManagedServiceIdentity identity = default)
        {
            return new RedisEnterpriseClusterData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                highAvailability is null && minimumTlsVersion is null && customerManagedKeyEncryption is null && maintenanceWindows is null && hostName is null && provisioningState is null && redundancyMode is null && resourceState is null && redisVersion is null && privateEndpointConnections is null && migratedEndpoint is null && publicNetworkAccess is null ? default : new ClusterCreateProperties(
                    highAvailability,
                    minimumTlsVersion,
                    customerManagedKeyEncryption is null ? default : new ClusterPropertiesEncryption(customerManagedKeyEncryption, default),
                    maintenanceWindows is null ? default : new MaintenanceConfiguration(maintenanceWindows.ToList(), default),
                    default,
                    hostName,
                    provisioningState,
                    redundancyMode,
                    resourceState,
                    redisVersion,
                    (privateEndpointConnections ?? new ChangeTrackingList<RedisEnterprisePrivateEndpointConnectionData>()).ToList(),
                    migratedEndpoint,
                    default,
                    publicNetworkAccess),
                kind,
                sku,
                (zones ?? new ChangeTrackingList<string>()).ToList(),
                identity,
                default);
        }

        /// <summary> Initializes a cluster patch for mocking. </summary>
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
        /// <returns> A cluster patch for mocking. </returns>
        public static RedisEnterpriseClusterPatch RedisEnterpriseClusterPatch(RedisEnterpriseSku sku = default, RedisEnterpriseHighAvailability? highAvailability = default, RedisEnterpriseTlsVersion? minimumTlsVersion = default, string hostName = default, RedisEnterpriseProvisioningStatus? provisioningState = default, RedisEnterpriseRedundancyMode? redundancyMode = default, RedisEnterpriseClusterResourceState? resourceState = default, string redisVersion = default, IEnumerable<RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections = default, string migratedEndpoint = default, RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption = default, IEnumerable<RedisEnterpriseMaintenanceWindow> maintenanceWindows = default, RedisEnterprisePublicNetworkAccess? publicNetworkAccess = default, ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default)
        {
            return new RedisEnterpriseClusterPatch(sku,
                highAvailability is null && minimumTlsVersion is null && customerManagedKeyEncryption is null && maintenanceWindows is null && hostName is null && provisioningState is null && redundancyMode is null && resourceState is null && redisVersion is null && privateEndpointConnections is null && migratedEndpoint is null && publicNetworkAccess is null ? default : new ClusterUpdateProperties(
                    highAvailability,
                    minimumTlsVersion,
                    customerManagedKeyEncryption is null ? default : new ClusterPropertiesEncryption(customerManagedKeyEncryption, default),
                    maintenanceWindows is null ? default : new MaintenanceConfiguration(maintenanceWindows.ToList(), default),
                    default,
                    hostName,
                    provisioningState,
                    redundancyMode,
                    resourceState,
                    redisVersion,
                    (privateEndpointConnections ?? new ChangeTrackingList<RedisEnterprisePrivateEndpointConnectionData>()).ToList(),
                    migratedEndpoint,
                    default,
                    publicNetworkAccess),
                identity, tags ?? new ChangeTrackingDictionary<string, string>(), default);
        }

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
        /// <param name="firewallRules"> The complete rule set. Null sends JSON null; an empty sequence sends an empty array. Both clear existing rules. With public access enabled, no rules allows all public source IPs. </param>
        /// <returns> Cluster data for mocking. </returns>
        public static RedisEnterpriseClusterData RedisEnterpriseClusterData([Optional] ResourceIdentifier id, [Optional] string name, [Optional] ResourceType resourceType, [Optional] SystemData systemData, [Optional] IDictionary<string, string> tags, [Optional] AzureLocation location, [Optional] RedisEnterpriseHighAvailability? highAvailability, [Optional] RedisEnterpriseTlsVersion? minimumTlsVersion, [Optional] string hostName, [Optional] RedisEnterpriseProvisioningStatus? provisioningState, [Optional] RedisEnterpriseRedundancyMode? redundancyMode, [Optional] RedisEnterpriseClusterResourceState? resourceState, [Optional] string redisVersion, [Optional] IEnumerable<RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections, [Optional] string migratedEndpoint, [Optional] RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption, [Optional] IEnumerable<RedisEnterpriseMaintenanceWindow> maintenanceWindows, [Optional] RedisEnterprisePublicNetworkAccess? publicNetworkAccess, [Optional] RedisEnterpriseKind? kind, [Optional] RedisEnterpriseSku sku, [Optional] IEnumerable<string> zones, [Optional] ManagedServiceIdentity identity, IEnumerable<FirewallRule> firewallRules)
        {
            var data = RedisEnterpriseClusterData(id, name, resourceType, systemData, tags, location, highAvailability, minimumTlsVersion, hostName, provisioningState, redundancyMode, resourceState, redisVersion, privateEndpointConnections, migratedEndpoint, customerManagedKeyEncryption, maintenanceWindows, publicNetworkAccess, kind, sku, zones, identity);
            (data.Properties ??= new ClusterCreateProperties(default)).SetFirewallRules(firewallRules);
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
        /// <param name="firewallRules"> The complete rule set. Null sends JSON null; an empty sequence sends an empty array. Both clear existing rules. To preserve rules, omit this argument unless public access is being disabled. </param>
        /// <returns> A cluster patch for mocking. </returns>
        public static RedisEnterpriseClusterPatch RedisEnterpriseClusterPatch([Optional] RedisEnterpriseSku sku, [Optional] RedisEnterpriseHighAvailability? highAvailability, [Optional] RedisEnterpriseTlsVersion? minimumTlsVersion, [Optional] string hostName, [Optional] RedisEnterpriseProvisioningStatus? provisioningState, [Optional] RedisEnterpriseRedundancyMode? redundancyMode, [Optional] RedisEnterpriseClusterResourceState? resourceState, [Optional] string redisVersion, [Optional] IEnumerable<RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections, [Optional] string migratedEndpoint, [Optional] RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption, [Optional] IEnumerable<RedisEnterpriseMaintenanceWindow> maintenanceWindows, [Optional] RedisEnterprisePublicNetworkAccess? publicNetworkAccess, [Optional] ManagedServiceIdentity identity, [Optional] IDictionary<string, string> tags, IEnumerable<FirewallRule> firewallRules)
        {
            var patch = RedisEnterpriseClusterPatch(sku, highAvailability, minimumTlsVersion, hostName, provisioningState, redundancyMode, resourceState, redisVersion, privateEndpointConnections, migratedEndpoint, customerManagedKeyEncryption, maintenanceWindows, publicNetworkAccess, identity, tags);
            (patch.Properties ??= new ClusterUpdateProperties()).SetFirewallRules(firewallRules);
            return patch;
        }
    }
}
