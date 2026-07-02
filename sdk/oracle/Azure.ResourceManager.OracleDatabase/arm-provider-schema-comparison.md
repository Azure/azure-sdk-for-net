# ARM provider schema comparison: Azure.ResourceManager.OracleDatabase

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 hierarchy differences; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 25 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 3 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 25 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 3 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/dbsystems/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/networkanchors/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/resourceanchors/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes/{dbsystemshapename}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Oracle.Database.DbSystemShapes.listByLocationDeprecated` | `List` | `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions/{giversionname}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Oracle.Database.GiVersions.listByLocationDeprecated` | `List` | `/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 17 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/oracle.database/locations/{}/autonomousdbversions/{}` | `AutonomousDBVersion` | `AutonomousDbVersion` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/dbsystemdbversions/{}` | `OracleDBVersion` | `DbVersion` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/dbsystemshapes/{}` | `OracleDBSystemShape` | `DbSystemShape` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/dnsprivateviews/{}` | `OracleDnsPrivateView` | `DnsPrivateView` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/dnsprivatezones/{}` | `OracleDnsPrivateZone` | `DnsPrivateZone` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/flexcomponents/{}` | `OracleFlexComponent` | `FlexComponent` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/giversions/{}` | `OracleGIVersion` | `GiVersion` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/giversions/{}/giminorversions/{}` | `OracleGIMinorVersion` | `GiMinorVersion` |
| `/subscriptions/{}/providers/oracle.database/locations/{}/systemversions/{}` | `OracleSystemVersion` | `SystemVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/cloudexadatainfrastructures/{}/dbservers/{}` | `OracleDBServer` | `DbServer` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/cloudvmclusters/{}/dbnodes/{}` | `CloudVmClusterDBNode` | `DbNode` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/cloudvmclusters/{}/virtualnetworkaddresses/{}` | `CloudVmClusterVirtualNetworkAddress` | `VirtualNetworkAddress` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/dbsystems/{}` | `OracleDBSystem` | `DbSystem` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/exadbvmclusters/{}/dbnodes/{}` | `ExascaleDBNode` | `ExascaleDbNode` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/exascaledbstoragevaults/{}` | `ExascaleDBStorageVault` | `ExascaleDbStorageVault` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/networkanchors/{}` | `OracleNetworkAnchor` | `NetworkAnchor` |
| `/subscriptions/{}/resourcegroups/{}/providers/oracle.database/resourceanchors/{}` | `OracleResourceAnchor` | `ResourceAnchor` |

