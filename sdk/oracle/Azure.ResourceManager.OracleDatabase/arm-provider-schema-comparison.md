# ARM provider schema comparison: Azure.ResourceManager.OracleDatabase

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 hierarchy differences; 2 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 25 resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 3 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 25 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 3 hierarchy differences.

| Resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/dbSystems/{dbSystemName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/networkAnchors/{networkAnchorName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/resourceAnchors/{resourceAnchorName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List/action operation differences: `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes/{dbsystemshapename}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Oracle.Database.DbSystemShapes.listByLocationDeprecated` | `List` | `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes` | Missing. | Present. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions/{giversionname}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Oracle.Database.GiVersions.listByLocationDeprecated` | `List` | `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 17 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/autonomousDbVersions/{autonomousdbversionsname}` | `AutonomousDBVersion` | `AutonomousDbVersion` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemDbVersions/{dbversionsname}` | `OracleDBVersion` | `DbVersion` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes/{dbsystemshapename}` | `OracleDBSystemShape` | `DbSystemShape` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dnsPrivateViews/{dnsprivateviewocid}` | `OracleDnsPrivateView` | `DnsPrivateView` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dnsPrivateZones/{dnsprivatezonename}` | `OracleDnsPrivateZone` | `DnsPrivateZone` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/flexComponents/{flexComponentName}` | `OracleFlexComponent` | `FlexComponent` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions/{giversionname}` | `OracleGIVersion` | `GiVersion` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions/{giversionname}/giMinorVersions/{giMinorVersionName}` | `OracleGIMinorVersion` | `GiMinorVersion` |
| `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/systemVersions/{systemversionname}` | `OracleSystemVersion` | `SystemVersion` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/cloudExadataInfrastructures/{cloudexadatainfrastructurename}/dbServers/{dbserverocid}` | `OracleDBServer` | `DbServer` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/cloudVmClusters/{cloudvmclustername}/dbNodes/{dbnodeocid}` | `CloudVmClusterDBNode` | `DbNode` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/cloudVmClusters/{cloudvmclustername}/virtualNetworkAddresses/{virtualnetworkaddressname}` | `CloudVmClusterVirtualNetworkAddress` | `VirtualNetworkAddress` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/dbSystems/{dbSystemName}` | `OracleDBSystem` | `DbSystem` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/exadbVmClusters/{exadbVmClusterName}/dbNodes/{exascaleDbNodeName}` | `ExascaleDBNode` | `ExascaleDbNode` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/exascaleDbStorageVaults/{exascaleDbStorageVaultName}` | `ExascaleDBStorageVault` | `ExascaleDbStorageVault` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/networkAnchors/{networkAnchorName}` | `OracleNetworkAnchor` | `NetworkAnchor` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/resourceAnchors/{resourceAnchorName}` | `OracleResourceAnchor` | `ResourceAnchor` |

