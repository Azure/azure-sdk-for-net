# ARM provider schema comparison: Azure.ResourceManager.MachineLearning

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 53 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 53 | Matching normalized resource ID patterns are compared in the following sections. |
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

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.MachineLearningServices.Workspaces.getInWorkspace` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/deployments` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 27 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/registries/{}` | `MachineLearningRegistry` | `Registry` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}` | `MachineLearningWorkspace` | `Workspace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/batchendpoints/{}` | `MachineLearningBatchEndpoint` | `BatchEndpoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/batchendpoints/{}/deployments/{}` | `MachineLearningBatchDeployment` | `BatchDeployment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/computes/{}` | `MachineLearningCompute` | `ComputeResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/connections/{}` | `MachineLearningWorkspaceConnection` | `WorkspaceConnectionPropertiesV2BasicResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/connections/{}/raiblocklists/{}` | `RaiBlocklist` | `RaiBlocklistPropertiesBasicResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/connections/{}/raiblocklists/{}/raiblocklistitems/{}` | `RaiBlocklistItem` | `RaiBlocklistItemPropertiesBasicResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/connections/{}/raipolicies/{}` | `ConnectionRaiPolicy` | `ConnectionsRaiPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/datastores/{}` | `MachineLearningDatastore` | `Datastore` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/endpoints/{}` | `MachineLearningEndpoint` | `EndpointResourcePropertiesBasicResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/endpoints/{}/raipolicies/{}` | `RaiPolicy` | `EndpointsRaiPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/featuresets/{}` | `MachineLearningFeatureSetContainer` | `FeaturesetContainer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/featuresets/{}/versions/{}` | `MachineLearningFeatureSetVersion` | `FeaturesetVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/featuresets/{}/versions/{}/features/{}` | `MachineLearningFeature` | `VersionsFeatures` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/featurestoreentities/{}` | `MachineLearningFeatureStoreEntityContainer` | `FeaturestoreEntityContainer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/featurestoreentities/{}/versions/{}` | `MachineLearningFeaturestoreEntityVersion` | `FeaturestoreEntityVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/inferencepools/{}/endpoints/{}` | `InferenceEndpoint` | `InferencePoolsEndpoints` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/inferencepools/{}/groups/{}` | `InferenceGroup` | `InferencePoolsGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/jobs/{}` | `MachineLearningJob` | `JobBase` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/managednetworks/{}` | `MachineLearningManagedNetworkSettings` | `ManagedNetworkSettingsPropertiesBasicResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/marketplacesubscriptions/{}` | `MachineLearningMarketplaceSubscription` | `MarketplaceSubscription` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/onlineendpoints/{}` | `MachineLearningOnlineEndpoint` | `OnlineEndpoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/onlineendpoints/{}/deployments/{}` | `MachineLearningOnlineDeployment` | `OnlineDeployment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/privateendpointconnections/{}` | `MachineLearningPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/schedules/{}` | `MachineLearningSchedule` | `Schedule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.machinelearningservices/workspaces/{}/serverlessendpoints/{}` | `MachineLearningServerlessEndpoint` | `ServerlessEndpoint` |

