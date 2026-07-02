# ARM provider schema comparison: Azure.ResourceManager.DataBoxEdge

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 19 matching normalized patterns; 0 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 1 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 19 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}/operationsStatus/{name}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 16 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/alerts/{}` | `DataBoxEdgeAlert` | `Alert` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/devicecapacityinfo/default` | `DataBoxEdgeDeviceCapacityInfo` | `DeviceCapacityInfo` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/diagnosticproactivelogcollectionsettings/default` | `DiagnosticProactiveLogCollectionSetting` | `DiagnosticProactiveLogCollectionSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/diagnosticremotesupportsettings/default` | `DiagnosticRemoteSupportSetting` | `DiagnosticRemoteSupportSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/networksettings/default` | `DataBoxEdgeDeviceNetworkSettings` | `NetworkSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/orders/default` | `DataBoxEdgeOrder` | `Order` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/roles/{}` | `DataBoxEdgeRole` | `Role` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/roles/{}/addons/{}` | `DataBoxEdgeRoleAddon` | `RolesAddons` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/roles/{}/monitoringconfig/default` | `MonitoringMetricConfiguration` | `RolesMonitoringConfig` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/shares/{}` | `DataBoxEdgeShare` | `Share` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/storageaccountcredentials/{}` | `DataBoxEdgeStorageAccountCredential` | `StorageAccountCredential` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/storageaccounts/{}` | `DataBoxEdgeStorageAccount` | `StorageAccount` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/storageaccounts/{}/containers/{}` | `DataBoxEdgeStorageContainer` | `Container` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/triggers/{}` | `DataBoxEdgeTrigger` | `Trigger` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/updatesummary/default` | `DataBoxEdgeDeviceUpdateSummary` | `UpdateSummary` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.databoxedge/databoxedgedevices/{}/users/{}` | `DataBoxEdgeUser` | `User` |

