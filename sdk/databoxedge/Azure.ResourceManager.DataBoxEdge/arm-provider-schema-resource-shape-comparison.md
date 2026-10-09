# ARM resource shape comparison: Azure.ResourceManager.DataBoxEdge

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 19 |
| resolveArmResources resources | 20 |
| Matching normalized resource IDs | 19 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 1 |
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
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{}/operationsStatus/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}/operationsStatus/{name}`<br>resourceType=`Microsoft.DataBoxEdge/dataBoxEdgeDevices/operationsStatus`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=_none_ |

## Matched resource-shape differences

None.
