# ARM resource shape comparison: Azure.ResourceManager.Monitor

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 14 |
| resolveArmResources resources | 14 |
| Matching normalized resource IDs | 14 |
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
| `/subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/privateLinkScopes/{}/privateLinkResources/{}` | resourceId | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{groupName}` | `/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{privateLinkResourceName}` |
| `/subscriptions/{}/resourcegroups/{}/providers/Microsoft.Insights/privateLinkScopes/{}/privateLinkResources/{}` | read | `PrivateLinkScopesApi.PrivateLinkResources.get /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{groupName} [ResourceGroup, /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{groupName}, Microsoft.Resources/resourceGroups]` | `PrivateLinkScopesApi.PrivateLinkResources.get /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{privateLinkResourceName} [ResourceGroup, /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Insights/privateLinkScopes/{scopeName}/privateLinkResources/{privateLinkResourceName}, Microsoft.Resources/resourceGroups]` |
