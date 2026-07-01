# ARM provider schema comparison: Azure.ResourceManager.ContainerRegistry

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 1 resolve-only resource ID patterns.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 14 matching patterns; 1 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 1 legacy-only pattern(s), 1 resolve-only pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 14 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{groupName}` |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{privateLinkResourceName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching `resourceIdPattern`, the `List` and `Action` operation sets are identical.

No list/action operation differences were found for matching resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 12 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}` | `ContainerRegistry` | `Registry` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/cacheRules/{cacheRuleName}` | `ContainerRegistryCacheRule` | `CacheRule` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/credentialSets/{credentialSetName}` | `ContainerRegistryCredentialSet` | `CredentialSet` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/exportPipelines/{exportPipelineName}` | `ContainerRegistryExportPipeline` | `ExportPipeline` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/importPipelines/{importPipelineName}` | `ContainerRegistryImportPipeline` | `ImportPipeline` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/packages/{packageType}/archives/{archiveName}` | `ContainerRegistryArchive` | `PackagesArchives` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/packages/{packageType}/archives/{archiveName}/versions/{archiveVersionName}` | `ContainerRegistryArchiveVersion` | `ArchivesVersions` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/pipelineRuns/{pipelineRunName}` | `ContainerRegistryPipelineRun` | `PipelineRun` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateEndpointConnections/{privateEndpointConnectionName}` | `ContainerRegistryPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/replications/{replicationName}` | `ContainerRegistryReplication` | `Replication` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tokens/{tokenName}` | `ContainerRegistryToken` | `Token` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/webhooks/{webhookName}` | `ContainerRegistryWebhook` | `Webhook` |

