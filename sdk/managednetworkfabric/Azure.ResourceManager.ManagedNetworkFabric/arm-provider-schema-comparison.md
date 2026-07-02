# ARM provider schema comparison: Azure.ResourceManager.ManagedNetworkFabric

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 resource model difference; 12 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 26 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 12 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 26 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/networkfabrics/{}` | `Missing` | `Microsoft.ManagedNetworkFabric.NetworkFabricDeprecated` | `Missing` | `Microsoft.ManagedNetworkFabric/networkFabrics` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 12 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/accessControlLists/{accessControlListName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.AccessControlLists.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/accessControlLists/{accessControlListName}/updateAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l2IsolationDomains/{l2IsolationDomainName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.L2IsolationDomains.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l2IsolationDomains/{l2IsolationDomainName}/updateAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.L3IsolationDomains.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/updateAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/externalNetworks/{externalNetworkName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.ExternalNetworks.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/externalNetworks/{externalNetworkName}/updateAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.ExternalNetworks.updateBfdAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/externalNetworks/{externalNetworkName}/updateBfdAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.ExternalNetworks.updateStaticRouteBfdAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/externalNetworks/{externalNetworkName}/updateStaticRouteBfdAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/internalNetworks/{internalNetworkName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.InternalNetworks.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/internalNetworks/{internalNetworkName}/updateAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.InternalNetworks.updateBfdAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/internalNetworks/{internalNetworkName}/updateBfdAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.InternalNetworks.updateBgpAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/internalNetworks/{internalNetworkName}/updateBgpAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.InternalNetworks.updateBgpAdministrativeStateDeprecatedV2` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/internalNetworks/{internalNetworkName}/updateBgpAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.InternalNetworks.updateStaticRouteBfdAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/{l3IsolationDomainName}/internalNetworks/{internalNetworkName}/updateStaticRouteBfdAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.NetworkDevices.rebootDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/reboot` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkDevices.refreshConfigurationDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/refreshConfiguration` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkDevices.runRoCommandDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/runRoCommand` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkDevices.runRwCommandDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/runRwCommand` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkDevices.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/updateAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkDevices.upgradeDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/upgrade` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/networkInterfaces/{networkInterfaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.NetworkInterfaces.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkDevices/{networkDeviceName}/networkInterfaces/{networkInterfaceName}/updateAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkFabrics/{networkFabricName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.NetworkFabrics.listByResourceGroupDeprecated` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkFabrics` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkFabrics/{networkFabricName}/networkToNetworkInterconnects/{networkToNetworkInterconnectName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.NetworkToNetworkInterconnects.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkFabrics/{networkFabricName}/networkToNetworkInterconnects/{networkToNetworkInterconnectName}/updateAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkToNetworkInterconnects.updateBfdAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkFabrics/{networkFabricName}/networkToNetworkInterconnects/{networkToNetworkInterconnectName}/updateBfdAdministrativeState` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkToNetworkInterconnects.updateNpbStaticRouteBfdAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkFabrics/{networkFabricName}/networkToNetworkInterconnects/{networkToNetworkInterconnectName}/updateNpbStaticRouteBfdAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkTapRules/{networkTapRuleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.NetworkTapRules.resyncDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkTapRules/{networkTapRuleName}/resync` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkTaps/{networkTapName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.NetworkTaps.resyncDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkTaps/{networkTapName}/resync` | Missing. | Present. |
| `Microsoft.ManagedNetworkFabric.NetworkTaps.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/networkTaps/{networkTapName}/updateAdministrativeState` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/routePolicies/{routePolicyName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ManagedNetworkFabric.RoutePolicies.updateAdministrativeStateDeprecated` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedNetworkFabric/routePolicies/{routePolicyName}/updateAdministrativeState` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 13 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/accesscontrollists/{}` | `NetworkFabricAccessControlList` | `AccessControlList` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/internetgatewayrules/{}` | `NetworkFabricInternetGatewayRule` | `InternetGatewayRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/internetgateways/{}` | `NetworkFabricInternetGateway` | `InternetGateway` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/ipcommunities/{}` | `NetworkFabricIPCommunity` | `IpCommunity` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/ipextendedcommunities/{}` | `NetworkFabricIPExtendedCommunity` | `IpExtendedCommunity` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/ipprefixes/{}` | `NetworkFabricIPPrefix` | `IpPrefix` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/l2isolationdomains/{}` | `NetworkFabricL2IsolationDomain` | `L2IsolationDomain` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/l3isolationdomains/{}` | `NetworkFabricL3IsolationDomain` | `L3IsolationDomain` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/l3isolationdomains/{}/externalnetworks/{}` | `NetworkFabricExternalNetwork` | `ExternalNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/l3isolationdomains/{}/internalnetworks/{}` | `NetworkFabricInternalNetwork` | `InternalNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/neighborgroups/{}` | `NetworkFabricNeighborGroup` | `NeighborGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/networkdevices/{}/networkinterfaces/{}` | `NetworkDeviceInterface` | `NetworkInterface` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.managednetworkfabric/routepolicies/{}` | `NetworkFabricRoutePolicy` | `RoutePolicy` |

