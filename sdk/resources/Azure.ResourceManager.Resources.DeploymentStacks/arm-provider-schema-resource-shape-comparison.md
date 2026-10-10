# ARM resource shape comparison: Azure.ResourceManager.Resources.DeploymentStacks

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 2 |
| resolveArmResources resources | 8 |
| Matching normalized resource IDs | 2 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 6 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Resources/deploymentStacks/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}`<br>resourceType=`Microsoft.Resources/deploymentStacks`<br>parent=_none_<br>scope=`kind=ManagementGroup`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{deploymentStacksWhatIfResultName}`<br>resourceType=`Microsoft.Resources/deploymentStacksWhatIfResults`<br>parent=_none_<br>scope=`kind=ManagementGroup`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/providers/Microsoft.Resources/deploymentStacks/{}` | resourceId=`/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}`<br>resourceType=`Microsoft.Resources/deploymentStacks`<br>parent=_none_<br>scope=`kind=Subscription`; `id=/subscriptions/{subscriptionId}`; `type=Microsoft.Resources/subscriptions`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{}` | resourceId=`/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{deploymentStacksWhatIfResultName}`<br>resourceType=`Microsoft.Resources/deploymentStacksWhatIfResults`<br>parent=_none_<br>scope=`kind=Subscription`; `id=/subscriptions/{subscriptionId}`; `type=Microsoft.Resources/subscriptions`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Resources/deploymentStacks/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}`<br>resourceType=`Microsoft.Resources/deploymentStacks`<br>parent=_none_<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{deploymentStacksWhatIfResultName}`<br>resourceType=`Microsoft.Resources/deploymentStacksWhatIfResults`<br>parent=_none_<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |

## Matched resource-shape differences

None.
