# ARM resource shape comparison: Azure.ResourceManager.ContainerRegistry

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 15 |
| resolveArmResources resources | 15 |
| Matching normalized resource IDs | 15 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 1 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 0 |
| Read lifecycle differences | 1 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerRegistry/registries/{}/privateLinkResources/{}` | resourceId | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{groupName}` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{privateLinkResourceName}` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerRegistry/registries/{}/privateLinkResources/{}` | read | `Microsoft.ContainerRegistry.PrivateLinkResources.getPrivateLinkResource /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{groupName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{groupName}, Microsoft.Resources/resourceGroups]` | `Microsoft.ContainerRegistry.PrivateLinkResources.getPrivateLinkResource /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{privateLinkResourceName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/privateLinkResources/{privateLinkResourceName}, Microsoft.Resources/resourceGroups]` |
