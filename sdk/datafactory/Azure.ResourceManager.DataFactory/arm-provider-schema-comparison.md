# ARM provider schema comparison: Azure.ResourceManager.DataFactory

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 13 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 13 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

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

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DataFactory.Factories.triggersQueryByFactory` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/querytriggers` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 13 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}` | `DataFactory` | `Factory` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/adfcdcs/{}` | `DataFactoryChangeDataCapture` | `ChangeDataCaptureResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/credentials/{}` | `DataFactoryServiceCredential` | `CredentialResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/dataflows/{}` | `DataFactoryDataFlow` | `DataFlowResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/datasets/{}` | `DataFactoryDataset` | `DatasetResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/globalparameters/{}` | `DataFactoryGlobalParameter` | `GlobalParameterResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/integrationruntimes/{}` | `DataFactoryIntegrationRuntime` | `IntegrationRuntimeResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/linkedservices/{}` | `DataFactoryLinkedService` | `LinkedServiceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/managedvirtualnetworks/{}` | `DataFactoryManagedVirtualNetwork` | `ManagedVirtualNetworkResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/managedvirtualnetworks/{}/managedprivateendpoints/{}` | `DataFactoryPrivateEndpoint` | `ManagedPrivateEndpointResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/pipelines/{}` | `DataFactoryPipeline` | `PipelineResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/privateendpointconnections/{}` | `DataFactoryPrivateEndpointConnection` | `PrivateEndpointConnectionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datafactory/factories/{}/triggers/{}` | `DataFactoryTrigger` | `TriggerResource` |

